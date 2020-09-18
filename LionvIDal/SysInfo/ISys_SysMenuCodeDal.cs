using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_SysMenuCodeDal
    {

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string scode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_SysMenuCode model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_SysMenuCode model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string scode);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_SysMenuCode Query(string where);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_SysMenuCode> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool SetEnMenuCode(string emcode, string scode, string dcode);
        bool ReSetEnMenuCode(string emcode);
        string GetEnMenuCode(string emcode);
        string QueryEmcode(string escode, string bdcode);
        #endregion  MethodEx
    } 
}
