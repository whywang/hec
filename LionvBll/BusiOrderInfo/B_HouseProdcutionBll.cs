using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LionvBll.BusiOrderInfo
{
   public class B_HouseProdcutionBll
    {
        private readonly IB_HouseProdcutionDal dal = BusiOrderAccess.CreateB_HouseProdcution();
        public bool Exist(string where)
        {
            return dal.Exist(where);
        }
        public bool InUpdate(string[] idlist,string isid)
        {
            return dal.InUpdate(idlist,isid);
        }
        public bool OutUpdate(string[] idlist,string osid)
        {
            return dal.OutUpdate(idlist ,osid);
        }
        public List<B_HouseProdcution> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }
    }
}