using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
   public interface IB_YqAfterSaleOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string sid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_YqAfterSaleOrder model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_YqAfterSaleOrder model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string sid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_YqAfterSaleOrder Query(string where);
        List<B_YqAfterSaleOrder> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        //#region//获取取消订单
        //DataTable CanalQueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        //#endregion
        //string QueryProductDate(string sid);
        //string QueryFactoryDate(string sid);
        //void UpdateQr(string sid, string url);
        int SetDuty(string sid, string dcode, string clfs, decimal om);
        //bool SetGDiscount(string sid, decimal dv);
        //bool SetOrderCode(string sid, string cv);
        //bool SetOrderMoney(string sid, string cv);
        #endregion  MethodEx
    }
}
