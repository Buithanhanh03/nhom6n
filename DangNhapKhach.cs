using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_ThucTap_LTNET
{
    public partial class DangNhapKhach : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection connectdb()
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn = new SqlConnection(sqlqr);
            }
            return conn;
        }

        public DangNhapKhach()
        {
            InitializeComponent();
            conn = connectdb();
        }

        private void btnGhetham_Click(object sender, EventArgs e)
        {
            MainOnline f = new MainOnline();
            f.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTK.Text) || string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }

            string username = txtTK.Text;
            string password = txtMK.Text;

            try
            {
                conn = connectdb(); // Ensure the connection is initialized
                string query = "SELECT COUNT(*) FROM taikhoan WHERE username = @username AND password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TempSave.username = username;
                    txtTK.Clear();
                    txtMK.Clear();
                    MainOnline f = new MainOnline();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void cbHien_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHien.Checked)
            {
                txtMK.PasswordChar = '\0';
            }
            else
            {
                txtMK.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKyKhach f = new DangKyKhach();
            f.ShowDialog();
        }

        private void linklblQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhauKhach f = new QuenMatKhauKhach();
            f.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
