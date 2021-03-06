﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.Account;

namespace LionvIDal.Account
{
    public interface IB_ExchangeRecordDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_ExchangeRecord model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_ExchangeRecord model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string id);
    
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_ExchangeRecord Query(string id);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_ExchangeRecord> QueryList(string strWhere);
         
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
