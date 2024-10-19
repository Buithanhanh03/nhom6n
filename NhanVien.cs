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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
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
        private void CheckInputType()
        {
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
            CheckInputType();

        }
    }
}
