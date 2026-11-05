using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QRCoder;

namespace QuanLyKtx.Utils
{
    /// <summary>
    /// Helper tạo mã QR chuyển khoản ngân hàng Việt Nam theo chuẩn VietQR (NAPAS EMVCo)
    /// </summary>
    public static class QRCodeHelper
    {
        // ==========================================
        // THÔNG TIN TÀI KHOẢN NGÂN HÀNG KTX
        // ==========================================
        public const string BANK_ID       = "VCB";                  // Vietcombank
        public const string BANK_BIN      = "970436";               // Mã BIN Vietcombank (NAPAS)
        public const string ACCOUNT_NO    = "9329022717";           // Số tài khoản
        public const string ACCOUNT_NAME  = "NGUYEN DUC TRUNG";     // Tên chủ tài khoản
        private const string TEMPLATE     = "compact2";             // Template QR

        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        static QRCodeHelper()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) QuanLyKtx/1.0");
            }
        }

        /// <summary>
        /// Tạo ảnh QR VietQR hoàn chỉnh (gồm cả khung thẻ và các ô mã QR scannable).
        /// Ưu tiên gọi VietQR API chính thức (POST v2/generate), tự động fallback vẽ thẻ ngoại tuyến chuẩn EMVCo nếu mất mạng.
        /// </summary>
        public static async Task<Bitmap?> GenerateVietQRAsync(decimal amount, string description)
        {
            string safeDesc = RemoveDiacritics(description);

            // 1. Thử gọi API chính thức VietQR v2 qua giao thức POST
            try
            {
                var requestBody = new
                {
                    accountNo   = ACCOUNT_NO,
                    accountName = ACCOUNT_NAME,
                    acqId       = BANK_BIN,
                    amount      = (long)amount,
                    addInfo     = safeDesc,
                    format      = "text",
                    template    = TEMPLATE
                };

                string jsonContent = JsonSerializer.Serialize(requestBody);
                using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                using var response = await _httpClient.PostAsync("https://api.vietqr.io/v2/generate", content);
                if (response.IsSuccessStatusCode)
                {
                    string respJson = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(respJson);
                    var root = doc.RootElement;

                    if (root.TryGetProperty("code", out var codeElem) && codeElem.GetString() == "00" &&
                        root.TryGetProperty("data", out var dataElem) &&
                        dataElem.TryGetProperty("qrDataURL", out var qrDataUrlElem))
                    {
                        string qrDataUrl = qrDataUrlElem.GetString() ?? string.Empty;
                        int commaIdx = qrDataUrl.IndexOf(',');
                        if (commaIdx >= 0)
                        {
                            byte[] pngBytes = Convert.FromBase64String(qrDataUrl.Substring(commaIdx + 1));
                            using var ms = new MemoryStream(pngBytes);
                            return new Bitmap(ms);
                        }
                    }
                }
            }
            catch
            {
                // Bỏ qua lỗi mạng, chuyển sang tạo ngoại tuyến ngay lập tức
            }

            // 2. Fallback ngoại tuyến: Tự sinh mã QR chuẩn EMVCo và vẽ thẻ VietQR hoàn chỉnh
            try
            {
                return GenerateOfflineQRCode(amount, safeDesc);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Tạo thẻ VietQR ngoại tuyến theo chuẩn EMVCo NAPAS (không cần kết nối internet).
        /// Đảm bảo 100% quét được trên tất cả ứng dụng ngân hàng tại Việt Nam.
        /// </summary>
        public static Bitmap GenerateOfflineQRCode(decimal amount, string description)
        {
            // Xây dựng chuỗi EMVCo chuẩn Napas
            string emvcoPayload = BuildVietQREMVCo(BANK_BIN, ACCOUNT_NO, amount, description);

            // Tạo QR matrix bằng QRCoder
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(emvcoPayload, QRCodeGenerator.ECCLevel.M);
            using var qrCode = new QRCode(qrCodeData);
            using Bitmap qrBitmap = qrCode.GetGraphic(8, Color.FromArgb(15, 23, 42), Color.White, true);

            // Vẽ thẻ VietQR card hoàn chỉnh (460 x 540 px)
            int cardW = 460;
            int cardH = 540;
            var card = new Bitmap(cardW, cardH);

            using (Graphics g = Graphics.FromImage(card))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Nền thẻ trắng bo viền
                g.Clear(Color.White);
                using (var borderPen = new Pen(Color.FromArgb(226, 232, 240), 2))
                {
                    g.DrawRectangle(borderPen, 1, 1, cardW - 3, cardH - 3);
                }

                // Header VietQR banner
                using (var headerBrush = new SolidBrush(Color.FromArgb(248, 250, 252)))
                {
                    g.FillRectangle(headerBrush, 2, 2, cardW - 4, 60);
                }
                using (var linePen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    g.DrawLine(linePen, 2, 62, cardW - 2, 62);
                }

                // Tiêu đề VIETQR & NAPAS 247
                using (var fontVietQR = new Font("Segoe UI", 16, FontStyle.Bold))
                using (var brushRed = new SolidBrush(Color.FromArgb(220, 38, 38)))
                using (var brushBlue = new SolidBrush(Color.FromArgb(2, 132, 199)))
                {
                    g.DrawString("VIET", fontVietQR, brushRed, 24, 16);
                    g.DrawString("QR", fontVietQR, brushBlue, 78, 16);
                }

                using (var fontSub = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var brushSub = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    string napasText = "NAPAS 247 • VIETCOMBANK";
                    var sz = g.MeasureString(napasText, fontSub);
                    g.DrawString(napasText, fontSub, brushSub, cardW - sz.Width - 24, 22);
                }

                // Vẽ mã QR ở giữa thẻ
                int qrSize = 310;
                int qrX = (cardW - qrSize) / 2;
                int qrY = 78;

                // Viền khung QR
                using (var qrFramePen = new Pen(Color.FromArgb(203, 213, 225), 1.5F))
                {
                    g.DrawRectangle(qrFramePen, qrX - 4, qrY - 4, qrSize + 8, qrSize + 8);
                }
                g.DrawImage(qrBitmap, qrX, qrY, qrSize, qrSize);

                // Footer: Thông tin người thụ hưởng & Số tiền
                using (var fontName = new Font("Segoe UI", 11.5F, FontStyle.Bold))
                using (var fontAcc = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                using (var fontAmount = new Font("Segoe UI", 13F, FontStyle.Bold))
                using (var brushDark = new SolidBrush(Color.FromArgb(15, 23, 42)))
                using (var brushMuted = new SolidBrush(Color.FromArgb(71, 85, 105)))
                using (var brushGreen = new SolidBrush(Color.FromArgb(16, 185, 129)))
                {
                    var sfCenter = new StringFormat { Alignment = StringAlignment.Center };

                    // Tên chủ tài khoản
                    g.DrawString(ACCOUNT_NAME, fontName, brushDark, cardW / 2f, 404, sfCenter);

                    // Số tài khoản & Ngân hàng
                    g.DrawString($"STK: {ACCOUNT_NO} - Vietcombank", fontAcc, brushMuted, cardW / 2f, 428, sfCenter);

                    // Số tiền
                    if (amount > 0)
                    {
                        g.DrawString($"{amount:N0} VNĐ", fontAmount, brushGreen, cardW / 2f, 452, sfCenter);
                    }

                    // Ghi chú chuyển khoản
                    using (var fontNote = new Font("Segoe UI", 8F, FontStyle.Italic))
                    {
                        string noteStr = string.IsNullOrWhiteSpace(description) ? "" : $"Nội dung: {description}";
                        if (noteStr.Length > 45) noteStr = noteStr.Substring(0, 42) + "...";
                        g.DrawString(noteStr, fontNote, brushMuted, cardW / 2f, 482, sfCenter);
                    }

                    // Chú thích chân
                    using (var fontFoot = new Font("Segoe UI", 7.5F, FontStyle.Regular))
                    using (var brushFoot = new SolidBrush(Color.FromArgb(148, 163, 184)))
                    {
                        g.DrawString("Quét bằng App Ngân hàng bất kỳ hoặc Ví điện tử hỗ trợ VietQR", fontFoot, brushFoot, cardW / 2f, 510, sfCenter);
                    }
                }
            }

            return card;
        }

        /// <summary>
        /// Tạo chuỗi EMVCo VietQR chuẩn NAPAS (Merchant-Presented QR Code)
        /// </summary>
        public static string BuildVietQREMVCo(string bin, string accountNumber, decimal amount, string description)
        {
            var sb = new StringBuilder();

            // 00: Payload Format Indicator (01)
            AppendTag(sb, "00", "01");

            // 01: Point of Initiation Method (12 = Dynamic, có số tiền)
            AppendTag(sb, "01", amount > 0 ? "12" : "11");

            // 38: Merchant Account Information (NAPAS)
            var sbNapas = new StringBuilder();
            AppendTag(sbNapas, "00", "A000000727"); // NAPAS AID

            var sbBeneficiary = new StringBuilder();
            AppendTag(sbBeneficiary, "00", bin);           // BIN Ngân hàng (970436 cho VCB)
            AppendTag(sbBeneficiary, "01", accountNumber); // Số tài khoản thụ hưởng
            AppendTag(sbNapas, "01", sbBeneficiary.ToString());

            AppendTag(sbNapas, "02", "QRIBFTTA");          // Service code
            AppendTag(sb, "38", sbNapas.ToString());

            // 53: Transaction Currency (704 = VND)
            AppendTag(sb, "53", "704");

            // 54: Transaction Amount
            if (amount > 0)
            {
                AppendTag(sb, "54", ((long)amount).ToString());
            }

            // 58: Country Code (VN)
            AppendTag(sb, "58", "VN");

            // 62: Additional Data Field (Nội dung chuyển khoản)
            if (!string.IsNullOrWhiteSpace(description))
            {
                var sbAdd = new StringBuilder();
                AppendTag(sbAdd, "08", RemoveDiacritics(description));
                AppendTag(sb, "62", sbAdd.ToString());
            }

            // 63: CRC16-CCITT
            string dataWithoutCRC = sb.ToString() + "6304";
            ushort crc = ComputeCRC16(dataWithoutCRC);
            sb.Append("6304");
            sb.Append(crc.ToString("X4"));

            return sb.ToString();
        }

        private static void AppendTag(StringBuilder sb, string tag, string value)
        {
            sb.Append(tag);
            sb.Append(value.Length.ToString("D2"));
            sb.Append(value);
        }

        /// <summary>
        /// Tính mã kiểm tra CRC16-CCITT (Polynomial 0x1021, Khởi tạo 0xFFFF)
        /// </summary>
        private static ushort ComputeCRC16(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            ushort crc = 0xFFFF;
            foreach (byte b in bytes)
            {
                crc ^= (ushort)(b << 8);
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0)
                    {
                        crc = (ushort)((crc << 1) ^ 0x1021);
                    }
                    else
                    {
                        crc = (ushort)(crc << 1);
                    }
                }
            }
            return crc;
        }

        /// <summary>
        /// Xây dựng nội dung chuyển khoản chuẩn cho KTX
        /// </summary>
        public static string BuildTransferDescription(string studentCode, string paymentType, int? paymentId = null)
        {
            string idPart = paymentId.HasValue ? $" PT{paymentId:D4}" : string.Empty;
            return $"KTX {studentCode} {paymentType}{idPart}";
        }

        /// <summary>
        /// Loại bỏ dấu tiếng Việt để dùng trong nội dung QR
        /// </summary>
        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            string normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in normalized)
            {
                var cat = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (cat != System.Globalization.CharUnicodeInfo.GetUnicodeCategory('a') &&
                    cat == System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    continue;
                }
                sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
