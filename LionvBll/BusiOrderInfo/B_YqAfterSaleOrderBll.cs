using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvBll.BusiOrderInfo
{
   public class B_YqAfterSaleOrderBll
    {
        private readonly IB_YqAfterSaleOrderDal dal = BusiOrderAccess.CreateB_YqAfterSaleOrder();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string sid)
        {
            return dal.Exists(sid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_YqAfterSaleOrder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_YqAfterSaleOrder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string sid)
        {

            return dal.Delete(sid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_YqAfterSaleOrder Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_YqAfterSaleOrder> QueryList(string where)
        {
            return dal.QueryList(where);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
        //public DataTable CanalQueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        //{
        //    return dal.CanalQueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        //}
        //public string QueryProductDate(string sid)
        //{
        //    return dal.QueryProductDate(sid);
        //}
        //public string QueryFactoryDate(string sid)
        //{
        //    return dal.QueryFactoryDate(sid);
        //}
        //public void UpdateQr(string sid, string url)
        //{
        //    dal.UpdateQr(sid, url);
        //}
        public int SetDuty(string sid, string dcode, string clfs, decimal om)
        {
            return dal.SetDuty(sid, dcode, clfs, om);
        }
        //public bool SetGDiscount(string sid, decimal dv)
        //{
        //    return dal.SetGDiscount(sid, dv);
        //}
        ///// 设置订单编码
        //public bool SetOrderCode(string sid, string cv)
        //{
        //    return dal.SetOrderCode(sid, cv);
        //}
        ///// 设置售后单金额
        //public bool SetOrderMoney(string sid, string cv)
        //{
        //    return dal.SetOrderMoney(sid, cv);
        //}
        #endregion  ExtensionMethod
    }
}
