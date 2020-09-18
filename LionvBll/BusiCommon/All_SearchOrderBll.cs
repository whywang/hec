using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;
using System.Data;

namespace LionvBll.BusiCommon
{
    public class All_SearchOrderBll
    {
        private readonly IAll_SearchOrderDal dal=BusiCommonAccess.CreateAll_SearchOrder();
		#region  BasicMethod
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public All_SearchOrder Query(string where)
		{
            return dal.Query(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<All_SearchOrder> QueryList(string where)
		{
			 return dal.QueryList(where);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
		#endregion  ExtensionMethod
    }
}
