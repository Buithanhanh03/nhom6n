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
    public partial class XuLyDonHang : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public XuLyDonHang()
        {
            InitializeComponent();
            conn = connectdb();
        }
        private void LoadForm()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From donhang";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void XuLyDonHang_Load(object sender, EventArgs e)
        {
            LoadForm();
            LoadNhanVien();
            
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string madh = txtTimkiem.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From donhang Where madh LIKE @madh";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@madh", "%" + madh + "%");
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void LoadNhanVien()
        {
            using (conn)
            {
                conn.Open();
                string query = "SELECT manv, tennv FROM nhanvien";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataTable.Columns.Add("DisplayColumn", typeof(string));
                foreach (DataRow row in dataTable.Rows)
                {
                    row["DisplayColumn"] = $"{row["manv"]} - {row["tennv"]}";
                }

                comboBox1.DataSource = dataTable;
                comboBox1.DisplayMember = "DisplayColumn";
                comboBox1.ValueMember = "manv";
            }
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int madh = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["madh"].Value);
                string trangthai = dataGridView1.SelectedRows[0].Cells["trangthai"].Value.ToString();
                MessageBox.Show(trangthai);
                // Chưa fix được lỗi này
                if (trangthai.Equals("Đã giao", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Bạn không thể chỉnh sửa vì đơn hàng đã giao.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    int manv = Convert.ToInt32(comboBox1.SelectedValue);

                    conn = connectdb();
                    try
                    {
                        conn.Open();
                        string query = "UPDATE donhang SET manv = @manv WHERE madh = @madh";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@manv", manv);
                        cmd.Parameters.AddWithValue("@madh", madh);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Chỉnh sửa nhân viên phụ trách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dataGridView1.SelectedRows[0].Cells["manv"].Value = manv;
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để thực hiện chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDatngay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int madh = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["madh"].Value);
                DateTime ngaygiao = dateNgaygiao.Value;

                conn = connectdb();
                try
                {
                    conn.Open();
                    string query = "UPDATE donhang SET ngaygiao = @ngaygiao WHERE madh = @madh";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ngaygiao", ngaygiao);
                    cmd.Parameters.AddWithValue("@madh", madh);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật ngày giao thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridView1.SelectedRows[0].Cells["ngaygiao"].Value = ngaygiao;
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để thực hiện cập nhật ngày giao.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
