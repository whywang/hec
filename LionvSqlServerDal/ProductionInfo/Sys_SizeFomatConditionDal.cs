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
    public class Sys_SizeFomatConditionDal : ISys_SizeFomatConditionDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SizeFomatCondition");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SizeFomatCondition model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SizeFomatCondition(");
			strSql.Append("sfcname,sfccode,sfname,sfcode,isms,used,fixd,hlv,htv,wlv,wtv,dlv,dtv,maker,cdate,ctype)");
			strSql.Append(" values (");
            strSql.Append("@sfcname,@sfccode,@sfname,@sfcode,@isms,@used,@fixd,@hlv,@htv,@wlv,@wtv,@dlv,@dtv,@maker,@cdate,@ctype)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sfcname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfccode", SqlDbType.NVarChar,30),
					new SqlParameter("@sfname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfcode", SqlDbType.NVarChar,30),
					new SqlParameter("@isms", SqlDbType.Bit,1),
					new SqlParameter("@used", SqlDbType.Bit,1),
					new SqlParameter("@fixd", SqlDbType.NVarChar,10),
					new SqlParameter("@hlv", SqlDbType.Int,4),
					new SqlParameter("@htv", SqlDbType.Int,4),
					new SqlParameter("@wlv", SqlDbType.Int,4),
					new SqlParameter("@wtv", SqlDbType.Int,4),
					new SqlParameter("@dlv", SqlDbType.Int,4),
					new SqlParameter("@dtv", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ctype", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.sfcname;
			parameters[1].Value = model.sfccode;
			parameters[2].Value = model.sfname;
			parameters[3].Value = model.sfcode;
			parameters[4].Value = model.isms;
			parameters[5].Value = model.used;
			parameters[6].Value = model.fixd;
			parameters[7].Value = model.hlv;
			parameters[8].Value = model.htv;
			parameters[9].Value = model.wlv;
			parameters[10].Value = model.wtv;
			parameters[11].Value = model.dlv;
			parameters[12].Value = model.dtv;
			parameters[13].Value = model.maker;
			parameters[14].Value = model.cdate;
            parameters[15].Value = model.ctype;
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
		public bool Update( Sys_SizeFomatCondition model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SizeFomatCondition set ");
			strSql.Append("sfcname=@sfcname,");
			strSql.Append("sfname=@sfname,");
			strSql.Append("sfcode=@sfcode,");
			strSql.Append("isms=@isms,");
			strSql.Append("used=@used,");
			strSql.Append("fixd=@fixd,");
			strSql.Append("hlv=@hlv,");
			strSql.Append("htv=@htv,");
			strSql.Append("wlv=@wlv,");
			strSql.Append("wtv=@wtv,");
			strSql.Append("dlv=@dlv,");
			strSql.Append("dtv=@dtv,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where sfccode=@sfccode");
			SqlParameter[] parameters = {
					new SqlParameter("@sfcname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfcode", SqlDbType.NVarChar,30),
					new SqlParameter("@isms", SqlDbType.Bit,1),
					new SqlParameter("@used", SqlDbType.Bit,1),
					new SqlParameter("@fixd", SqlDbType.NVarChar,10),
					new SqlParameter("@hlv", SqlDbType.Int,4),
					new SqlParameter("@htv", SqlDbType.Int,4),
					new SqlParameter("@wlv", SqlDbType.Int,4),
					new SqlParameter("@wtv", SqlDbType.Int,4),
					new SqlParameter("@dlv", SqlDbType.Int,4),
					new SqlParameter("@dtv", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sfccode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sfcname;
			parameters[1].Value = model.sfname;
			parameters[2].Value = model.sfcode;
			parameters[3].Value = model.isms;
			parameters[4].Value = model.used;
			parameters[5].Value = model.fixd;
			parameters[6].Value = model.hlv;
			parameters[7].Value = model.htv;
			parameters[8].Value = model.wlv;
			parameters[9].Value = model.wtv;
			parameters[10].Value = model.dlv;
			parameters[11].Value = model.dtv;
			parameters[12].Value = model.maker;
			parameters[13].Value = model.cdate;
			parameters[14].Value = model.sfccode;

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
		public bool Delete(string sfccode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Sys_SizeFomatCondition ");
            strSql.AppendFormat(" where sfccode='{0}' ;", sfccode);
            strSql.Append("delete from Sys_SizeFormatCollection ");
            strSql.AppendFormat(" where sfccode='{0}' ;", sfccode);
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
        public Sys_SizeFomatCondition Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sfcname,sfccode,sfname,sfcode,isms,used,fixd,hlv,htv,wlv,wtv,dlv,dtv,maker,cdate ,ctype from Sys_SizeFomatCondition ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SizeFomatCondition r = new Sys_SizeFomatCondition();
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
		public  Sys_SizeFomatCondition DataRowToModel(DataRow row)
		{
			 Sys_SizeFomatCondition model=new  Sys_SizeFomatCondition();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sfcname"]!=null)
				{
					model.sfcname=row["sfcname"].ToString();
				}
				if(row["sfccode"]!=null)
				{
					model.sfccode=row["sfccode"].ToString();
				}
				if(row["sfname"]!=null)
				{
					model.sfname=row["sfname"].ToString();
				}
				if(row["sfcode"]!=null)
				{
					model.sfcode=row["sfcode"].ToString();
				}
				if(row["isms"]!=null && row["isms"].ToString()!="")
				{
					if((row["isms"].ToString()=="1")||(row["isms"].ToString().ToLower()=="true"))
					{
						model.isms=true;
					}
					else
					{
						model.isms=false;
					}
				}
				if(row["used"]!=null && row["used"].ToString()!="")
				{
					if((row["used"].ToString()=="1")||(row["used"].ToString().ToLower()=="true"))
					{
						model.used=true;
					}
					else
					{
						model.used=false;
					}
				}
				if(row["fixd"]!=null)
				{
					model.fixd=row["fixd"].ToString();
				}
				if(row["hlv"]!=null && row["hlv"].ToString()!="")
				{
					model.hlv=int.Parse(row["hlv"].ToString());
				}
				if(row["htv"]!=null && row["htv"].ToString()!="")
				{
					model.htv=int.Parse(row["htv"].ToString());
				}
				if(row["wlv"]!=null && row["wlv"].ToString()!="")
				{
					model.wlv=int.Parse(row["wlv"].ToString());
				}
				if(row["wtv"]!=null && row["wtv"].ToString()!="")
				{
					model.wtv=int.Parse(row["wtv"].ToString());
				}
				if(row["dlv"]!=null && row["dlv"].ToString()!="")
				{
					model.dlv=int.Parse(row["dlv"].ToString());
				}
				if(row["dtv"]!=null && row["dtv"].ToString()!="")
				{
					model.dtv=int.Parse(row["dtv"].ToString());
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["ctype"] != null)
                {
                    model.ctype = row["ctype"].ToString();
                }
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SizeFomatCondition> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sfcname,sfccode,sfname,sfcode,isms,used,fixd,hlv,htv,wlv,wtv,dlv,dtv,maker,cdate,ctype ");
            strSql.AppendFormat(" FROM Sys_SizeFomatCondition where 1=1 {0}", strWhere);
            List<Sys_SizeFomatCondition> r = new List<Sys_SizeFomatCondition>();
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
            sql = "select isnull(max(convert(int,sfccode)),0) as n from Sys_SizeFomatCondition ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
