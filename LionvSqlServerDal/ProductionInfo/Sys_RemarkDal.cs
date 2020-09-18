using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_RemarkDal : ISys_RemarkDal
   {
       #region//BasicMethod
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Remark");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_Remark model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Remark(");
			strSql.Append("rcode,rname,rchangtext,rfixtext,maker,cdate,dcode)");
			strSql.Append(" values (");
			strSql.Append("@rcode,@rname,@rchangtext,@rfixtext,@maker,@cdate,@dcode)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@rcode", SqlDbType.NVarChar,20),
					new SqlParameter("@rname", SqlDbType.NVarChar,20),
					new SqlParameter("@rchangtext", SqlDbType.NVarChar,500),
					new SqlParameter("@rfixtext", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.rcode;
			parameters[1].Value = model.rname;
			parameters[2].Value = model.rchangtext;
			parameters[3].Value = model.rfixtext;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
            parameters[6].Value = model.dcode;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            }
            catch
            {
                r = -1;
            }
            return r;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_Remark model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Remark set ");
			strSql.Append("rname=@rname,");
			strSql.Append("rchangtext=@rchangtext,");
			strSql.Append("rfixtext=@rfixtext,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where rcode=@rcode");
			SqlParameter[] parameters = {
					new SqlParameter("@rname", SqlDbType.NVarChar,20),
					new SqlParameter("@rchangtext", SqlDbType.NVarChar,500),
					new SqlParameter("@rfixtext", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rcode", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.rname;
			parameters[1].Value = model.rchangtext;
			parameters[2].Value = model.rfixtext;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
			parameters[5].Value = model.rcode;

            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			 strSql.AppendFormat("delete from Sys_Remark where 1=1 {0}", where);
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
		public  Sys_Remark Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,rcode,rname,rchangtext,rfixtext,maker,cdate from Sys_Remark ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_Remark r = new  Sys_Remark();
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
		public  Sys_Remark DataRowToModel(DataRow row)
		{
			 Sys_Remark model=new  Sys_Remark();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["rcode"]!=null)
				{
					model.rcode=row["rcode"].ToString();
				}
				if(row["rname"]!=null)
				{
					model.rname=row["rname"].ToString();
				}
				if(row["rchangtext"]!=null)
				{
					model.rchangtext=row["rchangtext"].ToString();
				}
				if(row["rfixtext"]!=null)
				{
					model.rfixtext=row["rfixtext"].ToString();
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
		public List<Sys_Remark> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,rcode,rname,rchangtext,rfixtext,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_Remark where 1=1 {0}", strWhere);
            List<Sys_Remark> r = new List<Sys_Remark>();
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
            sql = "select isnull(max(convert(int,rcode)),0) as n from Sys_Remark ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetProductionBz(string pcode, string rcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryRemark where pcode like '{0}%';", pcode);
            sql.AppendFormat(" insert into Sys_RInventoryRemark (pcode,rcode) values ('{0}','{1}') ;", pcode, rcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetProductionBz(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryRemark where pcode like '{0}%';", pcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetProductionBz(string pcode)
        {
            string r = "";
            r=LoodQuery(pcode);
            return r;
        }
        private string LoodQuery(string pcode)
        {
            string p = "";
            if (pcode.Length > 2)
            {

                string sql = "select rcode from Sys_RInventoryRemark where pcode='" + pcode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(pcode.Substring(0, pcode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
		#endregion  ExtensionMethod
    }
}
