using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;
using System.Data;

namespace LionvBll.BusiCommon
{
   public class CB_OrderTraceRecordBll
    {
       
		private readonly ICB_OrderTraceRecordDal dal=BusiCommonAccess.CreateCB_OrderTraceRecord();
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CB_OrderTraceRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CB_OrderTraceRecord model)
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
		public CB_OrderTraceRecord Query(string id)
		{

            return dal.Query(id);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CB_OrderTraceRecord> QueryList(string where)
		{
            return dal.QueryList(where);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
		#endregion  ExtensionMethod
    }
}
