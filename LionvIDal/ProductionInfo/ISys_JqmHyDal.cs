using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_JqmHyDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string hyname);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_JqmHy model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_JqmHy model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string hyname);
	 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_JqmHy Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_JqmHy> QueryList(string strWhere);
	 
		#endregion  成员方法
		#region  MethodEx
		#endregion  MethodEx
    }
}
