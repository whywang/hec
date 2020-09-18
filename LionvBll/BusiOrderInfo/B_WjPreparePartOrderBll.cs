using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvBll.BusiOrderInfo
{
   public class B_WjPreparePartOrderBll
    {
       private readonly IB_WjPreparePartOrderDal dal=BusiOrderAccess.CreateB_WjPreparePartOrder();

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
		public int  Add( B_WjPreparePartOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_WjPreparePartOrder model)
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
		public  B_WjPreparePartOrder Query(string id)
		{
            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_WjPreparePartOrder> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int GetOrderNum(string sid)
        {
            return dal.GetOrderNum(sid);
        }
        public bool SavePreParePartOrder(B_WjPreparePartOrder bp, List<B_WjPreParePartGroupProduction> pbpp, ArrayList alui)
        {
            return dal.SavePreParePartOrder(bp, pbpp, alui);
        }
		#endregion  ExtensionMethod
    }
}
