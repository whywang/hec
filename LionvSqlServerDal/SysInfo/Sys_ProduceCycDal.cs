using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
   public class Sys_ProduceCycDal : ISys_ProduceCycDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProduceCyc");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ProduceCyc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProduceCyc(");
            strSql.Append("cname,ccode,fname,fcode,emname,emcode,cnum,bdname,bdcode,csql,otype,dcode,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@cname,@ccode,@fname,@fcode,@emname,@emcode,@cnum,@bdname,@bdcode,@csql,@otype,@dcode,@cdate,@maker)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,10),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@fcode", SqlDbType.NVarChar,50),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,10),
					new SqlParameter("@cnum", SqlDbType.Int,4),
					new SqlParameter("@bdname", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@csql", SqlDbType.NVarChar,500),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.fname;
            parameters[3].Value = model.fcode;
            parameters[4].Value = model.emname;
            parameters[5].Value = model.emcode;
            parameters[6].Value = model.cnum;
            parameters[7].Value = model.bdname;
            parameters[8].Value = model.bdcode;
            parameters[9].Value = model.csql;
            parameters[10].Value = model.otype;
            parameters[11].Value = model.dcode;
            parameters[12].Value = model.cdate;
            parameters[13].Value = model.maker;
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
        public bool Update( Sys_ProduceCyc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProduceCyc set ");
            strSql.Append("cname=@cname,");
            strSql.Append("fname=@fname,");
            strSql.Append("fcode=@fcode,");
            strSql.Append("emname=@emname,");
            strSql.Append("emcode=@emcode,");
            strSql.Append("cnum=@cnum,");
            strSql.Append("bdname=@bdname,");
            strSql.Append("bdcode=@bdcode,");
            strSql.Append("csql=@csql,");
            strSql.Append("otype=@otype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where ccode=@ccode");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@fcode", SqlDbType.NVarChar,50),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,10),
					new SqlParameter("@cnum", SqlDbType.Int,4),
					new SqlParameter("@bdname", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@csql", SqlDbType.NVarChar,500),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.fname;
            parameters[2].Value = model.fcode;
            parameters[3].Value = model.emname;
            parameters[4].Value = model.emcode;
            parameters[5].Value = model.cnum;
            parameters[6].Value = model.bdname;
            parameters[7].Value = model.bdcode;
            parameters[8].Value = model.csql;
            parameters[9].Value = model.otype;
            parameters[10].Value = model.dcode;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.maker;
            parameters[13].Value = model.ccode;
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
        public bool Delete(string ccode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProduceCyc ");
            strSql.AppendFormat(" where  ccode= '{0}';", ccode);
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
        public Sys_ProduceCyc Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,cname,ccode,fname,fcode,emname,emcode,cnum,bdname,bdcode,csql,otype,dcode,cdate,maker from Sys_ProduceCyc ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProduceCyc r = new Sys_ProduceCyc();
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
        public  Sys_ProduceCyc DataRowToModel(DataRow row)
        {
             Sys_ProduceCyc model = new  Sys_ProduceCyc();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["cname"] != null)
                {
                    model.cname = row["cname"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["fname"] != null)
                {
                    model.fname = row["fname"].ToString();
                }
                if (row["fcode"] != null)
                {
                    model.fcode = row["fcode"].ToString();
                }
                if (row["emname"] != null)
                {
                    model.emname = row["emname"].ToString();
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["cnum"] != null && row["cnum"].ToString() != "")
                {
                    model.cnum = int.Parse(row["cnum"].ToString());
                }
                if (row["bdname"] != null)
                {
                    model.bdname = row["bdname"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["csql"] != null)
                {
                    model.csql = row["csql"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProduceCyc> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,cname,ccode,fname,fcode,emname,emcode,cnum,bdname,bdcode,csql,otype,dcode,cdate,maker ");
            strSql.AppendFormat(" FROM Sys_ProduceCyc where 1=1 {0}  ", strWhere);
            List<Sys_ProduceCyc> r = new List<Sys_ProduceCyc>();
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
            string sql = "select isnull(max(convert(int,ccode)),0) as n from Sys_ProduceCyc ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
