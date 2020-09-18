using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_OverComputeCategoryDal
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string ocode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Sys_OverComputeCategory model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Sys_OverComputeCategory model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string ocode);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_OverComputeCategory Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		List<Sys_OverComputeCategory> QueryList(string where);
		 
		#endregion  成员方法
		#region  MethodEx
        int CreateCode();
		#endregion  MethodEx
    }
}
