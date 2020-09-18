using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_WorkLineBll
    {
       
		private readonly ISys_WorkLineDal dal=DataProductionAccess.CreateSys_WorkLine();
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_WorkLine model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_WorkLine model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string wcode)
		{
			
			return dal.Delete(wcode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_WorkLine Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_WorkLine> QueryList(string strWhere)
		{
          	return  dal.QueryList(strWhere);
		
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
		#endregion  ExtensionMethod
    }
}
