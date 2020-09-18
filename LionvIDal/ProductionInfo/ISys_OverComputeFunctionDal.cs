using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_OverComputeFunctionDal
    {
        #region  成员方法
       bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_OverComputeFunction model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_OverComputeFunction model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string fcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_OverComputeFunction Query(string where);

        List<Sys_OverComputeFunction> QueryList(string strWhere);
     
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetProductionOcm(string pcode, string fcode);

        int ReSetProductionOcm(string pcode);

        string GetProductionOcm(string pcode);
        #endregion  MethodEx
    }
}
