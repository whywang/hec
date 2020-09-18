using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_SetMealDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string tsid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( B_SetMeal model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( B_SetMeal model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tsid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         B_SetMeal Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<B_SetMeal> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
         bool DelTcProduction(string sid, string tsid);
         decimal GQueryTcMoney(string sid);
        #endregion  MethodEx
    } 
}
