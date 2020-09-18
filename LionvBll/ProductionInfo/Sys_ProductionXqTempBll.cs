using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_ProductionXqTempBll
    {
       private readonly ISys_ProductionXqTempDal dal = DataProductionAccess.CreateSys_ProductionXqTemp();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string qtcode)
		{
			return dal.Exists(qtcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_ProductionXqTemp model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ProductionXqTemp model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string qtcode)
		{
			
			return dal.Delete(qtcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_ProductionXqTemp Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionXqTemp> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetXqTemp(string pcode,string qtcode,string emcode)
        {
            return dal.SetXqTemp(pcode, qtcode, emcode);
        }
        public bool ReSetXqTemp(string pcode, string emcode)
        {
            return dal.ReSetXqTemp(pcode,emcode);
        }
        public string GetXqTemp(string pcode, string emcode)
        {
            return dal.GetXqTemp(pcode, emcode);
        }
		#endregion  ExtensionMethod
    }
}
