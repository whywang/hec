using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvBll.ProductionInfo
{
   public class Sys_SizeTransformRBll
    {
        private readonly ISys_SizeTransformRDal dal=DataProductionAccess.CreateSys_SizeTransformR();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string rcode)
		{
			return dal.Exists(rcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_SizeTransformR model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_SizeTransformR model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string rcode)
		{
			
			return dal.Delete(rcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_SizeTransformR Query(string id)
		{

            return dal.Query(id);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SizeTransformR> QueryList(string strWhere)
		{  
			return  dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetRjc(string mcode, string tcode, string cname, string rcode)
        {
            return dal.SetRjc(mcode, tcode, cname, rcode);
        }
        public bool ReSetRjc(string mcode, string tcode, string cname)
        {
            return dal.ReSetRjc(mcode, tcode, cname);
        }
        public string GetRjc(string mcode, string tcode, string cname)
        {
            return dal.GetRjc(mcode, tcode, cname);
        }
        public DataTable QueryCaveType(string mcode, string tcode)
        {
            return dal.QueryCaveType(mcode, tcode);
        }
		#endregion  ExtensionMethod
    }
}
