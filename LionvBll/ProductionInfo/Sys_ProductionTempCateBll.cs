using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_ProductionTempCateBll
    {
       private readonly ISys_ProductionTempCateDal dal = DataProductionAccess.CreateSys_ProductionTempCate();
		 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ptcode)
		{
			return dal.Exists(ptcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_ProductionTempCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_ProductionTempCate model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ptcode)
		{
			
			return dal.Delete(ptcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_ProductionTempCate Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionTempCate> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode("");
        }
        public bool SetInvTempCate(string icode, string ptcode)
        {
            return dal.SetInvTempCate(icode, ptcode);
        }
        public bool ReSetInvTempCate(string icode)
        {
            return dal.ReSetInvTempCate(icode);
        }
        public string GetInvTempCate(string icode)
        {
            return dal.GetInvTempCate(icode);
        }
		#endregion  ExtensionMethod
    }
}
