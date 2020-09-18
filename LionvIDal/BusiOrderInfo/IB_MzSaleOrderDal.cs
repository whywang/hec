using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
    /// <summary>
    /// 接口层B_MzSaleOrder
    /// </summary>
    public interface IB_MzSaleOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string sid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_MzSaleOrder model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_MzSaleOrder model);

        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_MzSaleOrder Query(string where);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_MzSaleOrder> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        #region//获取正常订单
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        #endregion
        #region//获取取消订单
        DataTable CanalQueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        #endregion
        bool SetOrderCode(string sid, string cv);
        bool SetOrderType(string sid, string cv);
        bool SetCustomMoney(string sid, string cv);
        bool SetDesign(string sid, string dv);
        bool SetOrderMoney(string sid, string ov);
        bool SetProductionType(string sid, string pv);
        #endregion  MethodEx
    } 
}
