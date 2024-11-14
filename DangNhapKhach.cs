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
    public partial class DangNhapKhach : Form
    {
        public DangNhapKhach()
        {
            InitializeComponent();
        }

        private void btnGhetham_Click(object sender, EventArgs e)
        {
            MainOnline f = new MainOnline();
            f.ShowDialog();
            this.Close();
        }
    }

}
