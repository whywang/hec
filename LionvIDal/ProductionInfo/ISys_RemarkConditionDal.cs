using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_RemarkConditionDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string rccode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_RemarkCondition model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_RemarkCondition model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string rccode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_RemarkCondition Query(string where);
        Sys_RemarkCondition DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_RemarkCondition> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        #endregion  MethodEx
    }
}
