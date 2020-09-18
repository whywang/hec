using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
    public class Sys_ComponentCateBll
    {
        private readonly ISys_ComponentCateDal dal=DataProductionAccess.CreateSys_ComponentCate();
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string cccode)
		{
			return dal.Exists(cccode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_ComponentCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_ComponentCate model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string cccode)
		{
			
			return dal.Delete(cccode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_ComponentCate Query(string where)
		{

            return dal.Query(where);
		}

		
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ComponentCate> QueryList(string strWhere)
		{
			return dal.QueryList(strWhere);
		}
	
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode(string where)
        {
            return dal.CreateCode(where);
        }
        public int SetInvComCate(string icode,string ccode)
        {
            return dal.SetInvComCate(icode, ccode);
        }
        public int ReSetInvComCate(string icode)
        {
            return dal.ReSetInvComCate(icode);
        }
        public string GetInvComCate(string icode)
        {
            return dal.GetInvComCate(icode);
        }
		#endregion  ExtensionMethod
    }
}
