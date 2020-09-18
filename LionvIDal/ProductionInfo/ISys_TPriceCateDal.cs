﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_TPriceCateDal
    {
        
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string lpcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_TPriceCate model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_TPriceCate model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string lpcode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_TPriceCate Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_TPriceCate> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
         bool SetMsMtPrice(string ptype, string mscode, string mtcode, string lpcode);
         bool ReSetMsMtPrice(string ptype, string mscode);
         string GetMsMtPrice(string ptype, string mscode, string mtcode);
		#endregion  MethodEx
    }
}
