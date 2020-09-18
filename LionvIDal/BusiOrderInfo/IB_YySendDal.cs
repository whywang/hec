using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_YySendDal
    {
        #region  成员方法
 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( B_YySend model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( B_YySend model);

        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         B_YySend Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<B_YySend> QueryList(string strWhere);
      
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
