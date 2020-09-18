using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
   public interface ICB_ProduceStartDateDal
    {
       #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string msid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( CB_ProduceStartDate model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( CB_ProduceStartDate model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string msid);
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 CB_ProduceStartDate Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<CB_ProduceStartDate> QueryList(string strWhere);
		 
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
    }
}
