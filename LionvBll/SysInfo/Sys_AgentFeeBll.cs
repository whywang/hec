using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public  class Sys_AgentFeeBll
    {
        private readonly ISys_AgentFeeDal dal=DataAccess.CreateSys_AgentFee();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
            return dal.Exists(where);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_AgentFee model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_AgentFee model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where)
		{

            return dal.Delete(where);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_AgentFee Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_AgentFee> QueryList(string where)
		{
            return dal.QueryList(where);
		}


		#endregion  BasicMethod
		#region  ExtensionMethod
        public string GetProductionFee(string acode,string icode)
        {
            return dal.GetProductionFee(acode, icode);
        }
		#endregion  ExtensionMethod
    }
}
