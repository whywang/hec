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
    public class B_AfterGroupProductionBll
    {
        
		private readonly IB_AfterGroupProductionDal dal=BusiOrderAccess.CreateB_AfterGroupProduction();
		 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string psid)
		{
			return dal.Exists(psid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_AfterGroupProduction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_AfterGroupProduction model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string psid)
		{
			
			return dal.Delete(psid);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_AfterGroupProduction Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterGroupProduction> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
        public string QueryStrList(string sid)
        {
            StringBuilder plist = new StringBuilder();
            int xh=1;
            List<B_AfterGroupProduction> laf = dal.QueryList(" and sid='" + sid + "'");
            foreach (B_AfterGroupProduction pa in laf)
            {
                plist.AppendFormat("{0}.{1}-{2}-{3}<br>", xh.ToString(),pa.itype,pa.place, pa.pname);
                xh++;
            }
            return plist.ToString();
        }

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int GetGnum(string where)
        {
            return dal.GetGnum(where);
        }
        public ArrayList GetGnumArr(string sid)
        {
            return dal.GetGnumArr(sid);
        }
        public bool SetRemark(string sid, string gnum, string adremark)
        {
            return dal.SetRemark(sid, gnum, adremark);
        }
        public bool SetWorkFrom(string sid,ArrayList plist)
        {
            return dal.SetWorkFrom(sid, plist);
        }
		#endregion  ExtensionMethod
    }
}
