using Example_04.Models;

namespace Example_04.Repository
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(SChoolDbContext context) : base(context)
        {
        }
    }
}