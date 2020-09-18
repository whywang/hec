using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_AddressListDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_AddressList model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_AddressList model);
 
        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_AddressList Query(string id);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_AddressList> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
