﻿using System;
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
        private void HuongDan_Load(object sender, EventArgs e)
        {
            if (TempSave.TaiKhoan == "admin")
            {
                guna2GroupBox2.Enabled = true;
            }
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
            richTextBox1.Text = "BÁO CÁO\r\nChỉ admin mới có thể xem Báo cáo doanh thu hoặc Báo cáo tồn kho.\r\nCác chưc năng gồm:\r\n- In văn bản: Bạn có thể in ra báo cáo tại đây.\r\n- Thoát: Thoát khỏi trang báo cáo.";
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "NHÂN VIÊN:\r\nChỉ admin mới có thể chỉnh sửa.\r\nĐể có thể thao tác, bạn cần chọn 1 dòng trên bảng Nhân viên.\r\n- Thêm: Sau khi đã điền đầy đủ các trường, hãy ấn Thêm để thêm 1 nhân viên mới.\r\n- Cập nhật: Bạn có thể sửa các thuộc tính của sản phẩm bằng cách nhập vào các trường ở dưới. Sau khi đã hoàn tất, hãy ấn Cập nhật.\r\n Nếu muốn xóa nhanh các trường đã nhập, hãy ấn Reset.\r\n- Xóa: Xóa 1 dòng nhân viên đã chọn.\r\n- Thoát: Thoát khỏi trang nhân viên.\r\n- Tìm kiếm theo mã: Hãy nhập mã của nhân viên và bảng sẽ hiển thị ra nhân viên tương ứng.";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXulydonhang(object sender, EventArgs e)
        {
            richTextBox1.Text = "XỬ LÝ ĐƠN HÀNG:\r\nNgười dùng có thể xem danh sách các đơn hàng tại đây. Chỉ admin mới có thể chỉnh sửa.\r\nAdmin có thể chỉnh sửa các thuộc tính sau của một đơn hàng khi chọn đối tượng trên bảng:\r\n- Bổ sung nhân viên phụ trách.\r\n- Đặt ngày giao hàng dự kiến.";
        }

        private void btnLichlamviec(object sender, EventArgs e)
        {
            richTextBox1.Text = "LỊCH LÀM VIỆC:\r\nNgười dùng có thể xem lịch làm việc tại đây. Chỉ admin mới có thể chỉnh sửa.\r\nAdmin có thể chỉnh sửa thời gian nhân viên làm việc bằng cách ấn vào ô muốn sửa.";
        }

        private void btnChoigame_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "CHƠI GAME:\r\nChỉ nhân viên mới có thể chơi game, còn admin hãy đi làm việc đi.\r\nNhân viên có thể chơi game oẳn tù tì (cực khó) với máy. Mỗi khi thắng sẽ được 1 điểm, thua sẽ bị trừ 1 điểm. Nhân viên có\r\nthể ấn nút đổi quà tương ứng khi đã đạt số điểm cần thiết. Phần quà rất hứa hẹn, hãy chơi ngay.";
        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "KHÁCH HÀNG:\r\nBạn có thể xem danh sách khách hàng ở đây.";
        }

        private void btnLichsunhaphang_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "LỊCH SỬ NHẬP HÀNG:\r\nBạn có thể xem danh sách Lịch sử nhập hàng ở đây.";

        }

        private void btnChuongtrinhgiamgia_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "QUẢN LÝ CHƯƠNG TRÌNH GIẢM GIÁ:\r\nAdmin có thể xem danh sách các đơn hàng tại đây.\r\nAdmin có thể chỉnh sửa hoặc xóa các thuộc tính sau của một phiếu giảm giá khi chọn đối tượng trên bảng:\r\nCác thuộc tính có thể sửa đổi: Tên phiếu, Mô tả, Lần sử dụng còn lại, Giá trị giảm giá";
        }

        

        private void btnXemphanhoi_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "XEM THÔNG TIN PHẢN HỒI:\r\nAdmin có thể xem danh sách các thông tin phản hồi từ khách hàng tại đây.\r\nAdmin có thể chỉnh sửa hoặc xóa các thuộc tính sau của một thông tin phản hồi khi chọn đối tượng trên bảng:\r\nCác thuộc tính có thể sửa đổi: Mô tả của khách hàng";
        }

        private void btnQuangcao_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "QUẢN LÝ CHƯƠNG TRÌNH GIẢM GIÁ:\r\nAdmin có thể xem danh sách các quảng cáo tại đây.\r\nAdmin có thể chỉnh sửa hoặc xóa các thuộc tính sau của một quảng cáo khi chọn đối tượng trên bảng:\r\nCác thuộc tính có thể sửa đổi: Tên QC, Mô tả, Ngày bắt đầu, ngày kết thúc";
        }

        private void btnQuanlytaikhoankhachhang_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "QUẢN LÝ TÀI KHOẢN KHÁCH HÀNG:\r\nAdmin có thể xem danh sách các thông tin tài khoản khách hàng tại đây.\r\nAdmin có thể chỉnh sửa hoặc xóa các thuộc tính sau của một tài khoản khách hàng khi chọn đối tượng trên bảng:\r\nCác thuộc tính có thể sửa đổi: mật khẩu, vip";
        }

    }
}
