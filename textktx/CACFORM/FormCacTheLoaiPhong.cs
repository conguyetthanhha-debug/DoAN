
using System;
using System.Windows.Forms;
using BUS;

namespace textktx.CACFORM
{
    public partial class FormCacTheLoaiPhong : Form
    {
        private readonly LoaiPhongBUS _svc = new LoaiPhongBUS();

        public FormCacTheLoaiPhong()
        {
            InitializeComponent();
        }

        private void OpenLoaiPhong(int soSV)
        {
            var vm = _svc.LayLoaiPhongTheoSoSV(soSV);
            var f = new FormLoaiPhong();
            if (vm != null) f.SetData(vm);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenLoaiPhong(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenLoaiPhong(4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenLoaiPhong(6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenLoaiPhong(8);
        }
    }
}
