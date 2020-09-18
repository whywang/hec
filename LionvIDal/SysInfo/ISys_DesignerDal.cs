using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_DesignerDal
	{
		#region  成员方法
        bool Exists(string where);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_Designer model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_Designer model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string where);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_Designer Query(string where);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_Designer> QueryList(string strWhere);
	 
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	} 
}
