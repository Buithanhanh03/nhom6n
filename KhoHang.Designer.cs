namespace BTL_ThucTap_LTNET
{
    partial class KhoHang
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxDanhmuc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNhaphangmoi = new System.Windows.Forms.Button();
            this.btnNhapthem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAnh = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTonkho = new System.Windows.Forms.TextBox();
            this.txtMadm = new System.Windows.Forms.TextBox();
            this.txtMau = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.masp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anh = new System.Windows.Forms.DataGridViewImageColumn();
            this.mau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.madm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tonkho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDanhmuc
            // 
            this.comboBoxDanhmuc.FormattingEnabled = true;
            this.comboBoxDanhmuc.Location = new System.Drawing.Point(146, 26);
            this.comboBoxDanhmuc.Name = "comboBoxDanhmuc";
            this.comboBoxDanhmuc.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDanhmuc.TabIndex = 1;
            this.comboBoxDanhmuc.SelectedIndexChanged += new System.EventHandler(this.comboBoxDanhmuc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DANH MỤC";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.masp,
            this.tensp,
            this.gia,
            this.anh,
            this.mau,
            this.madm,
            this.tonkho});
            this.dataGridView1.Location = new System.Drawing.Point(2, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(796, 236);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnNhaphangmoi
            // 
            this.btnNhaphangmoi.Location = new System.Drawing.Point(190, 374);
            this.btnNhaphangmoi.Name = "btnNhaphangmoi";
            this.btnNhaphangmoi.Size = new System.Drawing.Size(110, 46);
            this.btnNhaphangmoi.TabIndex = 4;
            this.btnNhaphangmoi.Text = "NHẬP HÀNG MỚI";
            this.btnNhaphangmoi.UseVisualStyleBackColor = true;
            this.btnNhaphangmoi.Click += new System.EventHandler(this.btnNhaphangmoi_Click);
            // 
            // btnNhapthem
            // 
            this.btnNhapthem.Location = new System.Drawing.Point(523, 374);
            this.btnNhapthem.Name = "btnNhapthem";
            this.btnNhapthem.Size = new System.Drawing.Size(130, 46);
            this.btnNhapthem.TabIndex = 5;
            this.btnNhapthem.Text = "NHẬP THÊM";
            this.btnNhapthem.UseVisualStyleBackColor = true;
            this.btnNhapthem.Click += new System.EventHandler(this.btnNhapthem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCapnhat);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnAnh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTonkho);
            this.groupBox1.Controls.Add(this.txtMadm);
            this.groupBox1.Controls.Add(this.txtMau);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.txtGia);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Location = new System.Drawing.Point(12, 442);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 164);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(521, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ảnh";
            // 
            // btnAnh
            // 
            this.btnAnh.Location = new System.Drawing.Point(571, 76);
            this.btnAnh.Name = "btnAnh";
            this.btnAnh.Size = new System.Drawing.Size(100, 23);
            this.btnAnh.TabIndex = 6;
            this.btnAnh.Text = "Chọn ảnh";
            this.btnAnh.UseVisualStyleBackColor = true;
            this.btnAnh.Click += new System.EventHandler(this.btnAnh_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(376, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tồn kho";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(175, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mã danh mục";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Màu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(376, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(175, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(521, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Mã sản phẩm";
            // 
            // txtTonkho
            // 
            this.txtTonkho.Location = new System.Drawing.Point(445, 79);
            this.txtTonkho.Name = "txtTonkho";
            this.txtTonkho.Size = new System.Drawing.Size(54, 20);
            this.txtTonkho.TabIndex = 3;
            // 
            // txtMadm
            // 
            this.txtMadm.Location = new System.Drawing.Point(279, 80);
            this.txtMadm.Name = "txtMadm";
            this.txtMadm.Size = new System.Drawing.Size(54, 20);
            this.txtMadm.TabIndex = 3;
            // 
            // txtMau
            // 
            this.txtMau.Location = new System.Drawing.Point(115, 79);
            this.txtMau.Name = "txtMau";
            this.txtMau.Size = new System.Drawing.Size(54, 20);
            this.txtMau.TabIndex = 3;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(445, 37);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(54, 20);
            this.txtSize.TabIndex = 3;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(279, 38);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(54, 20);
            this.txtGia.TabIndex = 3;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(571, 37);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(100, 20);
            this.txtTen.TabIndex = 3;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(115, 41);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(54, 20);
            this.txtMa.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(511, 118);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 46);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.Enabled = false;
            this.btnCapnhat.Location = new System.Drawing.Point(168, 112);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(130, 46);
            this.btnCapnhat.TabIndex = 7;
            this.btnCapnhat.Text = "CẬP NHẬT";
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // masp
            // 
            this.masp.DataPropertyName = "masp";
            this.masp.HeaderText = "Mã";
            this.masp.Name = "masp";
            this.masp.ReadOnly = true;
            this.masp.Width = 50;
            // 
            // tensp
            // 
            this.tensp.DataPropertyName = "tensp";
            this.tensp.HeaderText = "Tên";
            this.tensp.Name = "tensp";
            this.tensp.ReadOnly = true;
            this.tensp.Width = 300;
            // 
            // gia
            // 
            this.gia.DataPropertyName = "gia";
            this.gia.HeaderText = "Giá";
            this.gia.Name = "gia";
            this.gia.ReadOnly = true;
            // 
            // anh
            // 
            this.anh.DataPropertyName = "anh";
            this.anh.HeaderText = "Ảnh";
            this.anh.Name = "anh";
            this.anh.ReadOnly = true;
            this.anh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.anh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // mau
            // 
            this.mau.DataPropertyName = "mau";
            this.mau.HeaderText = "Màu";
            this.mau.Name = "mau";
            this.mau.ReadOnly = true;
            this.mau.Width = 50;
            // 
            // madm
            // 
            this.madm.DataPropertyName = "madm";
            this.madm.HeaderText = "Mã danh mục";
            this.madm.Name = "madm";
            this.madm.ReadOnly = true;
            this.madm.Width = 50;
            // 
            // tonkho
            // 
            this.tonkho.DataPropertyName = "tonkho";
            this.tonkho.HeaderText = "Tồn kho";
            this.tonkho.Name = "tonkho";
            this.tonkho.ReadOnly = true;
            this.tonkho.Width = 50;
            // 
            // KhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNhapthem);
            this.Controls.Add(this.btnNhaphangmoi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDanhmuc);
            this.Name = "KhoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KhoHang";
            this.Load += new System.EventHandler(this.KhoHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxDanhmuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNhaphangmoi;
        private System.Windows.Forms.Button btnNhapthem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAnh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTonkho;
        private System.Windows.Forms.TextBox txtMadm;
        private System.Windows.Forms.TextBox txtMau;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn masp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensp;
        private System.Windows.Forms.DataGridViewTextBoxColumn gia;
        private System.Windows.Forms.DataGridViewImageColumn anh;
        private System.Windows.Forms.DataGridViewTextBoxColumn mau;
        private System.Windows.Forms.DataGridViewTextBoxColumn madm;
        private System.Windows.Forms.DataGridViewTextBoxColumn tonkho;
    }
}