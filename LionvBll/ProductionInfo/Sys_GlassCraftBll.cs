using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_GlassCraftBll
    {
        
		private readonly ISys_GlassCraftDal dal=DataProductionAccess.CreateSys_GlassCraft();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string gccode)
		{
			return dal.Exists(gccode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_GlassCraft model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_GlassCraft model)
		{
			return dal.Update(model);
		}

 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string gccode)
		{
			
			return dal.Delete(gccode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_GlassCraft Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_GlassCraft> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetGlassCraft(string pcode, string gccode)
        {
            return dal.SetGlassCraft(pcode, gccode);
        }
        public bool ReSetGlassCraft(string pcode)
        {
            return dal.ReSetGlassCraft(pcode);
        }
        public string GetGlassCraft(string pcode)
        {
            return dal.GetGlassCraft(pcode);
        }
		#endregion  ExtensionMethod
    }
}
