namespace RCP.Managers
{
    public interface IWorktimeManager
    {

        public string StartWork(Guid userId);

        public string StopWork(Guid userId);

        public string StartBreak(Guid userId);

        public string StopBreak(Guid userId);
    }
}
