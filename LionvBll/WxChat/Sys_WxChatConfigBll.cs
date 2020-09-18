using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.WxChat;
using LionvFactoryDal;
using LionvModel.WxChat;

namespace LionvBll.WxChat
{
   public class Sys_WxChatConfigBll
    {
       private readonly ISys_WxChatConfigDal dal=WxChatAccess.CreateSys_WxChatConfig();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string acode)
		{
			return dal.Exists(acode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_WxChatConfig model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_WxChatConfig model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string acode)
		{
			
			return dal.Delete(acode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_WxChatConfig Query(string where)
		{

            return dal.Query(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List< Sys_WxChatConfig> QueryList(string strWhere)
		{
			return  dal.QueryList(strWhere);
		}
	 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public void setImg(string tcode, string img)
        {
             dal.setImg(tcode, img);
        }
		#endregion  ExtensionMethod
    }
}
