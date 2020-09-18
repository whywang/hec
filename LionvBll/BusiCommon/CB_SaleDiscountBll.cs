using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
   public  class CB_SaleDiscountBll
    {
       private readonly ICB_SaleDiscountDal dal=BusiCommonAccess.CreateCB_SaleDiscount();
 
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
		public int  Add( CB_SaleDiscount model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( CB_SaleDiscount model)
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
		public  CB_SaleDiscount Query(string id)
		{

            return dal.Query(id);
		}

 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< CB_SaleDiscount> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
