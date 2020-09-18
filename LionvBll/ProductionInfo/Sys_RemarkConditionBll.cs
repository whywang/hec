using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
   public class Sys_RemarkConditionBll
    {
       private readonly ISys_RemarkConditionDal r = DataProductionAccess.CreateSys_RemarkCondition();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string rccode)
		{
			return r.Exists(rccode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_RemarkCondition model)
		{
			return r.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_RemarkCondition model)
		{
			return r.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string rccode)
		{
			
			return r.Delete(rccode);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_RemarkCondition Query(string where)
		{

            return r.Query(where);
		}

		public List<Sys_RemarkCondition> QueryList(string where)
		{ 
			return r.QueryList(where);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return r.CreateCode();
        }
		#endregion  ExtensionMethod
    }
}
