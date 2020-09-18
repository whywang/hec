using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_FixProductionBll
    {
       
		private readonly ISys_FixProductionDal dal=DataProductionAccess.CreateSys_FixProduction();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string apcode)
		{
			return dal.Exists(apcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_FixProduction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_FixProduction model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string apcode)
		{
			
			return dal.Delete(apcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_FixProduction Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public  List<Sys_FixProduction>  QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public int SetFixProduction(string fcode, string icode, string[] pcode)
        {
            return dal.SetFixProduction(fcode, icode, pcode);
        }
        public int ReSetFixProduction(string fcode, string icode)
        {
            return dal.ReSetFixProduction(fcode, icode);
        }
        public string GetFixProduction(string fcode, string icode)
        {
            return dal.GetFixProduction(fcode, icode);
        }
		#endregion  ExtensionMethod
    }
}
