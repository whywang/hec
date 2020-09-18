using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_SectionPriceCateBll
    {
        private readonly ISys_SectionPriceCateDal dal=DataProductionAccess.CreateSys_SectionPriceCate();
 
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
		public int  Add( Sys_SectionPriceCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_SectionPriceCate model)
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
        public Sys_SectionPriceCate Query(string id)
		{
            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SectionPriceCate> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetSectionPrice(string[] pcode, string scode,string uname)
        {
            return dal.SetSectionPrice(pcode, scode, uname);
        }
        public bool ReSetSectionPrice(string[] pcode)
        {
            return dal.ReSetSectionPrice(pcode);
        }
        public string GetSectionPrice(string pcode)
        {
            return dal.GetSectionPrice(pcode);
        }
		#endregion  ExtensionMethod
    }
}
