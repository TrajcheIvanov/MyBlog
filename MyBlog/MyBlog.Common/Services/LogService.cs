using Microsoft.Extensions.Configuration;
using MyBlog.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyBlog.Common.Services
{
    public class LogService : ILogService
    {
        private string _fliePath;

        public LogService(IConfiguration congiguration)
        {
            // this means if "LogFilePath" exist than use it , if not then use Logs.txt
            _fliePath = congiguration["LogFilePath"] ?? "Logs.txt";
        }
        public void Log(LogData logData)
        {
            switch (logData.Type)
            {
                case LogType.Info:
                    File.AppendAllLines($"Info_{ DateTime.Now.ToString("yyyy_MM_dd")}_{_fliePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                case LogType.Warning:
                    File.AppendAllLines($"Warning{ DateTime.Now.ToString("yyyy_MM_dd")}_{_fliePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                case LogType.Error:
                    File.AppendAllLines($"Error{ DateTime.Now.ToString("yyyy_MM_dd")}_{_fliePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                default:
                    throw new NotImplementedException(logData.Type.ToString());
            }
        }
    }
}
