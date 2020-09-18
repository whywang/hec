using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_BackEventDal : ISys_BackEventDal
    {
        #region  BasicMethod
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_BackEvent");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_BackEvent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_BackEvent(");
            strSql.Append("ename,ecode,bname,bcode,esort,source,ebody,estate)");
            strSql.Append(" values (");
            strSql.Append("@ename,@ecode,@bname,@bcode,@esort,@source,@ebody,@estate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ename", SqlDbType.NVarChar,50),
					new SqlParameter("@ecode", SqlDbType.NVarChar,20),
					new SqlParameter("@bname", SqlDbType.NVarChar,20),
					new SqlParameter("@bcode", SqlDbType.NVarChar,20),
					new SqlParameter("@esort", SqlDbType.NVarChar,1),
					new SqlParameter("@source", SqlDbType.NVarChar,20),
					new SqlParameter("@ebody", SqlDbType.NVarChar,3000),
					new SqlParameter("@estate", SqlDbType.NVarChar,1)};
            parameters[0].Value = model.ename;
            parameters[1].Value = model.ecode;
            parameters[2].Value = model.bname;
            parameters[3].Value = model.bcode;
            parameters[4].Value = model.esort;
            parameters[5].Value = model.source;
            parameters[6].Value = model.ebody;
            parameters[7].Value = model.estate;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
               // UpdateStoreProcess(model.source, model.ename, model.ebody);
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
        public bool Update(Sys_BackEvent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_BackEvent set ");
            strSql.Append("ename=@ename,");
            strSql.Append("bname=@bname,");
            strSql.Append("bcode=@bcode,");
            strSql.Append("esort=@esort,");
            strSql.Append("source=@source,");
            strSql.Append("ebody=@ebody,");
            strSql.Append("estate=@estate");
            strSql.Append(" where ecode=@ecode");
            SqlParameter[] parameters = {
					new SqlParameter("@ename", SqlDbType.NVarChar,50),
					new SqlParameter("@bname", SqlDbType.NVarChar,20),
					new SqlParameter("@bcode", SqlDbType.NVarChar,20),
					new SqlParameter("@esort", SqlDbType.NVarChar,1),
					new SqlParameter("@source", SqlDbType.NVarChar,20),
					new SqlParameter("@ebody", SqlDbType.NVarChar,3000),
                    new SqlParameter("@estate", SqlDbType.NVarChar,1),
					new SqlParameter("@ecode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.ename;
            parameters[1].Value = model.bname;
            parameters[2].Value = model.bcode;
            parameters[3].Value = model.esort;
            parameters[4].Value = model.source;
            parameters[5].Value = model.ebody;
            parameters[6].Value = model.estate;
            parameters[7].Value = model.ecode;

            bool r = false;

            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
                //UpdateStoreProcess(model.source, model.ename, model.ebody);
            }
            return r;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ecode)
        {

            StringBuilder strSql = new StringBuilder();
            Sys_BackEvent model= Query(" and ecode='" + ecode + "'");
            strSql.Append("delete from Sys_BackEvent ");
            strSql.AppendFormat(" where  ecode= '{0}'", ecode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                DelStoreProcess(model.source, model.ename);
                r = true;
            }
            return r;
        }
        public Sys_BackEvent Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ename,ecode,bname,bcode,esort,source,ebody,estate from Sys_BackEvent ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_BackEvent r = new Sys_BackEvent();
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
        private  Sys_BackEvent DataRowToModel(DataRow row)
        {
            Sys_BackEvent model = new  Sys_BackEvent();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ename"] != null)
                {
                    model.ename = row["ename"].ToString();
                }
                if (row["ecode"] != null)
                {
                    model.ecode = row["ecode"].ToString();
                }
                if (row["bname"] != null)
                {
                    model.bname = row["bname"].ToString();
                }
                if (row["bcode"] != null)
                {
                    model.bcode = row["bcode"].ToString();
                }
                if (row["esort"] != null)
                {
                    model.esort = row["esort"].ToString();
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["ebody"] != null)
                {
                    model.ebody = row["ebody"].ToString();
                }
                if (row["estate"] != null)
                {
                    model.estate = row["estate"].ToString();
                }
            }
            return model;
        }
        public List<Sys_BackEvent> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,ename,ecode,bname,bcode,esort,source,ebody,estate from Sys_BackEvent ");
            strSql.AppendFormat("  where 1=1 {0}", strWhere);
            List<Sys_BackEvent> r = new List<Sys_BackEvent>();
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
            string sql = "select isnull(max(convert(int,ecode)),0) as n from Sys_BackEvent ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        private void UpdateStoreProcess(string source,string spname, string spbody)
        {
            string connstr="";
            string sql = "select count(1) from dbo.sysobjects where OBJECTPROPERTY(id, N'IsProcedure') = 1 and name='" + spname + "'";
            StringBuilder esql = new StringBuilder ();
            if (source == "LvErpBase")
            {
                connstr = SqlHelp.ConnectionString;
            }
            else
            {
                connstr = SqlHelp.ConnectionStringb;
            }
            object o = SqlHelp.ExecuteScalar(connstr, CommandType.Text, sql, null);
            if (Convert.ToInt32(o) > 0)
            {
                esql.AppendFormat(" drop proc {0};", spname);
                if (spbody != "")
                {
                    esql.AppendFormat(" {0}", spbody);
                }
            }
            else
            {
                if (spbody != "")
                {
                    esql.AppendFormat(" {0}", spbody);
                }
            }
            if (esql.ToString() != "")
            {
                SqlHelp.ExecuteNonQuery(connstr, CommandType.Text, esql.ToString(), null);
            }
        }
        private void DelStoreProcess(string source, string spname)
        {
            string connstr = "";
            string sql = "select count(1) from dbo.sysobjects where OBJECTPROPERTY(id, N'IsProcedure') = 1 and name='" + spname + "'";
            StringBuilder esql = new StringBuilder();
            if (source == "LvErpBase" || source == "TLvErpBase")
            {
                connstr = SqlHelp.ConnectionString;
            }
            else
            {
                connstr = SqlHelp.ConnectionStringb;
            }
            object o = SqlHelp.ExecuteScalar(connstr, CommandType.Text, sql, null);
            if (Convert.ToInt32(o) > 0)
            {
                esql.AppendFormat(" drop proc {0};", spname);
            }
            SqlHelp.ExecuteNonQuery(connstr, CommandType.Text, esql.ToString(), null);

        }
        public void FireBackEvent(string basename, string ename, string sid, string maker)
        {
            if (basename == "LvErpBusiness" || basename == "TLvErpBusiness")
            {
                SqlParameter[] parms = { new SqlParameter("@sid", sid), new SqlParameter("@maker", maker) };
                SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, ename, parms);
            }
            else
            {
                SqlParameter[] parms = { new SqlParameter("@sid", sid), new SqlParameter("@maker", maker) };
                SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.StoredProcedure, ename, parms);
            }
        }
        public string FireBackEventE(string basename, string ename, string sid, string maker)
        {
            string r = "";
            if (basename == "LvErpBusiness" || basename == "TLvErpBusiness")
            {
                SqlParameter[] parms = { new SqlParameter("@sid", sid),
                                         new SqlParameter("@maker", maker) ,
                                         new SqlParameter("@ostr",SqlDbType.NVarChar,100) 
                                       };
                parms[2].Direction = ParameterDirection.Output;
                SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, ename, parms);
                if (parms[2].Value != null)
                {
                    r = parms[2].Value.ToString();
                }
            }
            else
            {
                SqlParameter[] parms = { new SqlParameter("@sid", sid), 
                                         new SqlParameter("@maker", maker) ,
                                        new SqlParameter("@ostr",SqlDbType.NVarChar,100) 
                                       };
                parms[2].Direction = ParameterDirection.Output;
                SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.StoredProcedure, ename, parms);
                if (parms[2].Value != null)
                {
                    r = parms[2].Value.ToString();
                }
            }
            return r;
        }
        public void FireBackEvent(string ename, string sid, string maker)
        {
            SqlParameter[] parms = { new SqlParameter("@sid", sid), new SqlParameter("@maker", maker) };
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, ename, parms);
        }
        #endregion  ExtensionMethod
    }
}
