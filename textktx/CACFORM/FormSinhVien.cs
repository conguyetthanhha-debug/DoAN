using BUS;
using DAL.Model;
using DAL.Services; // để dùng SinhVienVm (chỉ kiểu dữ liệu)
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace textktx.CACFORM
{
    public partial class FormSinhVien : Form
    {
        private readonly SinhVienBUS _bus = new SinhVienBUS();
        private string _anhPath; // path ảnh (model: string)

        public FormSinhVien()
        {
            InitializeComponent();

            // mutual-exclusive cho 2 checkbox giới tính (ckbNu = "Nam", checkBox1 = "Nữ" theo Designer)
            ckbNu.CheckedChanged += (s, e) => { if (ckbNu.Checked) checkBox1.Checked = false; };
            checkBox1.CheckedChanged += (s, e) => { if (checkBox1.Checked) ckbNu.Checked = false; };
        }

        private SINHVIEN GetInput()
        {
            DateTime? ngsinh = dateTimePicker1.Checked ? (DateTime?)dateTimePicker1.Value.Date : null;

            return new SINHVIEN
            {
                MSSV = txtMSSV.Text.Trim(),
                DienSV = string.IsNullOrWhiteSpace(cmbDienSV.Text) ? null : cmbDienSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                Phai = ckbNu.Checked, // true = Nam
                NgSinh = ngsinh,
                CMND = string.IsNullOrWhiteSpace(txtCMND.Text) ? null : txtCMND.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                SDT = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim(),
                BHYT = string.IsNullOrWhiteSpace(txtBHYT.Text) ? null : txtBHYT.Text.Trim(),
                QueQuan = string.IsNullOrWhiteSpace(txtQueQuan.Text) ? null : txtQueQuan.Text.Trim(),
                AnhChanDung = _anhPath
            };
        }


        private void BindToForm(SINHVIEN sv)
        {
            if (sv == null) return;

            txtMSSV.Text = sv.MSSV;
            txtHoTen.Text = sv.HoTen;
            txtCMND.Text = sv.CMND;
            txtEmail.Text = sv.Email;
            txtSDT.Text = sv.SDT;
            txtBHYT.Text = sv.BHYT;
            txtQueQuan.Text = sv.QueQuan;
            if (sv.NgSinh.HasValue)
            {
                dateTimePicker1.Value = sv.NgSinh.Value;
                dateTimePicker1.Checked = true;
            }
            else
            {
                dateTimePicker1.Checked = false;
            }


            cmbDienSV.Text = sv.DienSV ?? "";

            ckbNu.Checked = sv.Phai;        // Nam
            checkBox1.Checked = !sv.Phai;   // Nữ

            _anhPath = sv.AnhChanDung;
            LoadPictureFromPath(_anhPath);
        }

        private void LoadPictureFromPath(string path)
        {
            // clear ảnh cũ
            if (pictureBoxSV.Image != null) { pictureBoxSV.Image.Dispose(); pictureBoxSV.Image = null; }

            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    pictureBoxSV.Image = Image.FromStream(ms);
                }
            }
        }

        private void ClearForm()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtCMND.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtBHYT.Clear();
            txtQueQuan.Clear();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Checked = false;

            cmbDienSV.SelectedIndex = -1; cmbDienSV.Text = "";
            ckbNu.Checked = false; checkBox1.Checked = false;

            if (pictureBoxSV.Image != null) { pictureBoxSV.Image.Dispose(); pictureBoxSV.Image = null; }
            _anhPath = null;
            txtMSSV.Focus();
        }

        // ===== Check: mở FormTimkiem và auto chuyển tab Sinh viên =====
        private void button1_Click(object sender, EventArgs e)
        {
            var f = new FormTimkiem(initialTab: TableKind.SinhVien, closeOnPick: true);
            f.SinhVienSelected += OnSinhVienPicked;
            f.Show(this);
        }

        private void OnSinhVienPicked(SinhVienVm vm)
        {
            if (vm == null) return;

            // Lấy full SinhVien từ BUS theo MSSV
            var full = _bus.LaySinhVienTheoMSSV(vm.MSSV);
            if (full != null) BindToForm(full);
            else
            {
                // fallback: bind những trường có trong Vm
                txtMSSV.Text = vm.MSSV;
                txtHoTen.Text = vm.HoTen;
                txtCMND.Text = vm.CMND;
                txtEmail.Text = vm.Email;
                txtSDT.Text = vm.SDT;
                txtQueQuan.Text = vm.QueQuan;

                bool isNam = string.Equals(vm.GioiTinh, "Nam", StringComparison.OrdinalIgnoreCase);
                ckbNu.Checked = isNam;
                checkBox1.Checked = !isNam;

                cmbDienSV.SelectedIndex = -1; cmbDienSV.Text = "";
                txtBHYT.Clear();

                LoadPictureFromPath(null);
                _anhPath = null;
            }
        }

        // ===== Lưu: thêm mới khi MSSV CHƯA tồn tại =====
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                var sv = GetInput();
                if (string.IsNullOrWhiteSpace(sv.MSSV) || string.IsNullOrWhiteSpace(sv.HoTen))
                {
                    MessageBox.Show("Vui lòng nhập MSSV và Họ tên.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ▶▶ THÊM DÒNG NÀY: rút ngắn path ảnh trước khi gọi BUS
                sv.AnhChanDung = EnsureShortImagePath(sv.AnhChanDung, sv.MSSV);

                if (_bus.TonTaiMSSV(sv.MSSV))
                {
                    MessageBox.Show("MSSV đã tồn tại. Vui lòng dùng nút Sửa.", "Trùng MSSV",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _bus.ThemSinhVien(sv);
                MessageBox.Show("Đã thêm sinh viên thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // ▶▶ SỬA: show inner-most message để thấy lỗi SQL thật
                var msg = ex.GetBaseException()?.Message ?? ex.Message;
                MessageBox.Show("Lỗi khi lưu: " + msg, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ===== Sửa: cập nhật khi MSSV ĐÃ tồn tại =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var sv = GetInput();
                if (string.IsNullOrWhiteSpace(sv.MSSV))
                {
                    MessageBox.Show("Cần nhập MSSV để cập nhật.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ▶▶ THÊM DÒNG NÀY
                sv.AnhChanDung = EnsureShortImagePath(sv.AnhChanDung, sv.MSSV);

                _bus.CapNhatSinhVien(sv);
                MessageBox.Show("Cập nhật sinh viên thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // ▶▶ SỬA: show inner-most message
                var msg = ex.GetBaseException()?.Message ?? ex.Message;
                MessageBox.Show("Lỗi khi cập nhật: " + msg, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ===== Chọn hình: lưu path, load ảnh không khóa file =====
        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                _anhPath = ofd.FileName;
                LoadPictureFromPath(_anhPath);
            }
        }

        private string EnsureShortImagePath(string srcPath, string mssv)
        {
            if (string.IsNullOrWhiteSpace(srcPath)) return null;

            // nếu đã đủ ngắn thì dùng luôn
            if (srcPath.Length <= 255) return srcPath;

            // copy sang đường dẫn ngắn trong AppData
            var app = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dir = Path.Combine(app, "KTXApp", "Images");
            Directory.CreateDirectory(dir);

            var safeName = $"{mssv}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(srcPath)}";
            var dst = Path.Combine(dir, safeName);

            try
            {
                File.Copy(srcPath, dst, overwrite: true);
                return dst;
            }
            catch
            {
                // nếu copy lỗi, không để đường dẫn quá dài gây fail Save
                return null;
            }
        }

        private void lbNgaySinh_Click(object sender, EventArgs e)
        {

        }

        // các handler TextChanged trống giữ nguyên

    }
}
