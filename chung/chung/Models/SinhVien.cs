using System;
using System.Collections.Generic;

namespace chung.Models
{
    public partial class SinhVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public int IdLop { get; set; }

        public virtual Lop IdLopNavigation { get; set; }
    }
}
