using System;
using System.Windows.Forms;
using BUS;
using DAL.Model;
 // lớp chứa AppSession

namespace textktx.CACFORM
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usernameData = textBox1.Text?.Trim();
            var passwordData = textBox2.Text?.Trim();

            var login = new DangNhapBUS();

            if (login.DangNhap(usernameData, passwordData, out var maNV))
            {
                // Lưu session (để các form khác như InDangKy dùng MaNV)
                AppSession.TenDN = usernameData;
                AppSession.MaNV = maNV;

                var frmMain = new FormMain();
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Model1())
                {
                    bool ok = db.Database.Exists();
                    MessageBox.Show(ok ? "✅ Kết nối OK" : "❌ Không tìm thấy database");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
