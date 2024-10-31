using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_ThucTap_LTNET
{
    public partial class InHoaDon : Form
    {
        private PrintDocument printDocument;

        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        public InHoaDon()
        {
            InitializeComponent();
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        private void LoadForm()
        {
            string query = "SELECT * FROM donhang WHERE madh = @madh";
            using (SqlConnection conn = new SqlConnection(sqlqr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@madh", TempSave.MaDonHang);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblMadon.Text = row["madh"].ToString();
                    lblManv.Text = row["manv"].ToString();
                    lblNgaydat.Text = row["ngaydat"].ToString();
                    lblTongtien.Text = row["tongtien"].ToString();
                    lblMakh.Text = row["makh"].ToString();
                }
            }
            string query1 = "SELECT * FROM chitietdonhang WHERE madh = @madh";
            using (SqlConnection conn = new SqlConnection(sqlqr))
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@madh", TempSave.MaDonHang);

                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblSoluong.Text = row["soluongdaban"].ToString();
                }
            }
            string query2 = "SELECT * FROM khachhang WHERE makh = @makh";
            using (SqlConnection conn = new SqlConnection(sqlqr))
            {
                conn.Open();
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@makh", int.Parse(lblMakh.Text.ToString()));

                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblHoten.Text = row["tenkh"].ToString();
                    lblSDT.Text = row["sdtkh"].ToString();
                    lblDiachi.Text = row["diachitruong"].ToString();
                }
            }
        }
        private void InHoaDon_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument;
            previewDialog.ShowDialog();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle printArea = new Rectangle(0, 0, this.Width, this.Height - btnThoat.Height - 10); // Adjust as needed

            // Capture the bitmap of the desired print area
            Bitmap bmp = new Bitmap(printArea.Width, printArea.Height);
            this.DrawToBitmap(bmp, printArea);

            // Draw the bitmap on the PrintPage event graphics
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
