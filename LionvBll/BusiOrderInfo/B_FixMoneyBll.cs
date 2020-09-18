using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using System.Collections;

namespace LionvBll.BusiOrderInfo
{
   public class B_FixMoneyBll
    {
       private readonly IB_FixMoneyDal dal = BusiOrderAccess.CreateB_FixMoney();
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_FixMoney model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_FixMoney model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string sid)
        {

            return dal.Delete(sid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_FixMoney Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_FixMoney> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool UpdateFixMoney(B_FixMoney model,ArrayList plist)
        {
            return dal.UpdateFixMoney(model, plist);
        }
        #endregion  ExtensionMethod
    }
}
