﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_WjPartGroupProductionDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string psid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_WjPartGroupProduction model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_WjPartGroupProduction model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string psid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_WjPartGroupProduction Query(string id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_WjPartGroupProduction> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         bool CheckPrePareState(string sid,string fv);
		#endregion  MethodEx
    }
}
