using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_OverConditionDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ccode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_OverCondition model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_OverCondition model);
     
        bool Delete(string ccode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_OverCondition Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_OverCondition> QueryList(string strWhere);
      
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         int SetProductionOc(string icode,string pcode, string ocode);
         int ReSetProductionOc(string icode, string ocode);
         string GetProductionOc(string pcode);
         string GetProductionOcEx(string icode, string ocode);
        #endregion  MethodEx
    }
}
