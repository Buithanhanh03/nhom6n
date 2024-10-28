namespace BTL_ThucTap_LTNET
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("BÁN HÀNG");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("SẢN PHẨM");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("KHO HÀNG");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("BÁO CÁO TỒN KHO", -2, -2);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("BÁO CÁO DOANH THU", -2, -2);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("BÁO CÁO", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("NHÂN VIÊN");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("KHÁCH HÀNG");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("ĐƠN ĐẶT HÀNG");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("DANH MỤC", -2, -2, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageListMainIcon = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tHÔNGTINỨNGDỤNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRỢGIÚPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bẢOTRÌToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tHOÁTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tHOÁTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageListMainIcon;
            this.treeView1.Location = new System.Drawing.Point(-1, 92);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "shopping-cart.png";
            treeNode1.Name = "Node1";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.SelectedImageKey = "shopping-cart.png";
            treeNode1.Text = "BÁN HÀNG";
            treeNode2.ImageKey = "SanPham.png";
            treeNode2.Name = "Node2";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.SelectedImageKey = "SanPham.png";
            treeNode2.Text = "SẢN PHẨM";
            treeNode3.ImageKey = "KhoHang.png";
            treeNode3.Name = "Node3";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode3.SelectedImageKey = "KhoHang.png";
            treeNode3.Text = "KHO HÀNG";
            treeNode4.ImageIndex = -2;
            treeNode4.Name = "Node7";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode4.SelectedImageIndex = -2;
            treeNode4.Text = "BÁO CÁO TỒN KHO";
            treeNode5.ImageIndex = -2;
            treeNode5.Name = "Node8";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.SelectedImageIndex = -2;
            treeNode5.Text = "BÁO CÁO DOANH THU";
            treeNode6.Name = "Node4";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.Text = "BÁO CÁO";
            treeNode7.ImageKey = "NhanVien.png";
            treeNode7.Name = "Node6";
            treeNode7.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode7.SelectedImageKey = "NhanVien.png";
            treeNode7.Text = "NHÂN VIÊN";
            treeNode8.Name = "Node1";
            treeNode8.Text = "KHÁCH HÀNG";
            treeNode9.Name = "Node2";
            treeNode9.Text = "ĐƠN ĐẶT HÀNG";
            treeNode10.ImageIndex = -2;
            treeNode10.Name = "Node0";
            treeNode10.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode10.SelectedImageIndex = -2;
            treeNode10.Text = "DANH MỤC";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(264, 357);
            this.treeView1.TabIndex = 1;
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick_1);
            // 
            // imageListMainIcon
            // 
            this.imageListMainIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMainIcon.ImageStream")));
            this.imageListMainIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMainIcon.Images.SetKeyName(0, "BaoCao.png");
            this.imageListMainIcon.Images.SetKeyName(1, "KhoHang.png");
            this.imageListMainIcon.Images.SetKeyName(2, "NhanVien.png");
            this.imageListMainIcon.Images.SetKeyName(3, "SanPham.png");
            this.imageListMainIcon.Images.SetKeyName(4, "shopping-cart.png");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Sienna;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(288, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 39);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SẢN PHẨM";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tHÔNGTINỨNGDỤNGToolStripMenuItem,
            this.tRỢGIÚPToolStripMenuItem,
            this.bẢOTRÌToolStripMenuItem,
            this.tHOÁTToolStripMenuItem,
            this.tHOÁTToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(1, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(672, 29);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tHÔNGTINỨNGDỤNGToolStripMenuItem
            // 
            this.tHÔNGTINỨNGDỤNGToolStripMenuItem.Image = global::BTL_ThucTap_LTNET.Properties.Resources.shirt;
            this.tHÔNGTINỨNGDỤNGToolStripMenuItem.Name = "tHÔNGTINỨNGDỤNGToolStripMenuItem";
            this.tHÔNGTINỨNGDỤNGToolStripMenuItem.Size = new System.Drawing.Size(212, 25);
            this.tHÔNGTINỨNGDỤNGToolStripMenuItem.Text = "THÔNG TIN ỨNG DỤNG";
            this.tHÔNGTINỨNGDỤNGToolStripMenuItem.Click += new System.EventHandler(this.tHÔNGTINỨNGDỤNGToolStripMenuItem_Click);
            // 
            // tRỢGIÚPToolStripMenuItem
            // 
            this.tRỢGIÚPToolStripMenuItem.Image = global::BTL_ThucTap_LTNET.Properties.Resources.question_mark;
            this.tRỢGIÚPToolStripMenuItem.Name = "tRỢGIÚPToolStripMenuItem";
            this.tRỢGIÚPToolStripMenuItem.Size = new System.Drawing.Size(135, 25);
            this.tRỢGIÚPToolStripMenuItem.Text = "HƯỚNG DẪN";
            this.tRỢGIÚPToolStripMenuItem.Click += new System.EventHandler(this.tRỢGIÚPToolStripMenuItem_Click);
            // 
            // bẢOTRÌToolStripMenuItem
            // 
            this.bẢOTRÌToolStripMenuItem.Image = global::BTL_ThucTap_LTNET.Properties.Resources.wrench;
            this.bẢOTRÌToolStripMenuItem.Name = "bẢOTRÌToolStripMenuItem";
            this.bẢOTRÌToolStripMenuItem.Size = new System.Drawing.Size(99, 25);
            this.bẢOTRÌToolStripMenuItem.Text = "BẢO TRÌ";
            this.bẢOTRÌToolStripMenuItem.Click += new System.EventHandler(this.bẢOTRÌToolStripMenuItem_Click);
            // 
            // tHOÁTToolStripMenuItem
            // 
            this.tHOÁTToolStripMenuItem.Image = global::BTL_ThucTap_LTNET.Properties.Resources.user;
            this.tHOÁTToolStripMenuItem.Name = "tHOÁTToolStripMenuItem";
            this.tHOÁTToolStripMenuItem.Size = new System.Drawing.Size(128, 25);
            this.tHOÁTToolStripMenuItem.Text = "ĐĂNG XUẤT";
            this.tHOÁTToolStripMenuItem.Click += new System.EventHandler(this.tHOÁTToolStripMenuItem_Click);
            // 
            // tHOÁTToolStripMenuItem1
            // 
            this.tHOÁTToolStripMenuItem1.Image = global::BTL_ThucTap_LTNET.Properties.Resources.person;
            this.tHOÁTToolStripMenuItem1.Name = "tHOÁTToolStripMenuItem1";
            this.tHOÁTToolStripMenuItem1.Size = new System.Drawing.Size(90, 25);
            this.tHOÁTToolStripMenuItem1.Text = "THOÁT";
            this.tHOÁTToolStripMenuItem1.Click += new System.EventHandler(this.tHOÁTToolStripMenuItem1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Chocolate;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(1, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 39);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(19, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "CHỨC NĂNG";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(288, 92);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(383, 357);
            this.guna2PictureBox1.TabIndex = 12;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 456);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageListMainIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tHÔNGTINỨNGDỤNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tRỢGIÚPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bẢOTRÌToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHOÁTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHOÁTToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}