using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Model
{
    public interface ILogger
    {
        void Info(string text);
        void Warn(string text);
        void Error(string text);
    }
}
