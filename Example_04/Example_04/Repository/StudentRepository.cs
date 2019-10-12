using Example_04.Models;

namespace Example_04.Repository
{
    public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        public StudentRepository(SChoolDbContext context) : base(context)
        {
        }
    }
}