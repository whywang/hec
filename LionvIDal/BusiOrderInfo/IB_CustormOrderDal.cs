using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_CustormOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_CustormOrder model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_CustormOrder model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_CustormOrder Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_CustormOrder> QueryList(string where);
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        
        #endregion  成员方法
        #region  MethodEx
        bool SetThirdDep(string tname, string tcode, string sid);
        #endregion  MethodEx
    } 
}
