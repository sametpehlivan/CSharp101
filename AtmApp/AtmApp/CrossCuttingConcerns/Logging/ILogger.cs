namespace CrossCuttingConcerns.Logging
{
    public interface ILogger 
    {
        void Log(string userName,string typeName,string result,string message);
        List<LogObject> GetLogs();
    }
}