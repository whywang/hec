using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
   public class CB_InSapRecordBll
    {
       private readonly ICB_InSapRecordDal dal=BusiCommonAccess.CreateCB_InSapRecord();
		#region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(string where)
       {
           return dal.Exists(where);
       }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CB_InSapRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CB_InSapRecord model)
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
		public CB_InSapRecord Query(string where)
		{
            return dal.Query(where);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CB_InSapRecord> QueryList(string where)
		{ 
			return dal.QueryList(where);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
