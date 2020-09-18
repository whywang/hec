using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvSqlServerDal.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
    public class Sys_ComponentBll
    {
        
		private readonly ISys_ComponentDal dal=DataProductionAccess.CreateSys_Component();
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ccode)
		{
			return dal.Exists(ccode);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_Component model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_Component model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ccode)
		{
			
			return dal.Delete(ccode);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_Component Query(string where)
		{
			
			return dal.Query(where);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< Sys_Component> QueryList(string where)
		{
			 
			return dal.QueryList(where);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode(string where)
        {
            return dal.CreateCode(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddList(List<Sys_Component> model)
        {
            return dal.AddList(model);
        }
		#endregion  ExtensionMethod
    }
}
