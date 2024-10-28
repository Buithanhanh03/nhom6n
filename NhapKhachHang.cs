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
    public partial class NhapKhachHang : Form
    {
        public NhapKhachHang()
        {
            InitializeComponent();
        }
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public bool EmptyTextbox()
        {
            foreach (Control ctrl in groupBox1.Controls)
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
        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (EmptyTextbox() == false)
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if (IsInteger(txtMaKH.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho mã khách hàng");
                return;
            }
            if (IsInteger(txtSDTKH.Text) == false)
            {
                MessageBox.Show("Không thể nhập kí tự trong số điện thoại");
                return;
            }
            int makh = int.Parse(txtMaKH.Text);
            string tenkh = txtTenKH.Text;
            string sdtkh = txtSDTKH.Text;
            string diachitruong = txtDiachitruong.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            using (SqlConnection conn = connectdb())
            {
                SqlCommand command = new SqlCommand("SELECT COUNT (*) FROM khachhang WHERE makh = @makh", conn);

                command.Parameters.AddWithValue("@makh", makh);
                conn.Open();
                int rs = (int)command.ExecuteScalar();
                if (rs > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại!");
                    return;
                }
                else
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO khachhang(makh, tenkh, sdtkh, diachitruong) VALUES(@makh, @tenkh, @sdtkh, @diachitruong)";
                    cmd.Parameters.AddWithValue("@makh", makh);
                    cmd.Parameters.AddWithValue("@tenkh", tenkh);
                    cmd.Parameters.AddWithValue("@sdtkh", sdtkh);
                    cmd.Parameters.AddWithValue("@diachitruong", diachitruong);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "Update donhang Set makh=@makh Where makh IS NULL";
                    cmd1.Parameters.AddWithValue("@makh", makh);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm thông tin khách hàng thành công, bạn sẽ được chuyển tới trang in hóa đơn");
                }
                conn.Close();
                InHoaDon f =new InHoaDon();
                f.ShowDialog();
                this.Close();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox TextBox)
                {
                    control.Text = string.Empty;
                }
            }
        }
    }
}
