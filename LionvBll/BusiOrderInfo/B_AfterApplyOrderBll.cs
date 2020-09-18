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
    public class B_AfterApplyOrderBll
    {
        private readonly IB_AfterApplyOrderDal dal=BusiOrderAccess.CreateB_AfterApplyOrder();
	 
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
		public int  Add(B_AfterApplyOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(B_AfterApplyOrder model)
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
		public B_AfterApplyOrder Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterApplyOrder> QueryList(string strWhere)
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
		#endregion  ExtensionMethod
    }
}
