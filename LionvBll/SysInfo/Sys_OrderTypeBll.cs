using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;
using LionvFactoryDal;

namespace LionvBll.SysInfo
{
   public class Sys_OrderTypeBll
    {
       private readonly ISys_OrderTypeDal dal=DataAccess.CreateSys_OrderType();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string tcode)
		{
			return dal.Exists(tcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_OrderType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_OrderType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string tcode)
		{
			
			return dal.Delete(tcode);
		}
	

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_OrderType Query(string  where)
		{
			
			return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
	 
	 
		public List<Sys_OrderType> QueryList(string where)
		{
			 
			return dal.QueryList(where);
		}
		 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
		#endregion  ExtensionMethod
    }
}
