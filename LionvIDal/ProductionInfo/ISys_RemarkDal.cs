using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_RemarkDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string rcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Remark model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_Remark model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string rcode);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Remark Query(string where);
        Sys_Remark DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Remark> QueryList(string strWhere);
    
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetProductionBz(string pcode, string rcode);
        int ReSetProductionBz(string pcode);
        string GetProductionBz(string pcode);
        
        #endregion  MethodEx
    }
}
