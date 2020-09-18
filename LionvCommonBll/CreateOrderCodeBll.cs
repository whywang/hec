using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvCommonBll
{
   public class CreateOrderCodeBll
   {
       #region//预定单编号
       public string SetCustomerOrderCode()
       {
           string r = "";
           r = "Y"+DateTime.Now.ToString("yyyyMMddHHmmss");
           return r;
       }
       #endregion
   }
}
