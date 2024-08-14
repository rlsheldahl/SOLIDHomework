using SOLIDHomework.Core.Builder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SOLIDHomework.Core.Model
{
    public class MyLogger : ILogger
    {
        private readonly string filePath;

        public MyLogger()
        {
            filePath = ConfigurationManager.AppSettings["LogPath"];
        }

        public void Info(string text)
        {
            WriteToFile(text);
        }
        public void Warn(string text)
        {
            WriteToFile(text);
        }
        public void Error(string text)
        {
            WriteToFile(text);
        }

        private void WriteToFile(string text)
        {
            using (Stream file = File.OpenWrite(filePath))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}
