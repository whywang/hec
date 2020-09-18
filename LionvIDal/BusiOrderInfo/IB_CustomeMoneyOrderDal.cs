﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_CustomeMoneyOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string csid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_CustomeMoneyOrder model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_CustomeMoneyOrder model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string csid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_CustomeMoneyOrder Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_CustomeMoneyOrder> QueryList(string strWhere);
    
        #endregion  成员方法
        #region  MethodEx
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        #endregion  MethodEx
    }
}
