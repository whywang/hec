using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
   public interface ICB_CodeRecorderDal
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string sid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( CB_CodeRecorder model);
 
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 CB_CodeRecorder Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<CB_CodeRecorder> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int QueryCount(string where);
		#endregion  MethodEx
    }
}
