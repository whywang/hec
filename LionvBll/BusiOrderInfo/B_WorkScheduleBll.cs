using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvFactoryDal;

namespace LionvBll.BusiOrderInfo
{
   public class B_WorkScheduleBll
    {
       private readonly IB_WorkScheduleDal dal = BusiOrderAccess.CreateB_WorkSchedule();
	 
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
		public int  Add( B_WorkSchedule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_WorkSchedule model)
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
		public  B_WorkSchedule Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_WorkSchedule> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool SaveList(string dname, string dcode, int year, int month)
        {
            return dal.SaveList(dname, dcode, year, month);
        }
		#endregion  ExtensionMethod
    }
}
