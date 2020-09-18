using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_PartQualityOrderDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string qsid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_PartQualityOrder model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_PartQualityOrder model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string qsid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        B_PartQualityOrder Query(string id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_PartQualityOrder> QueryList(string strWhere);
	 	#endregion  成员方法
		#region  MethodEx
         int QueryQorderNum(string strWhere);
         bool SaveQualityOrder(B_PartQualityOrder bpqo, List<B_PartQualityItems> lq);
		#endregion  MethodEx
    }
}
