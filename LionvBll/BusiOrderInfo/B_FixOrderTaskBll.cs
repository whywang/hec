using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvBll.BusiOrderInfo
{
   public  class B_FixOrderTaskBll
    {

       private readonly IB_FixOrderTaskDal dal = BusiOrderAccess.CreateB_FixOrderTask();
 
		#region  BasicMethod
       public bool Exists(string where)
       {
           return dal.Exists(where);
       }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(B_FixOrderTask model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(B_FixOrderTask model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(  string where)
		{

            return dal.Delete(where);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public B_FixOrderTask Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_FixOrderTask> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }
 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool SetAzs(string sid, string[] azslist, string maker)
        {
            return dal.SetAzs(sid, azslist, maker);
        }
        public bool ASetAzs(string sid, string[] azslist, string maker)
        {
            return dal.ASetAzs(sid, azslist, maker);
        }
        public bool SaveDisMoney(string sid, ArrayList alist, ArrayList wlist, decimal wmoney)
        {
            return dal.SaveDisMoney(sid,  alist,  wlist,  wmoney);
        }
		#endregion  ExtensionMethod
    }
}
