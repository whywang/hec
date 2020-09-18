using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_EventMenuAttrBll
    {
        
		private readonly ISys_EventMenuAttrDal dal=DataAccess.CreateSys_EventMenuAttr();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_EventMenuAttr model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_EventMenuAttr model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{
			
			return dal.Delete(id);
		}
	 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_EventMenuAttr Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_EventMenuAttr> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
