using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.WxChat;
using LionvFactoryDal;
using LionvModel.WxChat;

namespace LionvBll.WxChat
{
   public class Sys_EmplyeeFouseWxBll
    {
        private readonly ISys_EmplyeeFouseWxDal dal=WxChatAccess.CreateSys_EmplyeeFouseWx();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
            return dal.Exists(where);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_EmplyeeFouseWx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_EmplyeeFouseWx model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{
			
			return dal.Delete(id);
		}
 

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_EmplyeeFouseWx Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_EmplyeeFouseWx> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
