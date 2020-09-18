using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_SizeFormatCateDal
    {
       #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string sfcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_SizeFormatCate model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_SizeFormatCate model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string sfcode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 Sys_SizeFormatCate Query(string id);

		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_SizeFormatCate> QueryList(string strWhere);

		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
         bool SetSizeFormat(string icode, string pcode, string sfcode);
         bool ReSetSizeFormat(string icode, string pcode);
         string GetSizeFormat(string pcode);
		#endregion  MethodEx
    }
}
