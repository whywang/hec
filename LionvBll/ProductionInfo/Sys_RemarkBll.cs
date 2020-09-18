using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_RemarkBll
    {
       private readonly ISys_RemarkDal dal=DataProductionAccess.CreateSys_Remark();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string rcode)
		{
			return dal.Exists(rcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_Remark model)
		{
			return dal.Add(model);
		}
        public bool Update(Sys_Remark model)
        {
            return dal.Update(model);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string rcode)
		{
			
			return dal.Delete(rcode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_Remark Query(string where)
		{

            return dal.Query(where);
		}

	 
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Remark> QueryList(string where)
		{
 
			return dal.QueryList(where);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public int SetProductionBz(string pcode, string rcode)
        {
            return dal.SetProductionBz(pcode,rcode);
        }
        public int ReSetProductionBz(string pcode)
        {
            return dal.ReSetProductionBz(pcode);
        }
        public string GetProductionBz(string pcode)
        {
            return dal.GetProductionBz(pcode);
        }
       //查找固定备注
        public string QueryGByIcode(string pcode)
        {
            string r ="";
            string rcode = dal.GetProductionBz(pcode);
            if (rcode != "")
            {
                Sys_Remark sr = Query(" and rcode='" + rcode + "'");
                if (sr != null)
                {
                    r = sr.rfixtext;
                }
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
