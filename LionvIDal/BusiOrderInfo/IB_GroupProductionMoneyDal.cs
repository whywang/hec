using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_GroupProductionMoneyDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_GroupProductionMoney model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_GroupProductionMoney model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string psid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_GroupProductionMoney Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_GroupProductionMoney> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        bool SetProductionPrice(List<B_GroupProductionMoney> bfpm, string ptype);
        decimal QueryGroupMoney(string gsid, string ptype, string mtype);
        decimal[] QueryGroupMoneyDetail(string gsid, string ptype, string mtype);
        decimal QueryOrderMoney(string sid, string ptype, string mtype);
        decimal QueryClassOrderMoney(string sid, string ptype, string mtype, string ctype);
        bool EditProductionMoney(ArrayList plist, string ttype);
        #endregion  MethodEx
    }
}
