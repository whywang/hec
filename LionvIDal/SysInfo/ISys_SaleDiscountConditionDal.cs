using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Collections;

namespace LionvIDal.SysInfo
{
    public interface ISys_SaleDiscountConditionDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_SaleDiscountCondition model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_SaleDiscountCondition model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_SaleDiscountCondition Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_SaleDiscountCondition> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
         bool AddList(string dcode,List<Sys_SaleDiscountCondition> ls);
         int CreateCode();
         ArrayList QuerySortNum(string acode);
        #endregion  MethodEx
    }
}
