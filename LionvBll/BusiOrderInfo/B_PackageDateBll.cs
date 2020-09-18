using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_PackageDateBll
    {
       private readonly IB_PackageDateDal r = BusiOrderAccess.CreateB_PackageDate();
        #region  BasicMethod
  
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_PackageDate model)
        { 
            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_PackageDate model)
        {
            
            return r.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {
 
            return r.Delete(where);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_PackageDate Query(string where)
        { 
            return r.Query(where);
        }
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_PackageDate> QueryList(string where)
        { 
            return r.QueryList(where);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        #region//更新包日期
        public bool UpPackageState(string sid, string bsid, string v)
        { 
            return r.UpPackageState(sid,  bsid,  v);
        }
        #endregion
        #region//更新订单包日期
        public bool UpPackageState(string sid, string v)
        {
            return r.UpPackageState(sid, v);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
