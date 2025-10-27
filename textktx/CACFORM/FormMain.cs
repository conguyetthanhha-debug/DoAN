using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textktx.CACFORM
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSinhVien frm = new FormSinhVien();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDangNhap frmDangNhap = new FormDangNhap();
            frmDangNhap.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormInDangKy frm = new FormInDangKy();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormHoaDon formHoaDon = new FormHoaDon();
            formHoaDon.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormkhuPhong formkhuPhong = new FormkhuPhong();
            formkhuPhong.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhan = new FormNhanVien();
            formNhan.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormCacTheLoaiPhong frmLoai = new FormCacTheLoaiPhong();
            frmLoai.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormCacLoaiDichVu formDichVu = new FormCacLoaiDichVu();
            formDichVu.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Khi mở từ Main, KHÔNG đóng khi double-click
            var f = new FormTimkiem(initialTab: TableKind.NhanVien, closeOnPick: false);
            f.Show(this);
        }



        private void button11_Click(object sender, EventArgs e)
        {
            FormHuongDan formHuong = new FormHuongDan();    
            formHuong.Show();
        }
    }
}
