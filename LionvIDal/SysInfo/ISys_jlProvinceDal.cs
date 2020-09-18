using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_jlProvinceDal
    {
        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_jlProvince Query(string id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_jlProvince> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
