using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.FuncitonInfo;

namespace LionvBll.FuncitonInfo
{
   public class F_SetOrderTypeBll
    {
       private readonly IF_SetOrderTypeDal dal = FuntionsAccess.CreateF_SetOrderType();
        public bool SetOrderType(string tname, string codev, string where)
        {
            return dal.SetOrderType(tname, codev, where);
        }
    }
}
