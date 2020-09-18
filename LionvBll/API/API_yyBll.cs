using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Api;
using LionvFactoryDal;
using LionvModel.Api;

namespace LionvBll.API
{
    public class API_yyBll
    {
        
		private readonly IAPI_yyDal dal=ApiAccess.CreateAPI_yy();
		 
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
		public int  Add( API_yy model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( API_yy model)
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
		public  API_yy Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<API_yy> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		/// <summary>
		 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
