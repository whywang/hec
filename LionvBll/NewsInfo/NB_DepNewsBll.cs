using LionvFactoryDal;
using LionvIDal.NewsInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LionvBll.NewsInfo
{
   public class NB_DepNewsBll
    {
        private readonly INB_DepNewsDal dal = NewsAccess.CreateNB_DepNews();
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(string nid,ArrayList dcode)
        {
            return dal.Add(nid,dcode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string idlist)
        {
            return dal.Delete(idlist);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}