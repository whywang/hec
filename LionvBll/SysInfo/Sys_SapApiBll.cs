﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_SapApiBll
    {
       private readonly ISys_SapApiDal dal=DataAccess.CreateSys_SapApi();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string scode)
		{
			return dal.Exists(scode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_SapApi model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_SapApi model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string scode)
		{
			
			return dal.Delete(scode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_SapApi Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SapApi> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
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
