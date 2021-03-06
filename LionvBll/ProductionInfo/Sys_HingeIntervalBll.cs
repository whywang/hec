﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_HingeIntervalBll
    {
        private readonly ISys_HingeIntervalDal dal=DataProductionAccess.CreateSys_HingeInterval();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string hcode)
		{
			return dal.Exists(hcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_HingeInterval model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_HingeInterval model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string hcode)
		{
			
			return dal.Delete(hcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_HingeInterval Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_HingeInterval> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public int QueryIntervalValue( int hv)
        {
            Sys_HingeInterval shi = dal.Query(" and lv<=" + hv + " and tv>=" + hv + "");
            if (shi != null)
            {
                return shi.iv;
            }
            else
            {
                return 0;
            }
        }
		#endregion  ExtensionMethod
    }
}
