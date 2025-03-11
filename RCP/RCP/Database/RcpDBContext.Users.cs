using Microsoft.EntityFrameworkCore;
using RCP.Model;

namespace RCP.Database
{
    public partial class RcpDbContext : DbContext
    {
        private DbSet<User> Users { get; set; }

    }
}
