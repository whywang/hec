using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
   public interface ICB_SapRecordDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( CB_SapRecord model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( CB_SapRecord model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         CB_SapRecord Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<CB_SapRecord> QueryList(string strWhere);
  
        #endregion  成员方法
        #region  MethodEx
         bool AddList(string[] idarr, string backstr, string mstr, string itype);
        #endregion  MethodEx
    }
}
