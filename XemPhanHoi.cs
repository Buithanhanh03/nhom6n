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
    public partial class XemPhanHoi : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public XemPhanHoi()
        {
            InitializeComponent();
            conn = connectdb();
        }

        private void XemPhanHoi_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void LoadForm()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From lienhe";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
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
                string malh = dataGridView1.SelectedRows[0].Cells["malh"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ý kiến này? (Bạn thật hèn)", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (conn = connectdb())
                    {
                        conn.Open();
                        string sql = "Delete From lienhe Where malh = @malh";
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@malh", malh);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa thành công");
                        conn.Close();
                        LoadForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ý kiến để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
