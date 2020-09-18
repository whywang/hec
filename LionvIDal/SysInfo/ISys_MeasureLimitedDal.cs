using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_MeasureLimitedDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string dcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_MeasureLimited model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_MeasureLimited model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string dcode);
	 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_MeasureLimited Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_MeasureLimited> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         Sys_MeasureLimited QueryDepLimited(string dcode);
		#endregion  MethodEx
    }
}
