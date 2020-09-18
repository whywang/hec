using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_MzDesignPlanDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( B_MzDesignPlan model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( B_MzDesignPlan model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
 
        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         B_MzDesignPlan Query(string where);
    
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<B_MzDesignPlan> QueryList(string strWhere);
     
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
