using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using System.Data;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
    public class B_PackageInSapBll
    {
        private readonly IB_PackageInSapDal dal = BusiOrderAccess.CreateB_PackageInSap();
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_PackageInSap model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_PackageInSap model)
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
        public B_PackageInSap Query(string where)
        {
            return dal.Query(where);
        }
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_PackageInSap> QueryList(string strWhere)
        { 
            return dal.QueryList(strWhere);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable QueryViewList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        { 
            return dal.QueryViewList(curpage,  pagesize,  sfeild,  where,  sort, ref  rcount, ref  pcount);
        }
        public bool UpPackageState(string[] idarr, string field, int fvalue)
        {
            return dal.UpPackageState( idarr,  field,  fvalue);
        }
        #endregion  ExtensionMethod
    }
}
