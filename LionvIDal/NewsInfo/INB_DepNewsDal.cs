using LionvModel.NewsInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LionvIDal.NewsInfo
{
    public interface INB_DepNewsDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(string nid, ArrayList depcode);
      
        bool Delete(string idlist);
     
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
