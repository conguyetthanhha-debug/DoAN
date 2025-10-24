
using BUS;
using DAL.Model;
using System;
using System.Windows.Forms;

namespace textktx.CACFORM
{
    public partial class FormCacLoaiDichVu : Form
    {
        private readonly DichVuBUS _bus = new DichVuBUS();

        public FormCacLoaiDichVu()
        {
            InitializeComponent();
        }

        private void OpenDichVuByTen(string ten)
        {
            DICHVU dv = _bus.LayTheoTen(ten);
            if (dv == null)
            {
                MessageBox.Show($"Không tìm thấy dịch vụ \"{ten}\" trong cơ sở dữ liệu.",
                                "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new FormDichVu(dv))
                f.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            OpenDichVuByTen("Điện");
        }

        private void button4_Click(object sender, EventArgs e)
        {
  
            OpenDichVuByTen("Nước");
        }
    }
}
