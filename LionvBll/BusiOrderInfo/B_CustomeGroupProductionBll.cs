using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvBll.BusiOrderInfo
{
   public class B_CustomeGroupProductionBll
    {
        private readonly IB_CustomeGroupProductionDal dal=BusiOrderAccess.CreateB_CustomeGroupProduction();
		 
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
		public int  Add( B_CustomeGroupProduction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_CustomeGroupProduction model)
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
		public  B_CustomeGroupProduction Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_CustomeGroupProduction> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int GetGnum(string where)
        {
            return dal.GetGnum(where);
        }
        public ArrayList GetGnumArr(string where)
        {
            return dal.GetGnumArr(where);
        }
		#endregion  ExtensionMethod
    }
}
