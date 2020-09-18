﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_SectionPriceDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string jcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_SectionPrice model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_SectionPrice model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string jcode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_SectionPrice Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_SectionPrice> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
		#endregion  MethodEx
    }
}
