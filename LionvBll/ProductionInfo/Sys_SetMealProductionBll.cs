﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_SetMealProductionBll
    {

       private readonly ISys_SetMealProductionDal dal = DataProductionAccess.CreateSys_SetMealProduction();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string tcblbcode)
		{
			return dal.Exists(tcblbcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_SetMealProduction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_SetMealProduction model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string tcblbcode)
		{
			
			return dal.Delete(tcblbcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_SetMealProduction Query(string where)
		{

            return dal.Query(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< Sys_SetMealProduction> QueryList(string strWhere)
		{
			return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetSmProductin(string tcv, string iv, string[] pv)
        {
            return dal.SetSmProductin(tcv, iv, pv);
        }
        public bool ReSetSmProductin(string tcv, string iv)
        {
            return dal.ReSetSmProductin(tcv, iv);
        }
        public string GetSmProductin(string tcv, string iv)
        {
            return dal.GetSmProductin(tcv, iv);
        }

        public bool SetSmProductinAdd(string tcv, string iv, string[] pv)
        {
            return dal.SetSmProductinAdd(tcv, iv,pv);
        }
        public bool ReSetSmProductinAdd(string tcv, string iv)
        {
            return dal.ReSetSmProductinAdd(tcv, iv);
        }
        public string GetSmProductinAdd(string tcv, string iv)
        { 
            return dal.GetSmProductinAdd(tcv,iv);
        }
		#endregion  ExtensionMethod
    }
}
