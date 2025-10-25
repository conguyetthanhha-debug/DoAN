using System;
using System.Windows.Forms;
using BUS;

namespace textktx.CACFORM
{
    public partial class FormInDangKy : Form
    {
        private readonly DangKyBUS _bus = new DangKyBUS();
        private readonly PhongBUS _phongBus = new PhongBUS();

        public FormInDangKy()
        {
            InitializeComponent();
            LoadComboboxes();
            this.cmbKhu.SelectedIndexChanged += (s, e) => LoadPhongTheoKhuDangChon();
        }

        private void LoadComboboxes()
        {
            // Khu chỉ A/B — dùng PhongBUS
            var khus = _phongBus.LayKhuAB();
            cmbKhu.DataSource = null;
            cmbKhu.DataSource = khus;
            if (cmbKhu.Items.Count > 0) cmbKhu.SelectedIndex = 0;

            // Học kỳ
            cmbHocKi.DataSource = new[] { "1", "2", "3" };

            // Phòng theo Khu
            LoadPhongTheoKhuDangChon();

            // Thông tin hiển thị
            lbMaNV.Text = (lbMaNV.Text ?? "").Trim();
            lbNgayGioDK.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }


        private void LoadPhongTheoKhuDangChon()
        {
            var khu = cmbKhu.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(khu))
            {
                cmbMaPhong.DataSource = null;
                cmbMaPhong.Enabled = false;
                return;
            }

            var phongs = _phongBus.LayPhongTheoKhu(khu);  // <-- dùng PhongBUS
            cmbMaPhong.DataSource = null;
            cmbMaPhong.DataSource = phongs;
            cmbMaPhong.Enabled = phongs.Count > 0;
            if (cmbMaPhong.Enabled) cmbMaPhong.SelectedIndex = 0;
        }



        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var mssv = txtMSSV.Text?.Trim();
            var khu = cmbKhu.SelectedItem?.ToString();
            var phong = cmbMaPhong.SelectedItem?.ToString();
            var hk = cmbHocKi.SelectedItem?.ToString();
            var namhoc = txtNamHoc.Text?.Trim();
            var ngaybd = dtpNgayBD.Value.Date;
            var thoihan = txtThoiHan.Text?.Trim();
            var maNV = lbMaNV.Text?.Trim(); // nếu có đăng nhập NV

            if (string.IsNullOrWhiteSpace(khu) || string.IsNullOrWhiteSpace(phong))
            {
                MessageBox.Show("Vui lòng chọn Khu và Mã phòng.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPDK;
            string error;
            var ok = _bus.TaoPhieuDangKy(mssv, khu, phong, hk, namhoc, ngaybd, thoihan, maNV, out maPDK, out error);

            if (ok)
            {
                MessageBox.Show($"Tạo phiếu đăng ký thành công! Mã PDK: {maPDK}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Bật nút in nếu có luồng in phiếu:
                // btnInPDK.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lỗi: " + (error ?? "Không xác định"), "Thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormInDangKy_Load(object sender, EventArgs e)
        {
            lbMaNV.Text = AppSession.MaNV ?? "";
  
            lbNgayGioDK.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            cmbKhu.DataSource = null;
            cmbKhu.DataSource = _phongBus.LayKhuAB(); // A/B

            cmbHocKi.DataSource = null;
            cmbHocKi.DataSource = new[] { "1", "2", "3" };

            BindPhongTheoKhu();
        }

        private void cmbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPhongTheoKhu();
        }

        private void BindPhongTheoKhu()
        {
            var khu = cmbKhu.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(khu))
            {
                cmbMaPhong.DataSource = null;
                cmbMaPhong.Enabled = false;
                return;
            }
            var ds = _phongBus.LayPhongTheoKhu(khu);
            cmbMaPhong.DataSource = null;
            cmbMaPhong.DataSource = ds;
            cmbMaPhong.Enabled = ds.Count > 0;
        }

    }
}
