using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;

namespace LionvBll.BusiOrderInfo
{
    public class B_AfterSearch_ProductionBll
    {
        private readonly IB_AfterSearch_ProductionDal dal=BusiOrderAccess.CreateB_AfterSearch_Production();
		#region  BasicMethod
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public B_AfterSearch_Production Query(string where)
		{
			
			return dal.Query(where);
		}

		 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<B_AfterSearch_Production> QueryList(string where)
		{
			 
			return dal.QueryList( where);
		}

	 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
