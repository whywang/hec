using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_ProductionPeriodBll
    {
        private readonly ISys_ProductionPeriodDal dal=DataProductionAccess.CreateSys_ProductionPeriod();
		 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string gqcode)
		{
			return dal.Exists(gqcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_ProductionPeriod model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ProductionPeriod model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string gqcode)
		{
			
			return dal.Delete(gqcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_ProductionPeriod Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionPeriod> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
	 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetPeriod(string icode, string fcode, string gqcode)
        {
            return dal.SetPeriod(icode, fcode, gqcode);
        }
        public bool ReSetPeriod(string icode, string fcode)
        {
            return dal.ReSetPeriod(icode, fcode);
        }
        public string GetPeriod(string icode, string fcode)
        {
            return dal.GetPeriod(icode, fcode);
        }
		#endregion  ExtensionMethod
    }
}
