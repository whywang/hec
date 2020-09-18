using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_DepmentDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Depment model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_Depment model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string dcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_Depment Query(string where );

        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_Depment> QueryList(string where);
 
        #endregion  成员方法
        #region  MethodEx
         int CreateCode(string pdepcode);
         bool SetProxyCity(string dcode, string ccode);
         bool ReSetProxyCity(string dcode);
         string GetProxyCity(string dcode);
        #endregion  MethodEx
    } 
}
