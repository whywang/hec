using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_PackageDateDal
    {
        #region  成员方法
 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_PackageDate model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_PackageDate model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_PackageDate Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_PackageDate> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        bool UpPackageState(string sid, string bsid, string v);
        bool UpPackageState(string sid, string v);
        #endregion  MethodEx
    }
}
