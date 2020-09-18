using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_AfterReModifyOrderDal
    {
        
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string sid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_AfterReModifyOrder model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_AfterReModifyOrder model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string sid);
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_AfterReModifyOrder Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_AfterReModifyOrder> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
         int GetOrderNum();
         bool SaveDuty(B_AfterReModifyOrder ba);
         bool SaveOverDate(string sid, string odate);
         bool SetPackageNum(string sid, string bnum);
         bool SaveSendDate(string sid, string odate);
         bool SetAppointment(B_AfterReModifyOrder ba);
         bool SetFixer(string sid, string azperson);
         bool SetOverInfo(string sid, string otype, string odate, string oinfo, string cinfo,string fmoney);
         bool SetTMoney(string sid, decimal tmoney);
         bool SetPmethod(string sid, string pmethod);
        #endregion  MethodEx
    }
}
