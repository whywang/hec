using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace LionVERP.SignalR
{
    public class SingalRSend
    {
         private Thread m_hreadCycle = null;
         private PushHub m_MySingal = null;
         public SingalRSend()
         {
             m_MySingal = new PushHub();
             m_hreadCycle = new Thread(ThreadCycle);
             m_hreadCycle.Start();
             m_hreadCycle.IsBackground = true;
         }
         private int m_Index = 0;
         private void ThreadCycle()
         {
             while (true)
             {
                 m_Index++;
                 m_MySingal.SendMessage();
                 Thread.Sleep(1000);
             }
         }
        ~SingalRSend()
        {
            m_hreadCycle.Abort();
        }
    }
}