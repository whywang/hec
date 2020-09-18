using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data;

namespace LionvIDal.SysInfo
{
  public interface ISys_DataTableDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_DataTable model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_DataTable model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_DataTable Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_DataTable> QueryList(string strWhere);
	 
		#endregion  成员方法
		#region  MethodEx
         DataTable QueryTables();
		#endregion  MethodEx
    }
}
