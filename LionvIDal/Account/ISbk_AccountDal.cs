using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.Account;

namespace LionvIDal.Account
{
    public interface ISbk_AccountDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sbk_Account model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sbk_Account model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string acode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sbk_Account Query(string where);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        List<Sbk_Account> QueryList(string strWhere );
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool SetCredit(string acode, decimal cnum);
        #endregion  MethodEx
    } 
}
