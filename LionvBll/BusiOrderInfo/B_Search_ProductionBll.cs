using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvFactoryDal;

namespace LionvBll.BusiOrderInfo
{
   public class B_Search_ProductionBll
    {
       private readonly IB_Search_ProductionDal dal = BusiOrderAccess.CreateB_Search_Production();
	 
		#region  BasicMethod
		/// <summary>
		/// 获得数据列表
		/// </summary>
       public B_Search_Production Query(string strWhere)
		{
            return dal.Query(strWhere);
		}
		 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<B_Search_Production> QueryList(string strWhere)
		{
            
			return   dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
