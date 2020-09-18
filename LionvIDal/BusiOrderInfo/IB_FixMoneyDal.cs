﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_FixMoneyDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_FixMoney model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_FixMoney model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string sid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_FixMoney Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_FixMoney> QueryList(string strWhere);
       #endregion  成员方法
        #region  MethodEx
        bool UpdateFixMoney(B_FixMoney model, ArrayList plist);
        #endregion  MethodEx
    }
}
