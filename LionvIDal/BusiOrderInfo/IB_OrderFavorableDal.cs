﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_OrderFavorableDal
    {
        
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_OrderFavorable model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_OrderFavorable model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_OrderFavorable Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_OrderFavorable> QueryList(string strWhere);
	 
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
    }
}
