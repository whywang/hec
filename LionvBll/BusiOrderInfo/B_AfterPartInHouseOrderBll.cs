using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_AfterPartInHouseOrderBll
    {
        	private readonly IB_AfterPartInHouseOrderDal dal=BusiOrderAccess.CreateB_AfterPartInHouseOrder();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sid)
		{
			return dal.Exists(sid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_AfterPartInHouseOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_AfterPartInHouseOrder model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sid)
		{
			
			return dal.Delete(sid);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_AfterPartInHouseOrder Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterPartInHouseOrder> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateNum(string sid, string plist)
        {
            return dal.CreateNum(sid, plist);
        }
		#endregion  ExtensionMethod
    }
}
