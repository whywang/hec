using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_PackageInSapDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_PackageInSap model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_PackageInSap model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_PackageInSap Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_PackageInSap> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        DataTable QueryViewList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        bool UpPackageState(string[] idarr, string field, int fvalue);
        #endregion  MethodEx
    }
}
