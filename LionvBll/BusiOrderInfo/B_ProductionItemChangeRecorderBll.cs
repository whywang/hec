using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_ProductionItemChangeRecorderBll
    {
        
		private readonly IB_ProductionItemChangeRecorderDal dal=BusiOrderAccess.CreateB_ProductionItemChangeRecorder();
	 
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
		public int  Add( B_ProductionItemChangeRecorder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_ProductionItemChangeRecorder model)
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
		public  B_ProductionItemChangeRecorder Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_ProductionItemChangeRecorder> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
