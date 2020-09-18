using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_DepmentDptDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_DepmentDpt model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_DepmentDpt model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_DepmentDpt Query( string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_DepmentDpt> QueryList(string where);
 
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
