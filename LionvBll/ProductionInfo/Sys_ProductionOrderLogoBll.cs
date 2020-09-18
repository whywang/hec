using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_ProductionOrderLogoBll
    {
       private readonly ISys_ProductionOrderLogoDal dal = DataProductionAccess.CreateSys_ProductionOrderLogo();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string dcode)
		{
			return dal.Exists(dcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_ProductionOrderLogo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ProductionOrderLogo model)
		{
			return dal.Update(model);
		}

 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string dcode)
		{
			
			return dal.Delete(dcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_ProductionOrderLogo Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionOrderLogo> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool UpdateLogo(Sys_ProductionOrderLogo m, string ltype)
        {
            return dal.UpdateLogo(m, ltype);
        }
        public bool DelLogo(string dcode, string ltype)
        {
            return dal.DelLogo(dcode, ltype);
        }
		#endregion  ExtensionMethod
    }
}
