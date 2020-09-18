using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_GlassDirectionBll
    {
       private readonly ISys_GlassDirectionDal dal=DataProductionAccess.CreateSys_GlassDirection();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string gdcode)
		{
			return dal.Exists(gdcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_GlassDirection model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_GlassDirection model)
		{
			return dal.Update(model);
		}

 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string gdcode)
		{
			
			return dal.Delete(gdcode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_GlassDirection Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_GlassDirection> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetGlassDire(string pcode, string gdcode)
        {
            return dal.SetGlassDire(pcode, gdcode);
        }
        public bool ReSetGlassDire(string pcode)
        {
            return dal.ReSetGlassDire(pcode);
        }
        public string GetGlassDire(string pcode)
        {
            return dal.GetGlassDire(pcode);
        }
		#endregion  ExtensionMethod
    }
}
