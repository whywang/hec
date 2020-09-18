using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    /// </summary>
    public interface ICB_SaleDiscountDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string sid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( CB_SaleDiscount model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( CB_SaleDiscount model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string sid);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         CB_SaleDiscount Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<CB_SaleDiscount> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
