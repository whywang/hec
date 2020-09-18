using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_BrandsDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string pbcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( Sys_Brands model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( Sys_Brands model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string pbcode);
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Sys_Brands Query(string strWhere);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<Sys_Brands> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int CreateCode();
         bool SetDepBrand(string dcode, string pbcode);
         bool ReSetDepBrand(string dcode);
         string GetDepBrand(string dcode);

         bool SetMaterialBrand(string pbcode, string mpcode, string mcode);
         bool ReSetMaterialBrand(string pbcode, string mcode);
         string GetMaterialBrand(string pbcode, string mpcode);

         bool SetInventroyBrand(string pbcode, string icode);
         bool ReSetInventroyBrand(string pbcode, string icode);
         string GetInventroyBrand(string pbcode, string icode);

         string QueryDepByBcode(string bcode);
		#endregion  MethodEx
    }
}
