using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_ProcessRecordDal
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_ProcessRecord model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_ProcessRecord model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_ProcessRecord Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_ProcessRecord> QueryList(string where);

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
