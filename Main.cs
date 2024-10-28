using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_ThucTap_LTNET
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            treeView1.BackColor = Color.LightBlue;
            treeView1.ForeColor = Color.White;
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);

            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Font nodeFont;
            if (e.Node.Level == 0)
            {
                nodeFont = new Font(treeView1.Font.FontFamily, 12, FontStyle.Bold); 
            }
            else if (e.Node.Level == 1)
            {
                nodeFont = new Font(treeView1.Font.FontFamily, 10, FontStyle.Regular);
            }
            else if (e.Node.Level == 2)
            {
                nodeFont = new Font(treeView1.Font.FontFamily, 8, FontStyle.Regular);
            }
            else
            {
                nodeFont = treeView1.Font;
            }

            if (e.Node.IsSelected)
            {
                e.Graphics.FillRectangle(Brushes.DarkBlue, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, nodeFont, e.Bounds, Color.White);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Transparent, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, nodeFont, e.Bounds, Color.Black);
            }
        }
       

        private void treeView1_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                if (e.Node.Text == "BÁN HÀNG")
                {
                    BanHang f = new BanHang();
                    f.ShowDialog();
                }
                else if (e.Node.Text == "SẢN PHẨM")
                {
                    SanPham f = new SanPham();
                    f.ShowDialog();
                }
                else if (e.Node.Text == "KHO HÀNG")
                {
                    KhoHang f = new KhoHang();
                    f.ShowDialog();
                }
                else if (e.Node.Text == "NHÂN VIÊN")
                {
                    NhanVien f = new NhanVien();
                    f.ShowDialog();
                }
                else if (e.Node.Text == "KHÁCH HÀNG")
                {
                    KhachHang f = new KhachHang();
                    f.ShowDialog();
                }
                else if (e.Node.Text == "ĐƠN ĐẶT HÀNG")
                {
                    DonDatHang f = new DonDatHang();
                    f.ShowDialog();
                }

            }
            if (e.Node.Level == 2)
            {
                if (e.Node.Text == "BÁO CÁO TỒN KHO")
                {
                    BaoCaoTonKho f = new BaoCaoTonKho();
                    f.ShowDialog();
                }
                else if (e.Node.Text == "BÁO CÁO DOANH THU")
                {
                    BaoCaoDoanhThu f = new BaoCaoDoanhThu();
                    f.ShowDialog();
                }
            }
        }

        private void tHÔNGTINỨNGDỤNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinUngDung f =new ThongTinUngDung();
            f.ShowDialog();
        }

        private void tRỢGIÚPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongDan f =new HuongDan();
            f.ShowDialog();
        }

        private void bẢOTRÌToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoTri f = new BaoTri();
            f.ShowDialog();
        }

        private void tHOÁTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tHOÁTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color color1 = Color.LightPink;
            Color color2 = Color.IndianRed;

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
