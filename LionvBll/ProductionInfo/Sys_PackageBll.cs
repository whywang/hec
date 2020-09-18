using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_PackageBll
    {
       private readonly ISys_PackageDal dal=DataProductionAccess.CreateSys_Package();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string pcode)
		{
			return dal.Exists(pcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_Package model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_Package model)
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
		public Sys_Package Query(string where)
		{

            return dal.Query(where);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Sys_Package> QueryList(string strWhere)
		{
			return dal.QueryList(strWhere);
		}
		 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        { 
            return dal.CreateCode();
        }
        public int SetInvPackage(string pcode, string icode, string [] ppcode)
        { 
            return dal.SetInvPackage(pcode,  icode,  ppcode);
        }
        public int ReSetInvPackage(string pcode)
        { 
            return dal.ReSetInvPackage(pcode);
        }
        public string GetInvPackage(string pcode, string icode)
        { 
            return dal.GetInvPackage(pcode,icode);
        }
		#endregion  ExtensionMethod
    }
}
