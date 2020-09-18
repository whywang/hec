using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_WjPreparePartOrderDal
    {
        
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string sid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_WjPreparePartOrder model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_WjPreparePartOrder model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string sid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_WjPreparePartOrder Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_WjPreparePartOrder> QueryList(string strWhere);
		 
		#endregion  成员方法
		#region  MethodEx
         int GetOrderNum(string sid);
         bool SavePreParePartOrder(B_WjPreparePartOrder bp, List<B_WjPreParePartGroupProduction> pbpp, ArrayList alui);
		#endregion  MethodEx
    }
}
