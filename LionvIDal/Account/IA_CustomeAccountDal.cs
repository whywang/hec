using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.Account;
using ViewModel.Account;
using System.Data;

namespace LionvIDal.Account
{
   public interface IA_CustomeAccountDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( A_CustomeAccount model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( A_CustomeAccount model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         A_CustomeAccount Query(string id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<A_CustomeAccount> QueryList(string strWhere);
        #endregion  成员方法
        #region  MethodEx
         VCustomeAccount QueryCustomeAccount(string where);
         DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
         bool UpdateEx(A_CustomeAccount model);
        #endregion  MethodEx
    }
}
