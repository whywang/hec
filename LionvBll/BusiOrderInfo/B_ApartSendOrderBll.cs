using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_ApartSendOrderBll
    {
       private readonly IB_ApartSendOrderDal dal = BusiOrderAccess.CreateB_ApartSendOrder();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string osid)
		{
			return dal.Exists(osid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(B_ApartSendOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(B_ApartSendOrder model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string osid)
		{
			
			return dal.Delete(osid);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public B_ApartSendOrder Query(string id)
		{

            return dal.Query(id);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_ApartSendOrder> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
	 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int QueryMaxNum(string sid)
        {
            return dal.QueryMaxNum(sid);
        }
		#endregion  ExtensionMethod
    }
}
