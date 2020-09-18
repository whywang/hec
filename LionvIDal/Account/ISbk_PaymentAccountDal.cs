using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.Account;

namespace LionvIDal.Account
{
    public interface ISbk_PaymentAccountDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sbk_PaymentAccount model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sbk_PaymentAccount model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string id);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sbk_PaymentAccount Query(string id);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sbk_PaymentAccount> QueryList(string strWhere);
    
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
        #endregion  MethodEx
    } 
}
