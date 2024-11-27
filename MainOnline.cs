using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_ThucTap_LTNET
{
    public partial class MainOnline : Form
    {
        public MainOnline()
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
        private void VeChungToiMenu_Click(object sender, EventArgs e)
        {
            GioiThieuCuaHang f = new GioiThieuCuaHang();
            f.ShowDialog();
        }

        private void ThoatMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadProducts()
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.Padding = new Padding(10);

            using (conn = connectdb())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT masp, tensp, gia, anh, tonkho, rating FROM sanpham", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Lấy ID sản phẩm để đánh giá
                    int productId = Convert.ToInt32(reader["masp"]);

                    var panel = new Guna2Panel
                    {
                        Size = new Size(180, 290),
                        BorderColor = Color.LightGray,
                        BorderThickness = 2,
                        BorderRadius = 15,
                        BackColor = Color.White,
                    };

                    var labelTensanpham = new Guna2HtmlLabel
                    {
                        Text = reader["tensp"].ToString(),
                        Location = new Point(10, 10),
                        AutoSize = false,
                        Width = panel.Width - 20,
                        TextAlignment = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = Color.MidnightBlue,
                        BackColor = Color.Transparent
                    };

                    var labelGiasanpham = new Guna2HtmlLabel
                    {
                        Text = "Giá: " + string.Format("{0:N0}", reader["gia"]) + " VND",
                        Location = new Point(10, 155),
                        AutoSize = false,
                        Width = panel.Width - 20,
                        Height = 30,
                        TextAlignment = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        ForeColor = Color.White,
                        BackColor = Color.OrangeRed,
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new Padding(5)
                    };

                    var labelTonkho = new Guna2HtmlLabel
                    {
                        Text = "Tồn kho: " + reader["tonkho"].ToString(),
                        Location = new Point(10, 190),
                        AutoSize = false,
                        Width = panel.Width - 20,
                        Height = 30,
                        TextAlignment = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        ForeColor = Color.DarkSlateGray,
                        BackColor = Color.LightGoldenrodYellow,
                        Padding = new Padding(5)
                    };

                    var pictureBoxHinhanh = new Guna2PictureBox
                    {
                        Size = new Size(140, 100),
                        Location = new Point(20, 40),
                        ImageLocation = reader["anh"].ToString(),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderRadius = 8,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Tạo ra ngôi sao để click
                    var ratingStar = new Guna2RatingStar
                    {
                        Location = new Point(10, 230),
                        Width = panel.Width - 20,
                        Value = Convert.ToInt32(reader["rating"]),
                        RatingColor = Color.Gold,
                        BackColor = Color.Transparent,
                        BorderThickness = 5
                    };

                    // sự kiện ấn sao
                    ratingStar.ValueChanged += (sender, e) => UpdateRating(productId, (int)ratingStar.Value);

                    panel.Controls.Add(labelTensanpham);
                    panel.Controls.Add(pictureBoxHinhanh);
                    panel.Controls.Add(labelGiasanpham);
                    panel.Controls.Add(labelTonkho);
                    panel.Controls.Add(ratingStar);

                    flowLayoutPanel1.Controls.Add(panel);
                }

                reader.Close();
            }
        }

        // Cập nhật rating trong sanpham
        private void UpdateRating(int productId, int newRating)
        {
                using (conn = connectdb())
                {
                    conn.Open();
                    SqlCommand updateCmd = new SqlCommand("UPDATE sanpham SET rating = @rating WHERE masp = @masp", conn);
                    updateCmd.Parameters.AddWithValue("@rating", newRating);
                    updateCmd.Parameters.AddWithValue("@masp", productId);
                    updateCmd.ExecuteNonQuery();
                }


        }


        private void MainOnline_Load(object sender, EventArgs e)
        {
            // Câp nhật lại khả năng truy cập vào các chức năng khi người dùng đã đăng nhập
            if (TempSave.username != null)
            {
                DangNhapMenu.Text = "ĐĂNG XUẤT";
                btnDathang.Enabled = true;
                btnLichsumuahang.Enabled = true;
                btnUudai.Enabled = true;
            }
            LoadProducts();
        }

        private void DangNhap_Click(object sender, EventArgs e)
        {
            if(DangNhapMenu.Text == "ĐĂNG NHẬP")
            {
                DangNhapKhach f = new DangNhapKhach();
                f.ShowDialog();
            }
            if (DangNhapMenu.Text == "ĐĂNG XUẤT")
            {
                TempSave.username = null;
                this.Close();
            }
        }

        private void btnDathang_Click(object sender, EventArgs e)
        {
            DatHang f = new DatHang();
            f.ShowDialog();
        }

        private void btnLichsumuahang_Click(object sender, EventArgs e)
        {
            LichSuMuaHang f = new LichSuMuaHang();
            f.ShowDialog();
        }

        private void HuongDanMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Hướng dẫn sử dụng cho khách hàng đang được phát triển");
        }

        private void btnUudai_Click(object sender, EventArgs e)
        {
            ChuongTrinhUuDai f = new ChuongTrinhUuDai();
            f.ShowDialog();

        }

        private void LienHeMenu_Click(object sender, EventArgs e)
        {
            LienHe f = new LienHe();
            f.ShowDialog();
        }

        private void btnNapvip_Click(object sender, EventArgs e)
        {
            NapVip f = new NapVip();
            f.ShowDialog();
        }
    }
}
