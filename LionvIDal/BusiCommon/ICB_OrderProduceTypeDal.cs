using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    public interface ICB_OrderProduceTypeDal
    {
        #region  成员方法
 
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( CB_OrderProduceType model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string sid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 CB_OrderProduceType Query(string id);
 
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
    }
}
