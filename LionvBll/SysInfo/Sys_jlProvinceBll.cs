using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_jlProvinceBll
    {
        private readonly ISys_jlProvinceDal dal=DataAccess.CreateSys_jlProvince();
	 
		#region  BasicMethod
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_jlProvince Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_jlProvince> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
