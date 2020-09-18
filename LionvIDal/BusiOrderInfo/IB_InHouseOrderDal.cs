using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_InHouseOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_InHouseOrder model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_InHouseOrder model);
        /// <summary>
        /// 删除一条数据
        /// </summary>

        bool Delete(string isid);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_InHouseOrder Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_InHouseOrder> QueryList(string strWhere);
      
        #endregion  成员方法
        #region  MethodEx
        int QueryIorderNum(string strWhere);
        bool SaveQualityOrder(B_InHouseOrder bpqo, List<B_InhousePackage> lq);
        #endregion  MethodEx
    } 
}
