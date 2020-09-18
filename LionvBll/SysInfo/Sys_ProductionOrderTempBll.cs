using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_ProductionOrderTempBll
    {
        private readonly ISys_ProductionOrderTempDal dal=DataAccess.CreateSys_ProductionOrderTemp();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string tcode)
		{
			return dal.Exists(tcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_ProductionOrderTemp model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ProductionOrderTemp model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string tcode)
		{
			
			return dal.Delete(tcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_ProductionOrderTemp Query(string id)
		{
            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionOrderTemp> QueryList(string strWhere)
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
