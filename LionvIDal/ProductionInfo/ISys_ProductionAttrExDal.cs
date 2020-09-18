using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ProductionAttrExDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string acode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ProductionAttrEx model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ProductionAttrEx model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string acode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProductionAttrEx Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_ProductionAttrEx> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        #endregion  MethodEx
    }
}
