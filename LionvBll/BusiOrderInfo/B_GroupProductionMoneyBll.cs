using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using System.Collections;

namespace LionvBll.BusiOrderInfo
{
    public class B_GroupProductionMoneyBll
    {
        private readonly IB_GroupProductionMoneyDal dal = BusiOrderAccess.CreateB_GroupProductionMoney();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string psid)
        {
            return dal.Exists(psid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_GroupProductionMoney model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_GroupProductionMoney model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string psid)
        {
            return dal.Delete(psid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public B_GroupProductionMoney Query(string strWhere)
        {
            return dal.Query(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_GroupProductionMoney> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool SetProductionPrice(List<B_GroupProductionMoney> bfpms, string ptype)
        {
            return dal.SetProductionPrice(bfpms, ptype);
        }
        //ptype 为价格类型（销售、供货、采购）；mtype未金额类型（标准金额、实际金额）
        public decimal QueryGroupMoney(string gsid, string ptype, string mtype)
        {
            return dal.QueryGroupMoney(gsid, ptype, mtype);
        }
        //ptype 为价格类型（销售、供货、采购）；mtype未金额类型（标准金额、实际金额）
        public decimal[] QueryGroupMoneyDetail(string gsid, string ptype, string mtype)
        {
            return dal.QueryGroupMoneyDetail(gsid, ptype, mtype);
        }
        //获取订单金额
        public decimal QueryOrderMoney(string sid, string ptype, string mtype)
        {
            return dal.QueryOrderMoney(sid, ptype, mtype);
        }
        //获取订单产品分类金额
        public decimal QueryClassOrderMoney(string sid, string ptype, string mtype, string ctype)
        {
            return dal.QueryClassOrderMoney(sid, ptype, mtype, ctype);
        }
        //更新价格
        public bool EditProductionMoney(ArrayList plist ,string ttype)
        {
            return dal.EditProductionMoney(plist , ttype);
        }
        #endregion  ExtensionMethod
    }
}
