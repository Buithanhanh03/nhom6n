using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BTL_ThucTap_LTNET
{
    public partial class GioHang : Form
    {
        private List<TempSave.GioHang> danhSachGioHang;
        public DatHang datHangForm;
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }

        public GioHang(List<TempSave.GioHang> gioHang)
        {
            danhSachGioHang = gioHang;
            conn = connectdb();
            InitializeComponent();
        }

        private void GioHang_Load(object sender, EventArgs e)
        {
            LoadGioHang();
        }

        private void LoadGioHang()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.Padding = new Padding(10);

            foreach (var item in danhSachGioHang.ToList())
            {
                var panel = new Guna2Panel
                {
                    Size = new Size(400, 110),
                    BorderColor = Color.LightGray,
                    BorderThickness = 1,
                    BorderRadius = 10,
                    BackColor = Color.White,
                    Margin = new Padding(10)
                };

                var labelMasp = new Guna2HtmlLabel
                {
                    Text = "Mã SP: " + item.masp,
                    Location = new Point(10, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.DarkSlateGray
                };

                var labelTensp = new Guna2HtmlLabel
                {
                    Text = "Tên SP: " + item.tensp,
                    Location = new Point(10, 30),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.DarkSlateGray
                };

                var labelSoluong = new Guna2HtmlLabel
                {
                    Text = "Số lượng: " + item.soluongdaban,
                    Location = new Point(200, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.DarkSlateGray
                };

                var labelGia = new Guna2HtmlLabel
                {
                    Text = "Giá: " + string.Format("{0:N0}", item.gia) + " VND",
                    Location = new Point(200, 30),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.DarkSlateGray
                };

                int tongGia = item.soluongdaban * item.gia;

                var labelTongGia = new Guna2HtmlLabel
                {
                    Text = "Tổng giá trị: " + string.Format("{0:N0}", tongGia) + " VND",
                    Location = new Point(10, 60),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.SeaGreen
                };

                var buttonXoa = new Guna2Button
                {
                    Text = "X",
                    Location = new Point(350, 10),
                    Size = new Size(40, 30),
                    FillColor = Color.Red,
                    ForeColor = Color.White,
                    BorderRadius = 5,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold)
                };

                buttonXoa.Click += (s, ev) =>
                {
                    danhSachGioHang.Remove(item);
                    LoadGioHang();
                };

                panel.Controls.Add(labelMasp);
                panel.Controls.Add(labelTensp);
                panel.Controls.Add(labelSoluong);
                panel.Controls.Add(labelGia);
                panel.Controls.Add(labelTongGia);
                panel.Controls.Add(buttonXoa);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            if (string.IsNullOrEmpty(txtMagiamgia.Text) == false)
            {
                string maGiamGia = txtMagiamgia.Text.Trim();

                using (var conn = connectdb())
                {
                    conn.Open();
                    SqlCommand cmdCheckDiscount = new SqlCommand("SELECT giamgia, lansudung FROM phieugiamgia WHERE magiamgia = @maGiamGia", conn);
                    cmdCheckDiscount.Parameters.AddWithValue("@maGiamGia", maGiamGia);

                    SqlDataReader reader = cmdCheckDiscount.ExecuteReader();
                    if (reader.Read())
                    {
                        int giamGia = Convert.ToInt32(reader["giamgia"]);
                        int lansudung = Convert.ToInt32(reader["lansudung"]);

                        if (lansudung > 0)
                        {
                            TempSave.GiamGia = giamGia;

                            reader.Close();
                            SqlCommand cmdUpdateDiscount = new SqlCommand("UPDATE phieugiamgia SET lansudung = lansudung - 1 WHERE magiamgia = @magiamgia", conn);
                            cmdUpdateDiscount.Parameters.AddWithValue("@magiamgia", maGiamGia);
                            cmdUpdateDiscount.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Mã giảm giá này đã hết lượt sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã giảm giá không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            int tongTien = danhSachGioHang.Sum(item => item.soluongdaban * item.gia);

            string username = TempSave.username;
            int makh = GetCustomerIdByUsername(username);
            int madh = GenerateUniqueOrderId();
            TempSave.MaDonHang = madh;
            DateTime ngayDat = DateTime.Now;

            using (var conn = connectdb())
            {
                conn.Open();
                SqlCommand cmdInsertOrder = new SqlCommand("INSERT INTO donhang (madh, makh, manv, ngaydat, tongtien, trangthai) VALUES (@madh, @makh, NULL, @ngaydat, @tongtien, @trangthai)", conn);
                cmdInsertOrder.Parameters.AddWithValue("@madh", madh);
                cmdInsertOrder.Parameters.AddWithValue("@makh", makh);
                cmdInsertOrder.Parameters.AddWithValue("@ngaydat", ngayDat);
                cmdInsertOrder.Parameters.AddWithValue("@tongtien", tongTien);
                cmdInsertOrder.Parameters.AddWithValue("@trangthai", "Đang xử lý");
                cmdInsertOrder.ExecuteNonQuery();
            }
            Random random = new Random();

            foreach (var item in danhSachGioHang)
            {
                int mactdh = random.Next(100000, 999999);

                using (var conn = connectdb())
                {
                    conn.Open();
                    SqlCommand cmdInsertDetail = new SqlCommand("INSERT INTO chitietdonhang (mactdh, madh, masp, dongiadh, soluongdaban) VALUES (@mactdh, @madh, @masp, @dongiadh, @soluongdaban)", conn);
                    cmdInsertDetail.Parameters.AddWithValue("@mactdh", mactdh);
                    cmdInsertDetail.Parameters.AddWithValue("@madh", madh);
                    cmdInsertDetail.Parameters.AddWithValue("@masp", item.masp);
                    cmdInsertDetail.Parameters.AddWithValue("@dongiadh", item.gia); 
                    cmdInsertDetail.Parameters.AddWithValue("@soluongdaban", item.soluongdaban);

                    cmdInsertDetail.ExecuteNonQuery();
                }
                UpdateInventory(item.masp, item.soluongdaban);
            }

            MessageBox.Show("Thanh toán thành công. Bạn có thể in hóa đơn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            danhSachGioHang.Clear();
            InHoaDon f = new InHoaDon();
            f.ShowDialog();
            LoadGioHang();
        }

        private void UpdateInventory(int masp, int soluongmua)
        {
            using (var conn = connectdb())
            {
                conn.Open();
                SqlCommand cmdUpdateInventory = new SqlCommand("UPDATE sanpham SET tonkho = tonkho - @soluongmua WHERE masp = @masp", conn);
                cmdUpdateInventory.Parameters.AddWithValue("@soluongmua", soluongmua);
                cmdUpdateInventory.Parameters.AddWithValue("@masp", masp);

                cmdUpdateInventory.ExecuteNonQuery();
            }
        }

        private int GenerateUniqueOrderId()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }


        private int GetCustomerIdByUsername(string username)
        {
            int makh = -1;

            using (var conn = connectdb())
            {
                conn.Open();

                string query = "SELECT makh FROM taikhoan WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    makh = Convert.ToInt32(reader["makh"]);
                }
                reader.Close();
            }

            return makh;
        }


        private void btnTrolai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
