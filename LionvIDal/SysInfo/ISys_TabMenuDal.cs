using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_TabMenuDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_TabMenu model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_TabMenu model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tmcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_TabMenu Query(string id);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List< Sys_TabMenu> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode ();
        bool SetTabMenuEvent(string tcode, string ecode, string dcode);
        bool ReSetTabMenuEvent(string tcode, string dcode);
        string GetTabMenuEvent(string tcode, string dcode);
        #endregion  MethodEx
    } 
}
