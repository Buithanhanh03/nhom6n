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
        }
        private void LoadSanPham()
        {
            dataGridView1.Rows.Clear();
            anh.ImageLayout = DataGridViewImageCellLayout.Zoom;
            string query = "SELECT masp, tensp, gia, anh, mau, madm, tonkho FROM sanpham";

            using (SqlConnection conn = new SqlConnection(sqlqr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string imgPath = row["anh"].ToString();
                    string imagePath = Path.Combine(Application.StartupPath, imgPath);
                    Image productImage = null;
                    if (System.IO.File.Exists(imagePath))
                    {
                        productImage = Image.FromFile(imagePath);
                    }
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells["anh"].Value = productImage;
                    dataGridView1.Rows[index].Cells["masp"].Value = row["masp"];
                    dataGridView1.Rows[index].Cells["tensp"].Value = row["tensp"];
                    dataGridView1.Rows[index].Cells["gia"].Value = row["gia"];
                    dataGridView1.Rows[index].Cells["mau"].Value = row["mau"];
                    dataGridView1.Rows[index].Cells["madm"].Value = row["madm"];
                    dataGridView1.Rows[index].Cells["tonkho"].Value = row["tonkho"];
                }
            }
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
            if (IsInteger(txtMadm.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho mã mục");
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
            int madm = int.Parse(txtMadm.Text);
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
                    cmd.CommandText = "INSERT INTO sanpham(masp, tensp, gia, anh, size, mau, madm, tonkho) VALUES(@masp, @tensp, @gia, @anh, @size, @mau, @madm, @tonkho)";
                    cmd.Parameters.AddWithValue("@masp", masp);
                    cmd.Parameters.AddWithValue("@tensp", tensp);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.Parameters.AddWithValue("@anh", anh);
                    cmd.Parameters.AddWithValue("@size", size);
                    cmd.Parameters.AddWithValue("@mau", mau);
                    cmd.Parameters.AddWithValue("@madm", madm);
                    cmd.Parameters.AddWithValue("@tonkho", tonkho);
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
    }
}
