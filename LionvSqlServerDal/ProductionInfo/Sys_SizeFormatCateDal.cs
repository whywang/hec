using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvModel.ProductionInfo;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_SizeFormatCateDal : ISys_SizeFormatCateDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SizeFormatCate");
	        strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SizeFormatCate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SizeFormatCate(");
            strSql.Append("sfname,sfcode,bdcode,maker,cdate,sftype)");
			strSql.Append(" values (");
            strSql.Append("@sfname,@sfcode,@bdcode,@maker,@cdate,@sftype)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sfname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sftype", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sfname;
			parameters[1].Value = model.sfcode;
			parameters[2].Value = model.bdcode;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
            parameters[5].Value = model.sftype;
			object obj =SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
		public bool Update( Sys_SizeFormatCate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SizeFormatCate set ");
			strSql.Append("sfname=@sfname,");
			strSql.Append("bdcode=@bdcode,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where sfcode=@sfcode");
			SqlParameter[] parameters = {
					new SqlParameter("@sfname", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sfcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sfname;
			parameters[1].Value = model.bdcode;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.sfcode;

			int rows=SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
		public bool Delete(string sfcode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_SizeFormatCate ");
            strSql.AppendFormat(" where sfcode='{0}' ;", sfcode);
            strSql.Append("delete from Sys_SizeFomatCondition ");
            strSql.AppendFormat(" where sfcode='{0}' ;", sfcode);
            strSql.Append("delete from Sys_SizeFormatCollection ");
            strSql.AppendFormat(" where sfcode='{0}' ;", sfcode);
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
        public Sys_SizeFormatCate Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sfname,sfcode,bdcode,maker,cdate, sftype from Sys_SizeFormatCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SizeFormatCate r = new Sys_SizeFormatCate();
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
		public  Sys_SizeFormatCate DataRowToModel(DataRow row)
		{
			 Sys_SizeFormatCate model=new  Sys_SizeFormatCate();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sfname"]!=null)
				{
					model.sfname=row["sfname"].ToString();
				}
				if(row["sfcode"]!=null)
				{
					model.sfcode=row["sfcode"].ToString();
				}
				if(row["bdcode"]!=null)
				{
					model.bdcode=row["bdcode"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["sftype"] != null)
                {
                    model.sftype = row["sftype"].ToString();
                }
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SizeFormatCate> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sfname,sfcode,bdcode,maker,cdate,sftype ");
             strSql.AppendFormat(" FROM Sys_SizeFormatCate where 1=1 {0}", strWhere);
            List<Sys_SizeFormatCate> r = new List<Sys_SizeFormatCate>();
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
            sql = "select isnull(max(convert(int,sfcode)),0) as n from Sys_SizeFormatCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetSizeFormat(string icode, string pcode, string sfcode)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            if (pcode != "")
            {
                string[] plc = pcode.Split(';');
                foreach (string pv in plc)
                {
                    strSql.AppendFormat("delete from Sys_RInventorySizeTransform where pcode='{0}';",pv);
                    strSql.AppendFormat("insert into Sys_RInventorySizeTransform (pcode,jcode) values ('{0}','{1}') ;", pv, sfcode);
                }
                if (strSql.ToString() != "")
                {
                    if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
                    {
                        r = true;
                    }
                }
            }
            else
            {
                SqlParameter[] parms = { new SqlParameter("@icode", icode), new SqlParameter("@jcode", sfcode) };
                if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.StoredProcedure, "b_setsizeform", parms)>0)
                {
                    r = true;
                }
            }
            return r;
        }
        public bool ReSetSizeFormat(string icode, string pcode)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            if (pcode != "")
            {
                string[] plc = pcode.Split(';');
                foreach (string pv in plc)
                {
                    strSql.AppendFormat("delete from Sys_RInventorySizeTransform where pcode='{0}';", pv);
                }
                if (strSql.ToString() != "")
                {
                    if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
                    {
                        r = true;
                    }
                }
            }
            else
            {
                SqlParameter[] parms = { new SqlParameter("@icode", icode) };
                if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.StoredProcedure, "b_resetsizeform", parms) > 0)
                {
                    r = true;
                }
            }
            return r;
        }
        public string GetSizeFormat(string pcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select jcode ");
            strSql.AppendFormat(" FROM Sys_RInventorySizeTransform where pcode='{0}'", pcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["jcode"].ToString();
            }
            else
            {
                r = "";
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
