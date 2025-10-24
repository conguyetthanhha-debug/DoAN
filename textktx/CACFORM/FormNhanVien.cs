    using BUS;
    using DAL.Model;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

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
                new FormTimkiem(tknv: true).Show();
            }
        }
    }
