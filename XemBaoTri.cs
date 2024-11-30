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
    public partial class XemBaoTri : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public XemBaoTri()
        {
            InitializeComponent();
            conn = connectdb();
        }
        private void LoadForm()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From baotri";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void XemBaoTri_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string mabt = txtTimkiem.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From baotri Where mabt LIKE @mabt";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@mabt", "%" + mabt + "%");

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string mabt = dataGridView1.SelectedRows[0].Cells["mabt"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phản hồi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (conn = connectdb())
                    {
                        conn.Open();
                        string sql = "Delete From baotri Where mabt = @mabt";
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@mabt", mabt);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa thành công");
                        conn.Close();
                        LoadForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phản hồi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
