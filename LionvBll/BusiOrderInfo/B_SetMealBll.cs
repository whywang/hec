using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
    public class B_SetMealBll
    {
        private readonly IB_SetMealDal dal = BusiOrderAccess.CreateB_SetMeal();
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string tsid)
		{
			return dal.Exists(tsid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_SetMeal model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_SetMeal model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string tsid)
		{
			
			return dal.Delete(tsid);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_SetMeal Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<B_SetMeal> QueryList(string strWhere)
		{
			return dal.QueryList(strWhere);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool DelTcProduction(string sid, string tsid)
        {
            return dal.DelTcProduction( sid,  tsid);
        }
        #region//获取订单套餐金额
        public decimal GQueryTcMoney(string sid)
        {
            return dal.GQueryTcMoney(sid);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
