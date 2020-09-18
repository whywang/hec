using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
   public class Sys_WorkLineCateBll
    {
       private readonly ISys_WorkLineCateDal dal=DataProductionAccess.CreateSys_WorkLineCate();
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_WorkLineCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_WorkLineCate model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where)
		{

            return dal.Delete(where);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_WorkLineCate Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Sys_WorkLineCate> QueryList(string strWhere)
		{

            return dal.QueryList(strWhere);
		}


		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetWorkLine(string wccode,string icode,string[] pcode)
        {
            return dal.SetWorkLine(wccode, icode, pcode);
        }
        public bool ReSetWorkLine(string wccode, string icode)
        {
            return dal.ReSetWorkLine(wccode, icode);
        }
        public string GetWorkLine(string wccode, string icode)
        {
            return dal.GetWorkLine(wccode, icode);
        }
		#endregion  ExtensionMethod
    }
}
