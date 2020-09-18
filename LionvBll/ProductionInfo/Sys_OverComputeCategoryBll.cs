using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_OverComputeCategoryBll
    {
        private readonly ISys_OverComputeCategoryDal dal=DataAccess.CreateSys_OverComputeCategory();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ocode)
		{
			return dal.Exists(ocode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_OverComputeCategory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_OverComputeCategory model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
 
		public bool Delete(string ocode)
		{
			
			return dal.Delete(ocode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_OverComputeCategory Query(string where)
		{

            return dal.Query(where);
		}
 
        public List<Sys_OverComputeCategory> QueryList(string where)
		{
          
			return    dal.QueryList(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
		#endregion  ExtensionMethod
    }
}
