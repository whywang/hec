using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    /// <summary>
    /// 接口层Sys_PriceProportion
    /// </summary>
    public interface ISys_PriceProportionDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_PriceProportion model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_PriceProportion model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ppcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_PriceProportion Query(string id);
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_PriceProportion> QueryList(string strWhere);
       
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetPriceBl(string icode, string ppcode);
        int ReSetPriceBl(string icode);
        string GetSetPriceBl(string icode);
        #endregion  MethodEx
    } 
}
