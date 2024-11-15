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
    public partial class LichSuMuaHang : Form
    {
        private SqlConnection conn = null;

        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public LichSuMuaHang()
        {
            InitializeComponent();
            conn = connectdb();
        }
        private void LoadForm()
        {
            conn.Open();

            string sql1 = "SELECT makh FROM taikhoan WHERE username = @username";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            cmd1.Parameters.AddWithValue("@username", "chinh1");

            object result = cmd1.ExecuteScalar();

            if (result != null)
            {
                int makh = Convert.ToInt32(result);

                string sql2 = "SELECT * FROM donhang WHERE makh = @makh";
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@makh", makh);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            conn.Close();
        }

        private void LichSuMuaHang_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                int madh = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["madh"].Value);

                string query = @"
SELECT sp.tensp, ctdh.dongiadh, ctdh.soluongdaban
FROM chitietdonhang ctdh
INNER JOIN sanpham sp ON ctdh.masp = sp.masp
WHERE ctdh.madh = @madh";

                using (SqlConnection conn = connectdb())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@madh", madh);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        panel1.Controls.Clear();

                        int yOffset = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Label lblTensp = new Label
                            {
                                Text = "Tên sản phẩm: " + row["tensp"].ToString(),
                                Location = new Point(10, yOffset),
                                AutoSize = true,
                                Font = new Font("Arial", 10, FontStyle.Bold),
                                ForeColor = Color.Black
                            };
                            panel1.Controls.Add(lblTensp);

                            yOffset += lblTensp.Height + 5;

                            Label lblDongia = new Label
                            {
                                Text = "Đơn giá: " + row["dongiadh"].ToString(),
                                Location = new Point(10, yOffset),
                                AutoSize = true,
                                Font = new Font("Arial", 10),
                                ForeColor = Color.DarkGreen
                            };
                            panel1.Controls.Add(lblDongia);

                            yOffset += lblDongia.Height + 5;

                            Label lblSoluong = new Label
                            {
                                Text = "Số lượng bán: " + row["soluongdaban"].ToString(),
                                Location = new Point(10, yOffset),
                                AutoSize = true,
                                Font = new Font("Arial", 10),
                                ForeColor = Color.DarkBlue
                            };
                            panel1.Controls.Add(lblSoluong);

                            yOffset += lblSoluong.Height + 10;
                        }

                        panel1.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Không có chi tiết cho đơn hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
