using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_FixProductionBll
    {
       private readonly IB_FixProductionDal dal=BusiOrderAccess.CreateB_FixProduction();
 
		#region  BasicMethod
       public bool Exists(string where)
       {
           return dal.Exists(where);
       }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_FixProduction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_FixProduction model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string psid)
		{
			return dal.Delete(psid);
		}
 

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public B_FixProduction Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_FixProduction> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool SaveFixProductionList(string sid, List<B_FixProduction> lbf)
        {
            return dal.SaveFixProductionList(sid, lbf);
        }
        public decimal QueryOrderMoney(string where)
        {
            return dal.QueryOrderMoney(where);
        }
		#endregion  ExtensionMethod
    }
}
