using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace BTL_ThucTap_LTNET
{
    public partial class BaoCaoDoanhThu : Form
    {
        public BaoCaoDoanhThu()
        {
            InitializeComponent();
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }
        private SqlConnection conn = null;
        private PrintDocument printDocument;
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
                        ddh.gianhap AS gianhap,
                        ddh.soluongnhap AS soluongnhap,
                        sp.gia AS gia,
                        sp.tonkho AS tonkho,
                        (ddh.gianhap * ddh.soluongnhap) AS tienton
                    FROM 
                        sanpham sp
                    LEFT JOIN 
                        dondathang ddh ON sp.masp = ddh.masp";

            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }

            //Hiển thị các label trong ô vuông:
            int tongNhap = 0;
            int tongTonkho = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["gianhap"].Value != null && row.Cells["soluongnhap"].Value != null)
                {
                    int giaNhap = Convert.ToInt32(row.Cells["gianhap"].Value);
                    int soLuongNhap = Convert.ToInt32(row.Cells["soluongnhap"].Value);
                    tongNhap += giaNhap * soLuongNhap;
                }

                if (row.Cells["TonKho"].Value != null)
                {
                    tongTonkho += Convert.ToInt32(row.Cells["tonkho"].Value);
                }
            }
            string query1 = "SELECT SUM(tongtien) FROM donhang";
            conn = connectdb();
            using (conn)
            using (SqlCommand command = new SqlCommand(query1, conn))
            {
                conn.Open();
                object result = command.ExecuteScalar();

                int tongtienban = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                lblTongban.Text = tongtienban.ToString();
            }

            lblTongnhap.Text = tongNhap.ToString();
        }
        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument;
            previewDialog.ShowDialog();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color color1 = Color.MediumAquamarine;
            Color color2 = Color.WhiteSmoke;

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
