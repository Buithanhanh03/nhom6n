﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_ThucTap_LTNET
{
    public partial class Main : Form
    {
        private Image[] images;
        private int currentImageIndex = 0;
        private Timer imageTimer;
        private Timer fadeTimer;
        private float opacity = 1.0f;
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public Main()
        {
            InitializeComponent();
            string imageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "anh");
            string[] imagePaths = Directory.GetFiles(imageDirectory, "*.jpg");

            // Khởi tạo mảng ảnh từ các đường dẫn tương đối
            images = new Image[imagePaths.Length];
            for (int i = 0; i < imagePaths.Length; i++)
            {
                images[i] = Image.FromFile(imagePaths[i]);
            }

            // Hiển thị ảnh đầu tiên
            pictureBox1.Image = images[currentImageIndex];
            pictureBox1.Paint += pictureBox1_Paint;
            imageTimer = new Timer();
            imageTimer.Interval = 3000;
            imageTimer.Tick += ImageTimer_Tick;
            imageTimer.Start();
            fadeTimer = new Timer();
            fadeTimer.Interval = 50;
            fadeTimer.Tick += FadeTimer_Tick;
        }

        private void ImageTimer_Tick(object sender, EventArgs e)
        {
            opacity = 1.0f;
            fadeTimer.Start();
        }
        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            opacity -= 0.1f;
            if (opacity <= 0)
            {
                currentImageIndex = (currentImageIndex + 1) % images.Length;
                pictureBox1.Image = images[currentImageIndex];

                opacity = 1.0f;
                fadeTimer.Stop();
            }
            pictureBox1.Invalidate();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if(TempSave.TaiKhoan == "admin")
            {
                btnBaocaodoanhthu.Enabled = true;
                btnBaocaotonkho.Enabled = true;
                btnChuongtrinhgiamgia.Enabled = true;
                btnQuangcao.Enabled = true;
                btnQuanlytaikhoankhachhang.Enabled = true;
                btnXemphanhoi.Enabled = true;
                btnNhanvien.Enabled = true;
                btnXembaotri.Enabled = true;
            }
        }
        private void tHÔNGTINỨNGDỤNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinUngDung f = new ThongTinUngDung();
            f.ShowDialog();
        }

        private void tRỢGIÚPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongDan f = new HuongDan();
            f.ShowDialog();
        }

        private void bẢOTRÌToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoTri f = new BaoTri();
            f.ShowDialog();
        }

        private void tHOÁTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            f.ShowDialog();
            this.Close();
        }

        private void tHOÁTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color color1 = Color.LightPink;
            Color color2 = Color.BlueViolet;

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void btnBanhang_Click(object sender, EventArgs e)
        {
            BanHang f = new BanHang();
            f.ShowDialog();
        }

        private void btnKhohang_Click(object sender, EventArgs e)
        {
            KhoHang f = new KhoHang();
            f.ShowDialog();
        }

        private void btnSanpham_Click(object sender, EventArgs e)
        {
            SanPham f = new SanPham();
            f.ShowDialog();
        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            KhachHang f = new KhachHang();
            f.ShowDialog();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            NhanVien f = new NhanVien();
            f.ShowDialog();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            LichSuNhapHang f = new LichSuNhapHang();
            f.ShowDialog();
        }

        private void btnBaocaodoanhthu_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhThu f = new BaoCaoDoanhThu();
            f.ShowDialog();
        }

        private void btnBaocaotonkho_Click(object sender, EventArgs e)
        {
            BaoCaoTonKho f = new BaoCaoTonKho();
            f.ShowDialog();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ ảnh với độ mờ hiện tại
            if (pictureBox1.Image != null)
            {
                e.Graphics.Clear(pictureBox1.BackColor);
                ColorMatrix colorMatrix = new ColorMatrix
                {
                    Matrix33 = opacity // Đặt độ mờ của ảnh
                };
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Vẽ ảnh với độ mờ
                e.Graphics.DrawImage(pictureBox1.Image,
                                     new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
                                     0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height,
                                     GraphicsUnit.Pixel, attributes);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            XemLich f = new XemLich();
            f.ShowDialog();
        }

        private void btnChoigame_Click(object sender, EventArgs e)
        {
            if(TempSave.TaiKhoan == "admin")
            {
                MessageBox.Show("Admin không thể chơi game");
                return;
            }
            // Hiển thị hộp thoại nhập mã nhân viên
            string inputManv = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã nhân viên:", "Kiểm tra mã nhân viên", "");

            if (!string.IsNullOrEmpty(inputManv))
            {
                // Kiểm tra mã nhân viên trong cơ sở dữ liệu
                if (CheckManvExists(inputManv))
                {
                    TempSave.MaNhanVien = int.Parse(inputManv);
                    ChoiGame f = new ChoiGame();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }
        private bool CheckManvExists(string manv)
        {
            bool exists = false;

            // Kết nối và truy vấn cơ sở dữ liệu
            using (conn = connectdb())
            {
                string query = "SELECT COUNT(*) FROM nhanvien WHERE manv = @manv";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manv", manv);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    exists = count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return exists;
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            XuLyDonHang f = new XuLyDonHang();
            f.ShowDialog();
        }

        private void btnChuongtrinhgiamgia_Click(object sender, EventArgs e)
        {
            QuanLyGiamGia f = new QuanLyGiamGia();
            f.ShowDialog();
        }

        private void btnXemphanhoi_Click(object sender, EventArgs e)
        {
            XemPhanHoi f = new XemPhanHoi();
            f.ShowDialog();
        }

        private void btnQuangcao_Click(object sender, EventArgs e)
        {
            QuanLyQuangCao f = new QuanLyQuangCao();
            f.ShowDialog();
        }

        private void btnQuanlytaikhoankhachhang_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoanKhachHang f = new QuanLyTaiKhoanKhachHang();
            f.ShowDialog();
        }

        private void btnXulydonhang_Click(object sender, EventArgs e)
        {
            XuLyDonHang f = new XuLyDonHang();
            f.ShowDialog();
        }

        private void btnXembaotri_Click(object sender, EventArgs e)
        {
            XemBaoTri f = new XemBaoTri();
            f.ShowDialog();
        }
    }
}
