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

namespace BTL_ThucTap_LTNET
{
    public partial class DangKyKhach : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public DangKyKhach()
        {
            InitializeComponent();
            conn = connectdb();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTK.Clear();
            txtMK.Clear();
            txtXacnhan.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtDiachi.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool EmptyTextbox()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2TextBox TextBox && string.IsNullOrWhiteSpace(ctrl.Text))
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
        private void btnDangky_Click(object sender, EventArgs e)
        {
            if (EmptyTextbox() == false)
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if(txtMK.Text != txtXacnhan.Text)
            {
                MessageBox.Show("Mật khẩu và xác nhận lại mật khẩu chưa trùng khớp");
                return;
            }
            if (IsInteger(txtSDT.Text) == false)
            {
                MessageBox.Show("Không thể nhập kí tự trong số điện thoại");
                return;
            }
            int makh;
            string username = txtTK.Text;
            string password = txtMK.Text;
            string tenkh = txtTen.Text;
            string sdtkh = txtSDT.Text;
            string diachitruong = txtDiachi.Text;
            using (conn)
            {
                conn.Open();
                string sql1 = "SELECT COUNT(*) FROM taikhoan WHERE username = @username";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@username", username);

                int count = (int)cmd1.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                do
                {
                    makh = new Random().Next(0, 99999);
                    string sql2 = "SELECT COUNT(*) FROM khachhang WHERE makh = @makh";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@makh", makh);
                    int khCount = (int)cmd2.ExecuteScalar();

                    if (khCount == 0) break;
                } while (true);

                string insertKhachHangQuery = "INSERT INTO khachhang (makh, tenkh, sdtkh, diachitruong) VALUES (@makh, @tenkh, @sdtkh, @diachitruong)";
                SqlCommand insertKhachHangCmd = new SqlCommand(insertKhachHangQuery, conn);
                insertKhachHangCmd.Parameters.AddWithValue("@makh", makh);
                insertKhachHangCmd.Parameters.AddWithValue("@tenkh", tenkh);
                insertKhachHangCmd.Parameters.AddWithValue("@sdtkh", sdtkh);
                insertKhachHangCmd.Parameters.AddWithValue("@diachitruong", diachitruong);
                insertKhachHangCmd.ExecuteNonQuery();

                string insertTaiKhoanQuery = "INSERT INTO taikhoan (username, password, makh) VALUES (@username, @password, @makh)";
                SqlCommand insertTaiKhoanCmd = new SqlCommand(insertTaiKhoanQuery, conn);
                insertTaiKhoanCmd.Parameters.AddWithValue("@username", username);
                insertTaiKhoanCmd.Parameters.AddWithValue("@password", password);
                insertTaiKhoanCmd.Parameters.AddWithValue("@makh", makh);
                insertTaiKhoanCmd.ExecuteNonQuery();

                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }
    }
}
