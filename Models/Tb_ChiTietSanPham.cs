//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace baitapcuoimonweb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tb_ChiTietSanPham
    {
        public long ID { get; set; }
        public Nullable<long> IdSanPham { get; set; }
        public string Mau { get; set; }
        public string anh1 { get; set; }
        public string anh2 { get; set; }
        public string anh3 { get; set; }
        public string anh4 { get; set; }
    
        public virtual Tb_SanPham Tb_SanPham { get; set; }
    }
}