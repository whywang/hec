using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_OutHouseRecordBll
    {
       private readonly IB_OutHouseRecordDal dal = BusiOrderAccess.CreateB_OutHouseRecord();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string  where)
		{
            return dal.Exists(where);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_OutHouseRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(B_OutHouseRecord model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string idlist )
		{
			return dal.Delete(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_OutHouseRecord Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_OutHouseRecord> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
