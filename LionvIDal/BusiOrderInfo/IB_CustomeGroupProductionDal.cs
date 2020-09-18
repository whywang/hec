using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_CustomeGroupProductionDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string psid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_CustomeGroupProduction model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_CustomeGroupProduction model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string psid);
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_CustomeGroupProduction Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_CustomeGroupProduction> QueryList(string strWhere);
	 
		#endregion  成员方法
		#region  MethodEx
         int GetGnum(string where);
         ArrayList GetGnumArr(string where);
		#endregion  MethodEx
    }
}
