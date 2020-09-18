using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_PartQualityOrderBll
    {
        private readonly IB_PartQualityOrderDal dal=BusiOrderAccess.CreateB_PartQualityOrder();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string qsid)
		{
			return dal.Exists(qsid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_PartQualityOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_PartQualityOrder model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{
			
			return dal.Delete(id);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_PartQualityOrder Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_PartQualityOrder> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int QueryQorderNum(string strWhere)
        {
            return dal.QueryQorderNum(strWhere);
        }
        public bool SaveQualityOrder(B_PartQualityOrder bpqo, List<B_PartQualityItems> lq)
        {
            return dal.SaveQualityOrder(bpqo, lq);
        }
		#endregion  ExtensionMethod
    }
}
