using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Collections;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_PackageDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_Package model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( B_Package model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_Package Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_Package> QueryList(string where);

        #endregion  成员方法
        #region  MethodEx
        DataTable QueryVList(string colv, string where,string sort);
        int PackageNum(string sid);
        #region//更行包状态
        bool UpPackageState(string sid,int bnum, string field, string v);
        #endregion
        #region//更行订单包状态
        bool UpPackageState(string sid, string field, string v);
        #endregion
        string QueryPackageCode(string bsid, string padstr,string ptype);
        string QueryPackageCodeEx(string bsid, string padstr, string h,string w);
        DataRow ViewQuery(string where);
        DataRow QuerySendPackage(string sid);
        bool SavePackageList(ArrayList gsid, List<B_Package> lbp);
        #endregion  MethodEx
    } 
}
