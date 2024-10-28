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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTK.Text) || string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if(txtTK.Text != "admin")
            {
                MessageBox.Show("Sai tài khoản");
                return;
            }
            if (txtMK.Text != "admin")
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }
            if(txtTK.Text == "admin" && txtMK.Text == "admin")
            {
                MessageBox.Show("Đăng nhập thành công");
                Main m = new Main();
                m.ShowDialog();
                this.Close();
            }
        }

        private void cbHien_CheckedChanged(object sender, EventArgs e)
        {
            if(cbHien.Checked)
            {
                txtMK.PasswordChar = '\0';
            }
            else
            {
                txtMK.PasswordChar = '*';
            }

        }

        private void linklblQuenMK_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau f = new QuenMatKhau();
            f.ShowDialog();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color color1 = Color.BlueViolet;
            Color color2 = Color.WhiteSmoke;

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
