using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;
using System.Data;

namespace LionvIDal.BusiCommon
{
   public interface ICB_OrderTraceRecordDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(CB_OrderTraceRecord model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CB_OrderTraceRecord model);
        /// <summary>
        /// 删除一条数据
        /// </summary
        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CB_OrderTraceRecord Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<CB_OrderTraceRecord> QueryList(string strWhere);
        #endregion  成员方法
        #region  MethodEx
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        #endregion  MethodEx
    }
}
