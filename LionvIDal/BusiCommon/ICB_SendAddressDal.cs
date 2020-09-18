using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    public interface ICB_SendAddressDal
    {
        
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( CB_SendAddress model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( CB_SendAddress model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 CB_SendAddress Query(string where);
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<CB_SendAddress> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
    }
}
