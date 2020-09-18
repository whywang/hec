using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
   public class CB_CodeRecorderBll
    {
        private readonly ICB_CodeRecorderDal dal=BusiCommonAccess.CreateCB_CodeRecorder();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sid)
		{
			return dal.Exists(sid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( CB_CodeRecorder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  CB_CodeRecorder Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CB_CodeRecorder> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int QueryCount(string where)
        {
            return dal.QueryCount(where);
        }
		#endregion  ExtensionMethod
    }
}
