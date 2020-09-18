using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    public interface ICB_InSapRecordDal
    {

        #region  成员方法
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(CB_InSapRecord model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CB_InSapRecord model);
 
        bool Delete(string where);
        CB_InSapRecord Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<CB_InSapRecord> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
