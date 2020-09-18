using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_OrderSourceDal : ISys_OrderSourceDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_OrderSource");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
  
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_OrderSource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_OrderSource(");
            strSql.Append("emcode,sname,sread,stype,dcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@emcode,@sname,@sread,@stype,@dcode,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,10),
					new SqlParameter("@sname", SqlDbType.NVarChar,50),
					new SqlParameter("@sread", SqlDbType.Bit,1),
					new SqlParameter("@stype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.emcode;
            parameters[1].Value = model.sname;
            parameters[2].Value = model.sread;
            parameters[3].Value = model.stype;
            parameters[4].Value = model.dcode;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
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
        public bool Update( Sys_OrderSource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_OrderSource set ");
            strSql.Append("emcode=@emcode,");
            strSql.Append("sname=@sname,");
            strSql.Append("sread=@sread,");
            strSql.Append("stype=@stype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,10),
					new SqlParameter("@sname", SqlDbType.NVarChar,50),
					new SqlParameter("@sread", SqlDbType.Bit,1),
					new SqlParameter("@stype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.emcode;
            parameters[1].Value = model.sname;
            parameters[2].Value = model.sread;
            parameters[3].Value = model.stype;
            parameters[4].Value = model.dcode;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.id;
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_OrderSource ");
            strSql.AppendFormat(" where  1=1 {0}", where);
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
        public  Sys_OrderSource Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,emcode,sname,sread,stype,dcode,maker,cdate from Sys_OrderSource  ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_OrderSource r = new Sys_OrderSource();
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
        public  Sys_OrderSource DataRowToModel(DataRow row)
        {
            Sys_OrderSource model = new  Sys_OrderSource();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["sname"] != null)
                {
                    model.sname = row["sname"].ToString();
                }
                if (row["sread"] != null && row["sread"].ToString() != "")
                {
                    if ((row["sread"].ToString() == "1") || (row["sread"].ToString().ToLower() == "true"))
                    {
                        model.sread = true;
                    }
                    else
                    {
                        model.sread = false;
                    }
                }
                if (row["stype"] != null)
                {
                    model.stype = row["stype"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_OrderSource> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,emcode,sname,sread,stype,dcode,maker,cdate ");
            strSql.Append(" FROM Sys_OrderSource ");
            List<Sys_OrderSource> r = new List<Sys_OrderSource>();
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

        #endregion  ExtensionMethod
    }
}
