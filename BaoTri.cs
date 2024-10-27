using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_ThucTap_LTNET
{
    public partial class BaoTri : Form
    {
        public BaoTri()
        {
            InitializeComponent();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Bạn chưa mô tả thông tin phản hồi");
                return;
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
