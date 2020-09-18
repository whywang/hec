using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_WjBomBll
    {
        private readonly ISys_WjBomDal dal = DataProductionAccess.CreateSys_WjBom();
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_WjBom model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_WjBom model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string bcode)
		{
			
			return dal.Delete(bcode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_WjBom Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< Sys_WjBom> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetWjBom(string pcode,string [] bcode)
        {
            return dal.SetWjBom(pcode, bcode);
        }
        public bool ReSetWjBom(string pcode)
        {
            return dal.ReSetWjBom(pcode);
        }
        public string GetWjBom(string pcode)
        {
            return dal.GetWjBom(pcode);
        }
		#endregion  ExtensionMethod
    }
}
