﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_OverConditionBll
    {
        private readonly ISys_OverConditionDal dal=DataAccess.CreateSys_OverCondition();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ccode)
		{
			return dal.Exists(ccode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_OverCondition model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_OverCondition model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
	 
		public bool Delete(string ccode)
		{
			
			return dal.Delete(ccode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_OverCondition Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
 
		public List< Sys_OverCondition> QueryList(string where)
		{
            return dal.QueryList(where); ;
		}
 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public int SetProductionOc(string icode,string pcode, string ocode)
        {
            return dal.SetProductionOc(icode,pcode, ocode);
        }
        public int ReSetProductionOc(string icode, string ocode)
        {
            return dal.ReSetProductionOc(icode,ocode);
        }
        public string GetProductionOc( string pcode)
        {
            return dal.GetProductionOc(pcode);
        }
        public string GetProductionOcEx(string icode, string ocode)
        {
            return dal.GetProductionOcEx(icode, ocode);
        }
		#endregion  ExtensionMethod
    }
}
