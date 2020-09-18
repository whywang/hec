using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_XsOverCondtionCategoryBll
    {
        private readonly ISys_XsOverCondtionCategoryDal dal=DataProductionAccess.CreateSys_XsOverCondtionCategory();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ocode)
		{
			return dal.Exists(ocode);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_XsOverCondtionCategory model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_XsOverCondtionCategory model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ocode)
		{
			
			return dal.Delete(ocode);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_XsOverCondtionCategory Query(string where)
		{

            return dal.Query(where);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< Sys_XsOverCondtionCategory> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere); ;
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
