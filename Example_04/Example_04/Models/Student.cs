using System.ComponentModel;
namespace Example_04.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("Mã sinh viên")]
        public string MaSv { get; set; }
        [DisplayName("Họ và tên")]
        public string HoTen { get; set; }
    }
}