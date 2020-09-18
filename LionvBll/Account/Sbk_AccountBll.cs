using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.Account;
using LionvModel.Account;

namespace LionvBll.Account
{
   public class Sbk_AccountBll
    {
        private readonly ISbk_AccountDal dal=AccountAccess.CreateSbk_Account();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string acode)
		{
			return dal.Exists(acode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sbk_Account model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sbk_Account model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string acode)
		{
			
			return dal.Delete(acode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sbk_Account Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sbk_Account> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetCredit(string acode, decimal cnum)
        {
            return dal.SetCredit(acode, cnum);
        }
		#endregion  ExtensionMethod
    }
}
