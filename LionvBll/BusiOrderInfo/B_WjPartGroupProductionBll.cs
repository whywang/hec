using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
    public class B_WjPartGroupProductionBll
    {
        private readonly IB_WjPartGroupProductionDal dal=BusiOrderAccess.CreateB_WjPartGroupProduction();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string psid)
		{
			return dal.Exists(psid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_WjPartGroupProduction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_WjPartGroupProduction model)
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
		public  B_WjPartGroupProduction Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_WjPartGroupProduction> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        //检测备货产品数量
        public bool CheckPrePareState(string sid,string fv)
        {
            return dal.CheckPrePareState(sid,fv);
        }
		#endregion  ExtensionMethod
    }
}
