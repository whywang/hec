using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_HelpContextBll
    {
       private readonly ISys_HelpContextDal dal=DataAccess.CreateSys_HelpContext();
 
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_HelpContext model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Sys_HelpContext Query(string where)
		{
			
			return dal.Query(where);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
