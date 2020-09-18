using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_DomainDal
    {
       /// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string where);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Sys_Domain model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Sys_Domain model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string where);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Sys_Domain Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		List<Sys_Domain> QueryList(string strWhere);
 
		#region  MethodEx

		#endregion  MethodEx
    }
}
