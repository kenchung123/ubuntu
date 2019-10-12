using Bai04.Models;

namespace Bai04.Services
{
    public class Repository : IStudent

    {
        private Bai4DbContext _bai4DbContext;

        public Repository(Bai4DbContext bai4DbContext)
        {
            _bai4DbContext = bai4DbContext;
        }
        public Student Create(Student student)
        {
            _bai4DbContext.Students.Add(student);
            _bai4DbContext.SaveChanges();
            return student;
        }
    }
}