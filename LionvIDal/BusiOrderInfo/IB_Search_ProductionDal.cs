﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_Search_ProductionDal
    {
        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_Search_Production Query(string where);
        B_Search_Production DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_Search_Production> QueryList(string strWhere);
         
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
