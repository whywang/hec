using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_SectionPriceCateDal
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string scode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_SectionPriceCate model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_SectionPriceCate model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string scode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_SectionPriceCate Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_SectionPriceCate> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
         bool SetSectionPrice(string[] pcode, string scode,string uname);
         bool ReSetSectionPrice(string[] pcode);
         string GetSectionPrice(string pcode);
		#endregion  MethodEx
	} 
}
