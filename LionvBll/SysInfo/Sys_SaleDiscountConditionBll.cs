using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;
using System.Collections;

namespace LionvBll.SysInfo
{
   public class Sys_SaleDiscountConditionBll
    {
       private readonly ISys_SaleDiscountConditionDal dal=DataAccess.CreateSys_SaleDiscountCondition();

		#region  BasicMethod
 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_SaleDiscountCondition model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_SaleDiscountCondition model)
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
		public  Sys_SaleDiscountCondition Query(string id)
		{

            return dal.Query(id);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SaleDiscountCondition> QueryList(string strWhere)
		{
			return dal.QueryList(strWhere);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool AddList(string dcode,List<Sys_SaleDiscountCondition> ls)
        {
            return dal.AddList(dcode,ls);
        }
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public ArrayList QuerySortNum(string acode)
        {
            return dal.QuerySortNum(acode);
        }
		#endregion  ExtensionMethod
    }
}
