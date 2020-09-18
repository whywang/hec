using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_GroupProductionChangeRecordBll
    {
        
		private readonly IB_GroupProductionChangeRecordDal dal=BusiOrderAccess.CreateB_GroupProductionChangeRecord();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string psid)
		{
			return dal.Exists(psid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_GroupProductionChangeRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_GroupProductionChangeRecord model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string psid)
		{
			
			return dal.Delete(psid);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_GroupProductionChangeRecord Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_GroupProductionChangeRecord> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
	
		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool CopyGroupProduction(string sid, string csid, string gnum)
        {
            return dal.CopyGroupProduction(sid, csid, gnum);
        }
		#endregion  ExtensionMethod
    }
}
