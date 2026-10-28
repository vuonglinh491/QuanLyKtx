using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyKtx.Utils
{
    /// <summary>
    /// Hệ thống Design Tokens và Styling chuẩn hóa cho toàn bộ ứng dụng QuanLyKtx
    /// Đảm bảo giao diện hiện đại, chuyên nghiệp, đồng nhất màu sắc và trạng thái tương tác.
    /// </summary>
    public static class UITheme
    {
        // ── PALETTE MÀU SẮC CHỦ ĐẠO (SLATE & BLUE ENTERPRISE) ───────────────────
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);        // Blue 600
        public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);   // Blue 700
        public static readonly Color PrimaryDown = Color.FromArgb(30, 58, 138);    // Blue 900

        public static readonly Color Success = Color.FromArgb(16, 185, 129);       // Emerald 500
        public static readonly Color SuccessHover = Color.FromArgb(5, 150, 105);   // Emerald 600
        public static readonly Color SuccessDown = Color.FromArgb(4, 120, 87);     // Emerald 700

        public static readonly Color Warning = Color.FromArgb(245, 158, 11);       // Amber 500
        public static readonly Color WarningHover = Color.FromArgb(217, 119, 6);   // Amber 600
        public static readonly Color WarningDown = Color.FromArgb(180, 83, 9);     // Amber 700

        public static readonly Color Danger = Color.FromArgb(239, 68, 68);         // Red 500
        public static readonly Color DangerHover = Color.FromArgb(220, 38, 38);    // Red 600
        public static readonly Color DangerDown = Color.FromArgb(185, 28, 28);     // Red 700

        public static readonly Color Info = Color.FromArgb(14, 165, 233);          // Sky 500
        public static readonly Color InfoHover = Color.FromArgb(2, 132, 199);      // Sky 600
        public static readonly Color InfoDown = Color.FromArgb(3, 105, 161);       // Sky 700

        public static readonly Color Secondary = Color.FromArgb(241, 245, 249);    // Slate 100
        public static readonly Color SecondaryHover = Color.FromArgb(226, 232, 240);// Slate 200
        public static readonly Color SecondaryDown = Color.FromArgb(203, 213, 225); // Slate 300
        public static readonly Color SecondaryBorder = Color.FromArgb(203, 213, 225);

        // Nền & Khung
        public static readonly Color AppBackground = Color.FromArgb(248, 250, 252);// Slate 50
        public static readonly Color CardBackground = Color.White;
        public static readonly Color BorderSubtle = Color.FromArgb(226, 232, 240); // Slate 200
        public static readonly Color BorderFocus = Color.FromArgb(59, 130, 246);   // Blue 500

        // Sidebar
        public static readonly Color SidebarBg = Color.FromArgb(15, 23, 42);       // Slate 900
        public static readonly Color SidebarHover = Color.FromArgb(30, 41, 59);    // Slate 800
        public static readonly Color SidebarActive = Color.FromArgb(37, 99, 235);   // Blue 600
        public static readonly Color SidebarStudentBg = Color.FromArgb(15, 76, 129);
        public static readonly Color SidebarStudentHover = Color.FromArgb(20, 95, 160);
        public static readonly Color SidebarStudentActive = Color.FromArgb(10, 50, 90);

        // Chữ
        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);      // Slate 900
        public static readonly Color TextSecondary = Color.FromArgb(71, 85, 105);  // Slate 600
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);    // Slate 400
        public static readonly Color TextWhite = Color.White;

        // Trạng thái Badge (Nền + Chữ)
        public static readonly Color BadgeSuccessBg = Color.FromArgb(236, 253, 245);
        public static readonly Color BadgeSuccessText = Color.FromArgb(6, 95, 70);

        public static readonly Color BadgeWarningBg = Color.FromArgb(254, 243, 199);
        public static readonly Color BadgeWarningText = Color.FromArgb(146, 64, 14);

        public static readonly Color BadgeDangerBg = Color.FromArgb(254, 226, 226);
        public static readonly Color BadgeDangerText = Color.FromArgb(153, 27, 27);

        public static readonly Color BadgeInfoBg = Color.FromArgb(224, 242, 254);
        public static readonly Color BadgeInfoText = Color.FromArgb(7, 89, 133);

        public static readonly Color BadgeNeutralBg = Color.FromArgb(241, 245, 249);
        public static readonly Color BadgeNeutralText = Color.FromArgb(71, 85, 105);

        // ── TYPOGRAPHY CHUẨN HOÁ ────────────────────────────────────────────────
        public static readonly Font FontHeadingLg = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font FontHeadingMd = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        public static readonly Font FontHeadingSm = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font FontBodyBold = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontButton = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 8.5F, FontStyle.Regular);

        // ── STYLING NÚT BẤM (BUTTONS) ──────────────────────────────────────────

        public static void ApplyPrimaryButton(Button btn, string? textWithIcon = null)
        {
            ApplyButton(btn, Primary, PrimaryHover, PrimaryDown, TextWhite, textWithIcon);
        }

        public static void ApplySuccessButton(Button btn, string? textWithIcon = null)
        {
            ApplyButton(btn, Success, SuccessHover, SuccessDown, TextWhite, textWithIcon);
        }

        public static void ApplyWarningButton(Button btn, string? textWithIcon = null)
        {
            ApplyButton(btn, Warning, WarningHover, WarningDown, TextWhite, textWithIcon);
        }

        public static void ApplyDangerButton(Button btn, string? textWithIcon = null)
        {
            ApplyButton(btn, Danger, DangerHover, DangerDown, TextWhite, textWithIcon);
        }

        public static void ApplyInfoButton(Button btn, string? textWithIcon = null)
        {
            ApplyButton(btn, Info, InfoHover, InfoDown, TextWhite, textWithIcon);
        }

        public static void ApplySecondaryButton(Button btn, string? textWithIcon = null)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = SecondaryBorder;
            btn.FlatAppearance.MouseOverBackColor = SecondaryHover;
            btn.FlatAppearance.MouseDownBackColor = SecondaryDown;
            btn.BackColor = Secondary;
            btn.ForeColor = TextPrimary;
            btn.Font = FontBody;
            btn.Cursor = Cursors.Hand;
            if (!string.IsNullOrEmpty(textWithIcon))
            {
                btn.Text = textWithIcon;
            }
        }

        private static void ApplyButton(Button btn, Color bg, Color hover, Color down, Color fg, string? text = null)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = hover;
            btn.FlatAppearance.MouseDownBackColor = down;
            btn.BackColor = bg;
            btn.ForeColor = fg;
            btn.Font = FontButton;
            btn.Cursor = Cursors.Hand;
            if (!string.IsNullOrEmpty(text))
            {
                btn.Text = text;
            }
        }

        public static void ApplySidebarButton(Button btn, bool isActive, Color activeColor, Color hoverColor, Color defaultBg)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.FlatAppearance.MouseDownBackColor = activeColor;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);

            if (isActive)
            {
                btn.BackColor = activeColor;
                btn.ForeColor = TextWhite;
                btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            }
            else
            {
                btn.BackColor = defaultBg;
                btn.ForeColor = Color.FromArgb(226, 232, 240);
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
        }

        // ── STYLING FORM & GROUPBOX ────────────────────────────────────────────

        public static void ApplySearchPanel(Panel pnl)
        {
            pnl.BackColor = CardBackground;
            pnl.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void ApplyCardPanel(Panel pnl, Color? borderColor = null)
        {
            pnl.BackColor = CardBackground;
            pnl.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void ApplyInputStyle(Control ctrl)
        {
            ctrl.Font = FontBody;
            ctrl.ForeColor = TextPrimary;
        }
    }
}
