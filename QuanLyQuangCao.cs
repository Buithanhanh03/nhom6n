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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_ThucTap_LTNET
{
    public partial class QuanLyQuangCao : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public QuanLyQuangCao()
        {
            InitializeComponent();
            conn = connectdb();
        }

        private void QuanLyQuangCao_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void LoadForm()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From quangcao";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
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
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnCapnhat.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenQC_TextChanged(object sender, EventArgs e)
        {
            string tenqc = txtTimkiem.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From quangcao Where tenqc LIKE @tenqc";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@tenqc", "%" + tenqc + "%");

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenQC.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên QC");
                return;
            }
            if (string.IsNullOrEmpty(txtMotaQC.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mô tả cho QC");
                return;
            }
            if (dateKT.Value <= dateBD.Value)
            {
                MessageBox.Show("Bạn phải chọn ngày kết thúc sau ngày bắt đầu");
                return;
            }
            string tenqc = txtTenQC.Text;
            string motaqc = txtMotaQC.Text;
            DateTime ngaybatdau = dateBD.Value;
            DateTime ngayketthuc = dateKT.Value;
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO quangcao(tenqc, motaqc, ngaybatdau, ngayketthuc) VALUES(@tenqc, @motaqc, @ngaybatdau, @ngayketthuc)";
                cmd.Parameters.AddWithValue("@tenqc", tenqc);
                cmd.Parameters.AddWithValue("@motaqc", motaqc);
                cmd.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                cmd.Parameters.AddWithValue("@ngayketthuc", ngayketthuc);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm quảng cáo thành công");
                conn.Close();
            }
            LoadForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnThem.Enabled = false;
                btnCapnhat.Enabled = true;
                btnXoa.Enabled = false;
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                TempSave.maqc = Convert.ToInt32(selectedRow.Cells["maqc"].Value);
                txtTenQC.Text = selectedRow.Cells["tenqc"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenQC.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên QC");
                return;
            }
            if (string.IsNullOrEmpty(txtMotaQC.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mô tả cho QC");
                return;
            }
            if (dateKT.Value <= dateBD.Value)
            {
                MessageBox.Show("Bạn phải chọn ngày kết thúc sau ngày bắt đầu");
                return;
            }
            string tenqc = txtTenQC.Text;
            string motaqc = txtMotaQC.Text;
            DateTime ngaybatdau = dateBD.Value;
            DateTime ngayketthuc = dateKT.Value;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            using (conn)
            {
                conn.Open();
                string sql = "Update quangcao Set tenqc = @tenqc, motaqc = @motaqc, ngaybatdau = @ngaybatdau, ngayketthuc = @ngayketthuc Where maqc =@maqc";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@maqc", TempSave.maqc);
                cmd.Parameters.AddWithValue("@tenqc", tenqc);
                cmd.Parameters.AddWithValue("@motaqc", motaqc);
                cmd.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                cmd.Parameters.AddWithValue("@ngayketthuc", ngayketthuc);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã sửa thành công");
                conn.Close();
                LoadForm();
                btnThem.Enabled = true;
                btnCapnhat.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maqc = dataGridView1.SelectedRows[0].Cells["maqc"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa quảng cáo này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (conn = connectdb())
                    {
                        conn.Open();
                        string sql = "Delete From quangcao Where maqc = @maqc";
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@maqc", maqc);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa thành công");
                        conn.Close();
                        LoadForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một quảng cáo để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string tenqc = txtTimkiem.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From nhanvien Where tenqc LIKE @tenqc";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@tenqc", "%" + tenqc + "%");

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
