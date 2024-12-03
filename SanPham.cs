using Guna.UI2.WinForms;
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
        Guna2Panel panelDetail = new Guna2Panel();
        Label lblInfo = new Label();
        PictureBox pictureBox = new PictureBox();
        private string relativePath;
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        public SanPham()
        {
            InitializeComponent();
            InitializePanel();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            this.Click += SanPham_Click;
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
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
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
                if (control is Guna.UI2.WinForms.Guna2TextBox TextBox)
                {
                    control.Text = string.Empty;
                }
            }
            btnCapnhat.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
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
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            using (conn)
            {
                conn.Open();
                string sql = "Update sanpham Set tensp = @tensp, gia = @gia, anh = @anh, mau = @mau Where masp =@masp";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@masp", masp);
                cmd.Parameters.AddWithValue("@tensp", tensp);
                cmd.Parameters.AddWithValue("@gia", gia);
                cmd.Parameters.AddWithValue("@anh", anh);
                cmd.Parameters.AddWithValue("@mau", mau);
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
        private void SanPham_Click(object sender, EventArgs e)
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
