using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_FixOrderTaskDal
    {
        #region  成员方法
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_FixOrderTask model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_FixOrderTask model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_FixOrderTask Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_FixOrderTask> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        bool SetAzs(string sid, string[] azslist, string maker);
        bool ASetAzs(string sid, string[] azslist, string maker);
        bool SaveDisMoney(string sid, ArrayList alist, ArrayList wlist, decimal wmoney);
        #endregion  MethodEx
    }
}
