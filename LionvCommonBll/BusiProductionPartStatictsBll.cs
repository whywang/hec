using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvCommonBll
{
    public class BusiProductionPartStatictsBll
    {
        private Sys_StatistcPartTypeBll ssptb = new Sys_StatistcPartTypeBll();
        private B_ProductionItemBll bpib = new B_ProductionItemBll();
        public string QueryStatictsProductionPart(string sid)
        {
            StringBuilder r = new StringBuilder();
            List<Sys_StatistcPartType> lt = ssptb.QueryList("");
            if (lt != null)
            {
                foreach (Sys_StatistcPartType t in lt)
                {
                    int n = 0;
                    string[] tjp = t.ttype.Split('|');
                    foreach (string p in tjp)
                    {
                        n = n + bpib.TjItemNum(" and substring(pcode,1,len(pcode)-3) in (select icode from LvErpBase.dbo.Sys_RInventoryStatistcPartType where tcode='" + t.tcode + "') and e_ptype='" + p + "' and sid='" + sid + "'");
                    }
                    if (n > 0)
                    {
                        r.AppendFormat("[{0}]-{1};", t.tname, n);
                    }
                }
            }
            return r.ToString();
        }
    }
}
