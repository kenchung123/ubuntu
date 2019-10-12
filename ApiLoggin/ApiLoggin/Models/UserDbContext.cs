using Microsoft.EntityFrameworkCore;

namespace ApiLoggin.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {}
        public DbSet<LogginModel> User{ get; set; }
        public DbSet<RequestTransferWork> TransferWork { get; set; }
   
    }
}