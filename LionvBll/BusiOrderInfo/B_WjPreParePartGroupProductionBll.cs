using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvBll.BusiOrderInfo
{
   public class B_WjPreParePartGroupProductionBll
    {
       private readonly IB_WjPreParePartGroupProductionDal dal=BusiOrderAccess.CreateB_WjPreParePartGroupProduction();
 
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
		public int  Add( B_WjPreParePartGroupProduction model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_WjPreParePartGroupProduction model)
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
		public  B_WjPreParePartGroupProduction Query(string id)
		{
            return dal.Query(id);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_WjPreParePartGroupProduction> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int QueryWjNum(string sid, string icode)
        {
            return dal.QueryWjNum(sid, icode);
        }
		#endregion  ExtensionMethod
    }
}
