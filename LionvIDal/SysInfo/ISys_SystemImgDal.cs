using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_SystemImgDal
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_SystemImg model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_SystemImg model);


        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_SystemImg Query(string where);



        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
