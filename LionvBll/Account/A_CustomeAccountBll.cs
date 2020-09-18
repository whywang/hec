using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvFactoryDal;
using LionvModel.Account;
using ViewModel.Account;
using System.Data;

namespace LionvBll.Account
{
   public class A_CustomeAccountBll
    {
        private readonly IA_CustomeAccountDal dal=AccountAccess.CreateA_CustomeAccount();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			return dal.Exists(where);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( A_CustomeAccount model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( A_CustomeAccount model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string idlist )
		{
			return dal.Delete(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  A_CustomeAccount Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<A_CustomeAccount> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
	
		#endregion  BasicMethod
		#region  ExtensionMethod
        public VCustomeAccount QueryCustomeAccount(string where)
        {
            return dal.QueryCustomeAccount(where);
        }
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(A_CustomeAccount model)
        {
            return dal.UpdateEx(model);
        }
		#endregion  ExtensionMethod
    }
}
