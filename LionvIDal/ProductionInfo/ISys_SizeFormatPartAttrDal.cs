﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_SizeFormatPartAttrDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_SizeFormatPartAttr model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_SizeFormatPartAttr model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string id);
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_SizeFormatPartAttr Query(string id);
	 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_SizeFormatPartAttr> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
    }
}
