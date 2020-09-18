using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.NewsInfo;
using LionvFactoryDal;
using LionvModel.NewsInfo;

namespace LionvBll.NewsInfo
{
   public class NB_NewsReaderBll
    {
       private readonly INB_NewsReaderDal r = NewsAccess.CreateNB_NewsReader();
       #region  BasicMethod


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(NB_NewsReader model)
       { 
           return r.Add(model);

       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(NB_NewsReader model)
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
       public NB_NewsReader Query(string where)
       { 
           return r.Query(where);
       }

 

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<NB_NewsReader> QueryList(string where)
       { 
           return r.QueryList(where);
       }


       #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
