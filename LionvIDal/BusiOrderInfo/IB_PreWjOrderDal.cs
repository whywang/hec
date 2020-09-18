using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_PreWjOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_PreWjOrder model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( B_PreWjOrder model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string sid);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_PreWjOrder Query(string where);
        B_PreWjOrder DataRowToModel(DataRow row);

        #endregion  成员方法
        #region  MethodEx
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        #endregion  MethodEx
    }
}
