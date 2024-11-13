using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BTL_ThucTap_LTNET
{
    public partial class XemLich : Form
    {
        public XemLich()
        {
            InitializeComponent();
        }

        private void XemLich_Load(object sender, EventArgs e)
        {
            if(TempSave.TaiKhoan == "nhanvien")
            {
                btnSua.Enabled = false;
            }
            if (System.IO.File.Exists("dataLich.txt"))
            {
                string[] data = System.IO.File.ReadAllLines("dataLich.txt");
                int index = 0;

                foreach (Control control in tableLayoutPanel1.Controls)
                {
                    if (control is Guna.UI2.WinForms.Guna2TextBox textBox && index < data.Length)
                    {
                        textBox.Text = data[index];
                        index++;
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnCapnhat.Enabled = true;
            btnSua.Enabled = false;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox)
                {
                    control.Enabled = true;
                }
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            btnCapnhat.Enabled = false;
            btnSua.Enabled = true;
            List<string> data = new List<string>();
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox textBox)
                {
                    data.Add(textBox.Text);
                }
            }

            System.IO.File.WriteAllLines("dataLich.txt", data);
        }
    }
}
