using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvFactoryDal;
using LionvModel.Account;
using System.Data;

namespace LionvBll.Account
{
   public class B_CityPayOrderBll
    {
       private readonly IB_CityPayOrderDal dal = AccountAccess.CreateB_CityPayOrder();
 
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
		public int  Add( B_CityPayOrder model)
		{
			return dal.Add(model);
		}
        /// <summary>
        /// 增加一条数据草稿状态付款单
        /// </summary>
        public int AddDraft(B_CityPayOrder model)
        {
            return dal.AddDraft(model);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_CityPayOrder model)
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
		public  B_CityPayOrder Query(string id)
		{

            return dal.Query(id);
		}

	 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< B_CityPayOrder> QueryList(string strWhere)
		{

            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
		#endregion  ExtensionMethod
    }
}
