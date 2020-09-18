using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.NewsInfo;

namespace LionvIDal.NewsInfo
{
   public interface INB_NewsReaderDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        //bool Exists(int id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(NB_NewsReader model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(NB_NewsReader model);
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        NB_NewsReader Query(string where);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<NB_NewsReader> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
