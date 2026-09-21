using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

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

        /// <summary>
        /// Tạo ảnh QR VietQR từ API img.vietqr.io
        /// </summary>
        /// <param name="amount">Số tiền cần chuyển (VNĐ)</param>
        /// <param name="description">Nội dung chuyển khoản (noti)</param>
        /// <returns>Ảnh QR dạng Bitmap, hoặc null nếu lỗi</returns>
        public static async Task<Bitmap?> GenerateVietQRAsync(decimal amount, string description)
        {
            try
            {
                // Encode nội dung chuyển khoản (loại bỏ dấu tiếng Việt để tránh lỗi API)
                string encodedDesc = Uri.EscapeDataString(RemoveDiacritics(description));
                string encodedName = Uri.EscapeDataString(ACCOUNT_NAME);

                string url = $"https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-{TEMPLATE}.png" +
                             $"?amount={(long)amount}" +
                             $"&addInfo={encodedDesc}" +
                             $"&accountName={encodedName}";

                byte[] imageBytes = await _httpClient.GetByteArrayAsync(url);

                using var ms = new System.IO.MemoryStream(imageBytes);
                return new Bitmap(ms);
            }
            catch
            {
                return null;
            }
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
        private static string RemoveDiacritics(string text)
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
