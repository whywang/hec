using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data;

namespace LionvIDal.SysInfo
{
    public interface ISys_EmployeeDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string eno);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_Employee model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_Employee model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Employee Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Employee> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        int AddList(Sys_Employee se, Sys_EmployeeDpt sed, Sys_User su);
        int UpdateList(string eno, Sys_Employee se, Sys_EmployeeDpt sed, Sys_User su);
        int GetEno();
        DataTable QueryEmploy(string where);
        #endregion  MethodEx
    } 
}
