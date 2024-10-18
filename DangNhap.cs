using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void linklblQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau f = new QuenMatKhau();
            f.ShowDialog();
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

    }
}
