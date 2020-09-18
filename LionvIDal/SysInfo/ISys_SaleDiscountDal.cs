using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Collections;

namespace LionvIDal.SysInfo
{
   /// <summary>
	/// 接口层Sys_SaleDiscount
	/// </summary>
    public interface ISys_SaleDiscountDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_SaleDiscount model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_SaleDiscount model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string dcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_SaleDiscount Query(string id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_SaleDiscount> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         int SetProdctionDiscount(string dcode,string icode, string[] pcodes);
         int ReSetProdctionDiscount(string dcode,string icode);
         string GetProdctionDiscount(string dcode,string icode);
         bool CheckProductionDiscount(string dcode, string pcode);
         int SetDepDiscount(string sdcode, string[] dcodes);
         int ReSetDepDiscount(string dcode);
         string GetDepDiscount(string dcode);
         ArrayList QueryLoopSaleDiscount(string dcode);
        #endregion  MethodEx
    }
}
