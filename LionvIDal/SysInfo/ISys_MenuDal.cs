using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data;
using System.Collections;

namespace LionvIDal.SysInfo
{
    public interface ISys_MenuDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string mcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_Menu model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_Menu model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
 
        bool Delete(string where);
 
        /// 得到一个对象实体
        /// </summary>
        Sys_Menu Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Menu> QueryList(string strWhere);
        List<Sys_Menu> QueryAllList(string strWhere);
        #endregion  成员方法
        #region  MethodEx
        int DelRoleMenu(string rcode);
        int SetRoleMenu(DataTable dt);
        string GetRoleMenu(string rocde);
        int CreateCode(string pmcode);
        ArrayList QueryMenuGroup(string pmcode);
        #endregion  MethodEx
    }
}
