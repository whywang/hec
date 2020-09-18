using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data;

namespace LionvIDal.SysInfo
{
    public interface ISys_UserDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string uname);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_User model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_User model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_User Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_User> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        DataTable QueryTable(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount);
        //密码重置
        int ReSetPass(string id,string mm);
        //账号停用启用
        int SetState(string id, string v);
        int RePersonSetPass(string eno, string mm);

        int SetEmployeeCity(string eno, string[] ptcode);
        int ReSetEmployeeCity(string eno);
        string GetEmployeeCity(string eno);
        #endregion  MethodEx
    } 
}
