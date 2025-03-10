namespace RCP.Model
{
    /// <summary>
    /// Praca
    /// </summary>
    public class Work
    {
        public int Id { get; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public Guid UserId { get; set; }

        public void EndWork()
        {
            EndTime = DateTime.UtcNow;
        }

    }
}
