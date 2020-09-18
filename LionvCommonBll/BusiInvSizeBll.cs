using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvCommonBll
{
    public  class BusiInvSizeBll
    {
        private Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
        public Sys_NomalSize RefInvSize(string icode)
        {
            Sys_NomalSize r = new Sys_NomalSize();
            string ncode= snsb.GetProductionNs(icode);
            if(ncode!="")
            {
                r = snsb.Query(" and ncode='" + ncode + "' and nattr='固定'");
            }
            return r;
        }

    }
}
