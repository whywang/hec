using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    public interface ICB_OperationRecodDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(CB_OperationRecod model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CB_OperationRecod model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string idlist);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        CB_OperationRecod Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<CB_OperationRecod> QueryList(string where);
     
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
