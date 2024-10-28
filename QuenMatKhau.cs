using Guna.UI2.WinForms;
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
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void btnLayLai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTK.Text) || string.IsNullOrEmpty(txtMaXT.Text))
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if (txtTK.Text != "admin")
            {
                MessageBox.Show("Sai tài khoản");
                return;
            }
            if(txtMaXT.Text != "0410")
            {
                MessageBox.Show("Sai mã xác thực");
                return;
            }
            if (txtTK.Text == "admin" && txtMaXT.Text == "0410")
            {
                MessageBox.Show("Mật khẩu của bạn là 'admin'");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Thiết lập màu gradient
            Color color1 = Color.FromArgb(0, 120, 215); // Màu xanh dương
            Color color2 = Color.White;                 // Màu trắng

            // Tạo LinearGradientBrush với kích thước Form và màu gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
