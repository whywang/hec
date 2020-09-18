using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_PayImgDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_PayImg model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_PayImg model);
        
        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_PayImg Query(string id);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_PayImg> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
