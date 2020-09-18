using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.WxChat;

namespace LionvIDal.WxChat
{
   public interface ISys_WxChatConfigDal
    {

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_WxChatConfig model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_WxChatConfig model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string acode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_WxChatConfig Query(string id);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_WxChatConfig> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         void setImg(string tcode, string img);
        #endregion  MethodEx
    }
}
