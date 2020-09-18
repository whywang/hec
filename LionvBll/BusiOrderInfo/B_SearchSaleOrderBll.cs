using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvFactoryDal;

namespace LionvBll.BusiOrderInfo
{
   public class B_SearchSaleOrderBll
    {
       private readonly IB_SearchSaleOrderDal dal = BusiOrderAccess.CreateB_SearchSaleOrder();
 
		#region  BasicMethod
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_SearchSaleOrder Query(string where)
		{

            return dal.Query(where);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
