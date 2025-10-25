    using BUS;
    using DAL.Model;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using DAL.Services;

namespace textktx.CACFORM
    {
        public partial class FormNhanVien : Form
        {
        private readonly NhanVienBUS _bus = new NhanVienBUS();
            private byte[] _anhBytes;

            public FormNhanVien()
            {
                InitializeComponent();
            }

            private NHANVIEN GetInput()
            {
                return new NHANVIEN
                {
                    MaNV = txtMaNV.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    CMND = txtCMND.Text.Trim(),
                    SDT = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim(),
                    MaNQL = string.IsNullOrWhiteSpace(txtMaNQL.Text) ? null : txtMaNQL.Text.Trim(),
                    Luong = int.TryParse(txtLuong.Text.Trim(), out var l) ? l : (int?)null,
                    AnhChanDung = _anhBytes 
                };
            }

            private void btnChoose_Click(object sender, EventArgs e)
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        picAvt.Image = Image.FromFile(ofd.FileName);
                        _anhBytes = File.ReadAllBytes(ofd.FileName);
                    }
                }
            }

            private void btnLuu_Click(object sender, EventArgs e)
            {
                try
                {
                    var nv = GetInput();
                    if (string.IsNullOrEmpty(nv.MaNV) || string.IsNullOrEmpty(nv.HoTen))
                    {
                        MessageBox.Show("Vui lòng nhập Mã NV và Họ tên.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_bus.ThemNhanVien(nv))
                        MessageBox.Show("Đã thêm nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Mã NV đã tồn tại, không thể thêm.", "Trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnSua_Click(object sender, EventArgs e)
            {
                try
                {
                    var nv = GetInput();
                    if (string.IsNullOrEmpty(nv.MaNV))
                    {
                        MessageBox.Show("Cần nhập Mã NV để cập nhật.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_bus.CapNhatNhanVien(nv))
                        MessageBox.Show("Cập nhật nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Không tìm thấy nhân viên để cập nhật.", "Không tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var f = new FormTimkiem(tknv: true);
            f.NhanVienSelected += OnNhanVienPicked;
            f.Show(this);
        }

        private void OnNhanVienPicked(NhanVienVm vm)
        {
            if (vm == null) return;

            txtMaNV.Text = vm.MaNV;
            txtHoTen.Text = vm.HoTen;
            txtCMND.Text = vm.CMND;
            txtSDT.Text = vm.SDT;
            txtEmail.Text = vm.Email;
            txtDiaChi.Text = vm.DiaChi;
            txtMaNQL.Text = vm.MaNQL;
            txtLuong.Text = vm.Luong?.ToString() ?? "";

            // Nếu muốn hiển thị ảnh luôn, có 2 cách:
            // Cách A: mở rộng NhanVienVm có byte[] AnhChanDung (khuyên dùng để tránh query thêm)
            // Cách B: query 1 lần theo MaNV để lấy ảnh:
            try
            {
                var dal = new DAL.Services.NhanVienDAL();
                var nvFull = dal.GetByMa(vm.MaNV);     // thêm method này ở DAL (mục 3)
                if (nvFull?.AnhChanDung != null && nvFull.AnhChanDung.Length > 0)
                {
                    using (var ms = new System.IO.MemoryStream(nvFull.AnhChanDung))
                    {
                        picAvt.Image = Image.FromStream(ms);
                        _anhBytes = nvFull.AnhChanDung; // giữ lại để khi Sửa/Lưu không mất ảnh
                    }
                }
                else
                {
                    picAvt.Image = null;
                    _anhBytes = null;
                }
            }
            catch { /* tùy ý log */ }
        }


        private void ClearForm()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtCMND.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtMaNQL.Clear();
            txtLuong.Clear();
            picAvt.Image = null;
            _anhBytes = null;
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            var ma = txtMaNV.Text?.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng nhập Mã NV cần xóa.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn chắc chắn muốn xóa nhân viên '{ma}'?",
                                          "Xác nhận xóa",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string error;
            var ok = _bus.XoaNhanVien(ma, out error);

            if (ok)
            {
                MessageBox.Show("Đã xóa nhân viên thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            else
            {
                MessageBox.Show(error ?? "Không thể xóa do là admin.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
