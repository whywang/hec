using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ProductionProcessCostDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ucode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ProductionProcessCost model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ProductionProcessCost model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ucode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProductionProcessCost Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_ProductionProcessCost> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool SetGyCost(ArrayList pcode, string gcode, string[] ucode);
        bool ReSetGyCost(ArrayList pcode, string gcode);
        string GetGyCost(string pcode, string gcode);
        #endregion  MethodEx
    }
}
