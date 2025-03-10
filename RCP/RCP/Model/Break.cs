namespace RCP.Model
{
    /// <summary>
    /// Przerwa
    /// </summary>
    public class Break
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public Guid UserId { get; set; }

        public void EndBreak()
        {
            EndTime = DateTime.UtcNow;
        }

    }
}
