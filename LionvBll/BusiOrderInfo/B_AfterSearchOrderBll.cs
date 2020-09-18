using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvFactoryDal;

namespace LionvBll.BusiOrderInfo
{
   public class B_AfterSearchOrderBll
    {
       private readonly IB_AfterSearchOrderDal dal = BusiOrderAccess.CreateB_AfterSearchOrder();
 
		#region  BasicMethod

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public B_AfterSearchOrder Query(string where)
		{

            return dal.Query(where);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
