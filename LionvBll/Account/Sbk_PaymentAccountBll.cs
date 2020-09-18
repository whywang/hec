using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.Account;
using LionvFactoryDal;
using LionvIDal.Account;

namespace LionvBll.Account
{
   public class Sbk_PaymentAccountBll
    {
       private readonly ISbk_PaymentAccountDal dal=AccountAccess.CreateSbk_PaymentAccount();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sbk_PaymentAccount model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sbk_PaymentAccount model)
		{
			return dal.Update(model);
		}

 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where )
		{
			return dal.Delete(where );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Sbk_PaymentAccount Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sbk_PaymentAccount> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
		#endregion  ExtensionMethod
    }
}
