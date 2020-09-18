using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.NewsInfo;

namespace LionvIDal.NewsInfo
{
    public interface INB_NewsDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(NB_News model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(NB_News model);
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        NB_News Query(string where);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<NB_News> QueryList(string strWhere);
        List<NB_News> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount);
        
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
