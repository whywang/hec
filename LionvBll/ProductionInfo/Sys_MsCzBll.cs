using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_MsCzBll
    {
        private readonly ISys_MsCzDal dal=DataProductionAccess.CreateSys_MsCz();
 
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_MsCz model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_MsCz model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string czcode)
		{
			
			return dal.Delete(czcode);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_MsCz Query(string id)
		{

            return dal.Query(id);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_MsCz> QueryList(string where)
		{

            return dal.QueryList(where);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetMsCz(string icode, string czcode)
        {
            return dal.SetMsCz(icode, czcode);
        }
        public bool ReSetMsCz(string icode)
        {
            return dal.ReSetMsCz(icode);
        }
        public string GetMsCz(string icode)
        {
            return dal.GetMsCz(icode);
        }
        public string QueryEx(string icode)
        {
            string czcode = GetMsCz(icode);
            Sys_MsCz smc= dal.Query(" and czcode='"+czcode+"'");
            return smc != null ? smc.czname : "";
        }
		#endregion  ExtensionMethod
    }
}
