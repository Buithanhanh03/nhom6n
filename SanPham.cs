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

namespace BTL_ThucTap_LTNET
{
    public partial class SanPham : Form
    {
        private string selectedImagePath;
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        public SanPham()
        {
            InitializeComponent();
        }
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public bool EmptyTextbox()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox && string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    return false;
                }

            }
            return true;
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
        private void LoadForm()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select masp, tensp, gia, mau, madm, tonkho From sanpham";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            string query = "SELECT anh FROM sanpham"; // Thay bằng tên bảng và cột thực tế của bạn

            //Sử dụng SqlConnection để truy xuất dữ liệu
            //using (conn)
            //{
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        conn.Open();

            //        SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            //        DataTable dt1 = new DataTable();
            //        adapter1.Fill(dt1);
            //        foreach (DataRow row in dt1.Rows)
            //        {
            //            string imagePath = row["anh"].ToString();
            //            string relativePath = Path.Combine("Resources", imagePath);
            //            string fullPath = System.IO.Path.Combine(Application.StartupPath, relativePath);
            //            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            //            dataGridView1.Rows[rowIndex].Cells["anh"].Value = Image.FromFile(fullPath);
            //        }
            //    }
            //}
            //conn = connectdb();
            //string sql = "Select * From sanpham";
            //using (conn)
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        conn.Open();

            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dataGridView1.Rows.Clear();

            //        // Duyệt qua từng dòng dữ liệu
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            int rowIndex = dataGridView1.Rows.Add();
            //            dataGridView1.Rows[rowIndex].Cells["masp"].Value = row["masp"];
            //            dataGridView1.Rows[rowIndex].Cells["tensp"].Value = row["tensp"];
            //            dataGridView1.Rows[rowIndex].Cells["gia"].Value = row["gia"];
            //            dataGridView1.Rows[rowIndex].Cells["size"].Value = row["size"];
            //            dataGridView1.Rows[rowIndex].Cells["mau"].Value = row["mau"];
            //            dataGridView1.Rows[rowIndex].Cells["Mã madm mục"].Value = row["madm"];
            //            dataGridView1.Rows[rowIndex].Cells["tonkho kho"].Value = row["tonkho"];

            //            // Xử lý ảnh: kiểm tra đường dẫn và chuyển thành ảnh
            //            string imagePath = row["anh"].ToString();
            //            if (System.IO.File.Exists(imagePath))
            //            {
            //                dataGridView1.Rows[rowIndex].Cells["imgColumn"].Value = Image.FromFile(imagePath);
            //            }
            //            else
            //            {
            //                // Hiển thị ảnh mặc định nếu không tìm thấy ảnh
            //                dataGridView1.Rows[rowIndex].Cells["imgColumn"].Value = Properties.Resources.defaultImage;
            //            }
            //        }
            //    }
            //}

        }
        private void CheckInputType()
        {
            if (IsInteger(txtMa.Text) == false)
            {
                MessageBox.Show("Mã sản phẩm chỉ có thể nhập kiểu số nguyên");
                return;
            }
            if (IsInteger(txtMadm.Text) == false)
            {
                MessageBox.Show("Mã danh mục chỉ có thể nhập kiểu số nguyên");
                return;
            }
            if (IsInteger(txtSize.Text) == false)
            {
                MessageBox.Show("Size chỉ có thể nhập kiểu số nguyên");
                return;
            }
            if (IsInteger(txtGia.Text) == false)
            {
                MessageBox.Show("Giá chỉ có thể nhập kiểu số nguyên");
                return;
            }
            if (IsInteger(txtTonkho.Text) == false)
            {
                MessageBox.Show("Tồn kho chỉ có thể nhập kiểu số nguyên");
                return;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (EmptyTextbox() == false)
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            CheckInputType();
            string maSP = txtMa.Text;
            string tenSP = txtTen.Text;
            string gia = txtGia.Text;
            string size = txtSize.Text;
            string mau = txtMau.Text;
            string maDM = txtMadm.Text;
            string tonKho = txtTonkho.Text;

            byte[] imgBytes = null;
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                imgBytes = File.ReadAllBytes(selectedImagePath);
            }
            using (conn)
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO sanpham (masp, tensp, gia, anh, size, mau, madm, tonkho) " +
                                   "VALUES (@masp, @tensp, @gia, @anh, @size, @mau, @madm, @tonkho)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@masp", maSP);
                        cmd.Parameters.AddWithValue("@tensp", tenSP);
                        cmd.Parameters.AddWithValue("@gia", gia);
                        cmd.Parameters.AddWithValue("@anh", (object)imgBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@size", size);
                        cmd.Parameters.AddWithValue("@mau", mau);
                        cmd.Parameters.AddWithValue("@madm", maDM);
                        cmd.Parameters.AddWithValue("@tonkho", tonKho);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            LoadForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }

        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        //CHỌN ẢNH
        private void btnAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                }
            }
        }

        private void SanPham_Load_1(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string maCanTim = txtTimkiem.Text.Trim();
            if (!string.IsNullOrEmpty(maCanTim) && IsInteger(txtTimkiem.Text))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"manv = '{maCanTim}'";
            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
