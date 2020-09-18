using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ProductionPeriodDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string gqcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_ProductionPeriod model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_ProductionPeriod model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string gqcode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_ProductionPeriod Query(string id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_ProductionPeriod> QueryList(string strWhere);
		 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
         bool SetPeriod(string icode, string fcode, string gqcode);
         bool ReSetPeriod(string icode, string fcode);
         string GetPeriod(string icode, string fcode);
		#endregion  MethodEx
    }
}
