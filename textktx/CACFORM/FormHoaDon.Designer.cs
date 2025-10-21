namespace textktx.CACFORM
{
    partial class FormHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnTop = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDonVi = new System.Windows.Forms.Label();
            this.btnXoaDV = new System.Windows.Forms.Button();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cmbTenDV = new System.Windows.Forms.ComboBox();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.lbTenDV = new System.Windows.Forms.Label();
            this.pnContainerBottom = new System.Windows.Forms.Panel();
            this.btnXoaHD = new System.Windows.Forms.Button();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.pnContainerTop = new System.Windows.Forms.Panel();
            this.txtThang = new System.Windows.Forms.ComboBox();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.dtNgayHD = new System.Windows.Forms.DateTimePicker();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lbNhanVien = new System.Windows.Forms.Label();
            this.lbNgay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPhong = new System.Windows.Forms.ComboBox();
            this.cmbKhu = new System.Windows.Forms.ComboBox();
            this.lbPhong = new System.Windows.Forms.Label();
            this.lbKhu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnTop.SuspendLayout();
            this.pnContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.pnContainerBottom.SuspendLayout();
            this.pnContainerTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lbTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(835, 45);
            this.pnTop.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(835, 45);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "THÔNG TIN HÓA ĐƠN";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnContainer
            // 
            this.pnContainer.Controls.Add(this.dgvHoaDon);
            this.pnContainer.Controls.Add(this.panel1);
            this.pnContainer.Controls.Add(this.pnContainerBottom);
            this.pnContainer.Controls.Add(this.pnContainerTop);
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 45);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(835, 730);
            this.pnContainer.TabIndex = 0;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeight = 34;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDV,
            this.TenDV,
            this.SoLuong,
            this.DonViTinh});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 205);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 62;
            this.dgvHoaDon.Size = new System.Drawing.Size(835, 485);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // MaDV
            // 
            this.MaDV.DataPropertyName = "MaDV";
            this.MaDV.HeaderText = "Mã dịch vụ";
            this.MaDV.MinimumWidth = 8;
            this.MaDV.Name = "MaDV";
            this.MaDV.ReadOnly = true;
            // 
            // TenDV
            // 
            this.TenDV.DataPropertyName = "TenDV";
            this.TenDV.HeaderText = "Tên dịch vụ";
            this.TenDV.MinimumWidth = 8;
            this.TenDV.Name = "TenDV";
            this.TenDV.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn vị tính";
            this.DonViTinh.MinimumWidth = 8;
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbDonVi);
            this.panel1.Controls.Add(this.btnXoaDV);
            this.panel1.Controls.Add(this.btnThemDV);
            this.panel1.Controls.Add(this.numSoLuong);
            this.panel1.Controls.Add(this.cmbTenDV);
            this.panel1.Controls.Add(this.lbSoLuong);
            this.panel1.Controls.Add(this.lbTenDV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 90);
            this.panel1.TabIndex = 1;
            // 
            // lbDonVi
            // 
            this.lbDonVi.Location = new System.Drawing.Point(20, 65);
            this.lbDonVi.Name = "lbDonVi";
            this.lbDonVi.Size = new System.Drawing.Size(100, 23);
            this.lbDonVi.TabIndex = 0;
            this.lbDonVi.Text = "Đơn vị tính:";
            // 
            // btnXoaDV
            // 
            this.btnXoaDV.Location = new System.Drawing.Point(460, 45);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Size = new System.Drawing.Size(75, 23);
            this.btnXoaDV.TabIndex = 1;
            this.btnXoaDV.Text = "Xóa";
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(460, 10);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(75, 23);
            this.btnThemDV.TabIndex = 2;
            this.btnThemDV.Text = "Thêm";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(120, 40);
            this.numSoLuong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(120, 26);
            this.numSoLuong.TabIndex = 3;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbTenDV
            // 
            this.cmbTenDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenDV.Location = new System.Drawing.Point(120, 10);
            this.cmbTenDV.Name = "cmbTenDV";
            this.cmbTenDV.Size = new System.Drawing.Size(121, 28);
            this.cmbTenDV.TabIndex = 4;
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.Location = new System.Drawing.Point(40, 42);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(100, 23);
            this.lbSoLuong.TabIndex = 5;
            this.lbSoLuong.Text = "Số lượng:";
            // 
            // lbTenDV
            // 
            this.lbTenDV.Location = new System.Drawing.Point(40, 13);
            this.lbTenDV.Name = "lbTenDV";
            this.lbTenDV.Size = new System.Drawing.Size(100, 23);
            this.lbTenDV.TabIndex = 6;
            this.lbTenDV.Text = "Dịch vụ:";
            // 
            // pnContainerBottom
            // 
            this.pnContainerBottom.Controls.Add(this.btnXoaHD);
            this.pnContainerBottom.Controls.Add(this.btnHoanTat);
            this.pnContainerBottom.Controls.Add(this.btnInHoaDon);
            this.pnContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnContainerBottom.Location = new System.Drawing.Point(0, 690);
            this.pnContainerBottom.Name = "pnContainerBottom";
            this.pnContainerBottom.Size = new System.Drawing.Size(835, 40);
            this.pnContainerBottom.TabIndex = 2;
            // 
            // btnXoaHD
            // 
            this.btnXoaHD.Location = new System.Drawing.Point(20, 8);
            this.btnXoaHD.Name = "btnXoaHD";
            this.btnXoaHD.Size = new System.Drawing.Size(75, 23);
            this.btnXoaHD.TabIndex = 0;
            this.btnXoaHD.Text = "Xóa";
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.Location = new System.Drawing.Point(230, 8);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(75, 23);
            this.btnHoanTat.TabIndex = 1;
            this.btnHoanTat.Text = "Hoàn tất";
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Location = new System.Drawing.Point(440, 8);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(75, 23);
            this.btnInHoaDon.TabIndex = 2;
            this.btnInHoaDon.Text = "In hóa đơn";
            // 
            // pnContainerTop
            // 
            this.pnContainerTop.Controls.Add(this.txtThang);
            this.pnContainerTop.Controls.Add(this.txtNamHoc);
            this.pnContainerTop.Controls.Add(this.dtNgayHD);
            this.pnContainerTop.Controls.Add(this.txtMaNV);
            this.pnContainerTop.Controls.Add(this.lbNhanVien);
            this.pnContainerTop.Controls.Add(this.lbNgay);
            this.pnContainerTop.Controls.Add(this.label2);
            this.pnContainerTop.Controls.Add(this.cmbPhong);
            this.pnContainerTop.Controls.Add(this.cmbKhu);
            this.pnContainerTop.Controls.Add(this.lbPhong);
            this.pnContainerTop.Controls.Add(this.lbKhu);
            this.pnContainerTop.Controls.Add(this.label1);
            this.pnContainerTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnContainerTop.Location = new System.Drawing.Point(0, 0);
            this.pnContainerTop.Name = "pnContainerTop";
            this.pnContainerTop.Size = new System.Drawing.Size(835, 115);
            this.pnContainerTop.TabIndex = 3;
            // 
            // txtThang
            // 
            this.txtThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.txtThang.Location = new System.Drawing.Point(220, 28);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(121, 28);
            this.txtThang.TabIndex = 0;
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(220, 81);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.Size = new System.Drawing.Size(100, 26);
            this.txtNamHoc.TabIndex = 1;
            // 
            // dtNgayHD
            // 
            this.dtNgayHD.Location = new System.Drawing.Point(20, 81);
            this.dtNgayHD.Name = "dtNgayHD";
            this.dtNgayHD.Size = new System.Drawing.Size(200, 26);
            this.dtNgayHD.TabIndex = 2;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(20, 28);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 26);
            this.txtMaNV.TabIndex = 3;
            // 
            // lbNhanVien
            // 
            this.lbNhanVien.Location = new System.Drawing.Point(20, 10);
            this.lbNhanVien.Name = "lbNhanVien";
            this.lbNhanVien.Size = new System.Drawing.Size(100, 23);
            this.lbNhanVien.TabIndex = 4;
            this.lbNhanVien.Text = "Nhân viên:";
            // 
            // lbNgay
            // 
            this.lbNgay.Location = new System.Drawing.Point(20, 61);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(100, 23);
            this.lbNgay.TabIndex = 5;
            this.lbNgay.Text = "Ngày lập hóa đơn:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(220, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Năm học:";
            // 
            // cmbPhong
            // 
            this.cmbPhong.Location = new System.Drawing.Point(410, 81);
            this.cmbPhong.Name = "cmbPhong";
            this.cmbPhong.Size = new System.Drawing.Size(121, 28);
            this.cmbPhong.TabIndex = 7;
            // 
            // cmbKhu
            // 
            this.cmbKhu.Location = new System.Drawing.Point(410, 28);
            this.cmbKhu.Name = "cmbKhu";
            this.cmbKhu.Size = new System.Drawing.Size(121, 28);
            this.cmbKhu.TabIndex = 8;
            // 
            // lbPhong
            // 
            this.lbPhong.Location = new System.Drawing.Point(410, 61);
            this.lbPhong.Name = "lbPhong";
            this.lbPhong.Size = new System.Drawing.Size(100, 23);
            this.lbPhong.TabIndex = 9;
            this.lbPhong.Text = "Phòng:";
            // 
            // lbKhu
            // 
            this.lbKhu.Location = new System.Drawing.Point(410, 10);
            this.lbKhu.Name = "lbKhu";
            this.lbKhu.Size = new System.Drawing.Size(100, 23);
            this.lbKhu.TabIndex = 10;
            this.lbKhu.Text = "Khu:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(220, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tháng:";
            // 
            // FormHoaDon
            // 
            this.ClientSize = new System.Drawing.Size(835, 775);
            this.Controls.Add(this.pnContainer);
            this.Controls.Add(this.pnTop);
            this.Name = "FormHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa đơn";
            this.pnTop.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.pnContainerBottom.ResumeLayout(false);
            this.pnContainerTop.ResumeLayout(false);
            this.pnContainerTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnContainerBottom;
        private System.Windows.Forms.Panel pnContainerTop;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnHoanTat;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Button btnXoaHD;
        private System.Windows.Forms.ComboBox cmbPhong;
        private System.Windows.Forms.ComboBox cmbKhu;
        private System.Windows.Forms.Label lbPhong;
        private System.Windows.Forms.Label lbKhu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDonVi;
        private System.Windows.Forms.Button btnXoaDV;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.ComboBox cmbTenDV;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label lbTenDV;
        private System.Windows.Forms.ComboBox txtThang;
        private System.Windows.Forms.TextBox txtNamHoc;
        private System.Windows.Forms.DateTimePicker dtNgayHD;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lbNhanVien;
        private System.Windows.Forms.Label lbNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
    }
}
