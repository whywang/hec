using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_InventoryDetailDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string icode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_InventoryDetail model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_InventoryDetail model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string icode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_InventoryDetail Query(string where);
        Sys_InventoryDetail DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_InventoryDetail> QueryList(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_InventoryDetail> QueryList(int num,string strWhere);
        #endregion  成员方法
        #region  MethodEx
        int CreateCode(string iccode);
        int SetPricce(string sql);
        int SetState(string sql);
        #endregion  MethodEx
    }
}
