using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvFactoryDal;
using LionvModel.Account;

namespace LionvBll.Account
{
   public class Sbk_CollectionAccountBll
    {
        private readonly ISbk_CollectionAccountDal dal=AccountAccess.CreateSbk_CollectionAccount();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string bcode)
		{
			return dal.Exists(bcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sbk_CollectionAccount model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sbk_CollectionAccount model)
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
        public Sbk_CollectionAccount Query(string strWhere)
		{

            return dal.Query(strWhere);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sbk_CollectionAccount> QueryList(string strWhere)
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
