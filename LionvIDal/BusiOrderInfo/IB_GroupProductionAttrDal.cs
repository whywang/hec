using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_GroupProductionAttrDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( B_GroupProductionAttr model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( B_GroupProductionAttr model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         B_GroupProductionAttr Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<B_GroupProductionAttr> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx
         int AddList(List<B_GroupProductionAttr> model, string gsid);
         decimal QueryProductionMoney(string where);
        #endregion  MethodEx
    }
}
