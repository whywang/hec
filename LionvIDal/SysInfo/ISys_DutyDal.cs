using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_DutyDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string dcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add( Sys_Duty model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_Duty model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Duty Quert(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Duty> QueryList(string where);
        
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
