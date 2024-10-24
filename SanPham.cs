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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BTL_ThucTap_LTNET
{
    public partial class SanPham : Form
    {
        private string selectedImagePath;
        private string relativePath;
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
                if (ctrl is System.Windows.Forms.TextBox && string.IsNullOrWhiteSpace(ctrl.Text))
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
            if (IsInteger(txtGia.Text) == false)
            {
                MessageBox.Show("Giá chỉ có thể nhập kiểu số nguyên");
                return;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
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
                    string selectedImagePath = openFileDialog.FileName;

                    string appPath = Application.StartupPath;
                    Uri appUri = new Uri(appPath + "\\");
                    Uri fileUri = new Uri(selectedImagePath);

                    relativePath = appUri.MakeRelativeUri(fileUri).ToString();

                    relativePath = relativePath.Replace("/", "\\");
                }
            }
        }

        private void SanPham_Load_1(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtMa.Enabled = false;
                btnCapnhat.Enabled = true;
                btnXoa.Enabled = false;
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtMa.Text = selectedRow.Cells["masp"].Value.ToString();
                txtTen.Text = selectedRow.Cells["tensp"].Value.ToString();
                txtGia.Text = selectedRow.Cells["gia"].Value.ToString();
                txtMau.Text = selectedRow.Cells["mau"].Value.ToString();
                txtMadm.Text = selectedRow.Cells["madm"].Value.ToString();
            }
            
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (EmptyTextbox() == false)
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if (IsInteger(txtGia.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho Giá");
                return;
            }
            if (IsInteger(txtMadm.Text) == false)
            {
                MessageBox.Show("Hãy nhập só cho mã danh mục");
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
            string mau = txtMau.Text;
            string madm = txtMadm.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            using (conn)
            {
                conn.Open();
                string sql = "Update sanpham Set tensp = @tensp, gia = @gia, anh = @anh, mau = @mau, madm = @madm Where masp =@masp";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@masp", masp);
                cmd.Parameters.AddWithValue("@tensp", tensp);
                cmd.Parameters.AddWithValue("@gia", gia);
                cmd.Parameters.AddWithValue("@anh", anh);
                cmd.Parameters.AddWithValue("@mau", mau);
                cmd.Parameters.AddWithValue("@madm", madm);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã sửa thành công");
                conn.Close();
                LoadForm();
                txtMa.Enabled = true;
                btnCapnhat.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string masp = dataGridView1.SelectedRows[0].Cells["masp"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(sqlqr))
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string updateForeignKeyQuery = "UPDATE dondathang SET masp = NULL WHERE masp = @masp";
                                using (SqlCommand cmdUpdate = new SqlCommand(updateForeignKeyQuery, conn, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@masp", masp);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                                string updateForeignKeyQuery1 = "UPDATE chitietdonhang SET masp = NULL WHERE masp = @masp";
                                using (SqlCommand cmdUpdate1 = new SqlCommand(updateForeignKeyQuery1, conn, transaction))
                                {
                                    cmdUpdate1.Parameters.AddWithValue("@masp", masp);
                                    cmdUpdate1.ExecuteNonQuery();
                                }
                                string deleteQuery = "DELETE FROM sanpham WHERE masp = @masp";
                                using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn, transaction))
                                {
                                    cmdDelete.Parameters.AddWithValue("@masp", masp);
                                    cmdDelete.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadForm();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
