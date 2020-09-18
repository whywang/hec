using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvCommonBll
{
   public class BusiProductionBll
   {
       private B_GroupProductionBll bgpb = new B_GroupProductionBll();
       #region//检验产品是否为套产品
       public string CheckProductionType(int n, string sid)
       {
          string r = "";
          B_GroupProduction bg= bgpb.Query(" and gnum=" + n + " and sid='" + sid + "'");
          r = bg.itype;
          return r;
       }
       #endregion
   }
}
