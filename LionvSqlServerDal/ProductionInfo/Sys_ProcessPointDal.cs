using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProcessPointDal : ISys_ProcessPointDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProcessPoint");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
 
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ProcessPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProcessPoint(");
            strSql.Append("jname,jcode,pcode,pname,jtype,precode,usetime,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@jname,@jcode,@pcode,@pname,@jtype,@precode,@usetime,@maker,@cdate)");
  
            SqlParameter[] parameters = {
					new SqlParameter("@jname", SqlDbType.NVarChar,30),
					new SqlParameter("@jcode", SqlDbType.NVarChar,20),
					new SqlParameter("@pcode", SqlDbType.NVarChar,20),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@jtype", SqlDbType.NVarChar,10),
					new SqlParameter("@precode", SqlDbType.NVarChar,20),
					new SqlParameter("@usetime", SqlDbType.Float,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.jname;
            parameters[1].Value = model.jcode;
            parameters[2].Value = model.pcode;
            parameters[3].Value = model.pname;
            parameters[4].Value = model.jtype;
            parameters[5].Value = model.precode;
            parameters[6].Value = model.usetime;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;
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
        public bool Update( Sys_ProcessPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProcessPoint set ");
            strSql.Append("jname=@jname,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("pname=@pname,");
            strSql.Append("jtype=@jtype,");
            strSql.Append("precode=@precode,");
            strSql.Append("usetime=@usetime,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where jcode=@jcode");
            SqlParameter[] parameters = {
					new SqlParameter("@jname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,20),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@jtype", SqlDbType.NVarChar,10),
					new SqlParameter("@precode", SqlDbType.NVarChar,20),
					new SqlParameter("@usetime", SqlDbType.Float,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
 
					new SqlParameter("@jcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.jname;
            parameters[1].Value = model.pcode;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.jtype;
            parameters[4].Value = model.precode;
            parameters[5].Value = model.usetime;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.jcode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }

        public bool Delete(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProcessPoint ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
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
        public  Sys_ProcessPoint Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,jname,jcode,pcode,pname,jtype,precode,usetime,maker,cdate from Sys_ProcessPoint ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProcessPoint r = new Sys_ProcessPoint();
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
        public  Sys_ProcessPoint DataRowToModel(DataRow row)
        {
            Sys_ProcessPoint model = new  Sys_ProcessPoint();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["jname"] != null)
                {
                    model.jname = row["jname"].ToString();
                }
                if (row["jcode"] != null)
                {
                    model.jcode = row["jcode"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["jtype"] != null)
                {
                    model.jtype = row["jtype"].ToString();
                }
                if (row["precode"] != null)
                {
                    model.precode = row["precode"].ToString();
                }
                if (row["usetime"] != null && row["usetime"].ToString() != "")
                {
                    model.usetime = decimal.Parse(row["usetime"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProcessPoint> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,jname,jcode,pcode,pname,jtype,precode,usetime,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_ProcessPoint where 1=1 {0}", strWhere);
            List<Sys_ProcessPoint> r = new List<Sys_ProcessPoint>();
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
            sql = "select isnull(max(convert(int,jcode)),0) as n from Sys_ProcessPoint ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
