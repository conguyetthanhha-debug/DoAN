namespace textktx.CACFORM
{
    partial class FromNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.pnTop = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.txtMaNQL = new System.Windows.Forms.TextBox();
            this.lbMaNQL = new System.Windows.Forms.Label();
            this.lbCMND = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbLuong = new System.Windows.Forms.Label();
            this.lbDiaChi = new System.Windows.Forms.Label();
            this.lbSDT = new System.Windows.Forms.Label();
            this.lbHoTen = new System.Windows.Forms.Label();
            this.lbMaNV = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.pnTop.SuspendLayout();
            this.pnContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lbTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.MinimumSize = new System.Drawing.Size(839, 65);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(849, 65);
            this.pnTop.TabIndex = 32;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Goldenrod;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Black", 30F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.MinimumSize = new System.Drawing.Size(845, 65);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(849, 65);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "THÔNG TIN NHÂN VIÊN";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnContainer
            // 
            this.pnContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnContainer.Controls.Add(this.txtMaNV);
            this.pnContainer.Controls.Add(this.txtCMND);
            this.pnContainer.Controls.Add(this.txtHoTen);
            this.pnContainer.Controls.Add(this.txtSDT);
            this.pnContainer.Controls.Add(this.txtEmail);
            this.pnContainer.Controls.Add(this.txtDiaChi);
            this.pnContainer.Controls.Add(this.txtLuong);
            this.pnContainer.Controls.Add(this.txtMaNQL);
            this.pnContainer.Controls.Add(this.lbMaNQL);
            this.pnContainer.Controls.Add(this.lbCMND);
            this.pnContainer.Controls.Add(this.lbEmail);
            this.pnContainer.Controls.Add(this.lbLuong);
            this.pnContainer.Controls.Add(this.lbDiaChi);
            this.pnContainer.Controls.Add(this.lbSDT);
            this.pnContainer.Controls.Add(this.lbHoTen);
            this.pnContainer.Controls.Add(this.lbMaNV);
            this.pnContainer.Location = new System.Drawing.Point(0, 68);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(680, 210);
            this.pnContainer.TabIndex = 33;
            // 
            // Các textbox
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaNV.Location = new System.Drawing.Point(112, 35);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(198, 25);
            this.txtCMND.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCMND.Location = new System.Drawing.Point(114, 171);
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtHoTen.Location = new System.Drawing.Point(112, 123);
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSDT.Location = new System.Drawing.Point(434, 35);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEmail.Location = new System.Drawing.Point(434, 79);
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDiaChi.Location = new System.Drawing.Point(434, 128);
            this.txtLuong.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtLuong.Location = new System.Drawing.Point(436, 175);
            this.txtMaNQL.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaNQL.Location = new System.Drawing.Point(112, 79);
            this.txtMaNQL.ReadOnly = true;
            // 
            // Labels
            // 
            this.lbMaNQL.AutoSize = true;
            this.lbMaNQL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbMaNQL.Location = new System.Drawing.Point(50, 79);
            this.lbMaNQL.Text = "Mã NQL";
            this.lbCMND.AutoSize = true;
            this.lbCMND.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbCMND.Location = new System.Drawing.Point(52, 174);
            this.lbCMND.Text = "CMND";
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbEmail.Location = new System.Drawing.Point(385, 79);
            this.lbEmail.Text = "Email";
            this.lbLuong.AutoSize = true;
            this.lbLuong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbLuong.Location = new System.Drawing.Point(387, 175);
            this.lbLuong.Text = "Lương";
            this.lbDiaChi.AutoSize = true;
            this.lbDiaChi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbDiaChi.Location = new System.Drawing.Point(385, 128);
            this.lbDiaChi.Text = "Địa chỉ";
            this.lbSDT.AutoSize = true;
            this.lbSDT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbSDT.Location = new System.Drawing.Point(385, 35);
            this.lbSDT.Text = "SĐT";
            this.lbHoTen.AutoSize = true;
            this.lbHoTen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbHoTen.Location = new System.Drawing.Point(50, 127);
            this.lbHoTen.Text = "Họ tên";
            this.lbMaNV.AutoSize = true;
            this.lbMaNV.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbMaNV.Location = new System.Drawing.Point(50, 35);
            this.lbMaNV.Text = "Mã NV";
            // 
            // Buttons
            // 
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.DarkRed;
            this.btnLuu.Location = new System.Drawing.Point(388, 284);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(93, 30);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;

            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSua.Location = new System.Drawing.Point(222, 284);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(93, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 329);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.pnContainer);
            this.Controls.Add(this.pnTop);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.pnTop.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.pnContainer.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.TextBox txtMaNQL;
        private System.Windows.Forms.Label lbMaNQL;
        private System.Windows.Forms.Label lbCMND;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbLuong;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.Label lbSDT;
        private System.Windows.Forms.Label lbHoTen;
        private System.Windows.Forms.Label lbMaNV;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
    }
}
