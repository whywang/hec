using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_SaleMaterielOrderDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string sid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_SaleMaterielOrder model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_SaleMaterielOrder model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string sid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_SaleMaterielOrder Query(string where);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_SaleMaterielOrder> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         #region//获取正常订单
         DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
         #endregion
         bool SetOrderCode(string sid, string cv);
		#endregion  MethodEx
    }
}
