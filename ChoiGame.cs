using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_ThucTap_LTNET
{
    public partial class ChoiGame : Form
    {
        public ChoiGame()
        {
            InitializeComponent();
        }

        private string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private Random random = new Random();

        // Phương thức kết nối cơ sở dữ liệu
        private SqlConnection connectdb()
        {
            return new SqlConnection(sqlqr);
        }

        // Sự kiện LoadForm
        private void ChoiGame_Load(object sender, EventArgs e)
        {
            LoadDiemVaTen();
            LoadBangXepHang();
        }

        // Tải tên và điểm của nhân viên
        private void LoadDiemVaTen()
        {
            using (SqlConnection conn = connectdb())
            {
                string query = "SELECT tennv, diem FROM nhanvien WHERE manv = @manv";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manv", TempSave.MaNhanVien);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string tennv = reader["tennv"].ToString();
                    int diem = Convert.ToInt32(reader["diem"]);
                    guna2GroupBox2.Text = tennv;
                    lblDiem.Text = diem.ToString();
                }
                reader.Close();
            }
        }

        // Tải bảng xếp hạng nhân viên
        private void LoadBangXepHang()
        {
            using (SqlConnection conn = connectdb())
            {
                string query = "SELECT manv, tennv, diem FROM nhanvien ORDER BY diem DESC";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        // Cập nhật điểm khi thắng
        private void CapNhatDiem(int index)
        {
            using (SqlConnection conn = connectdb())
            {
                conn.Open();
                string sql = "UPDATE nhanvien SET diem = diem + @index WHERE manv = @manv";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", TempSave.MaNhanVien);
                cmd.Parameters.AddWithValue("@index", index);
                cmd.ExecuteNonQuery();
            }
        }

        // Cập nhật điểm khi thua
        private void CapNhatDiemSauMuaQua(int index)
        {
            using (SqlConnection conn = connectdb())
            {
                conn.Open();
                string sql = "UPDATE nhanvien SET diem = diem - @index WHERE manv = @manv";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", TempSave.MaNhanVien);
                cmd.Parameters.AddWithValue("@index", index);
                cmd.ExecuteNonQuery();
            }
        }

        // Các sự kiện của các nút chơi game
        private void btnRock_Click(object sender, EventArgs e)
        {
            PlayGame(0);
        }

        private void btnScissor_Click(object sender, EventArgs e)
        {
            PlayGame(1);
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            PlayGame(2);
        }

        private void PlayGame(int userChoice)
        {
            int cpu = random.Next(0, 3);
            int diemthaydoi = 0;
            string result = "";

            if (cpu == 0)
            {
                result = "hòa!!";
                guna2CirclePictureBox1.Image = Properties.Resources.rock;
            }
            if (cpu == 1)
            {
                result = userChoice == 0 ? "hòa!!" : userChoice == 2 ? "thắng!!" : "thua!!";
                guna2CirclePictureBox1.Image = Properties.Resources.scissor;
                diemthaydoi = (userChoice == 2 ? 1 : (userChoice == 0 ? 0 : -1));
            }
            if (cpu == 2)
            {
                result = userChoice == 0 ? "thua!!" : userChoice == 1 ? "thắng!!" : "hòa!!";
                guna2CirclePictureBox1.Image = Properties.Resources.paper;
                diemthaydoi = (userChoice == 1 ? 1 : (userChoice == 0 ? -1 : 0));
            }

            lblResult.Text = result;
            lblResult.ForeColor = (diemthaydoi > 0) ? Color.Green : (diemthaydoi < 0) ? Color.Red : Color.Black;

            CapNhatDiem(diemthaydoi);
            LoadDiemVaTen();
            LoadBangXepHang();
        }

        // Các sự kiện mua quà
        private void btnQuanho_Click(object sender, EventArgs e)
        {
            CapNhatDiemSauMuaQua(15);
            ProcessGift("2h làm việc không công");
        }

        private void btnQuaTB_Click(object sender, EventArgs e)
        {
            CapNhatDiemSauMuaQua(50);
            ProcessGift("trừ 500k tiền lương");
        }

        private void btnQuato_Click(object sender, EventArgs e)
        {
            CapNhatDiemSauMuaQua(100);
            ProcessGift("đơn xin thôi việc miễn phí có giới hạn thời gian nộp");
        }

        private void ProcessGift(string phanthuong)
        {
            MessageBox.Show($"Chúc mừng bạn đã nhận được {phanthuong}.");
            LoadDiemVaTen();
            LoadBangXepHang();
        }
    }
}
