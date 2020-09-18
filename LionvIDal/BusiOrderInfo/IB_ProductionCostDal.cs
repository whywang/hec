using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_ProductionCostDal
    {
        	#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_ProductionCost model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_ProductionCost model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_ProductionCost Query(string id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_ProductionCost> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         DataTable QueryVList(string colv, string where, string sort);
		#endregion  MethodEx
    }
}
