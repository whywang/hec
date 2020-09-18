using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    /// <summary>
    /// 接口层Sys_ProductionPriceTempCate
    /// </summary>
    public interface ISys_ProductionPriceTempCateDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ppicode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ProductionPriceTempCate model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ProductionPriceTempCate model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ppicode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProductionPriceTempCate Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_ProductionPriceTempCate> QueryList(string strWhere);
       
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();

        bool SetInvPtemp(string icode, string ppcode);
        bool ReSetInvPtemp(string icode);
        string GetInvPtemp(string icode);
        #endregion  MethodEx
    } 
}
