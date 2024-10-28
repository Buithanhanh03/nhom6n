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
    public partial class HuongDan : Form
    {
        public HuongDan()
        {
            InitializeComponent();
        }

        private void btnBanhang_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "BÁN HÀNG\r\n-B1: Chọn 1 dòng ở bảng trên rồi nhập số lượng muốn mua.\r\n-B2: Ấn nút thêm vào giỏ hàng.\r\n-B3: Ấn nút thanh toán, hệ thống sẽ đưa ra lựa chọn, OK để thanh toán và chuyển tới trang nhập thông tin khách hàng, Cancel\r\nđể trở lại.\r\n-B4: Khi ấn OK, hãy nhập thông tin của khách hàng và ấn nút Nhập, bạn sẽ được chuyển tới trang In hóa đơn.\r\n-B5: Hệ thống sẽ hiển thị ra thông tin của hóa đơn, nếu muốn In, hãy nhấn nút In hóa đơn, nếu không muốn, hãy ấn Thoát.\r\n    + Các chức năng phụ: \r\n\t. Nhấn đúp vào 1 dòng trên bảng Sản phẩm, bạn có thể xem được tên hàng và số lượng đã được bán\r\n\t. Bảng Lịch sử: để xem lại thông tin đơn hàng đã giao dịch.\r\n\t. Nút Reset: Xóa thông tin đã nhập.\r\n\t. Nút Thoát: Thoát khỏi trang hiện tại.";

        }

        private void btnSanpham_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "SẢN PHẨM:\r\nĐể có thể thao tác, bạn cần chọn 1 dòng trên bảng Sản phẩm.\r\n- Sửa: Bạn có thể sửa các thuộc tính của sản phẩm bằng cách nhập vào các trường ở dưới, nếu muốn đổi ảnh hãy nhấn nút\r\nChọn ảnh, bạn sẽ có thể chọn ảnh có sẵn ở trong máy tính. Sau khi đã hoàn tất, hãy ấn Cập nhật. Nếu muốn xóa nhanh các\r\ntrường đã nhập, hãy ấn Reset.\r\n- Xóa: Xóa 1 dòng sản phẩm đã chọn.\r\n- Thoát: Thoát khỏi trang sản phẩm.\r\n- Tìm kiếm theo mã: Hãy nhập mã của sản phẩm và bảng sẽ hiển thị ra sản phẩm tương ứng.\r\n";
        }

        private void btnKhohang_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "KHO HÀNG\r\nĐể có thể thao tác, bạn cần chọn 1 dòng trên bảng Sản phẩm.\r\n- Nhập hàng mới: Bạn cần điền đầy đủ thông tin vào các trường bên dưới, sau đó ấn Cập nhật để có thể nhập 1 mặt hàng mới.\r\nBạn có thể ấn Reset để làm trống các trường.\r\n- Nhập thêm: Điền số lượng muốn nhập thêm cho 1 mặt hàng vào trường Số lượng, sau đó ấn Cập nhật để xác nhận.\r\n- Danh mục: Tìm kiếm các sản phẩm dựa theo danh mục mà bạn chọn.";
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "BÁO CÁO\r\nBạn có thể xem Báo cáo doanh thu hoặc Báo cáo tồn kho.\r\n- In văn bản: Bạn có thể in ra báo cáo tại đây.\r\n- Thoát: Thoát khỏi trang báo cáo.";
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "NHÂN VIÊN:\r\nĐể có thể thao tác, bạn cần chọn 1 dòng trên bảng Nhân viên.\r\n- Thêm: Sau khi đã điền đầy đủ các trường, hãy ấn Thêm để thêm 1 nhân viên mới.\r\n- Cập nhật: Bạn có thể sửa các thuộc tính của sản phẩm bằng cách nhập vào các trường ở dưới. Sau khi đã hoàn tất, hãy ấn Cập nhật.\r\n Nếu muốn xóa nhanh các trường đã nhập, hãy ấn Reset.\r\n- Xóa: Xóa 1 dòng nhân viên đã chọn.\r\n- Thoát: Thoát khỏi trang nhân viên.\r\n- Tìm kiếm theo mã: Hãy nhập mã của nhân viên và bảng sẽ hiển thị ra nhân viên tương ứng.";
        }

        private void btnKhac_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "KHÁCH HÀNG VÀ ĐƠN ĐẶT HÀNG:\r\nBạn có thể xem danh sách tương ứng ở đây.";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
