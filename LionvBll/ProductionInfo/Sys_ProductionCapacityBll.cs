using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_ProductionCapacityBll
    {
        private readonly ISys_ProductionCapacityDal dal=DataProductionAccess.CreateSys_ProductionCapacity();
		 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string cccode)
		{
			return dal.Exists(cccode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_ProductionCapacity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ProductionCapacity model)
		{
			return dal.Update(model);
		}

 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string cccode)
		{
			
			return dal.Delete(cccode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_ProductionCapacity Query(string id)
		{
			
			return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Sys_ProductionCapacity> QueryList(string strWhere)
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
