﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_FixProductionDal
    {
        #region  成员方法
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_FixProduction model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_FixProduction model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string psid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_FixProduction Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_FixProduction> QueryList(string strWhere);
       
        #endregion  成员方法
        #region  MethodEx
        bool SaveFixProductionList(string sid, List<B_FixProduction> lbf);
        decimal QueryOrderMoney(string where);
        #endregion  MethodEx
    }
}
