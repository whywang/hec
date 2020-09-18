using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using LionvFactoryDal;

namespace LionvBll.BusiCommon
{
   public class CB_OrderProduceTypeBll
    {
       
		private readonly ICB_OrderProduceTypeDal dal=BusiCommonAccess.CreateCB_OrderProduceType();
 
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( CB_OrderProduceType model)
		{
			return dal.Add(model);
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
		public  CB_OrderProduceType Query(string id)
		{

            return dal.Query(id);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
