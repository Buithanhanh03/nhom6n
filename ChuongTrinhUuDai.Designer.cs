namespace BTL_ThucTap_LTNET
{
    partial class ChuongTrinhUuDai
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
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2HtmlLabelSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnThoat = new Guna.UI2.WinForms.Guna2TileButton();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::BTL_ThucTap_LTNET.Properties.Resources.logo;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(237, 21);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(44, 46);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 6;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(278, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "UNIWEAR";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(645, 240);
            this.guna2GroupBox1.TabIndex = 4;
            // 
            // guna2HtmlLabelSubtitle
            // 
            this.guna2HtmlLabelSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabelSubtitle.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabelSubtitle.ForeColor = System.Drawing.Color.Chocolate;
            this.guna2HtmlLabelSubtitle.Location = new System.Drawing.Point(108, 73);
            this.guna2HtmlLabelSubtitle.Name = "guna2HtmlLabelSubtitle";
            this.guna2HtmlLabelSubtitle.Size = new System.Drawing.Size(453, 28);
            this.guna2HtmlLabelSubtitle.TabIndex = 1;
            this.guna2HtmlLabelSubtitle.Text = "CỬA HÀNG ĐỒNG PHỤC VIP NHẤT VIỆT NAM";
            // 
            // btnThoat
            // 
            this.btnThoat.Animated = true;
            this.btnThoat.BorderRadius = 10;
            this.btnThoat.BorderThickness = 1;
            this.btnThoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThoat.FillColor = System.Drawing.Color.DimGray;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(240, 258);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(179, 37);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // ChuongTrinhUuDai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 306);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChuongTrinhUuDai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChuongTrinhUuDai";
            this.Load += new System.EventHandler(this.ChuongTrinhUuDai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabelSubtitle;
        private Guna.UI2.WinForms.Guna2TileButton btnThoat;
    }
}