using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    public interface ICB_MessageDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( CB_Message model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( CB_Message model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CB_Message Query(string where);
  
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        List<CB_Message> QueryList( string strWhere);
        #endregion  成员方法
        #region  MethodEx
        void EventCreateMsg(string sid,string bname, string bcode, int zt);
        #endregion  MethodEx
    } 
}
