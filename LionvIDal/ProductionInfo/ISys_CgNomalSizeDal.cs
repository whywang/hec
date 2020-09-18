using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_CgNomalSizeDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where );
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_CgNomalSize model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_CgNomalSize model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
 
        bool Delete(string ncode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_CgNomalSize Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_CgNomalSize> QueryList(string strWhere);
      
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         int SetProductionNs(string pcode, string ncode);
         int ReSetProductionNs(string pcode);
         string GetProductionNs(string pcode);
        #endregion  MethodEx
    }
}
