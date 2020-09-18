using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_BrandsBll
    {
       private readonly ISys_BrandsDal dal = DataProductionAccess.CreateSys_Brands();
		 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string pbcode)
		{
			return dal.Exists(pbcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_Brands model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_Brands model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string pbcode)
		{
			
			return dal.Delete(pbcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_Brands Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Brands> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetDepBrand(string dcode, string pbcode)
        {
            return dal.SetDepBrand(dcode, pbcode);
        }
        public bool ReSetDepBrand(string dcode)
        {
            return dal.ReSetDepBrand(dcode);
        }
        public string GetDepBrand(string dcode)
        {
            return dal.GetDepBrand(dcode);
        }

        public bool SetMaterialBrand(string pbcode, string mpcode, string mcode)
        {
            return dal.SetMaterialBrand(pbcode, mpcode, mcode);
        }
        public bool ReSetMaterialBrand(string pbcode, string mcode)
        {
            return dal.ReSetMaterialBrand(pbcode,mcode);
        }
        public string GetMaterialBrand(string pbcode,string mpcode)
        {
            return dal.GetMaterialBrand(pbcode, mpcode);
        }

        public bool SetInventroyBrand(string pbcode, string icode)
        {
            return dal.SetInventroyBrand(pbcode, icode);
        }
        public bool ReSetInventroyBrand(string pbcode, string icode)
        {
            return dal.ReSetInventroyBrand(pbcode, icode);
        }
        public string GetInventroyBrand(string pbcode, string icode)
        {
            return dal.GetInventroyBrand(pbcode, icode);
        }
        public string QueryDepByBcode(string bcode)
        {
            return dal.QueryDepByBcode(bcode);
        }
		#endregion  ExtensionMethod
    }
}
