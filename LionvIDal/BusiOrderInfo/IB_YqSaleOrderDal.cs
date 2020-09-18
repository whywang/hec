using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_YqSaleOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_YqSaleOrder model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_YqSaleOrder model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string osid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_YqSaleOrder Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_YqSaleOrder> QueryList(string where);

        #endregion  成员方法
        #region  MethodEx
        void ExportToSaleOrder(string csid, string osid, string maker);
        void ExportToFixOrder(string csid, string osid, string maker);
        #region//获取正常订单
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        #endregion
        #region//获取取消订单
        DataTable CanalQueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        #endregion
        string QueryProductDate(string sid);
        string QueryFactoryDate(string sid);
        string QuerySendDate(string sid);
        void UpdateQr(string sid, string url);
        bool SetGDiscount(string sid, decimal dv);
        bool SetOrderCode(string sid, string cv);
        #endregion  MethodEx
    }
}
