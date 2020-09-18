using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_AfterProductionImgDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_AfterProductionImg model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string id);
	    bool Delete(string sid ,string gnum);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_AfterProductionImg Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_AfterProductionImg> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
    }
}
