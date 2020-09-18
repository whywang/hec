using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    /// <summary>
    /// 接口层Sys_ProductionTempCate
    /// </summary>
    public interface ISys_ProductionTempCateDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ptcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ProductionTempCate model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ProductionTempCate model);
     
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ptcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProductionTempCate Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_ProductionTempCate> QueryList(string strWhere);
      
        #endregion  成员方法
        #region  MethodEx
        int CreateCode(string where);
        bool SetInvTempCate(string icode, string ptcode);
        bool ReSetInvTempCate(string icode);
        string GetInvTempCate(string icode);
        #endregion  MethodEx
    } 
}
