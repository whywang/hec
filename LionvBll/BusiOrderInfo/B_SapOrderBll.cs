using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using System.Data;

namespace LionvBll.BusiOrderInfo
{
   public class B_SapOrderBll
    {
        private readonly IB_SapOrderDal dal = BusiOrderAccess.CreateB_SapOrder();
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(  curpage,   pagesize,  sfeild,  where,  sort, ref  rcount, ref  pcount);
        }
        public DataTable QueryCanelList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryCanelList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
    }
}
