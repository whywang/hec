using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ProduceCateDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string lcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_ProduceCate model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_ProduceCate model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string lcode);
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_ProduceCate Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_ProduceCate> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
         bool SetProductionCate(string lcode, string icode);
         bool ReSetProductionCate(string lcode);
         string GetProductionCate(string lcode);
		#endregion  MethodEx
    }
}
