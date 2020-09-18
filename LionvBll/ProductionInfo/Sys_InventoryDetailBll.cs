using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_InventoryDetailBll
    {
        private readonly ISys_InventoryDetailDal r=DataAccess.CreateSys_InventoryDetail();
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string icode)
		{
			return r.Exists(icode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_InventoryDetail model)
		{
			return r.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_InventoryDetail model)
		{
			return r.Update(model);
		}

	 
		public bool Delete(string icode)
		{
			
			return r.Delete(icode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_InventoryDetail Query(string where)
		{

            return r.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_InventoryDetail> QueryList(string where)
		{
            return r.QueryList(where);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_InventoryDetail> QueryList(int num, string where)
        {
            return r.QueryList(num,where);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode(string iccode)
        { 
            return r.CreateCode( iccode);
        }
        public int SetPrice(string []clist,string plx,string xsp,string ghp,string cgp,string tcp)
        {
            string sql = "";
            if (plx == "a")
            {
                sql=setallprice(clist, xsp, ghp, cgp,tcp);
            }
            if (plx == "x")
            {
                sql = setxprice(clist, xsp );
            }
            if (plx == "g")
            {
                sql = setgprice(clist, ghp);
            }
            if (plx == "c")
            {
                sql = setcprice(clist, cgp);
            }
            if (plx == "t")
            {
                sql = settcprice(clist, tcp);
            }
            return r.SetPricce(sql);
        }
        public int SetState(string[] clist, string t)
        {
            string sql = "";
            if (t == "o")
            {
                sql = setopen(clist);
            }
            if (t == "c")
            {
                sql = setclose(clist);
            }

            return r.SetState(sql);
        }
        private string setallprice(string[] clist, string xsp, string ghp, string cgp,string tcp)
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < clist.Length; i++)
            {
                sql.AppendFormat(" update Sys_InventoryDetail set isaleprice={0},isupplyprice={1},ipurchaseprice={2},tcprice={3} where icode='{4}';", Convert.ToDecimal(xsp), Convert.ToDecimal(ghp), Convert.ToDecimal(cgp), Convert.ToDecimal(tcp), clist[i]);
            }
            return sql.ToString();
        }
        private string setxprice(string[] clist, string xsp )
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < clist.Length; i++)
            {
                sql.AppendFormat(" update Sys_InventoryDetail set isaleprice={0}  where icode='{1}';", Convert.ToDecimal(xsp), clist[i]);
            }
            return sql.ToString();
        }
        private string setgprice(string[] clist, string ghp)
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < clist.Length; i++)
            {
                sql.AppendFormat(" update Sys_InventoryDetail set ipurchaseprice={0}  where icode='{1}';", Convert.ToDecimal(ghp), clist[i]);
            }
            return sql.ToString();
        }
        private string setcprice(string[] clist, string cgp)
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < clist.Length; i++)
            {
                sql.AppendFormat(" update Sys_InventoryDetail set ipurchaseprice={0}  where icode='{1}';", Convert.ToDecimal(cgp), clist[i]);
            }
            return sql.ToString();
        }
        private string settcprice(string[] clist, string tcp)
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < clist.Length; i++)
            {
                sql.AppendFormat(" update Sys_InventoryDetail set tcprice={0}  where icode='{1}';", Convert.ToDecimal(tcp), clist[i]);
            }
            return sql.ToString();
        }

        private string setopen(string[] clist)
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < clist.Length; i++)
            {
                sql.AppendFormat(" update Sys_InventoryDetail set istate='true'  where icode='{0}';",   clist[i]);
            }
            return sql.ToString();
        }
        private string setclose(string[] clist )
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < clist.Length; i++)
            {
                sql.AppendFormat(" update Sys_InventoryDetail set istate='false' where icode='{0}';",   clist[i]);
            }
            return sql.ToString();
        }
		#endregion  ExtensionMethod
    }
}
