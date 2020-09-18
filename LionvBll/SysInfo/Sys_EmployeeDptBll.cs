using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
    public class Sys_EmployeeDptBll
    {
        private readonly ISys_EmployeeDptDal r=DataAccess.CreateSys_EmployeeDpt();

		#region  BasicMethod
	
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Sys_EmployeeDpt model)
		{
			return r.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Sys_EmployeeDpt model)
		{
			return r.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return r.Delete(id);
		}
		 

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Sys_EmployeeDpt Query(string where)
		{
			
			return r.Query(where);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public List<Sys_EmployeeDpt> QueryList(string where)
		{
            return r.QueryList(where);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
		#endregion  ExtensionMethod
    }
}
