using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
   public class Sys_InventoryCategoryBll
    {
       private readonly ISys_InventoryCategoryDal dal=DataAccess.CreateSys_InventoryCategory();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string iccode)
		{
			return dal.Exists(iccode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_InventoryCategory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_InventoryCategory model)
		{
			return dal.Update(model);
		}

		 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string iccode)
		{
			
			return dal.Delete(iccode);
		}
	 

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Sys_InventoryCategory Query(string  where)
		{
			
			return dal.Query(where);
		}


        public List<Sys_InventoryCategory> QueryList(string where)
		{
            return dal.QueryList(where);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode(string where)
        {
            return dal.CreateCode(where);
        }
        #endregion  ExtensionMethod
    }
}
