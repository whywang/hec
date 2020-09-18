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
    public class B_CustormOrderBll
    {
        private readonly IB_CustormOrderDal dal = BusiOrderAccess.CreateB_CustormOrder();
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string csid)
		{
			return dal.Exists(csid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(B_CustormOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(B_CustormOrder model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where)
		{

            return dal.Delete(where);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public B_CustormOrder Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_CustormOrder> QueryList(string where)
		{
            return dal.QueryList(where);
		}
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool SetThirdDep(string tname, string tcode, string sid)
        {
            return dal.SetThirdDep(tname,tcode,sid);
        }
		#endregion  ExtensionMethod
    }
}
