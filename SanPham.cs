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
            string sql = "Select * From sanpham";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
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
    }
}
