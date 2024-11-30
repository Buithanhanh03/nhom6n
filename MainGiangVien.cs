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
    public partial class MainGiangVien : Form
    {
        public MainGiangVien()
        {
            InitializeComponent();
        }

        private void btnDetai_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "ĐỀ TÀI: Phần mềm winform quản lý hoạt động kinh doanh của shop đồng phục\r\nLÍ DO CHỌN ĐỀ TÀI\r\nNhu cầu về đồng phục trong các trường học trong khu vực Hà Nội ngày càng lớn, dẫn đến sự phát triển nhanh chóng của các cửa hàng kinh doanh đồng phục. Tuy nhiên, quản lý số lượng lớn đơn hàng, mẫu mã đa dạng và lượng khách hàng lớn trở thành thách thức không nhỏ. Vì thế, việc phát triển một phần mềm quản lý toàn diện cho shop kinh doanh đồng phục sẽ giúp các cửa hàng dễ dàng hơn trong việc quản lý thông tin, theo dõi đơn hàng, kiểm soát tồn kho và tính toán doanh thu. Đề tài này được chọn với mục tiêu cung cấp một giải pháp công nghệ hiệu quả, hỗ trợ tối đa cho hoạt động kinh doanh của các cửa hàng, từ đó cải thiện năng suất và tính chuyên nghiệp.\r\n ";
        }

        private void btnCacthanhvien_Click(object sender, EventArgs e)
        {
            ThongTinUngDung f = new ThongTinUngDung();
            f.ShowDialog();
        }

        private void btnChucnangPT1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "CÁC CHỨC NĂNG ĐÃ PHÁT TRIỂN THEO YÊU CẦU:\r\nChúng em đã phát triển được các chức năng theo yêu cầu của bài tập lớn là:\r\n- Bán hàng\r\n- Thanh toán, lưu đơn hàng và chi tiết đơn hàng\r\n- In hóa đơn thanh toán\r\n- Xem, thêm, sửa, xóa các danh sách cơ bản: Kho hàng, Đơn hàng, Chi tiết đơn hàng, Sản phẩm, Khách hàng, Nhân viên\r\n- Thiết kế giao diện thân thiện với người dùng";
        }

        private void btnChucnangPT2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "CÁC CHỨC NĂNG ĐÃ PHÁT TRIỂN THÊM:\r\nNgoài các chức năng cơ bản đã phát triển, chúng em đã phát triển thêm cho ứng dụng những chức năng sau:\r\n- Phân quyền cho 3 loại người dùng: Admin, Nhân viên và Khách hàng. Trong đó\r\n  + Admin: Có khả năng truy cập và sử dụng mọi chức năng của app. Những chức năng riêng biệt của admin bao gồm:\r\n    . Quản lý nhân viên\r\n    . Quản lý chương trình giảm giá\r\n    . Xem thông tin phản hồi(từ khách hàng)\r\n    . Quản lý quảng cáo\r\n    . Báo cáo doanh thu\r\n    . Báo cáo tồn kho\r\n    . Quản lý tài khoản khách hàng\r\n    . Xem thông tin bảo trì\r\n  + Nhân viên: Phụ trách bán hàng và xử lý các thông tin về:\r\n    . Kho hàng\r\n    . Xử lý đơn hàng\r\n    . Sản phẩm\r\n    . Khách hàng\r\n    . Lịch sử nhập hàng\r\n  + Khách hàng: Có thể truy cập ứng dụng để mua hàng online và sử dụng các chức năng:\r\n    . Các chức năng liên quan tới tài khoản: Đăng nhập, đăng xuất, quên mật khẩu.\r\n    . Đặt hàng\r\n    . Nạp vip (chưa hoàn thiện)\r\n    . Lịch sử mua hàng\r\n    . Chương trình ưu đãi\r\n    . Liên hệ\r\n- Các chức năng phụ bao gồm Xem thông tin ứng dụng, Hướng dẫn, Bảo trì, Chơi game, Lịch làm việc...";
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "NHỮNG HẠN CHẾ, THIẾU SÓT\r\nVì hạn chế trong trình độ và tư duy lập trình của chúng em, bài tập lớn này còn rất nhiều những thiếu sót. Một vài trong số\r\nđó có thể kể đến là:\r\n- Ứng dụng chỉ sử dụng nội bộ, chưa thể hoạt động đồng bộ với nhiều người dùng cùng lúc.\r\n- Khả năng bảo mật kém.\r\n- Các chức năng còn sơ sài, chưa phát triển đầy đủ, nhiều chức năng không thực sự cần thiết.\r\n- Chưa thể xuất các văn bản báo cáo, hóa đơn ra word, excel.\r\n- Chưa có phương tiện thanh toán.\r\n- Code không áp dụng mô hình 3 lớp nên nhiều chỗ lủng củng khó hiểu, gây khó khăn khi bảo trì.\r\n- Chúng em vẫn còn phụ thuộc rất lớn vào ChatGPT.";
        }

        private void btnChucnangmongmuon_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "CÁC CHỨC NĂNG MONG MUỐN ĐƯỢC PHÁT TRIỂN THÊM TRONG TƯƠNG LAI\r\nChúng em mong muốn được khắc phục những hạn chế và thiếu sót, đồng thời muốn phát triển ứng dụng một cách hoàn chỉnh trong tương lai.\r\nCác đề xuất để khắc phục các hạn chế:\r\n- Đồng bộ hóa và hỗ trợ nhiều người dùng cùng lúc: Triển khai ứng dụng trên nền tảng web hoặc sử dụng cơ sở dữ liệu server-client để hỗ trợ truy cập từ nhiều thiết bị, đồng thời áp dụng các phương pháp quản lý kết nối như SignalR hoặc WebSocket để cải thiện tính đồng bộ.\r\n- Cải thiện bảo mật: Sử dụng các phương pháp mã hóa dữ liệu nhạy cảm, thêm chức năng xác thực và phân quyền người dùng, và áp dụng các nguyên tắc bảo mật như bảo vệ chống SQL Injection, sử dụng HTTPS và lưu trữ mật khẩu dưới dạng hash.\r\n- Phát triển thêm các chức năng: Đầu tư thời gian phân tích nhu cầu thực tế để bổ sung các tính năng hữu ích, tối ưu hóa các chức năng hiện có và loại bỏ những chức năng không cần thiết để tránh phức tạp không cần thiết.\r\n- Hỗ trợ xuất báo cáo và hóa đơn: Tích hợp các thư viện hỗ trợ xuất file như Microsoft.Office.Interop.Excel hoặc EPPlus để tạo báo cáo Excel, và iTextSharp để tạo PDF, đảm bảo ứng dụng có khả năng hỗ trợ xử lý văn bản và in ấn.\r\n- Thêm phương tiện thanh toán: Tích hợp các cổng thanh toán trực tuyến phổ biến như MoMo, ZaloPay hoặc thẻ tín dụng thông qua các API dịch vụ.\r\n- Áp dụng mô hình 3 lớp: Tái cấu trúc mã nguồn theo mô hình 3 lớp để tách biệt các thành phần, giúp mã dễ bảo trì và nâng cấp.\r\n- Giảm sự phụ thuộc vào công cụ hỗ trợ: Tăng cường việc nghiên cứu tài liệu chính thống, tìm hiểu sâu về các công nghệ đang sử dụng, và tự giải quyết vấn đề để nâng cao tư duy lập trình.\r\n- Cải thiện giao diện: Thực hiện khảo sát người dùng, lấy ý kiến phản hồi để thiết kế giao diện thân thiện hơn. Đồng thời, áp dụng các tiêu chuẩn UI/UX để hướng dẫn cách sử dụng rõ ràng và dễ hiểu.\r\n\r\nĐể nâng cao khả năng của ứng dụng trong tương lai, chúng em định hướng phát triển thêm các chức năng sau:\r\n- Tích hợp trí tuệ nhân tạo (AI): Áp dụng AI để phân tích dữ liệu người dùng, đưa ra gợi ý sản phẩm/dịch vụ phù hợp hoặc dự đoán xu hướng tiêu dùng.\r\n- Hệ thống quản lý tồn kho nâng cao: Xây dựng chức năng tự động cảnh báo khi hàng tồn kho dưới mức tối thiểu hoặc quá hạn sử dụng, tích hợp mã QR hoặc RFID để quản lý kho nhanh chóng và chính xác.\r\n- Công cụ thống kê và phân tích dữ liệu: Phát triển biểu đồ trực quan và báo cáo phân tích chi tiết nhằm giúp người dùng đánh giá hiệu quả kinh doanh và đưa ra quyết định nhanh chóng.\r\n- Hỗ trợ đa nền tảng: Phát triển ứng dụng trên cả thiết bị di động (Android, iOS) để tăng tính tiện lợi và khả năng tiếp cận của người dùng.\r\n- Chế độ làm việc ngoại tuyến: Xây dựng tính năng lưu trữ tạm thời và đồng bộ dữ liệu khi có kết nối Internet, giúp người dùng làm việc liên tục kể cả khi mất mạng.\r\n- Cải tiến hệ thống khách hàng thân thiết: Xây dựng các chương trình khuyến mãi, tích điểm và đổi quà dành cho khách hàng thân thiết, tích hợp tự động hóa quy trình chăm sóc khách hàng.\r\n- Chatbot hỗ trợ: Phát triển chatbot tự động trả lời các câu hỏi thường gặp hoặc hỗ trợ kỹ thuật, nâng cao trải nghiệm người dùng.\r\n- Tích hợp mạng xã hội: Thêm chức năng chia sẻ sản phẩm hoặc dịch vụ qua các nền tảng mạng xã hội để tăng tính tương tác và quảng bá.\r\n- Tính năng đa ngôn ngữ: Phát triển ứng dụng hỗ trợ nhiều ngôn ngữ để mở rộng đối tượng người dùng, đặc biệt khi ứng dụng có kế hoạch phát triển ra thị trường quốc tế.\r\n- Hỗ trợ thanh toán quốc tế: Mở rộng tích hợp các cổng thanh toán quốc tế như PayPal, Stripe hoặc Visa/Mastercard để đáp ứng nhu cầu của người dùng ở nhiều quốc gia.\r\nNhững tính năng này không chỉ giúp ứng dụng đáp ứng tốt hơn nhu cầu thực tế mà còn nâng cao giá trị và khả năng cạnh tranh trong tương lai.";
        }

        private void btnLoicamon_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "LỜI CẢM ƠN\r\n\r\nNhóm 6 xin gửi lời cảm ơn chân thành và sâu sắc nhất đến thầy Nguyễn Việt Lập và cô Đỗ Thị Hồng Lĩnh, những người đã tận tình hướng dẫn và hỗ trợ chúng em trong quá trình thực hiện bài tập lớn với đề tài: \"Phần mềm WinForm quản lý hoạt động kinh doanh của shop đồng phục\".\r\n\r\nSự tận tâm của thầy cô trong việc chỉ dẫn, góp ý và chia sẻ kinh nghiệm thực tiễn không chỉ giúp chúng em hiểu rõ hơn về cách áp dụng lý thuyết vào thực hành mà còn trang bị thêm nhiều kỹ năng cần thiết cho việc phát triển phần mềm. Nhờ có sự hỗ trợ từ thầy cô, nhóm đã vượt qua nhiều khó khăn và hoàn thành bài tập lớn này với những kết quả tích cực.\r\n\r\nChúng em cũng xin gửi lời cảm ơn chân thành đến các bạn cùng lớp, những người đã luôn nhiệt tình hỗ trợ, chia sẻ kinh nghiệm và góp ý hữu ích trong suốt quá trình làm việc. Sự đồng hành và động viên từ các bạn đã tiếp thêm động lực để nhóm hoàn thành bài tập này tốt hơn.\r\n\r\nNhóm cũng xin cảm ơn ChatGPT, công cụ hỗ trợ đã cung cấp nhiều thông tin hữu ích, giải đáp các thắc mắc và giúp nhóm định hướng rõ ràng hơn trong quá trình phát triển dự án.\r\n\r\nMặc dù bài tập vẫn còn những thiếu sót, nhưng chúng em tin rằng những kinh nghiệm quý báu và kiến thức thu được từ thầy cô, các bạn cùng lớp và công cụ hỗ trợ sẽ là hành trang giá trị cho sự phát triển của chúng em trong tương lai.\r\n\r\nMột lần nữa, nhóm 6 xin chân thành cảm ơn tất cả. Kính chúc thầy cô sức khỏe, các bạn thành công trong học tập !!!\r\n\r\nNhóm 6\r\n\r\nCác thành viên\r\n- Bùi Thanh Anh\r\n- Đặng Nhân Chính\r\n- Phạm Lê Công\r\n- Lê Anh Quân";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
