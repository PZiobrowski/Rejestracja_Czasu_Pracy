using Microsoft.EntityFrameworkCore;
using RCP.Model;

namespace RCP.Database
{
    public partial class RcpDbContext : DbContext
    {
        private DbSet<Work> Works { get; set; }

        public void AddWork(Work work)
        {
            Works.Add(work);
        }

        public Work GetWorkInProgress(Guid userId)
        {
            return Works.FirstOrDefault(w => w.UserId == userId && w.EndTime == null);
        }

    }
}
