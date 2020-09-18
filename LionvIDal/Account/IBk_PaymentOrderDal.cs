using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.Account;

namespace LionvIDal.Account
{
    public interface IBk_PaymentOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string sid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Bk_PaymentOrder model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Bk_PaymentOrder model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string sid);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Bk_PaymentOrder Query(string where);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Bk_PaymentOrder> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
