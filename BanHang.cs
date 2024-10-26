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
    public partial class BanHang : Form
    {
        Panel panelDetail = new Panel();
        Label lblInfo = new Label();
        public BanHang()
        {
            InitializeComponent();
            panelDetail.Size = new Size(200, 30);
            panelDetail.BorderStyle = BorderStyle.Fixed3D;
            panelDetail.BackColor = Color.LightGray;
            panelDetail.Visible = false;
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            panelDetail.Controls.Add(lblInfo);
            this.Controls.Add(panelDetail);
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            this.Click += BanHang_Click;
        }
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        private void LoadForm()
        {
            dataGridView1.Rows.Clear();
            conn = connectdb();
            string query = @"SELECT 
                        sp.masp AS masp,
                        sp.tensp AS tensp,
                        ctdh.soluongdaban AS soluongdaban,
                        sp.gia AS gia,
                        sp.anh AS anh,
                        sp.size AS size,
                        sp.mau AS mau,
                        sp.madm AS madm,
                        sp.tonkho AS tonkho
                    FROM 
                        sanpham sp
                    LEFT JOIN 
                        chitietdonhang ctdh ON sp.masp = ctdh.masp";

            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        private void BanHang_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                string info = "";
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.HeaderText == "Tên" || cell.OwningColumn.HeaderText == "Đã bán")
                    {
                        info += cell.OwningColumn.HeaderText + ": " + cell.Value.ToString() + "\n";
                    }
                }

                lblInfo.Text = info;

                // Get the position of the DataGridView on the form
                Point dataGridViewLocation = dataGridView1.Location;

                // Calculate the y position for the panel
                int rowHeight = dataGridView1.RowTemplate.Height; // Get the height of a row
                int panelY = dataGridViewLocation.Y + row.Index * rowHeight;

                // Set the panel's location
                panelDetail.Location = new Point(dataGridViewLocation.X, panelY);
                panelDetail.BringToFront();
                panelDetail.Visible = true; // Make the panel visible
            }
        }

        private void BanHang_Click(object sender, EventArgs e)
        {
            if (panelDetail.Visible)
            {
                panelDetail.Visible = false;
                lblInfo.Text = ""; // Xóa thông tin trong label
            }
        }
    }
}
