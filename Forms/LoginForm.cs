using System;
using System.Windows.Forms;
using QuanLyKtx.Forms.Manager;
using QuanLyKtx.Forms.Student;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms
{
    public partial class LoginForm : Form
    {
        private readonly LoginService _loginService;

        public LoginForm()
        {
            InitializeComponent();
            _loginService = new LoginService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Gọi service xác thực đăng nhập
            var user = _loginService.Authenticate(username, password, out string errorMessage);

            if (user == null)
            {
                MessageBox.Show(errorMessage, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.SelectAll();
                txtPassword.Focus();
                return;
            }

            // Phân quyền điều hướng theo Role
            if (Session.IsManager)
            {
                var managerForm = new ManagerMainForm();
                this.Hide();
                managerForm.Show();
            }
            else if (Session.IsStudent)
            {
                var studentForm = new StudentMainForm();
                this.Hide();
                studentForm.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản chưa được phân quyền hợp lệ!", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Session.Clear();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
