using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_GlassCraftDal
    {
        	#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string gccode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Sys_GlassCraft model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Sys_GlassCraft model);
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string gccode);
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Sys_GlassCraft Query(string id);
	 
		/// <summary>
		/// 获得数据列表
		/// </summary>
        List<Sys_GlassCraft> QueryList(string strWhere);
		 
		#endregion  成员方法
		#region  MethodEx
        int CreateCode();
        bool SetGlassCraft(string pcode, string gccode);
        bool ReSetGlassCraft(string pcode);
        string GetGlassCraft(string pcode);
		#endregion  MethodEx
    }
}
