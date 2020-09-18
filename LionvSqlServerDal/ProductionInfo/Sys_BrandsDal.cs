using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
   public class Sys_BrandsDal : ISys_BrandsDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Brands");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_Brands model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Brands(");
			strSql.Append("pbname,pbcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@pbname,@pbcode,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@pbname", SqlDbType.NVarChar,50),
					new SqlParameter("@pbcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.pbname;
			parameters[1].Value = model.pbcode;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_Brands model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Brands set ");
			strSql.Append("pbname=@pbname,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where pbcode=@pbcode");
			SqlParameter[] parameters = {
					new SqlParameter("@pbname", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pbcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.pbname;
			parameters[1].Value = model.maker;
			parameters[2].Value = model.cdate;
			parameters[3].Value = model.pbcode;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Brands ");
            strSql.AppendFormat(" where pbcode='{0}' ", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
		}
	 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_Brands Query(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pbname,pbcode,maker,cdate from Sys_Brands ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Brands r = new Sys_Brands();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = DataRowToModel(dt.Rows[0]);
            }
            else
            {
                r = null;
            }
            return r;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_Brands DataRowToModel(DataRow row)
		{
			 Sys_Brands model=new  Sys_Brands();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["pbname"]!=null)
				{
					model.pbname=row["pbname"].ToString();
				}
				if(row["pbcode"]!=null)
				{
					model.pbcode=row["pbcode"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Brands> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,pbname,pbcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_Brands where 1=1 {0}", strWhere);
            List<Sys_Brands> r = new List<Sys_Brands>();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(DataRowToModel(dr));
                }
            }
            else
            {
                r = null;
            }
            return r;
		}

		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,pbcode)),0) as n from Sys_Brands ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetDepBrand(string dcode, string pbcode)
        {

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RDepBrands where dcode ='{0}';", dcode);
            string[] arr = pbcode.Split(';');
            if(arr.Length>0)
            {
                foreach(string p in arr)
                {
                    sql.AppendFormat(" insert into Sys_RDepBrands (dcode,pbcode) values ('{0}','{1}') ;", dcode, p);
                }
            }
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetDepBrand(string dcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RDepBrands where dcode ='{0}';", dcode);
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        public string GetDepBrand(string dcode)
        {
            string r = "";
            string sql = "select pbcode from Sys_RDepBrands where dcode='" + dcode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r+dr["pbcode"].ToString()+";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }

        public bool SetMaterialBrand(string pbcode, string mpcode, string mcode)
        {

            StringBuilder sql = new StringBuilder();
            string[] marr = mcode.Split(';');
            foreach (string mc in marr)
            {
                sql.AppendFormat(" delete from Sys_RBrandsMaterial where pbcode ='{0}' and mcode='{1}';", pbcode, mc);
                sql.AppendFormat(" insert into Sys_RBrandsMaterial (pbcode,mpcode,mcode) values ('{0}','{1}','{2}') ;", pbcode, mpcode,mc);
            }
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetMaterialBrand(string pbcode,string mcode)
        {
            StringBuilder sql = new StringBuilder();
             string[] marr = mcode.Split(';');
             foreach (string mc in marr)
             {
                 sql.AppendFormat(" delete from Sys_RBrandsMaterial where pbcode ='{0}' and mcode='{1}';", pbcode, mc);
             }
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetMaterialBrand(string pbcode, string mpcode)
        {
            string r = "";
            string sql = "select mcode from Sys_RBrandsMaterial where pbcode='" + pbcode + "' and mpcode='" + mpcode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r+dr["mcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }

        public bool SetInventroyBrand(string pbcode, string icode)
        {
            bool r = true;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(" delete from Sys_RBrandsInventory where pbcode ='{0}' and pcode like'{1}%';", pbcode, icode);
                SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id,iname,icode,icname,iccode,mname,iunit,isaleprice,isupplyprice,ipurchaseprice,iimage,istate,mcode,maker,cdate,idef1,idef2,idef3,tcprice,ptype,psize ");
                strSql.Append(" FROM Sys_InventoryDetail ");
                strSql.AppendFormat(" where iccode like '{0}%'", icode);
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sqll = new StringBuilder();
                        sqll.AppendFormat(" insert into Sys_RBrandsInventory (pbcode,icode,pcode) values ('{0}','{1}','{2}') ;", pbcode, dr["iccode"].ToString(), dr["icode"].ToString());
                        SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sqll.ToString(), null);
                    }
                }
            }
            catch
            {
                r = false;
            }
            
            return r;
        }
        public bool ReSetInventroyBrand(string pbcode, string icode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RBrandsInventory where pbcode ='{0}' and pcode like'{1}%';", pbcode, icode);
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetInventroyBrand(string pbcode, string icode)
        {
            string r = "";
            string sql = "select pcode from Sys_RBrandsInventory where pbcode='" + pbcode + "' and pcode like '" + icode + "___'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["pcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }
        public string QueryDepByBcode(string bcode)
        {
            string r = "";
            string sql = "select top 1 dcode from Sys_RDepBrands where pbcode='" + bcode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                r =dt.Rows[0]["dcode"].ToString();
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
