using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BrowserGame_courseSimbirSoft_.Models.Logger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string path;
        public FileLoggerProvider(string _path)
        {
            path = _path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }
        public void Dispose()
        {

        }
    }
}
