using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_MtZsbEditBll
    {
       	private readonly ISys_MtZsbEditDal dal=DataProductionAccess.CreateSys_MtZsbEdit();
	 
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
		public int  Add( Sys_MtZsbEdit model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_MtZsbEdit model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{
			return dal.Delete(id);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_MtZsbEdit Query(string id)
		{
            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_MtZsbEdit> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
	 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool Add(List<Sys_MtZsbEdit> model)
        {
            return dal.Add(model);
        }
		#endregion  ExtensionMethod
    }
}
