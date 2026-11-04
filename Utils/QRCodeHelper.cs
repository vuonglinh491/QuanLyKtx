using System;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QRCoder;

namespace QuanLyKtx.Utils
{
    /// <summary>
    /// Helper tạo mã QR chuyển khoản ngân hàng Việt Nam theo chuẩn VietQR
    /// </summary>
    public static class QRCodeHelper
    {
        // ==========================================
        // THÔNG TIN TÀI KHOẢN NGÂN HÀNG KTX
        // ==========================================
        public const string BANK_ID       = "VCB";                  // Vietcombank
        public const string ACCOUNT_NO    = "9329022717";           // Số tài khoản
        public const string ACCOUNT_NAME  = "NGUYEN DUC TRUNG";     // Tên chủ tài khoản
        private const string TEMPLATE     = "compact2";             // Template QR (compact2 = gọn, có logo)

        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        static QRCodeHelper()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) QuanLyKtx/1.0");
            }
        }

        /// <summary>
        /// Tạo ảnh QR VietQR từ API img.vietqr.io hoặc tự sinh mã ngoại tuyến qua QRCoder
        /// </summary>
        /// <param name="amount">Số tiền cần chuyển (VNĐ)</param>
        /// <param name="description">Nội dung chuyển khoản</param>
        /// <returns>Ảnh QR dạng Bitmap, hoặc null nếu lỗi</returns>
        public static async Task<Bitmap?> GenerateVietQRAsync(decimal amount, string description)
        {
            string safeDesc = RemoveDiacritics(description);

            try
            {
                // 1. Gọi API VietQR online
                string encodedDesc = Uri.EscapeDataString(safeDesc);
                string encodedName = Uri.EscapeDataString(ACCOUNT_NAME);

                string url = $"https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-{TEMPLATE}.png" +
                             $"?amount={(long)amount}" +
                             $"&addInfo={encodedDesc}" +
                             $"&accountName={encodedName}";

                byte[] responseBytes = await _httpClient.GetByteArrayAsync(url);

                // Trường hợp A: Phản hồi là ảnh nhị phân thuần PNG hoặc JPEG
                if (responseBytes.Length > 8 &&
                    ((responseBytes[0] == 0x89 && responseBytes[1] == 0x50 && responseBytes[2] == 0x4E && responseBytes[3] == 0x47) ||
                     (responseBytes[0] == 0xFF && responseBytes[1] == 0xD8)))
                {
                    using var ms = new System.IO.MemoryStream(responseBytes);
                    return new Bitmap(ms);
                }

                // Trường hợp B: API trả về SVG wrapper chứa base64 PNG bên trong
                string responseText = System.Text.Encoding.UTF8.GetString(responseBytes);
                var match = Regex.Match(responseText, @"data:image/png;base64,([A-Za-z0-9+/=]+)");
                if (match.Success)
                {
                    byte[] pngBytes = Convert.FromBase64String(match.Groups[1].Value);
                    using var ms = new System.IO.MemoryStream(pngBytes);
                    return new Bitmap(ms);
                }

                // Nếu không parse được từ API, fallback sang QRCoder
                return GenerateOfflineQRCode(amount, safeDesc);
            }
            catch
            {
                // 2. Fallback ngoại tuyến: Tự sinh mã QR chuẩn bằng thư viện QRCoder
                try
                {
                    return GenerateOfflineQRCode(amount, safeDesc);
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Tạo mã QR ngoại tuyến tiêu chuẩn sử dụng thư viện QRCoder (không cần kết nối internet)
        /// </summary>
        public static Bitmap GenerateOfflineQRCode(decimal amount, string description)
        {
            string payload = $"https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-{TEMPLATE}.png?amount={(long)amount}&addInfo={Uri.EscapeDataString(description)}&accountName={Uri.EscapeDataString(ACCOUNT_NAME)}";
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(12);
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

            string normalized = text.Normalize(System.Text.NormalizationForm.FormD);
            var sb = new System.Text.StringBuilder();
            foreach (char c in normalized)
            {
                var cat = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (cat != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }
    }
}
