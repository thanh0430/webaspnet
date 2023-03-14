using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baitapcuoimonweb.Models
{
    public class Cart
    {
        public long SanphamId { get; set; }
        public int soluong { get; set; }
        public Tb_SanPham Sanpham { get; set; }
    }
}