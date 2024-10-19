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
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }

        public bool EmptyTextbox()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox && string.IsNullOrWhiteSpace(ctrl.Text))
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
        private void CheckInputType()
        {
            if (IsInteger(txtMa.Text) == false)
            {
                MessageBox.Show("Mã sản phẩm chỉ có thể nhập kiểu số nguyên");
                return;
            }
            if (IsInteger(txtMadm.Text) == false)
            {
                MessageBox.Show("Mã danh mục chỉ có thể nhập kiểu số nguyên");
                return;
            }
            if (IsInteger(txtSize.Text) == false)
            {
                MessageBox.Show("Size chỉ có thể nhập kiểu số nguyên");
                return;
            }
            if (IsInteger(txtGia.Text) == false)
            {
                MessageBox.Show("Giá chỉ có thể nhập kiểu số nguyên");
                return;
            }
            if (IsInteger(txtTonkho.Text) == false)
            {
                MessageBox.Show("Tồn kho chỉ có thể nhập kiểu số nguyên");
                return;
            }
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
            CheckInputType();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }

        }
    }
}
