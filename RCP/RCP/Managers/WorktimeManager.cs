using RCP.Database;
using RCP.Model;

namespace RCP.Managers
{
    public class WorktimeManager : IWorktimeManager
    {
        private readonly RcpDBContext _context;

        public WorktimeManager(RcpDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Rozpoczęcie pracy
        /// </summary>
        /// <param name="userId">Identyfikator użytkownika rozpoczynającego pracę</param>
        public string StartWork(Guid userId)
        {
            var existingWork = _context.Works.FirstOrDefault(w => w.UserId == userId && w.EndTime == null);
            if (existingWork != null)
                return Messages.WorkInProgress;

            _context.Works.Add(new Work
            { 
                StartTime = DateTime.UtcNow, UserId = userId 
            });

            _context.SaveChanges();

            return Messages.StarkWork;
        }

        /// <summary>
        /// Zakończenie pracy
        /// </summary>
        /// <param name="userId">Identyfikator użytkownika kończącego pracę</param>
        public string StopWork(Guid userId)
        {
            var existingWork = _context.Works.FirstOrDefault(w => w.UserId == userId && w.EndTime == null);
            if (existingWork == null)
                return Messages.WorkNotStarted;

            existingWork.EndWork();

            _context.SaveChanges();

            return Messages.StopWork;
        }

        /// <summary>
        /// Rozpoczęcie przerwy
        /// </summary>
        /// <param name="userId">Identyfikator użytkownika rozpoczynającego przerwę</param>
        public string StartBreak(Guid userId)
        {
            var existingBreak = _context.Breaks.FirstOrDefault(w => w.UserId == userId && w.EndTime == null);
            if (existingBreak != null)
                return Messages.BreakInProgress;

            _context.Breaks.Add(new Break
            {
                StartTime = DateTime.UtcNow,
                UserId = userId
            });

            _context.SaveChanges();

            return Messages.StarkBreak;
        }

        /// <summary>
        /// Zakończenie przerwy
        /// </summary>
        /// <param name="userId">Identyfikator użytkownika kończącego przerwę</param>
        public string StopBreak(Guid userId)
        {
            var existingBreak = _context.Breaks.FirstOrDefault(w => w.UserId == userId && w.EndTime == null);
            if (existingBreak == null)
                return Messages.BreakNotStarted;

            existingBreak.EndBreak();

            _context.SaveChanges();

            return Messages.StopBreak;
        }

    }
}
