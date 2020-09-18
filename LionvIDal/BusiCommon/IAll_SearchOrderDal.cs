using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;
using System.Data;

namespace LionvIDal.BusiCommon
{
    public interface IAll_SearchOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        All_SearchOrder Query(string where);

        List<All_SearchOrder> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        #endregion  MethodEx
    }
}
