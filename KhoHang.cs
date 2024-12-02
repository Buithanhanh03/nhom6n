using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BTL_ThucTap_LTNET
{
    public partial class KhoHang : Form
    {
        Guna2Panel panelDetail = new Guna2Panel();
        Label lblInfo = new Label();
        PictureBox pictureBox = new PictureBox();

        string relativePath;
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
            InitializePanel();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            this.Click += KhoHang_Click;
        }
        private void LoadSanPham()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From sanpham";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private bool IsInteger(string input)
        {
            int number;
            if (int.TryParse(input, out number) && number > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EmptyTextbox()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2TextBox TextBox && string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    return false;
                }

            }
            return true;
        }
        private void LoadForm()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2TextBox TextBox)
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

        private void btnNhapthem_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox textBox)
                {
                    if(control != txtTonkho)
                    {
                        control.Enabled = true;
                    }    
                }
            }
            btnCapnhat.Enabled = true;
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTonkho.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng muốn nhập thêm");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int masp = int.Parse(selectedRow.Cells["masp"].Value.ToString());
                int tonkhocu = int.Parse(selectedRow.Cells["tonkho"].Value.ToString());
                int soluongnhap = int.Parse(txtTonkho.Text);
                
                conn = connectdb();
                conn = new SqlConnection(sqlqr);
                using (conn)
                {
                    conn.Open();
                    string sql = "Update sanpham Set tonkho = @tonkho Where masp =@masp";
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@masp", masp);
                    cmd.Parameters.AddWithValue("@tonkho", (tonkhocu + soluongnhap));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã sửa thành công");
                    conn.Close();
                    LoadForm();
                    LoadSanPham();
                    btnNhaphangmoi.Enabled = true;
                    btnAnh.Enabled = true;
                    btnReset.Enabled = true;
                    btnCapnhat.Enabled = false;
                    btnReset_Click(null, null);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để nhập thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNhaphangmoi_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2TextBox textBox)
                {
                    ctrl.Enabled = true;
                }
            }
            btnAnh.Enabled = true;
            if (EmptyTextbox() == false)
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if (IsInteger(txtMa.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho mã sản phẩm");
                return;
            }
            if (IsInteger(txtGia.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho giá");
                return;
            }
            if (IsInteger(txtSize.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho size");
                return;
            }
            if (string.IsNullOrEmpty(relativePath))
            {
                MessageBox.Show("Bạn chưa chọn ảnh");
                return;
            }
            int masp = int.Parse(txtMa.Text);
            string tensp = txtTen.Text;
            int gia = int.Parse(txtGia.Text);
            string anh = relativePath;
            int size = int.Parse(txtSize.Text);
            string mau = txtMau.Text;
            int tonkho = int.Parse(txtTonkho.Text);
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            using (SqlConnection conn = connectdb())
            {
                SqlCommand command = new SqlCommand("SELECT COUNT (*) FROM sanpham WHERE masp = @masp", conn);

                command.Parameters.AddWithValue("@masp", masp);
                conn.Open();
                int rs = (int)command.ExecuteScalar();
                if (rs > 0)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!");
                    return;
                }
                else
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO sanpham(masp, tensp, gia, anh, size, mau, tonkho, rating) VALUES(@masp, @tensp, @gia, @anh, @size, @mau, @tonkho, @rating)";
                    cmd.Parameters.AddWithValue("@masp", masp);
                    cmd.Parameters.AddWithValue("@tensp", tensp);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.Parameters.AddWithValue("@anh", anh);
                    cmd.Parameters.AddWithValue("@size", size);
                    cmd.Parameters.AddWithValue("@mau", mau);
                    cmd.Parameters.AddWithValue("@tonkho", tonkho);
                    cmd.Parameters.AddWithValue("@rating", 5);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm thành công");
                    LoadForm();
                    LoadSanPham();
                }
                conn.Close();
                // Tạo mã đơn đặt hàng ngẫu nhiên
                Random random = new Random();
                DateTime today = DateTime.Now;
                int maddh;
                int gianhap = random.Next(100000, 200001);
                do
                {
                    maddh = random.Next(1, 1001);
                    SqlCommand checkMaddh = new SqlCommand("SELECT COUNT(*) FROM dondathang WHERE maddh = @maddh", conn);
                    checkMaddh.Parameters.AddWithValue("@maddh", maddh);
                    conn.Open();
                    int exists = (int)checkMaddh.ExecuteScalar();
                    if (exists == 0) break;
                } while (true);
                string insertDDHQuery = "INSERT INTO dondathang(maddh, ngaydat, masp, gianhap, soluongnhap) VALUES(@maddh, @ngaydat, @masp, @gianhap, @soluongnhap)";
                using (SqlCommand cmd = new SqlCommand(insertDDHQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@maddh", maddh);
                    cmd.Parameters.AddWithValue("@ngaydat", today);
                    cmd.Parameters.AddWithValue("@masp", masp);
                    cmd.Parameters.AddWithValue("@gianhap", gianhap);
                    cmd.Parameters.AddWithValue("@soluongnhap", tonkho);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    string appPath = Application.StartupPath;
                    Uri appUri = new Uri(appPath + "\\");
                    Uri fileUri = new Uri(selectedImagePath);

                    relativePath = appUri.MakeRelativeUri(fileUri).ToString();

                    relativePath = relativePath.Replace("/", "\\");
                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox textBox)
                {
                    control.Text = string.Empty;
                    control.Enabled = true;
                }
            }
            btnCapnhat.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string tensp = txtTimkiem.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From sanpham Where tensp LIKE @tensp";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@tensp", "%" + tensp + "%");

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void InitializePanel()
        {
            panelDetail.Size = new Size(150, 150);
            panelDetail.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            panelDetail.BackColor = Color.LightBlue;
            panelDetail.Visible = false;
            panelDetail.BorderRadius = 10;
            panelDetail.BorderThickness = 1;

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

        private void KhoHang_Click(object sender, EventArgs e)
        {
            if (panelDetail.Visible)
            {
                panelDetail.Visible = false;
                lblInfo.Text = "";
                pictureBox.Image = null;
            }
        }
    }
}
