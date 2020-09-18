using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ComputeFunctionDal
    {
        #region  成员方法
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ComputeFunction model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ComputeFunction model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string  fcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ComputeFunction Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_ComputeFunction> QueryList(string strWhere);
       
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetProductionCm(string pcode, string fcode,string ptx);
        int ReSetProductionCm(string pcode, string ptx);
        string GetProductionCm(string pcode, string ptx);
        #endregion  MethodEx
    }
}
