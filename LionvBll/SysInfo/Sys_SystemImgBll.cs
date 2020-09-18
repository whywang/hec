using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_SystemImgBll
    {
        private readonly ISys_SystemImgDal r = DataAccess.CreateSys_SystemImgDal();
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SystemImg model)
        {

            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_SystemImg model)
        {

            return r.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {
            return r.Delete(where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_SystemImg Query(string where)
        {

            return r.Query(where);
        }



        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
