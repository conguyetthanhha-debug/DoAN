namespace textktx.CACFORM
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pnSV = new System.Windows.Forms.Panel();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.cmbDienSV = new System.Windows.Forms.ComboBox();
            this.ckbNu = new System.Windows.Forms.CheckBox();
            this.txtQueQuan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.cmbMaLop = new System.Windows.Forms.ComboBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.lbCMND = new System.Windows.Forms.Label();
            this.txtNgSinh = new System.Windows.Forms.TextBox();
            this.lbHoTen = new System.Windows.Forms.Label();
            this.lbNgaySinh = new System.Windows.Forms.Label();
            this.lbGioiTinh = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtBHYT = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lbMaLop = new System.Windows.Forms.Label();
            this.lbBHYT = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbSDT = new System.Windows.Forms.Label();
            this.lbMSSV = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChonHinh = new System.Windows.Forms.Button();
            this.pictureBoxSV = new System.Windows.Forms.PictureBox();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnSV.SuspendLayout();
            this.pnContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSV)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSua
            // 
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.Blue;
            this.btnSua.Location = new System.Drawing.Point(200, 9);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(108, 43);
            this.btnSua.TabIndex = 25;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.Crimson;
            this.btnLuu.Location = new System.Drawing.Point(350, 9);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(108, 43);
            this.btnLuu.TabIndex = 26;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // pnSV
            // 
            this.pnSV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnSV.Controls.Add(this.pnContainer);
            this.pnSV.Controls.Add(this.panel2);
            this.pnSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pnSV.Location = new System.Drawing.Point(0, 77);
            this.pnSV.Name = "pnSV";
            this.pnSV.Size = new System.Drawing.Size(800, 373);
            this.pnSV.TabIndex = 29;
            // 
            // pnContainer
            // 
            this.pnContainer.Controls.Add(this.pictureBoxSV);
            this.pnContainer.Controls.Add(this.btnChonHinh);
            this.pnContainer.Controls.Add(this.cmbDienSV);
            this.pnContainer.Controls.Add(this.ckbNu);
            this.pnContainer.Controls.Add(this.txtQueQuan);
            this.pnContainer.Controls.Add(this.label3);
            this.pnContainer.Controls.Add(this.txtMSSV);
            this.pnContainer.Controls.Add(this.cmbMaLop);
            this.pnContainer.Controls.Add(this.txtCMND);
            this.pnContainer.Controls.Add(this.lbCMND);
            this.pnContainer.Controls.Add(this.txtNgSinh);
            this.pnContainer.Controls.Add(this.lbHoTen);
            this.pnContainer.Controls.Add(this.lbNgaySinh);
            this.pnContainer.Controls.Add(this.lbGioiTinh);
            this.pnContainer.Controls.Add(this.txtHoTen);
            this.pnContainer.Controls.Add(this.txtBHYT);
            this.pnContainer.Controls.Add(this.txtEmail);
            this.pnContainer.Controls.Add(this.txtSDT);
            this.pnContainer.Controls.Add(this.lbMaLop);
            this.pnContainer.Controls.Add(this.lbBHYT);
            this.pnContainer.Controls.Add(this.lbEmail);
            this.pnContainer.Controls.Add(this.lbSDT);
            this.pnContainer.Controls.Add(this.lbMSSV);
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(800, 310);
            this.pnContainer.TabIndex = 30;
            // 
            // pictureBoxSV
            // 
            this.pictureBoxSV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSV.Location = new System.Drawing.Point(600, 30);
            this.pictureBoxSV.Name = "pictureBoxSV";
            this.pictureBoxSV.Size = new System.Drawing.Size(150, 180);
            this.pictureBoxSV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSV.TabIndex = 40;
            this.pictureBoxSV.TabStop = false;
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonHinh.ForeColor = System.Drawing.Color.DarkRed;
            this.btnChonHinh.Location = new System.Drawing.Point(600, 220);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(150, 33);
            this.btnChonHinh.TabIndex = 41;
            this.btnChonHinh.Text = "Chọn hình...";
            // 
            // Các control nhập liệu
            // 
            this.cmbDienSV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDienSV.Items.AddRange(new object[] { "1", "2", "2NT", "3" });
            this.cmbDienSV.Location = new System.Drawing.Point(150, 260);
            this.cmbDienSV.Size = new System.Drawing.Size(150, 25);
            this.ckbNu.Location = new System.Drawing.Point(150, 150);
            this.txtQueQuan.Location = new System.Drawing.Point(150, 220);
            this.label3.Text = "Quê quán";
            this.label3.Location = new System.Drawing.Point(50, 225);
            this.txtMSSV.Location = new System.Drawing.Point(150, 30);
            this.lbMSSV.Text = "MSSV";
            this.lbMSSV.Location = new System.Drawing.Point(50, 35);
            this.txtHoTen.Location = new System.Drawing.Point(150, 70);
            this.lbHoTen.Text = "Họ tên";
            this.lbHoTen.Location = new System.Drawing.Point(50, 75);
            this.txtNgSinh.Location = new System.Drawing.Point(150, 110);
            this.lbNgaySinh.Text = "Ngày sinh";
            this.lbNgaySinh.Location = new System.Drawing.Point(50, 115);
            this.lbGioiTinh.Text = "Giới tính";
            this.lbGioiTinh.Location = new System.Drawing.Point(50, 155);
            this.cmbMaLop.Location = new System.Drawing.Point(150, 180);
            this.lbMaLop.Text = "Mã lớp";
            this.lbMaLop.Location = new System.Drawing.Point(50, 185);
            this.txtSDT.Location = new System.Drawing.Point(400, 30);
            this.lbSDT.Text = "SĐT";
            this.lbSDT.Location = new System.Drawing.Point(330, 35);
            this.txtEmail.Location = new System.Drawing.Point(400, 70);
            this.lbEmail.Text = "Email";
            this.lbEmail.Location = new System.Drawing.Point(330, 75);
            this.txtBHYT.Location = new System.Drawing.Point(400, 110);
            this.lbBHYT.Text = "BHYT";
            this.lbBHYT.Location = new System.Drawing.Point(330, 115);
            this.txtCMND.Location = new System.Drawing.Point(400, 150);
            this.lbCMND.Text = "CMND";
            this.lbCMND.Location = new System.Drawing.Point(330, 155);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 310);
            this.panel2.Size = new System.Drawing.Size(800, 63);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lbTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Size = new System.Drawing.Size(800, 77);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Goldenrod;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbTitle.Text = "THÔNG TIN SINH VIÊN";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnSV);
            this.Controls.Add(this.pnTop);
            this.Text = "Sinh Viên";
            this.pnSV.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.pnContainer.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSV)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Panel pnSV;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.CheckBox ckbNu;
        private System.Windows.Forms.TextBox txtQueQuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDienSV;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.ComboBox cmbMaLop;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lbCMND;
        private System.Windows.Forms.TextBox txtNgSinh;
        private System.Windows.Forms.Label lbHoTen;
        private System.Windows.Forms.Label lbNgaySinh;
        private System.Windows.Forms.Label lbGioiTinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtBHYT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lbMaLop;
        private System.Windows.Forms.Label lbBHYT;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbSDT;
        private System.Windows.Forms.Label lbMSSV;
        private System.Windows.Forms.Button btnChonHinh;
        private System.Windows.Forms.PictureBox pictureBoxSV;
    }
}
