using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.BusiOrderInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_ProductionProcessCostPartBll
    {
       private readonly ISys_ProductionProcessCostPartDal dal=DataProductionAccess.CreateSys_ProductionProcessCostPart();
		 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_ProductionProcessCostPart model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_ProductionProcessCostPart model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where )
		{
            return dal.Delete(where);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_ProductionProcessCostPart Query(string where)
		{
            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionProcessCostPart> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		
		#endregion  BasicMethod
		#region  ExtensionMethod
        public string QueryListStr(string strWhere)
        {
            return dal.QueryListStr(strWhere);
        }
        public bool AddList(string uname, string ucode, string[] arr)
        {
            return dal.AddList(uname, ucode, arr);
        }
		#endregion  ExtensionMethod
    }
}
