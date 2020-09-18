using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_OptimizeDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ocode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Optimize model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_Optimize model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ocode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Optimize Query(string where);

        List<Sys_Optimize> QueryList(string strWhere);
 
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();

        int SetOptProduction(string ocode,string pcode, string[] ncode);
        
        int ReSetOptProduction(string ocode);

        string GetOptProduction(string ocode,string pcode);
        #endregion  MethodEx
    }
}
