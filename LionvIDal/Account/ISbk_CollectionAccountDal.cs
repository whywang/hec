using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.Account;

namespace LionvIDal.Account
{
    public interface ISbk_CollectionAccountDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string bcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sbk_CollectionAccount model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sbk_CollectionAccount model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sbk_CollectionAccount Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sbk_CollectionAccount> QueryList(string strWhere);
       
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        #endregion  MethodEx
    } 
}
