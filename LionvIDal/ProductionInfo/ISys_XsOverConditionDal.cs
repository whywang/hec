using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_XsOverConditionDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ccode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_XsOverCondition model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_XsOverCondition model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ccode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_XsOverCondition Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_XsOverCondition> QueryList(string strWhere);
      
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         int SetProductionOc(string icode, string pcode, string ocode);
         int ReSetProductionOc(string icode, string ocode);
         string GetProductionOc(string pcode);
         string GetProductionOcEx(string icode, string ocode);
        #endregion  MethodEx
    }
}
