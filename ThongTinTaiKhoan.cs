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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_ThucTap_LTNET
{
    public partial class ThongTinTaiKhoan : Form
    {
        private int makh;
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
            conn = connectdb();
        }
        private void LoadForm()
        {
            
            string query = @"
            SELECT 
                taikhoan.username, taikhoan.password, taikhoan.vip, 
                khachhang.makh, khachhang.tenkh, khachhang.sdtkh, khachhang.diachitruong
            FROM taikhoan
            INNER JOIN khachhang ON taikhoan.makh = khachhang.makh
            WHERE taikhoan.username = @username";

            using (conn)
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@username", TempSave.username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUsername.Text = reader["username"].ToString();
                                txtPassword.Text = reader["password"].ToString();
                                txtVip.Text = reader["vip"].ToString();
                                makh = Convert.ToInt32(reader["makh"].ToString());
                                txtTenkh.Text = reader["tenkh"].ToString();
                                txtSdtkh.Text = reader["sdtkh"].ToString();
                                txtDiachitruong.Text = reader["diachitruong"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public bool EmptyTextbox()
        {
            foreach (Control ctrl in guna2GroupBox1.Controls)
            {
                if (ctrl is TextBox && string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    return false;
                }

            }
            return true;
        }
        private bool IsInteger(string input)
        {
            int number;
            if (int.TryParse(input, out number) && number > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (EmptyTextbox() == false)
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if (IsInteger(txtSdtkh.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho số điện thoại");
                return;
            }

            string password = txtPassword.Text;
            string tenkh = txtTenkh.Text;
            string sdtkh = txtSdtkh.Text;
            string diachitruong = txtDiachitruong.Text;

            // Cập nhật bảng taikhoan
            using (SqlConnection conn = new SqlConnection(sqlqr))
            {
                try
                {
                    conn.Open();
                    string sql = "Update taikhoan Set password = @password Where makh = @makh";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@makh", makh);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message);
                }
            }

            // Cập nhật bảng khachhang
            using (SqlConnection conn = new SqlConnection(sqlqr))
            {
                try
                {
                    conn.Open();
                    string sql = "Update khachhang Set tenkh = @tenkh, sdtkh = @sdtkh, diachitruong = @diachitruong Where makh = @makh";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@makh", makh);
                        cmd.Parameters.AddWithValue("@tenkh", tenkh);
                        cmd.Parameters.AddWithValue("@sdtkh", sdtkh);
                        cmd.Parameters.AddWithValue("@diachitruong", diachitruong);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Đã sửa thành công !!!");
                    LoadForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật thông tin khách hàng: " + ex.Message);
                }
            }
        }

    }
}
