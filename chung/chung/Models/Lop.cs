using System;
using System.Collections.Generic;

namespace chung.Models
{
    public partial class Lop
    {
        public Lop()
        {
            SinhVien = new HashSet<SinhVien>();
        }

        public int Id { get; set; }
        public string HoTen { get; set; }

        public virtual ICollection<SinhVien> SinhVien { get; set; }
    }
}
