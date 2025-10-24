
using DAL.Model;
using System;
using System.Windows.Forms;

namespace textktx.CACFORM
{
    public partial class FormDichVu : Form
    {
        public FormDichVu()
        {
            InitializeComponent();
        }

        public FormDichVu(DICHVU dv) : this()
        {
            Bind(dv);
        }

        public void Bind(DICHVU dv)
        {
            if (dv == null) return;
            txtMaDV.Text = dv.MaDV;
            txtTenDV.Text = dv.TenDV;
            txtGiaDV.Text = dv.GiaDV.ToString("#,##0");
            txtDonViTinh.Text = dv.DonViTinh;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
