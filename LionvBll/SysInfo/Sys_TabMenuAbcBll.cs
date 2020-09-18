using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_TabMenuAbcBll
    {
       private readonly ISys_TabMenuAbcDal dal=DataAccess.CreateSys_TabMenuAbc();
 
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_TabMenuAbc model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_TabMenuAbc model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string idlist )
		{
			return dal.Delete(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_TabMenuAbc Query(string where)
		{

            return dal.Query(where);
		}

 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< Sys_TabMenuAbc> QueryList(string strWhere)
		{
 
			return  dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool CheckSql(Sys_TabMenuAbc m,string sid)
        {
            return dal.CheckSql(m,sid);
        }
		#endregion  ExtensionMethod
    }
}
