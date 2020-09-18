using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace LionvCommon
{
   public class Log4
    {
       
       public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
       public static void WriteLog(string text)
       {
           loginfo.Info(text);
       }
       public static void WriteErrLog(string text)
       {
           loginfo.Error(text);
       }
    }
}
