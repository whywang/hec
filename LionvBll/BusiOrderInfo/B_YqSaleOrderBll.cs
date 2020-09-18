using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvBll.BusiOrderInfo
{
   public class B_YqSaleOrderBll
    {
        private readonly IB_YqSaleOrderDal dal = BusiOrderAccess.CreateB_YqSaleOrder();
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string osid)
        {
            return dal.Exists(osid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_YqSaleOrder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_YqSaleOrder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string osid)
        {

            return dal.Delete(osid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_YqSaleOrder Query(string where)
        {

            return dal.Query(where);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_YqSaleOrder> QueryList(string where)
        {
            return dal.QueryList(where);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        //从预定单导入销售订单
        public void ExportToSaleOrder(string csid, string sid, string maker)
        {
            dal.ExportToSaleOrder(csid, sid, maker);
        }
        public void ExportToFixOrder(string csid, string sid, string maker)
        {
            dal.ExportToFixOrder(csid, sid, maker);
        }

        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
        public DataTable CanalQueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.CanalQueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
        public string QueryProductDate(string sid)
        {
            return dal.QueryProductDate(sid);
        }
        public string QueryFactoryDate(string sid)
        {
            return dal.QueryFactoryDate(sid);
        }
        public string QuerySendDate(string sid)
        {
            return dal.QuerySendDate(sid);
        }
        public void UpdateQr(string sid, string url)
        {
            dal.UpdateQr(sid, url);
        }
        public bool SetGDiscount(string sid, decimal dv)
        {
            return dal.SetGDiscount(sid, dv);
        }

        /// 设置订单编码
        public bool SetOrderCode(string sid, string cv)
        {
            return dal.SetOrderCode(sid, cv);
        }
        #endregion  ExtensionMethod
    }
}
