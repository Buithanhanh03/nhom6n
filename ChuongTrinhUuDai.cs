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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BTL_ThucTap_LTNET
{
    public partial class ChuongTrinhUuDai : Form
    {
        private SqlConnection conn = null;
        private Timer blinkTimer; // Timer để thực hiện nhấp nháy
        private List<Label> labels; // Danh sách Label để đổi màu
        private bool isColor1 = true; // Biến trạng thái để kiểm soát màu

        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public ChuongTrinhUuDai()
        {
            InitializeComponent();
            conn = connectdb();

            // Khởi tạo danh sách Label và Timer
            labels = new List<Label>();
            blinkTimer = new Timer
            {
                Interval = 500 // Đặt thời gian nhấp nháy (500ms)
            };
            blinkTimer.Tick += BlinkTimer_Tick;
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            // Đổi màu tất cả các Label
            foreach (var label in labels)
            {
                label.ForeColor = isColor1 ? Color.Red : Color.Blue;
            }
            isColor1 = !isColor1; // Đảo trạng thái màu
        }

        private void ChuongTrinhUuDai_Load(object sender, EventArgs e)
        {
            string query = @"
            SELECT tenqc, motaqc 
            FROM quangcao 
            WHERE @Today BETWEEN ngaybatdau AND ngayketthuc";

            try
            {
                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Today", DateTime.Now.Date);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int y = 100;

                            while (reader.Read())
                            {
                                string tenqc = reader["tenqc"].ToString();
                                string motaqc = reader["motaqc"].ToString();

                                Label label = new Label
                                {
                                    Text = $"{tenqc}: {motaqc}",
                                    AutoSize = true,
                                    Font = new Font("Arial", 8, FontStyle.Regular)
                                };

                                int labelWidth = TextRenderer.MeasureText(label.Text, label.Font).Width;
                                int centerX = (guna2GroupBox1.Width - labelWidth) / 2;

                                label.Location = new Point(centerX, y); // Đặt tọa độ cho Label

                                guna2GroupBox1.Controls.Add(label); // Thêm Label vào GroupBox
                                labels.Add(label); // Thêm Label vào danh sách để đổi màu
                                y += label.Height + 20; // Tăng vị trí y cho Label tiếp theo, cách nhau 20px
                            }
                        }
                    }
                }

                // Bắt đầu Timer sau khi thêm các Label
                if (labels.Count > 0)
                {
                    blinkTimer.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
