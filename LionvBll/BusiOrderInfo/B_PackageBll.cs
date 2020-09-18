using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Collections;

namespace LionvBll.BusiOrderInfo
{
   public class B_PackageBll
    {
       private IB_PackageDal dal = BusiOrderAccess.CreateB_Package();
       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(string where)
       {
           return dal.Exists(where);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(B_Package model)
       {
           return dal.Add(model);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(B_Package model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>

       public bool Delete(string where)
       {
           return dal.Delete(where);

       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public B_Package Query(string where)
       { 
           return dal.Query(where);

       }


       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<B_Package> QueryList(string where)
       {
            
           return dal.QueryList(where);
       }


       #endregion  BasicMethod
        #region  ExtensionMethod
       public DataTable QueryVList(string colv,string where,string sort)
       {

           return dal.QueryVList( colv, where,sort);
       }
       public int PackageNum(string sid)
       {
           return dal.PackageNum(sid);
       }
       #region//更行包状态
       public bool UpPackageState(string bsid,int bnum, string field, string v)
       {
           return dal.UpPackageState(bsid, bnum, field,  v);
       }
       #endregion
       #region//更行订单包状态
       public bool UpPackageState(string sid, string field, string v)
       {
           return dal.UpPackageState(sid, field, v);
       }
       #endregion
       public string QueryPackageCode(string bsid, string padstr,string ptype)
       {
           return dal.QueryPackageCode(bsid, padstr, ptype);
       }
       public string QueryPackageCodeEx(string bsid, string padstr, string h, string w)
       {
           return dal.QueryPackageCodeEx(bsid, padstr,  h,  w);
       }
       public DataRow ViewQuery(string where)
       {
           return dal.ViewQuery(where);
       }
       public DataRow QuerySendPackage(string sid)
       {
           return dal.QuerySendPackage(sid);
       }
       public bool SavePackageList(ArrayList gsid, List<B_Package> lbp)
       {
           return dal.SavePackageList(gsid, lbp);
       }
        #endregion  ExtensionMethod
    }
}
