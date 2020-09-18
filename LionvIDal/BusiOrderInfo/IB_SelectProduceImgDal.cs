using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_SelectProduceImgDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_SelectProduceImg model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_SelectProduceImg model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string xsid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_SelectProduceImg Query(string where);

        List<B_SelectProduceImg> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
