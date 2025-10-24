
using DAL.Services;
using System;
using System.Windows.Forms;
using static DAL.Services.LoaiPhongDAL;

namespace textktx.CACFORM
{
    public partial class FormLoaiPhong : Form
    {
        public FormLoaiPhong()
        {
            InitializeComponent();
        }

        public void SetData(LoaiPhongVm vm)
        {
            txtMaLoaiPhong.Text = vm?.MaLoaiPhong ?? "";
            txtSoSV.Text = vm?.SoSV.ToString() ?? "";
            txtDonGia.Text = vm != null ? vm.DonGia.ToString("#,0") : "";
            txtDienTich.Text = vm != null ? vm.DienTich.ToString("0.##") : "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
