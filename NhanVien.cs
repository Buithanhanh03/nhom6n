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
    public partial class NhanVien : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        public NhanVien()
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
                if (ctrl is TextBox && string.IsNullOrWhiteSpace(ctrl.Text) || ctrl is RichTextBox && string.IsNullOrWhiteSpace(ctrl.Text))
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
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox || control is RichTextBox)
                {
                    control.Text = string.Empty;
                }
            }
            comboBoxChucvu.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (EmptyTextbox() == false)
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if (IsInteger(txtManv.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho mã nhân viên");
                return;
            }
            if (IsInteger(txtSdt.Text) == false)
            {
                MessageBox.Show("Không thể nhập kí tự trong số điện thoại");
                return;
            }
            if (comboBoxChucvu.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn chức vụ");
                return;
            }
            int manv = int.Parse(txtManv.Text);
            string tennv = txtTen.Text;
            string chucvu = comboBoxChucvu.SelectedItem.ToString();
            string sdtnv = txtSdt.Text;
            string email = txtEmail.Text;
            string diachinv = txtDiachi.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            using (SqlConnection conn = connectdb())
            {
                SqlCommand command = new SqlCommand("SELECT COUNT (*) FROM nhanvien WHERE manv = @manv", conn);

                command.Parameters.AddWithValue("@manv", manv);
                conn.Open();
                int rs = (int)command.ExecuteScalar();
                if (rs > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    return;
                }
                else
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO nhanvien(manv, tennv, chucvu, sdtnv, email, diachinv) VALUES(@manv, @tennv, @chucvu, @sdtnv, @email, @diachinv)";
                    cmd.Parameters.AddWithValue("@manv", manv);
                    cmd.Parameters.AddWithValue("@tennv", tennv);
                    cmd.Parameters.AddWithValue("@chucvu", chucvu);
                    cmd.Parameters.AddWithValue("@sdtnv", sdtnv);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@diachinv", diachinv);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm thành công");
                    LoadForm();
                }
                conn.Close();
            }
        }
        private void LoadForm()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From nhanvien";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void NhanVien_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtManv.Enabled = false;
                btnThem.Enabled = false;
                btnCapnhat.Enabled = true;
                btnXoa.Enabled = false;
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtManv.Text = selectedRow.Cells["manv"].Value.ToString();
                txtTen.Text = selectedRow.Cells["tennv"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["email"].Value.ToString();
                txtSdt.Text = selectedRow.Cells["sdtnv"].Value.ToString();
                txtDiachi.Text = selectedRow.Cells["diachinv"].Value.ToString();
                comboBoxChucvu.SelectedItem = selectedRow.Cells["chucvu"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            //BẮT LỖI:
            if (EmptyTextbox() == false)
            {
                MessageBox.Show("Không được bỏ trống");
                return;
            }
            if (IsInteger(txtManv.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho mã nhân viên");
                return;
            }
            if (IsInteger(txtSdt.Text) == false)
            {
                MessageBox.Show("Không thể nhập kí tự trong số điện thoại");
                return;
            }
            if (comboBoxChucvu.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn chức vụ");
                return;
            }
            //BIẾN:
            int manv = int.Parse(txtManv.Text);
            string tennv = txtTen.Text;
            string chucvu = comboBoxChucvu.SelectedItem.ToString();
            string sdtnv = txtSdt.Text;
            string email = txtEmail.Text;
            string diachinv = txtDiachi.Text;
            //CSDL:
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            using (conn)
            {
                conn.Open();
                string sql = "Update nhanvien Set tennv = @tennv, chucvu = @chucvu, sdtnv = @sdtnv, email = @email, diachinv = @diachinv Where manv =@manv";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.Parameters.AddWithValue("@tennv", tennv);
                cmd.Parameters.AddWithValue("@chucvu", chucvu);
                cmd.Parameters.AddWithValue("@sdtnv", sdtnv);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@diachinv", diachinv);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã sửa thành công");
                conn.Close();
                LoadForm();
                txtManv.Enabled = true;
                btnThem.Enabled = true;
                btnCapnhat.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string manv = dataGridView1.SelectedRows[0].Cells["manv"].Value.ToString();
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
                                string updateForeignKeyQuery = "UPDATE donhang SET manv = NULL WHERE manv = @manv";
                                using (SqlCommand cmdUpdate = new SqlCommand(updateForeignKeyQuery, conn, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@manv", manv);
                                    cmdUpdate.ExecuteNonQuery();
                                }

                                string deleteQuery = "DELETE FROM nhanvien WHERE manv = @manv";
                                using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn, transaction))
                                {
                                    cmdDelete.Parameters.AddWithValue("@manv", manv);
                                    cmdDelete.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string maCanTim = txtTimkiem.Text.Trim();
            if (!string.IsNullOrEmpty(maCanTim)&&IsInteger(txtTimkiem.Text))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"manv = '{maCanTim}'";
            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
