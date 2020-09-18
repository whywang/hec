using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_CgOverCondtionCategoryDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_CgOverCondtionCategory model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_CgOverCondtionCategory model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_CgOverCondtionCategory Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_CgOverCondtionCategory> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        #endregion  MethodEx
    }
}
