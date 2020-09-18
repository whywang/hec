using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvFactoryDal;

namespace LionvBll.BusiOrderInfo
{
   public class B_MzDesignPlanBll
    {
       private readonly IB_MzDesignPlanDal dal = BusiOrderAccess.CreateB_MzDesignPlan();
 
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_MzDesignPlan model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_MzDesignPlan model)
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
		public  B_MzDesignPlan Query(string where)
		{

            return dal.Query(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< B_MzDesignPlan> QueryList(string strWhere)
		{

            return dal.QueryList(strWhere);
		}
	 
	 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
