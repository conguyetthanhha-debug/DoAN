
using BUS;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace textktx.CACFORM
{
    public partial class FormTimkiem : Form
    {
        private readonly bool timKiemNhanVien;
        private readonly TimKiemBUS _svc;
        private TableKind _current = TableKind.None;
        public event Action<NhanVienVm> NhanVienSelected;
        public event Action<DAL.Services.SinhVienVm> SinhVienSelected;

        public FormTimkiem(bool tknv = false)
        {

            InitializeComponent();
            timKiemNhanVien = tknv;
            _svc = new TimKiemBUS();
            this.Shown += FormTimkiem_Shown;

           
            dgv.CellDoubleClick += dgv_CellDoubleClick;  
            // Nếu muốn 1 click thì mở thêm dòng dưới:
            // dgv.CellClick += dgv_CellClick;
        }

        private static readonly string[] COL_SV = { "Tất cả", "MSSV", "HoTen", "GioiTinh", "NgSinh", "CMND", "Email", "SDT", "QueQuan" };
        private static readonly string[] COL_NV = { "Tất cả", "MaNV", "HoTen", "CMND", "SDT", "Email", "DiaChi", "Luong", "MaNQL" };
        private static readonly string[] COL_PHONG = { "Tất cả", "Khu", "MaPhong", "LoaiPhong", "SucChua", "DienTich", "DonGia", "DangO", "TrangThai" };
        private static readonly string[] COL_PDK = { "Tất cả", "MaPDK", "MSSV", "TenSV", "MaNV", "TenNV", "Khu", "MaPhong", "HocKi", "NamHoc", "NgayGioDK", "ThoiHan", "NgayBD" };
        private static readonly string[] COL_HD = { "Tất cả", "MaHD", "Nam", "Thang", "NgayHD", "Khu", "MaPhong", "MaNV", "TenNV", "TongTienDichVu" };

        private void FormTimkiem_Shown(object sender, EventArgs e)
        {
            if (timKiemNhanVien)
                BeginInvoke(new Action(() => SetCurrent(TableKind.NhanVien)));
        }

        public void ShowSinhVien()
        {
            
            btnSinhVien_Click(this, EventArgs.Empty);
        }
        private void SetCurrent(TableKind kind)
        {
            _current = kind;
            pnKey.Visible = true;
            btnSearch.Enabled = true;
            txtKhu.Clear(); 

            switch (kind)
            {
                case TableKind.SinhVien:
                    cmbMucTimKiem.DataSource = COL_SV.ToList();
                    BindGrid(_svc.LayDanhSachSinhVien());
                    break;

                case TableKind.NhanVien:
                    cmbMucTimKiem.DataSource = COL_NV.ToList();
                    BindGrid(_svc.LayDanhSachNhanVien());
                    break;

                case TableKind.Phong:
                    cmbMucTimKiem.DataSource = COL_PHONG.ToList();
                    BindGrid(_svc.LayDanhSachPhong());
                    break;

                case TableKind.PhieuDK:
                    cmbMucTimKiem.DataSource = COL_PDK.ToList();
                    BindGrid(_svc.LayDanhSachPhieuDK());
                    break;

                case TableKind.HoaDon:
                    cmbMucTimKiem.DataSource = COL_HD.ToList();
                    BindGrid(_svc.LayDanhSachHoaDon());
                    break;
            }
        }

        private void DoSearch()
        {
            if (_current == TableKind.None) return;

            var col = (cmbMucTimKiem.SelectedItem as string) ?? "Tất cả";
            var text = (txtKhu.Text ?? "").Trim();

            var data = _svc.TimKiem(_current, col, text);
            BindGrid(data);
        }

        private void btnSinhVien_Click(object sender, EventArgs e) => SetCurrent(TableKind.SinhVien);
        private void btnNhanVien_Click(object sender, EventArgs e) => SetCurrent(TableKind.NhanVien);
        private void btnPhong_Click(object sender, EventArgs e) => SetCurrent(TableKind.Phong);
        private void btnPhieuDK_Click(object sender, EventArgs e) => SetCurrent(TableKind.PhieuDK);
        private void btnHoaDon_Click(object sender, EventArgs e) => SetCurrent(TableKind.HoaDon);

    

  
        private void BindGrid<T>(IEnumerable<T> data)
        {
            dgv.DataSource = null;
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = data?.ToList();
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            DoSearch(); 
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
           => PickCurrentRow(e.RowIndex);
        private void PickCurrentRow(int rowIndex)
        {
            if (rowIndex < 0) return;

            if (_current == TableKind.NhanVien)
            {
                var vm = dgv.Rows[rowIndex].DataBoundItem as NhanVienVm;
                if (vm == null) return;
                NhanVienSelected?.Invoke(vm);
                Close();
                return;
            }

            if (_current == TableKind.SinhVien)
            {
                var svm = dgv.Rows[rowIndex].DataBoundItem as DAL.Services.SinhVienVm;
                if (svm == null) return;
                SinhVienSelected?.Invoke(svm);
                Close();
                return;
            }
        }
    }
}
