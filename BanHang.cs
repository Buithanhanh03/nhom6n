using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using TextBox = System.Windows.Forms.TextBox;

namespace BTL_ThucTap_LTNET
{
    public partial class BanHang : Form
    {
        Panel panelDetail = new Panel();
        Label lblInfo = new Label();
        PictureBox pictureBox = new PictureBox();
        private int slmua = 0;
        int tongtienban = 0;
        Random random = new Random();

        public BanHang()
        {
            InitializeComponent();
            InitializePanel();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            this.Click += BanHang_Click;
        }

        private void InitializePanel()
        {
            panelDetail.Size = new Size(150, 150);
            panelDetail.BorderStyle = BorderStyle.Fixed3D;
            panelDetail.BackColor = Color.LightGray;
            panelDetail.Visible = false;

            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            lblInfo.Location = new Point(5, 5);
            panelDetail.Controls.Add(lblInfo);

            pictureBox.Size = new Size(100, 100);
            pictureBox.Location = new Point(5, 30);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            panelDetail.Controls.Add(pictureBox);

            this.Controls.Add(panelDetail);
        }

        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }

        private void LoadDataSanPham()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From sanpham";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void LoadDataLichSu()
        {
            conn = connectdb();
            string query = @"SELECT 
                        dh.madh AS madh,
                        dh.makh AS makh,
                        ctdh.masp AS masp,
                        dh.ngaydat AS ngaydat,
                        ctdh.soluongdaban AS soluongdaban,
                        dh.tongtien AS tongtien,
                        dh.trangthai AS trangthai

                    FROM 
                        donhang dh
                    INNER JOIN 
                        chitietdonhang ctdh ON dh.madh = ctdh.madh";

            using (conn)
            using (SqlCommand command = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
            }
        }
        private void BanHang_Load(object sender, EventArgs e)
        {
            LoadDataSanPham();
            LoadDataLichSu();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                string info = "";
                string imagePath = "";

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.OwningColumn.HeaderText == "Tên SP" || cell.OwningColumn.HeaderText == "SLĐB")
                        {
                            info += cell.OwningColumn.HeaderText + ": " + cell.Value.ToString() + "\n";
                        }
                        if (cell.OwningColumn.HeaderText == "Ảnh")
                        {
                            imagePath = cell.Value.ToString();
                        }
                    }
                }

                lblInfo.Text = info;
                pictureBox.ImageLocation = imagePath;
                Point dataGridViewLocation = dataGridView1.Location;
                int rowHeight = dataGridView1.RowTemplate.Height;
                int panelY = dataGridViewLocation.Y + row.Index * rowHeight;
                panelDetail.Location = new Point(dataGridViewLocation.X, panelY);
                panelDetail.BringToFront();
                panelDetail.Visible = true;
            }
        }

        private void BanHang_Click(object sender, EventArgs e)
        {
            if (panelDetail.Visible)
            {
                panelDetail.Visible = false;
                lblInfo.Text = "";
                pictureBox.Image = null;
                txtSoluong.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoluong.Enabled = true;
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSoluong.Text))btnThem.Enabled = false;
            else btnThem.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int masp = int.Parse(selectedRow.Cells["masp"].Value.ToString());
                string tensp = selectedRow.Cells["tensp"].Value.ToString();
                int gia = int.Parse(selectedRow.Cells["gia"].Value.ToString());

                if (int.TryParse(txtSoluong.Text, out slmua) && slmua > 0)
                {
                    tongtienban = gia * slmua;
                    txtThongtin.Text = $"THÔNG TIN MUA HÀNG:\n" +
                                                  $"Mã sản phẩm: {masp}\n" +
                                                  $"Tên sản phẩm: {tensp}\n" +
                                                  $"Số lượng mua: {slmua}\n" +
                                                  $"Tổng giá: {tongtienban} VND";
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng mua hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtThongtin.Clear();
        }

        private void txtThongtin_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtThongtin.Text))
            { 
                btnThanhtoan.Enabled = false; 
                btnHuy.Enabled = false;
            }
            else
            {
                btnThanhtoan.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thanh toán không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cập nhật tồn kho sản phẩm
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int masp = int.Parse(selectedRow.Cells["masp"].Value.ToString());
                int tonkho = int.Parse(selectedRow.Cells["tonkho"].Value.ToString());
                int soluongban = slmua;
                conn = connectdb();
                using (conn)
                {
                    conn.Open();

                    // Cập nhật lại tồn kho
                    string updateSPQuery = "UPDATE sanpham SET tonkho = @tonkho WHERE masp = @masp";
                    using (SqlCommand cmd = new SqlCommand(updateSPQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tonkho", tonkho - soluongban);
                        cmd.Parameters.AddWithValue("@masp", masp);
                        cmd.ExecuteNonQuery();
                    }

                    // Tạo mã đơn hàng ngẫu nhiên
                    int madh;
                    do
                    {
                        madh = random.Next(1, 1001);
                        SqlCommand checkMadh = new SqlCommand("SELECT COUNT(*) FROM donhang WHERE madh = @madh", conn);
                        checkMadh.Parameters.AddWithValue("@madh", madh);
                        int exists = (int)checkMadh.ExecuteScalar();
                        if (exists == 0) break;
                    } while (true);
                    TempSave.MaDonHang = madh;
                    // Thêm đơn hàng vào bảng donhang
                    DateTime today = DateTime.Now;
                    string insertDHQuery = "INSERT INTO donhang(madh, tongtien, manv, trangthai, ngaydat) VALUES(@madh, @tongtien, @manv, @trangthai, @ngaydat)";
                    using (SqlCommand cmd = new SqlCommand(insertDHQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@madh", madh);
                        cmd.Parameters.AddWithValue("@tongtien", tongtienban);
                        cmd.Parameters.AddWithValue("@manv", "1");
                        cmd.Parameters.AddWithValue("@trangthai", "Đang xử lý");
                        cmd.Parameters.AddWithValue("@ngaydat", today);
                        cmd.ExecuteNonQuery();
                    }

                    // Tạo mã chi tiết đơn hàng ngẫu nhiên
                    int mactdh;
                    do
                    {
                        mactdh = random.Next(1, 1001);
                        SqlCommand checkMactdh = new SqlCommand("SELECT COUNT(*) FROM chitietdonhang WHERE mactdh = @mactdh", conn);
                        checkMactdh.Parameters.AddWithValue("@mactdh", mactdh);
                        int exists = (int)checkMactdh.ExecuteScalar();
                        if (exists == 0) break;
                    } while (true);

                    // Thêm chi tiết đơn hàng vào bảng chitietdonhang
                    string insertCTDHQuery = "INSERT INTO chitietdonhang(mactdh, madh, masp, dongiadh, soluongdaban) VALUES(@mactdh, @madh, @masp, @dongiadh, @soluongdaban)";
                    using (SqlCommand cmd = new SqlCommand(insertCTDHQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@mactdh", mactdh);
                        cmd.Parameters.AddWithValue("@madh", madh);
                        cmd.Parameters.AddWithValue("@masp", masp);
                        cmd.Parameters.AddWithValue("@dongiadh", tongtienban);
                        cmd.Parameters.AddWithValue("@soluongdaban", soluongban);
                        cmd.ExecuteNonQuery();
                    }
                    txtThongtin.Clear();
                    txtSoluong.Clear();
                    conn.Close();
                }
                MessageBox.Show("Thanh toán thành công! Bạn sẽ được chuyển đến phần In hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload dữ liệu sau khi thanh toán
                LoadDataSanPham();
                LoadDataLichSu();
                NhapKhachHang f =new NhapKhachHang();
                f.ShowDialog();
            }
            else
            {
                return;
            }
        }

    }
}
