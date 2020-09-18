using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_SetMealProductionDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string tcblbcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_SetMealProduction model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_SetMealProduction model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tcblbcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_SetMealProduction Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_SetMealProduction> QueryList(string strWhere);
  
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
        bool SetSmProductin(string tcv, string iv, string[] pv);
        bool ReSetSmProductin(string tcv, string iv);
        string GetSmProductin(string tcv, string iv);

        bool SetSmProductinAdd(string tcv, string iv, string[] pv);
        bool ReSetSmProductinAdd(string tcv, string iv);
        string GetSmProductinAdd(string tcv, string iv);
        #endregion  MethodEx
    }
}
