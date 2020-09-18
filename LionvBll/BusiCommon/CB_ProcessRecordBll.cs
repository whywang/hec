using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
   public class CB_ProcessRecordBll
    {

        private readonly ICB_ProcessRecordDal dal = BusiCommonAccess.CreateCB_ProcessRecord();
 
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
		public int  Add( CB_ProcessRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( CB_ProcessRecord model)
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
		public  CB_ProcessRecord Query(string where)
		{

            return dal.Query(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< CB_ProcessRecord> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
