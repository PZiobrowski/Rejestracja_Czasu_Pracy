﻿using RCP.Database;
using RCP.Model;

namespace RCP.Managers
{
    public class WorktimeManager : IWorktimeManager
    {
        private readonly RcpDbContext _context;

        public WorktimeManager(RcpDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Rozpoczęcie pracy
        /// </summary>
        /// <param name="userId">Identyfikator użytkownika rozpoczynającego pracę</param>
        public string StartWork(Guid userId)
        {
            var existingWork = _context.GetWorkInProgress(userId);
            if (existingWork != null)
                return Messages.WorkInProgress;

            _context.AddWork(new Work
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
            var existingWork = _context.GetWorkInProgress(userId);
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
            var existingBreak = _context.GetBreakInProgress(userId);
            if (existingBreak != null)
                return Messages.BreakInProgress;

            _context.AddBreak(new Break
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
            var existingBreak = _context.GetBreakInProgress(userId);
            if (existingBreak == null)
                return Messages.BreakNotStarted;

            existingBreak.EndBreak();

            _context.SaveChanges();

            return Messages.StopBreak;
        }

    }
}
