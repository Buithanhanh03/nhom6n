﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_ThucTap_LTNET
{
    static class TempSave
    {
        public static int MaDonHang { set; get; }
        public static int GiamGia { set; get; }
        public static string TaiKhoan { set; get; }
        public struct ChiTietDonHang
        {
            public int mactdh;
            public int madh;
            public int masp;
            public int dongiadh;
            public int soluongdaban;
            public int tongtienmothang;
        }
    }
}
