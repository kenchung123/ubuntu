using System.ComponentModel;

namespace Example_04.Models
{
    public class Class
    {
        public int Id { get; set; }
        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }
        [DisplayName("Tên lớp")]
        public string TenLop { get; set; }
    }
}