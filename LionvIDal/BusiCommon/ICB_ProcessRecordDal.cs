using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    public interface ICB_ProcessRecordDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( CB_ProcessRecord model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( CB_ProcessRecord model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         CB_ProcessRecord Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<CB_ProcessRecord> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
