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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_ThucTap_LTNET
{
    public partial class LienHe : Form
    {
        private SqlConnection conn = null;

        string sqlqr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlbh_btl.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection connectdb()
        {
            conn = new SqlConnection(sqlqr);
            return conn;
        }
        public LienHe()
        {
            InitializeComponent();
            conn = connectdb();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập ý kiến của bạn");
                return;
            }
            string username = "chinh1";
            string mota = richTextBox1.Text;
            using (SqlConnection conn = connectdb())
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO lienhe(username, mota) VALUES(@username, @mota)";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@mota", mota);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã gửi ý kiến thành công");
                conn.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
