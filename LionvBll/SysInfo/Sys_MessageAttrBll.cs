using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_MessageAttrBll
    {
        private readonly ISys_MessageAttrDal dal=DataAccess.CreateSys_MessageAttr();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ecode)
		{
			return dal.Exists(ecode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_MessageAttr model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_MessageAttr model)
		{
			return dal.Update(model);
		}

 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ecode)
		{
			
			return dal.Delete(ecode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_MessageAttr Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_MessageAttr> QueryList(string strWhere)
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
