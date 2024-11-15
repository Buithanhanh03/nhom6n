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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_ThucTap_LTNET
{
    public partial class QuenMatKhauKhach : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public QuenMatKhauKhach()
        {
            InitializeComponent();
            conn = connectdb();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLaylai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTK.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            string username = txtTK.Text;
            string sdtkh = txtSDT.Text;
            using (conn)
            {
                conn.Open();
                string query = @"
                SELECT tk.password
                FROM taikhoan tk
                INNER JOIN khachhang kh ON tk.makh = kh.makh
                WHERE tk.username = @username AND kh.sdtkh = @sdtkh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@sdtkh", sdtkh);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string password = result.ToString();
                        MessageBox.Show($"Mật khẩu của bạn là: {password}", "Password Retrieved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản và số điện thoại không tồn tại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
