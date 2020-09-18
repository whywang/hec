using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_SpecialProductionCateDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string tjlbcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_SpecialProductionCate model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_SpecialProductionCate model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tjlbcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_SpecialProductionCate Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_SpecialProductionCate> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         bool SetCatePCate(string ccode, string[] icode);
         bool ReSetCatePCate(string ccode);
         string GetCatePCate(string ccode);
        #endregion  MethodEx
    }
}
