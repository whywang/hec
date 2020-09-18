using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;
using System.Data;

namespace LionvBll.SysInfo
{
   public class Sys_DataTableBll
    {
        
		private readonly ISys_DataTableDal dal=DataAccess.CreateSys_DataTable();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_DataTable model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_DataTable model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{
			return dal.Delete(id);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_DataTable Query(string id)
		{
            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_DataTable> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
	 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataTable QueryTables()
        {
            return dal.QueryTables();
        }
		#endregion  ExtensionMethod
    }
}
