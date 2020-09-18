using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    /// <summary>
    /// 接口层Sys_ProductionTemp
    /// </summary>
    public interface ISys_ProductionTempDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string tcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ProductionTemp model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ProductionTemp model);
       
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProductionTemp Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_ProductionTemp> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx
        int CreateCode(string where);
        #endregion  MethodEx
    } 
}
