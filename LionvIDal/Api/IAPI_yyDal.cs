using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.Api;

namespace LionvIDal.Api
{
   public interface IAPI_yyDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string dcode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( API_yy model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( API_yy model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string dcode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 API_yy Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<API_yy> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
    }
}
