using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ProductionProcessPriceDal
    {

        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ProductionProcessPrice model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ProductionProcessPrice model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProductionProcessPrice Query(string where);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_ProductionProcessPrice> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int AddList(List<Sys_ProductionProcessPrice> model);
        #endregion  MethodEx
    }
}
