using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.FuncitonInfo;
using LionvFactoryDal;

namespace LionvBll.FuncitonInfo
{
   public class F_SetOrderCodeBll
    {
       private readonly IF_SetOrderCodeDal dal = FuntionsAccess.CreateF_SetOrderCode();
       public bool SetOrderCode(string tname, string codev, string where)
       {
           return dal.SetOrderCode(tname, codev, where);
       }
    }
}
