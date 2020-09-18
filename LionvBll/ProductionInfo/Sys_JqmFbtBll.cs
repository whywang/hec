using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_JqmFbtBll
    {
        	private readonly ISys_JqmFbtDal dal=DataProductionAccess.CreateSys_JqmFbt();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string fbcode)
		{
			return dal.Exists(fbcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_JqmFbt model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_JqmFbt model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string fbcode)
		{
			
			return dal.Delete(fbcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_JqmFbt Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_JqmFbt> QueryList(string strWhere)
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
