using System;
using System.Collections.Generic;
using ArtShop.Framework.Model;

namespace ArtShop.Framework.Logging
{
    public  interface ILoggingService
    {
        void Log(string message);
        void Error(string message);
        void Error(Exception ex);
        void Initialise(int maxLogSize); IList<LogEntry> ListLogFile();
        void Recycle();
        void ClearLogFiles();
    }
}
