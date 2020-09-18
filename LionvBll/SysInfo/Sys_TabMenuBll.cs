using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_TabMenuBll
    {
       private readonly ISys_TabMenuDal dal=DataAccess.CreateSys_TabMenu();
 
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_TabMenu model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_TabMenu model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string tmcode)
		{
			
			return dal.Delete(tmcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_TabMenu Query(string id)
		{

            return dal.Query(id);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< Sys_TabMenu> QueryList(string strWhere)
		{
 
			return dal.QueryList(strWhere);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetTabMenuEvent(string tcode, string ecode, string dcode)
        {
            return dal.SetTabMenuEvent(tcode, ecode, dcode);
        }
        public bool ReSetTabMenuEvent(string tcode, string dcode)
        {
            return dal.ReSetTabMenuEvent(tcode, dcode);
        }
        public string GetTabMenuEvent(string tcode, string dcode)
        {
            return dal.GetTabMenuEvent(tcode, dcode);
        }
		#endregion  ExtensionMethod
    }
}
