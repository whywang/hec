using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_SpecialProductionDal
    {

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string tjcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_SpecialProduction model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_SpecialProduction model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tjcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_SpecialProduction Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_SpecialProduction> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool SetCateProduction(string tjcode, string icode, string[] pcode);
        bool ReSetCateProduction(string tjcode, string icode);
        string GetCateProduction(string tjcode, string icode);
        #endregion  MethodEx
    }
}
