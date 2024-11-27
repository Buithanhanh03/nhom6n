using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_ThucTap_LTNET
{
    public static class TempSave
    {
        public static int MaNhanVien { set; get; }
        public static int MaDonHang { set; get; }
        public static int GiamGia { set; get; }
        public static string TaiKhoan { set; get; } //của admin và nhân viên
        public struct ChiTietDonHang
        {
            public int mactdh;
            public int madh;
            public int masp;
            public int dongiadh;
            public int soluongdaban;
            public int tongtienmothang;
        }
        public static string username { set; get; } // của khách
        public class GioHang //sau khi khách thêm các sản phẩm và số lượng vào giỏ
        {
            public int masp;
            public string tensp;
            public int gia;
            public int soluongdaban;
        }
        public static int maqc { set; get; } // của khách

    }
}
