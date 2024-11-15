using Guna.UI2.WinForms;
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
    public partial class DatHang : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        private List<TempSave.GioHang> gioHangList = new List<TempSave.GioHang>();

        public DatHang()
        {
            conn = connectdb();
            InitializeComponent();
        }

        private void DatHang_Load(object sender, EventArgs e)
        {
            LoadProducts();
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
                    int tonKho = Convert.ToInt32(reader["tonkho"]);
                    int masp = Convert.ToInt32(reader["masp"]);
                    string tensp = reader["tensp"].ToString();
                    int gia = Convert.ToInt32(reader["gia"]);
                    string anh = reader["anh"].ToString();

                    var panel = new Guna2Panel
                    {
                        Size = new Size(180, 330),
                        BorderColor = Color.LightGray,
                        BorderThickness = 2,
                        BorderRadius = 15,
                        BackColor = Color.White,
                    };

                    var labelTensanpham = new Guna2HtmlLabel
                    {
                        Text = tensp,
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
                        Text = "Giá: " + string.Format("{0:N0}", gia) + " VND",
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
                        Text = "Tồn kho: " + tonKho,
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
                        ImageLocation = anh,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderRadius = 8,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    var textBoxSoLuong = new Guna2TextBox
                    {
                        PlaceholderText = "Nhập số lượng",
                        Location = new Point(10, 230),
                        Width = panel.Width - 20,
                        Height = 30,
                        BorderRadius = 5,
                        Font = new Font("Segoe UI", 9),
                    };

                    var buttonThemGioHang = new Guna2Button
                    {
                        Text = "Thêm vào giỏ",
                        Location = new Point(10, 270),
                        Width = panel.Width - 20,
                        Height = 30,
                        BorderRadius = 5,
                        FillColor = Color.SeaGreen,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold)
                    };
                    buttonThemGioHang.Click += (s, ev) =>
                    {
                        int soluongmua;
                        if (int.TryParse(textBoxSoLuong.Text, out soluongmua))
                        {
                            if (soluongmua > tonKho)
                            {
                                MessageBox.Show("Số lượng nhập vượt quá tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (soluongmua <= 0)
                            {
                                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                var existingItem = gioHangList.FirstOrDefault(g => g.masp == masp);
                                if (existingItem != null)
                                {
                                    existingItem.soluongdaban += soluongmua;
                                }
                                else
                                {
                                    gioHangList.Add(new TempSave.GioHang
                                    {
                                        masp = masp,
                                        tensp = tensp,
                                        soluongdaban = soluongmua,
                                        gia = gia
                                    });
                                }

                                MessageBox.Show($"Đã thêm {soluongmua} sản phẩm vào giỏ hàng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    };

                    panel.Controls.Add(labelTensanpham);
                    panel.Controls.Add(pictureBoxHinhanh);
                    panel.Controls.Add(labelGiasanpham);
                    panel.Controls.Add(labelTonkho);
                    panel.Controls.Add(textBoxSoLuong);
                    panel.Controls.Add(buttonThemGioHang);

                    flowLayoutPanel1.Controls.Add(panel);
                }

                reader.Close();
            }
        }

        private void btnGiohang_Click(object sender, EventArgs e)
        {
            GioHang f = new GioHang(gioHangList);
            f.ShowDialog();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
