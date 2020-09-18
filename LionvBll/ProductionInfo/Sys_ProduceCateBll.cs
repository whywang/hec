using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
    public class Sys_ProduceCateBll
    {

        private readonly ISys_ProduceCateDal dal = DataProductionAccess.CreateSys_ProduceCate();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string lcode)
		{
			return dal.Exists(lcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_ProduceCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ProduceCate model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string lcode)
		{
			
			return dal.Delete(lcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_ProduceCate Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProduceCate> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetProductionCate(string lcode, string icode)
        {
            return dal.SetProductionCate(lcode, icode);
        }
        public bool ReSetProductionCate(string lcode)
        {
            return dal.ReSetProductionCate(lcode);
        }
        public string GetProductionCate(string lcode)
        {
            return dal.GetProductionCate(lcode);
        }
		#endregion  ExtensionMethod
    }
}
