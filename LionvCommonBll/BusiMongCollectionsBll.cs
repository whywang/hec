using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiMgOrderInfo;

namespace LionvCommonBll
{
    /// <summary>
    /// 调用MongoDB Collections方法集合类
    /// </summary>
   public class BusiMongCollectionsBll
    {
       private VProductionsBll vpb = new VProductionsBll();
       public void MongoSwitch(string proname,string sid)
       {
           switch(proname)
           {
               case "b_resetgnum":
                    ReSetGnum(sid);
                   break;
           }
       }
       private void ReSetGnum(string sid)
       {
            vpb.ReSetGnum(sid);
       }
    }
}
