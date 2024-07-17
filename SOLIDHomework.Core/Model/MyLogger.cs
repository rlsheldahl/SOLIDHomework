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
    public class MyLogger
    {
        private readonly string filePath;

        public MyLogger()
        {
            filePath = ConfigurationManager.AppSettings["LogPath"];
        }

        public void Write(string text)
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
