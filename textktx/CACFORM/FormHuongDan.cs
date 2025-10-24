using System;
using System.Windows.Forms;

namespace textktx.CACFORM
{
    public partial class FormHuongDan : Form
    {
        public FormHuongDan()
        {
            InitializeComponent();
            LoadHuongDan();
        }

        private void LoadHuongDan()
        {
            rtb.Clear();
            rtb.Text =
@"I. GIỚI THIỆU
Với việc quản lý thông tin sinh viên, phần mềm quản lý ký túc xá mang đến cho nhà ký túc xá sinh viên một giải pháp hoàn chỉnh; các khâu, quy trình đều liên thông, kết nối với nhau, giúp việc quản lý sinh viên thuê phòng thuận tiện và tối ưu.

II. CHỨC NĂNG

1. Đăng ký
• Đăng ký phòng ở cho sinh viên mới.

2. Cập nhật thông tin
• Cập nhật thông tin sinh viên.
• Cập nhật thông tin nhân viên.

3. Tìm kiếm
• Tìm kiếm thông tin sinh viên.
• Tìm kiếm thông tin nhân viên.
• Tìm kiếm phòng.
• Tìm kiếm hóa đơn.

4. Xuất hóa đơn
• Xuất hóa đơn sinh hoạt hằng tháng của phòng.";
            rtb.SelectionStart = 0; // cuộn lên đầu
            rtb.ScrollToCaret();
        }
    }
}
