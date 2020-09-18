using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_SizeLimitedBll
    {
      private readonly ISys_SizeLimitedDal dal=DataProductionAccess.CreateSys_SizeLimited();
 
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_SizeLimited model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_SizeLimited model)
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
		public Sys_SizeLimited Query(string where)
		{

            return dal.Query(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Sys_SizeLimited> QueryList(string strWhere)
		{
			return  	 dal.QueryList(strWhere);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetSizeLimitedCate(string icode, string lcode)
        {
            return dal.SetSizeLimitedCate(icode, lcode);
        }
        public bool ReSetSizeLimitedCate(string icode)
        {
            return dal.ReSetSizeLimitedCate(icode);
        }
        public string GetSizeLimitedCate(string icode)
        {
            return dal.GetSizeLimitedCate(icode);
        }
		#endregion  ExtensionMethod
    }
}
