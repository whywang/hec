using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_ContractTempDal
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string ccode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_ContractTemp model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_ContractTemp model);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string ccode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_ContractTemp Query(string id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_ContractTemp> QueryList(string strWhere);
		/// <summary>
 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
		#endregion  MethodEx
	} 
}
