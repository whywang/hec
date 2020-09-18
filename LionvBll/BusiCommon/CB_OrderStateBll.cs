using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
   public class CB_OrderStateBll
    {
       private readonly ICB_OrderStateDal dal = BusiCommonAccess.CreateCB_OrderState();
       #region
       public bool Exists(string sid)
		{
			return dal.Exists(sid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( CB_OrderState model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( CB_OrderState model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sid)
		{
			
			return dal.Delete(sid);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CB_OrderState Query(string where)
		{
			
			return dal.Query(where);
		}

	 
		public List<CB_OrderState> QueryList(string where)
		{
			return dal.QueryList(where);
		}
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int UpState( string sid,string feild,int value)
        {
            return dal.UpState(sid, feild, value);
        }
        public bool BatchUpState(string[] sidarr, string feild, int value)
        {
            return dal.BatchUpState(sidarr, feild, value);
        }
        public void Add(string  sid)
        {
            CB_OrderState cos = new CB_OrderState();
            cos.sid = sid;
            dal.Add(cos);
        }
		#endregion  ExtensionMethod
    }
}
