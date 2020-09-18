using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_SizeTransformRDal
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string rcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_SizeTransformR model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_SizeTransformR model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string rcode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_SizeTransformR Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_SizeTransformR> QueryList(string strWhere);
	 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
         bool SetRjc(string mcode, string tcode, string cname,string rcode);
         bool ReSetRjc(string mcode, string tcode, string cname);
         string GetRjc(string mcode, string tcode, string cname);
         DataTable QueryCaveType(string mcode, string tcode);
		#endregion  MethodEx
	} 
}
