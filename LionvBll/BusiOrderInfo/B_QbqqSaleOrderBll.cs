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
    public class B_QbqqSaleOrderBll
    {
        private readonly IB_QbqqSaleOrderDal dal = BusiOrderAccess.CreateB_QbqqSaleOrder();
 
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
		public int  Add( B_QbqqSaleOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_QbqqSaleOrder model)
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
		public  B_QbqqSaleOrder Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_QbqqSaleOrder> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
        public DataTable CanalQueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.CanalQueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
        /// 设置订单编码
        public bool SetOrderCode(string sid, string cv)
        {
            return dal.SetOrderCode(sid, cv);
        }
        #region//设置类型
        public bool SetOrderType(string sid, string cv)
        { 
            return dal.SetOrderType(sid,cv);
        }
        #endregion
        #region//设置木作订金
        public bool SetCustomMoney(string sid, string cv)
        {
            return dal.SetCustomMoney(sid, cv);
        }
        #endregion
        #region//设置设计类型设计师
        public bool SetDesign(string sid, string dv)
        {
            return dal.SetDesign(sid, dv);
        }
        #endregion
        #region//设置木作金额
        public bool SetOrderMoney(string sid, string ov)
        {
            return dal.SetOrderMoney(sid, ov);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
