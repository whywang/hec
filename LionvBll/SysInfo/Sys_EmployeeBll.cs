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
   public class Sys_EmployeeBll
    {
       private readonly ISys_EmployeeDal r=DataAccess.CreateSys_Employee();
       public Sys_EmployeeBll()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string eno)
		{
			return r.Exists(eno);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_Employee model)
		{
			return r.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_Employee model)
		{
			return r.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where)
		{
			
			return r.Delete(where);
		}
		 

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_Employee Query(string where)
		{
			
			return r.Query(where);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public List<Sys_Employee> QueryList(string where)
		{
            return r.QueryList(where);
		}

 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int AddList(Sys_Employee se, Sys_EmployeeDpt sed, Sys_User su)
        {
            return r.AddList(se, sed, su);
        }
        public int UpdateList(string eno, Sys_Employee se, Sys_EmployeeDpt sed, Sys_User su)
        {
            return r.UpdateList(eno, se, sed, su);
        }
        public int GetEno()
        {
            return r.GetEno();
        }
        public DataTable QueryEmploy(string where)
        {
            return r.QueryEmploy(where);
        }
		#endregion  ExtensionMethod
    }
}
