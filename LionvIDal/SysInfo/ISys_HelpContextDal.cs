using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_HelpContextDal
    {
        #region  成员方法
 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_HelpContext model);
  
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_HelpContext Query(string where);

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
