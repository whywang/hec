﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_DesignerBll
    {
        private readonly ISys_DesignerDal dal=DataAccess.CreateSys_Designer();
 
		#region  BasicMethod
        public bool Exists(string where)
        {
            return dal.Exists(where);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_Designer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_Designer model)
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
		public Sys_Designer Query(string id)
		{
			
			return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Designer> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
 
	 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
