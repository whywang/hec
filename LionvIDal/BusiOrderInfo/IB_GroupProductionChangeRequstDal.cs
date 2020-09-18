using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_GroupProductionChangeRequstDal
    {
        #region  成员方法
		/// <summary>
		/// </summary>
		/// 是否存在该记录
		bool Exists(string id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add( B_GroupProductionChangeRequst model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update( B_GroupProductionChangeRequst model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		 B_GroupProductionChangeRequst Query(string id);
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
         List<B_GroupProductionChangeRequst> QueryList(string strWhere);
 
		#endregion  成员方法
		#region  MethodEx
         int AddList(List<B_GroupProductionChangeRequst> model, string sid);
		#endregion  MethodEx
    }
}
