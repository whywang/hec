using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_SpecialProductionBll
    {
       private readonly ISys_SpecialProductionDal dal = DataProductionAccess.CreateSys_SpecialProduction();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string tjcode)
		{
			return dal.Exists(tjcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_SpecialProduction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_SpecialProduction model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string tjcode)
		{
			
			return dal.Delete(tjcode);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_SpecialProduction Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< Sys_SpecialProduction> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetCateProduction(string tjcode,string icode,string[] pcode)
        {
            return dal.SetCateProduction(tjcode, icode, pcode);
        }
        public bool ReSetCateProduction(string tjcode, string icode)
        {
            return dal.ReSetCateProduction(tjcode, icode);
        }
        public string GetCateProduction(string tjcode, string icode)
        {
            return dal.GetCateProduction(tjcode, icode);
        }
		#endregion  ExtensionMethod
    }
}
