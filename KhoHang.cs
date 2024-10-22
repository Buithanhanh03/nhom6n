using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_ThucTap_LTNET
{
    public partial class KhoHang : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public KhoHang()
        {
            InitializeComponent();
        }
        private void LoadSanPham()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select masp, tensp, gia, mau, madm, tonkho From sanpham";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void LoadForm()
        {
            string query = "SELECT tendm FROM danhmuc";

            using (SqlConnection conn = new SqlConnection(sqlqr))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Giả sử cột cần lấy là cột kiểu string
                    comboBoxDanhmuc.Items.Add(reader["tendm"].ToString());
                }

                reader.Close();
            }
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ctrl.Enabled = true;
                }
            }

        }
        private void KhoHang_Load(object sender, EventArgs e)
        {
            LoadForm();
            LoadSanPham();
        }

        private void comboBoxDanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int madmCantim = -1;
            string tendmCantim = comboBoxDanhmuc.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(tendmCantim))
            {
                conn = connectdb();
                string query = "SELECT madm FROM danhmuc WHERE tendm = @tendm";
                using (conn)
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@tendm", tendmCantim);

                    conn.Open();
                    object result = command.ExecuteScalar();
                    conn.Close();

                    if (result != null)
                    {
                        madmCantim = Convert.ToInt32(result);
                    }
                }
            }

            if (madmCantim != -1)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"madm = {madmCantim}";
            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in groupBox1.Controls)
            {
                if(ctrl is System.Windows.Forms.TextBox && ctrl != txtTonkho)
                {
                    ctrl.Enabled = false;
                }
            }
            btnAnh.Enabled= false;
        }

        private void btnNhapthem_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ctrl.Enabled = true;
                }
            }
            btnAnh.Enabled = true;
        }
    }
}
