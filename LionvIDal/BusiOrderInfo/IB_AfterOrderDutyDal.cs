using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_AfterOrderDutyDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_AfterOrderDuty model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_AfterOrderDuty model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_AfterOrderDuty Query(string where);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_AfterOrderDuty> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int AddList(List<B_AfterOrderDuty> model);
        #endregion  MethodEx
    }
}
