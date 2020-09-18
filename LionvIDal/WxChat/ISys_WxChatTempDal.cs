using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.WxChat;

namespace LionvIDal.WxChat
{
   public interface ISys_WxChatTempDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_WxChatTemp model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_WxChatTemp model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_WxChatTemp Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_WxChatTemp> QueryList(string strWhere);
     
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
        #endregion  MethodEx
    }
}
