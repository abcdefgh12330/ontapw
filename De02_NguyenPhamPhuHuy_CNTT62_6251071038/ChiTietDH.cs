//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace De02_NguyenPhamPhuHuy_CNTT62_6251071038
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDH
    {
        public string MaDonHang { get; set; }
        public string MaChiTietSP { get; set; }
        public Nullable<int> SoLuongMua { get; set; }
        public Nullable<long> DonGiaBan { get; set; }
    
        public virtual ChiTietSPBan ChiTietSPBan { get; set; }
        public virtual DonHang DonHang { get; set; }
    }
}
