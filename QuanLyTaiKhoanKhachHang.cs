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
    public partial class QuanLyTaiKhoanKhachHang : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public QuanLyTaiKhoanKhachHang()
        {
            InitializeComponent();
            conn = connectdb();
        }

        private void QuanLyTaiKhoanKhachHang_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void LoadForm()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From taikhoan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSuaVIP_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnCapnhat.Enabled = true;
                btnXoa.Enabled = false;
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string username = selectedRow.Cells["username"].Value.ToString();
                txtUsername.Text = username;
                txtPassword.Text = selectedRow.Cells["password"].Value.ToString();
                txtVIP.Text = selectedRow.Cells["vip"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                return;
            }
            if (string.IsNullOrEmpty(txtVIP.Text))
            {
                MessageBox.Show("Bạn chưa nhập cấp VIP");
                return;
            }
            string username  = txtUsername.Text;
            string password = txtPassword.Text;
            int vip = int.Parse(txtVIP.Text);
            using (conn)
            {
                conn.Open();
                string sql = "Update taikhoan Set password = @password, vip = @vip Where username =@username";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@vip", vip);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã sửa thành công");
                conn.Close();
                LoadForm();
                btnCapnhat.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox)
                {
                    control.Text = string.Empty;
                }
            }
            btnSuaVIP.Enabled = true;
            btnCapnhat.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string username = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này? Mặc kệ tài khoản VIP 666", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (conn = connectdb())
                    {
                        conn.Open();
                        string sql = "Delete From taikhoan Where username = @username";
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa thành công");
                        conn.Close();
                        LoadForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string username = txtTimkiem.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From nhanvien Where username LIKE @username";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@username", "%" + username + "%");

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
