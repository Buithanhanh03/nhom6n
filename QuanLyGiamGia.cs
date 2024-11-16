using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BTL_ThucTap_LTNET
{
    public partial class QuanLyGiamGia : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public QuanLyGiamGia()
        {
            InitializeComponent();
            conn = connectdb();
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
        private void LoadForm()
        {
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From phieugiamgia";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Quanlygiamgia_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox)
                {
                    control.Text = string.Empty;
                }
            }
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnCapnhat.Enabled = false;
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string magiamgia = txtTimkiem.Text;
            conn = connectdb();
            conn = new SqlConnection(sqlqr);
            string sql = "Select * From phieugiamgia Where magiamgia LIKE @magiamgia";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@magiamgia", "%" + magiamgia + "%");

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
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
            if (IsInteger(txtMaphieu.Text) == false)
            {
                MessageBox.Show("Hãy nhập số cho mã phiếu");
                return;
            }
            if (IsInteger(txtLansd.Text) == false || int.Parse(txtLansd.Text) <= 0)
            {
                MessageBox.Show("Hãy nhập số nguyên dương cho số lần sử dụng");
                return;
            }
            if (IsInteger(txtGiatri.Text) == false || int.Parse(txtGiatri.Text) <= 0)
            {
                MessageBox.Show("Hãy nhập số nguyên dương cho giá trị giảm giá");
                return;
            }
            int magiamgia = int.Parse(txtMaphieu.Text);
            string tenphieu = txtTenphieu.Text;
            string mota = txtMota.Text;
            int lansudung = int.Parse(txtLansd.Text);
            int giamgia = int.Parse(txtGiatri.Text);
            using (conn = connectdb())
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM phieugiamgia WHERE magiamgia = @magiamgia", conn);
                command.Parameters.AddWithValue("@magiamgia", magiamgia);
                int rs = (int)command.ExecuteScalar();

                if (rs > 0)
                {
                    MessageBox.Show("Mã phiếu đã tồn tại!");
                }
                else
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO phieugiamgia(magiamgia, tenphieu, mota, lansudung, giamgia) VALUES(@magiamgia, @tenphieu, @mota, @lansudung, @giamgia)";
                    cmd.Parameters.AddWithValue("@magiamgia", magiamgia);
                    cmd.Parameters.AddWithValue("@tenphieu", tenphieu);
                    cmd.Parameters.AddWithValue("@mota", mota);
                    cmd.Parameters.AddWithValue("@lansudung", lansudung);
                    cmd.Parameters.AddWithValue("@giamgia", giamgia);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm thành công");
                    LoadForm();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtMaphieu.Enabled = false;
                btnThem.Enabled = false;
                btnCapnhat.Enabled = true;
                btnXoa.Enabled = false;
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtMaphieu.Text = selectedRow.Cells["magiamgia"].Value.ToString();
                txtTenphieu.Text = selectedRow.Cells["tenphieu"].Value.ToString();
                txtMota.Text = selectedRow.Cells["mota"].Value.ToString();
                txtLansd.Text = selectedRow.Cells["lansudung"].Value.ToString();
                txtGiatri.Text = selectedRow.Cells["giamgia"].Value.ToString();
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
            if (IsInteger(txtLansd.Text) == false || int.Parse(txtLansd.Text) <= 0)
            {
                MessageBox.Show("Hãy nhập số nguyên dương cho số lần sử dụng");
                return;
            }
            if (IsInteger(txtGiatri.Text) == false || int.Parse(txtGiatri.Text) <= 0)
            {
                MessageBox.Show("Hãy nhập số nguyên dương cho giá trị giảm giá");
                return;
            }
            int magiamgia = int.Parse(txtMaphieu.Text);
            string tenphieu = txtTenphieu.Text;
            string mota = txtMota.Text;
            int lansudung = int.Parse(txtLansd.Text);
            int giamgia = int.Parse(txtGiatri.Text);
            using (conn = connectdb())
            {
                conn.Open();
                string sql = "Update phieugiamgia Set tenphieu = @tenphieu, mota = @mota, lansudung = @lansudung, giamgia = @giamgia Where magiamgia = @magiamgia";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@magiamgia", magiamgia);
                cmd.Parameters.AddWithValue("@tenphieu", tenphieu);
                cmd.Parameters.AddWithValue("@mota", mota);
                cmd.Parameters.AddWithValue("@lansudung", lansudung);
                cmd.Parameters.AddWithValue("@giamgia", giamgia);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã sửa thành công");
                conn.Close();
                LoadForm();
                txtMaphieu.Enabled = true;
                btnThem.Enabled = true;
                btnCapnhat.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string magiamgia = dataGridView1.SelectedRows[0].Cells["magiamgia"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu giảm giá này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (conn = connectdb())
                    {
                        conn.Open();
                        string sql = "Delete From phieugiamgia Where magiamgia = @magiamgia";
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@magiamgia", magiamgia);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa thành công");
                        conn.Close();
                        LoadForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
