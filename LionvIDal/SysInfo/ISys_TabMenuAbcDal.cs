using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_TabMenuAbcDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_TabMenuAbc model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_TabMenuAbc model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_TabMenuAbc Query(string id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_TabMenuAbc> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
         bool CheckSql(Sys_TabMenuAbc m,string sid);
        #endregion  MethodEx
    }
}
