using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using LionvFactoryDal;

namespace LionvBll.SysInfo
{
   public class Sys_ProduceCycBll
    {
       private readonly ISys_ProduceCycDal dal=DataAccess.CreateSys_ProduceCyc();
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ccode)
		{
			return dal.Exists(ccode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_ProduceCyc model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ProduceCyc model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ccode)
		{
			
			return dal.Delete(ccode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_ProduceCyc Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Sys_ProduceCyc> QueryList(string strWhere)
        {
			return dal.QueryList(strWhere);
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
