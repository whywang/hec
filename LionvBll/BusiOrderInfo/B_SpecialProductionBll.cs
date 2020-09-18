using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_SpecialProductionBll
    {
       private readonly IB_SpecialProductionDal dal=BusiOrderAccess.CreateB_SpecialProduction();
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_SpecialProduction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_SpecialProduction model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string gsid)
		{
			
			return dal.Delete(gsid);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_SpecialProduction Query(string where)
		{

            return dal.Query(where);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< B_SpecialProduction> QueryList(string strWhere)
		{
			return dal.QueryList(strWhere);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        #region//获取特价产品单项金额
        public decimal QueryItemPrice(string gsid)
        {
            return dal.QueryItemPrice(gsid);
        }
        #endregion
        #region//获取特价产品总金额
        public decimal QueryAllPrice(string sid)
        {
            return dal.QueryAllPrice(sid);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
