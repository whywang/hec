using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_ProductionProcessCostPartDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Sys_ProductionProcessCostPart model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Sys_ProductionProcessCostPart model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Sys_ProductionProcessCostPart Query(string id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
        List<Sys_ProductionProcessCostPart> QueryList(string strWhere);
		
		#endregion  成员方法
		#region  MethodEx
        string QueryListStr(string strWhere);
        bool AddList(string uname, string ucode, string[] arr);
		#endregion  MethodEx
    }
}
