using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
   public class CB_MessageBll
    {
        private readonly ICB_MessageDal dal=BusiCommonAccess.CreateCB_Message();
  
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
		public int  Add(CB_Message model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( CB_Message model)
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
		public  CB_Message Query(string where)
		{
            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CB_Message> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public void EventCreateMsg(string sid,string bname, string bcode, int zt)
        {
            dal.EventCreateMsg(sid,bname, bcode, zt);
        }
		#endregion  ExtensionMethod
    }
}
