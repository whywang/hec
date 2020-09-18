using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    public interface ICB_OrderFlowDal
    {
        #region  成员方法
 
        int Add( CB_OrderFlow model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CB_OrderFlow model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
 
        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CB_OrderFlow Query(string where);
       
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<CB_OrderFlow> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        /// <summary>
        /// 查询处理节点是否已处理
        /// </summary>
        bool IsDid(string where);
        int CreateWorkFlow(string sql);
        string QueryCurWorkFlow(string sid);
        #endregion  MethodEx
    }
}
