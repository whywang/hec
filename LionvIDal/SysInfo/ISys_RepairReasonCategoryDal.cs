using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_RepairReasonCategoryDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string rrcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_RepairReasonCategory model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_RepairReasonCategory model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
 
        bool Delete(string rrcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_RepairReasonCategory Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_RepairReasonCategory> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode(string pcode);
        #endregion  MethodEx
    } 
}
