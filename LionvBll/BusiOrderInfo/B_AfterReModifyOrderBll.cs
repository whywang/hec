using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Data;
using LionvBll.SysInfo;
using LionvModel.SysInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_AfterReModifyOrderBll
    {
       private Sys_AreaBll sab = new Sys_AreaBll();
        private readonly IB_AfterReModifyOrderDal dal=BusiOrderAccess.CreateB_AfterReModifyOrder();
	 
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
		public int  Add( B_AfterReModifyOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_AfterReModifyOrder model)
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
		public  B_AfterReModifyOrder Query(string id)
		{
            B_AfterReModifyOrder ab=  dal.Query(id);
            if (ab != null)
            {
                Sys_Area sa = sab.QueryDepArea(ab.citycode);
                ab.salearea = sa != null ? sa.aname : "";
            }
            return ab;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterReModifyOrder> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
        public int GetOrderNum()
        {
            return dal.GetOrderNum();
        }
        public bool SaveDuty(B_AfterReModifyOrder ba)
        {
            return dal.SaveDuty(ba);
        }
        public bool SaveOverDate(string sid, string odate)
        {
            return dal.SaveOverDate(sid, odate);
        }
        public bool SetPackageNum(string sid, string bnum)
        {
            return dal.SetPackageNum(sid, bnum);
        }
        public bool SaveSendDate(string sid, string odate)
        {
            return dal.SaveSendDate(sid, odate);
        }
        public bool SetAppointment(B_AfterReModifyOrder model)
        {
            return dal.SetAppointment(model);
        }
        public bool SetFixer(string sid, string azperson)
        {
            return dal.SetFixer(sid, azperson);
        }
        public bool SetOverInfo(string sid, string otype, string odate, string oinfo, string cinfo,string fmoney)
        {
            return dal.SetOverInfo(sid, otype, odate, oinfo, cinfo,fmoney);
        }
        public bool SetTMoney(string sid, decimal tmoney)
        {
            return dal.SetTMoney(sid, tmoney);
        }
        public bool SetPmethod(string sid, string pmethod)
        {
            return dal.SetPmethod(sid, pmethod);
        }
		#endregion  ExtensionMethod
    }
}
