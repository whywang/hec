using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.NewsInfo;
using LionvFactoryDal;
using LionvModel.NewsInfo;

namespace LionvBll.NewsInfo
{
    public  class NB_NewsBll
    {
        private readonly INB_NewsDal r = NewsAccess.CreateNB_News();
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
           
            return r.Exists(where);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(NB_News model)
        {
             
            return r.Add(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(NB_News model)
        { 
            return r.Update(model);
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool Delete(string where)
        { 
            return r.Delete(where);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NB_News Query(string where)
        { 
            return r.Query(where);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NB_News> QueryList(string where)
        {

            return r.QueryList(where);
        }

        public List<NB_News> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        {
            return r.QueryList(curpage, pagesize, where, sort, ref  rcount, ref  pcount);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
