using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_JqmHyBll
    {
       
		private readonly ISys_JqmHyDal dal=DataProductionAccess.CreateSys_JqmHy();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string hyname)
		{
			return dal.Exists(hyname);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_JqmHy model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_JqmHy model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string hyname)
		{
			
			return dal.Delete(hyname);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_JqmHy Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_JqmHy> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
