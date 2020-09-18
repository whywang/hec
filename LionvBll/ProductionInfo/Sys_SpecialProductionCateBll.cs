using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public  class Sys_SpecialProductionCateBll
    {
       private readonly ISys_SpecialProductionCateDal dal = DataProductionAccess.CreateSys_SpecialProductionCate();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string tjlbcode)
		{
			return dal.Exists(tjlbcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_SpecialProductionCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_SpecialProductionCate model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string tjlbcode)
		{
			
			return dal.Delete(tjlbcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_SpecialProductionCate Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SpecialProductionCate> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetCatePCate(string ccode, string[] icode)
        {
            return dal.SetCatePCate(ccode, icode);
        }
        public bool ReSetCatePCate(string ccode)
        {
            return dal.ReSetCatePCate(ccode);
        }
        public string GetCatePCate(string ccode)
        {
            return dal.GetCatePCate(ccode);
        }
		#endregion  ExtensionMethod
    }
}
