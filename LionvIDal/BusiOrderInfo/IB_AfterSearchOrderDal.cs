using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_AfterSearchOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_AfterSearchOrder Query(string where);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
