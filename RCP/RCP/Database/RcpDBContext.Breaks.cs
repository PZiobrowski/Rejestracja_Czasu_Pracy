using Microsoft.EntityFrameworkCore;
using RCP.Model;

namespace RCP.Database
{
    public partial class RcpDbContext : DbContext
    {
        private DbSet<Break> Breaks { get; set; }

        public void AddBreak(Break _break)
        {
            Breaks.Add(_break);
        }

        public Break GetBreakInProgress(Guid userId)
        {
            return Breaks.FirstOrDefault(w => w.UserId == userId && w.EndTime == null);
        }

    }
}
