using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    /// <summary>
    /// 接口层Sys_ProductionPriceTemp
    /// </summary>
    public interface ISys_ProductionPriceTempDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ptcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ProductionPriceTemp model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ProductionPriceTemp model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ptcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProductionPriceTemp Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_ProductionPriceTemp> QueryList(string strWhere);
      
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        #endregion  MethodEx
    } 
}
