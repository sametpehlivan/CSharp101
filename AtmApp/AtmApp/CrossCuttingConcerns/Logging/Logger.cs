using System.Text.Json;

namespace CrossCuttingConcerns.Logging
{
    public class Logger : ILogger
    {
        
        public void Log(string userName,string typeName,string result,string message )
        {
            LogObject logObj = new LogObject(){
                    UserName = userName,
                    TypeName = typeName,
                    Result = result,
                    DateTime = DateTime.Now,
                    Message = message
                };
           string logFilePath = "./" +"EOD_" + DateTime.Now.ToString("ddMMyyyy")+".txt";
           if(!(File.Exists(logFilePath)))
           {
                using (FileStream fs = File.Create(logFilePath)) 
                {
                    fs.Dispose();
                }
                File.WriteAllText(logFilePath, "[]");
           }
           string logsString =  File.ReadAllText(logFilePath);
           List<LogObject> logs = JsonSerializer.Deserialize<List<LogObject>>(logsString);
           logs.Add(logObj);
           logsString = JsonSerializer.Serialize(logs);
           File.WriteAllText(logFilePath,logsString);
        }
        public List<LogObject> GetLogs()
        {
            string logFilePath = "./" +"EOD_" + DateTime.Now.ToString("ddMMyyyy")+".txt";
            if(!(File.Exists(logFilePath))) return new List<LogObject>();
            string logsString =  File.ReadAllText(logFilePath);
            return JsonSerializer.Deserialize<List<LogObject>>(logsString);
        }
      
    }
}