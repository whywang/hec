using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_WjPreParePartGroupProductionDal
    {
       #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_WjPreParePartGroupProduction model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_WjPreParePartGroupProduction model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string where);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_WjPreParePartGroupProduction Query(string id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_WjPreParePartGroupProduction> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int QueryWjNum(string sid, string icode);
		#endregion  MethodEx
    }
}
