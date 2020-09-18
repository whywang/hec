using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_JqmSjBll
    {
        private readonly ISys_JqmSjDal dal=DataProductionAccess.CreateSys_JqmSj();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sjname)
		{
			return dal.Exists(sjname);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_JqmSj model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_JqmSj model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sjname)
		{
			
			return dal.Delete(sjname);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_JqmSj Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_JqmSj> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
	 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
