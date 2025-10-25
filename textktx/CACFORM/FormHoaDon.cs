using BUS;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace textktx.CACFORM
{
    public partial class FormHoaDon : Form
    {
        private bool _isViewMode = false;

        private readonly PhongBUS _phongBus = new PhongBUS();
        private readonly DichVuBUS _dvBus = new DichVuBUS();
        private readonly HoaDonBUS _hdBus = new HoaDonBUS();

        private List<DichVuVm> _dsDichVu = new List<DichVuVm>();
        private readonly BindingList<TempDV> _tempDichVu = new BindingList<TempDV>();

        private class TempDV
        {
            public string MaDV { get; set; }
            public string TenDV { get; set; }
            public string DonViTinh { get; set; }
            public int SoLuong { get; set; }
        }

        public FormHoaDon()
        {
            InitializeComponent();
            InitUi();
            LoadLookups();
            LoadDichVu();
            LoadHoaDonGrid();
        }

        private void InitUi()
        {
            txtMaNV.ReadOnly = true;
            dtNgayHD.Enabled = false;

            txtMaNV.Text = AppSession.MaNV ?? "";
            dtNgayHD.Value = DateTime.Now;

            txtThang.Items.Clear();
            for (int m = 1; m <= 12; m++) txtThang.Items.Add(m.ToString());
            txtThang.SelectedIndex = DateTime.Now.Month - 1;

            txtNamHoc.Text = DateTime.Now.Year.ToString();
            SetupHoaDonGridColumns();
            SetViewMode(false);
        }

        private void SetupHoaDonGridColumns()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.Columns.Clear();

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaHD", HeaderText = "Mã HĐ" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nam", HeaderText = "Năm" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Thang", HeaderText = "Tháng" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayHD", HeaderText = "Ngày lập" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Khu", HeaderText = "Khu" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaPhong", HeaderText = "Phòng" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNV", HeaderText = "Mã NV" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNV", HeaderText = "Tên NV" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongTienDichVu", HeaderText = "Tổng DV" });
        }

        private void LoadLookups()
        {
            var khus = _phongBus.LayKhuAB();
            cmbKhu.DataSource = khus;
            if (cmbKhu.Items.Count > 0) cmbKhu.SelectedIndex = 0;
            LoadPhongTheoKhu();
        }

        private void LoadPhongTheoKhu()
        {
            var khu = cmbKhu.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(khu))
            {
                cmbPhong.DataSource = null;
                return;
            }
            var rooms = _phongBus.LayPhongTheoKhu(khu);
            cmbPhong.DataSource = rooms;
            if (rooms.Count > 0) cmbPhong.SelectedIndex = 0;
        }

        private void LoadDichVu()
        {
            try
            {
                _dsDichVu = _dvBus.LayDanhSachDichVu();
                cmbTenDV.DataSource = _dsDichVu;
                cmbTenDV.DisplayMember = "TenDV";
                cmbTenDV.ValueMember = "MaDV";
                UpdateDonViTinhBySelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dịch vụ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDonViTinhBySelected()
        {
            var dv = cmbTenDV.SelectedItem as DichVuVm;
            lbDonVi.Text = dv != null ? $"Đơn vị tính: {dv.DonViTinh}" : "Đơn vị tính:";
        }

        private void LoadHoaDonGrid()
        {
            var list = _hdBus.LayTatCaHoaDon();
            dgvHoaDon.DataSource = list;
        }

        private void SetViewMode(bool viewMode)
        {
            _isViewMode = viewMode;

            txtThang.Enabled = !viewMode;
            txtNamHoc.ReadOnly = viewMode;
            cmbKhu.Enabled = !viewMode;
            cmbPhong.Enabled = !viewMode;

            cmbTenDV.Enabled = !viewMode;
            numSoLuong.Enabled = !viewMode;
            btnThemDV.Enabled = !viewMode;
            btnHoanTat.Enabled = !viewMode;

            txtMaNV.ReadOnly = true;
            dtNgayHD.Enabled = false;
        }

        private void cmbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isViewMode) LoadPhongTheoKhu();
        }

        private void cmbTenDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDonViTinhBySelected();
        }

        private void btnThemDV_Click_1(object sender, EventArgs e)
        {
            if (_isViewMode)
            {
                MessageBox.Show("Đang ở chế độ xem. Không thể thêm dịch vụ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sel = cmbTenDV.SelectedItem as DichVuVm;
            if (sel == null)
            {
                MessageBox.Show("Chưa chọn dịch vụ.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sl = (int)numSoLuong.Value;
            if (sl <= 0)
            {
                MessageBox.Show("Số lượng phải > 0.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existed = _tempDichVu.FirstOrDefault(x => x.MaDV == sel.MaDV);
            if (existed == null)
            {
                _tempDichVu.Add(new TempDV
                {
                    MaDV = sel.MaDV,
                    TenDV = sel.TenDV,
                    DonViTinh = sel.DonViTinh,
                    SoLuong = sl
                });
            }
            else
            {
                existed.SoLuong += sl;
            }

            lbDonVi.Text = $"Đơn vị tính: {sel.DonViTinh}";
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            if (_isViewMode)
            {
                MessageBox.Show("Đang ở chế độ xem. Không thể tạo hóa đơn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var maNV = txtMaNV.Text?.Trim();
            var khu = cmbKhu.SelectedItem?.ToString();
            var phong = cmbPhong.SelectedItem?.ToString();
            var thang = txtThang.SelectedItem?.ToString();
            var nam = txtNamHoc.Text?.Trim();
            var ngay = dtNgayHD.Value;

            var dsTam = _tempDichVu.Select(x => (x.MaDV, x.SoLuong)).ToList();
            if (!dsTam.Any())
            {
                var conf = MessageBox.Show(
                    "Hóa đơn chưa có dịch vụ. Bạn vẫn muốn tạo hóa đơn trống?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (conf != DialogResult.Yes) return;
            }

            if (_hdBus.TaoHoaDon(maNV, khu, phong, thang, nam, ngay, dsTam, out var maHD, out var error))
            {
                MessageBox.Show($"Đã tạo hóa đơn #{maHD}.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _tempDichVu.Clear();
                LoadHoaDonGrid();

                BindHoaDonLenControls(maHD);
                SetViewMode(true);
            }
            else
            {
                MessageBox.Show("Lỗi tạo hóa đơn: " + error, "Thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindHoaDonLenControls(int maHD)
        {
            var list = _hdBus.LayTatCaHoaDon();
            var row = list.FirstOrDefault(x => x.MaHD == maHD);
            if (row == null) return;

            txtMaNV.Text = row.MaNV;
            dtNgayHD.Value = row.NgayHD;
            txtThang.SelectedItem = row.Thang.ToString();
            txtNamHoc.Text = row.Nam.ToString();
            cmbKhu.SelectedItem = row.Khu;
            LoadPhongTheoKhu();
            cmbPhong.SelectedItem = row.MaPhong;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var list = dgvHoaDon.DataSource as List<HoaDonVm>;
            if (list == null || e.RowIndex >= list.Count) return;

            var item = list[e.RowIndex];
            txtMaNV.Text = item.MaNV;
            dtNgayHD.Value = item.NgayHD;
            txtThang.SelectedItem = item.Thang.ToString();
            txtNamHoc.Text = item.Nam.ToString();
            cmbKhu.SelectedItem = item.Khu;
            LoadPhongTheoKhu();
            cmbPhong.SelectedItem = item.MaPhong;
            SetViewMode(true);
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetViewMode(false);
            _tempDichVu.Clear();
            txtMaNV.Text = AppSession.MaNV ?? "";
            dtNgayHD.Value = DateTime.Now;
        }
    }
}
