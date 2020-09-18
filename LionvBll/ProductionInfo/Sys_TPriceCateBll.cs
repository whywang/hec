using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_TPriceCateBll
    {
        private readonly ISys_TPriceCateDal dal=DataProductionAccess.CreateSys_TPriceCate();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string lpcode)
		{
			return dal.Exists(lpcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_TPriceCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_TPriceCate model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string lpcode)
		{
			
			return dal.Delete(lpcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_TPriceCate Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_TPriceCate> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetMsMtPrice(string ptype, string mscode,string mtcode, string lpcode)
        {
            return dal.SetMsMtPrice(ptype, mscode, mtcode, lpcode);
        }
        public bool ReSetMsMtPrice(string ptype, string mscode)
        {
            return dal.ReSetMsMtPrice(ptype, mscode);
        }
        public string GetMsMtPrice(string ptype, string mscode, string mtcode)
        {
            return dal.GetMsMtPrice(ptype, mscode, mtcode);
        }
		#endregion  ExtensionMethod
    }
}
