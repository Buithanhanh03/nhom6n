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
    public partial class HuongDanKhach : Form
    {
        public HuongDanKhach()
        {
            InitializeComponent();
        }

        private void btnDathang_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "ĐẶT HÀNG:\r\nNgười dùng nhập số lượng của sản phẩm muốn mua rồi thêm vào giỏ hàng.";
        }

        private void btnGiohang_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "GIỎ HÀNG:\r\n- Người dùng có thể xem các sản phẩm đã được thêm vào giỏ hàng tại đây\r\n- Nếu không ưng ý, người dùng có thể ấn nút X màu đỏ để loại bỏ những sản phẩm không muốn mua nữa\r\n- Nếu đã vừa ý, người dùng ấn thanh toán để thanh toán, hệ thống sẽ hỏi người dùng một lần nữa. Nếu đồng ý sẽ được chuyển tới trang In hóa đơn, người dùng có thể in hóa đơn hoặc không.\r\n- Người dùng có thể nhập mã giảm giá hợp lệ để được giảm giá.";
        }

        private void btnNapvip_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "NẠP VIP(THỬ NGHIỆM):\r\nNgười dùng có thể nạp tiền cho tài khoản trên màn hình để được ưu đãi thành viên, giá trị ưu đãi tương ứng với mức nạp.";
        }

        private void btnTaikhoan_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "TÀI KHOẢN:\r\nNgười dùng có thể thay đổi các thông tin tài khoản và cá nhân tại đây";
        }

        private void btnUudai_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "CHƯƠNG TRÌNH ƯU ĐÃI:\r\nNgười dùng có thể xem các quảng cáo về chương trình ưu đãi tại đây";
        }

        private void btnLichsumuahang_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "LỊCH SỬ MUA HÀNG:\r\nNgười dùng có thể xem danh sách các đơn hàng của mình đã mua tại đây. Có thể ấn đúp vào 1 đơn hàng để xem chi tiết của nó.";
        }

        private void btnLienhe_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "KHÁCH HÀNG LIÊN HỆ:\r\nNgười dùng có thể gửi phản hồi của mình đến cửa hàng.";
        }

        private void btnDanhgia_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "ĐÁNH GIÁ SẢN PHẨM:\r\nTại Gian trưng bày, người dùng có thể đánh giá sản phẩm bằng cách bấm vào hình ngôi sao ở dưới các sản phẩm(Hãy bấm 5 sao!!!)";
        }
    }
}
