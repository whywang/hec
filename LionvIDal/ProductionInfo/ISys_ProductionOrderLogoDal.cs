using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ProductionOrderLogoDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string dcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_ProductionOrderLogo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_ProductionOrderLogo model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_ProductionOrderLogo Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_ProductionOrderLogo> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
         bool UpdateLogo(Sys_ProductionOrderLogo m, string ltype);
         bool DelLogo(string dcode, string ltype);
        #endregion  MethodEx
    }
}
