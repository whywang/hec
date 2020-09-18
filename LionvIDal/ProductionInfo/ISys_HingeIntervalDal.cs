using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_HingeIntervalDal
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string hcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_HingeInterval model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_HingeInterval model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string hcode);
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_HingeInterval Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_HingeInterval> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
		#endregion  MethodEx
	} 
}
