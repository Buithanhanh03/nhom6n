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

namespace BTL_ThucTap_LTNET
{
    public partial class BaoTri : Form
    {
        private SqlConnection conn = null;
        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public BaoTri()
        {
            InitializeComponent();
            conn = connectdb();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Bạn chưa mô tả thông tin phản hồi");
                return;
            }
            string motabt = richTextBox1.Text;
            DateTime ngaydang = DateTime.Now;
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO baotri(motabt, ngaydang) VALUES(@motabt, @ngaydang)";
                cmd.Parameters.AddWithValue("@motabt", motabt);
                cmd.Parameters.AddWithValue("@ngaydang", ngaydang);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Cảm ơn bạn đã gửi thông tin phản hồi. Đội ngũ bảo trì sẽ được gửi tới trong 1 ngày.");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
