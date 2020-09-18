using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;
using LionvModel.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_MaterialDal : ISys_MaterialDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Material");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_Material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Material(");
            strSql.Append("mname,mcode,mcname,mccode,mstate,maker,cdate,mtype)");
            strSql.Append(" values (");
            strSql.Append("@mname,@mcode,@mcname,@mccode,@mstate,@maker,@cdate,@mtype)");
        
            SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@mcode", SqlDbType.NVarChar,20),
					new SqlParameter("@mcname", SqlDbType.NVarChar,20),
					new SqlParameter("@mccode", SqlDbType.NVarChar,20),
					new SqlParameter("@mstate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@mtype", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.mname;
            parameters[1].Value = model.mcode;
            parameters[2].Value = model.mcname;
            parameters[3].Value = model.mccode;
            parameters[4].Value = model.mstate;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.mtype;
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
        public bool Update(Sys_Material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Material set ");
            strSql.Append("mname=@mname,");
            strSql.Append("mcname=@mcname,");
            strSql.Append("mccode=@mccode,");
            strSql.Append("mstate=@mstate,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("mtype=@mtype");
            strSql.Append(" where mcode=@mcode");
            SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@mcname", SqlDbType.NVarChar,20),
					new SqlParameter("@mccode", SqlDbType.NVarChar,20),
					new SqlParameter("@mstate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    	new SqlParameter("@mtype", SqlDbType.NVarChar,20),
					new SqlParameter("@mcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.mname;
            parameters[1].Value = model.mcname;
            parameters[2].Value = model.mccode;
            parameters[3].Value = model.mstate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.mtype;
            parameters[7].Value = model.mcode;
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
            strSql.AppendFormat("delete from Sys_Material where 1=1 {0}", where);
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
        public  Sys_Material Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,mname,mcode,mcname,mccode,mstate,maker,cdate ,mtype from Sys_Material ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Material r = new Sys_Material();
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
        public Sys_Material DataRowToModel(DataRow row)
        {
             Sys_Material model = new  Sys_Material();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["mcode"] != null)
                {
                    model.mcode = row["mcode"].ToString();
                }
                if (row["mcname"] != null)
                {
                    model.mcname = row["mcname"].ToString();
                }
                if (row["mccode"] != null)
                {
                    model.mccode = row["mccode"].ToString();
                }
                if (row["mstate"] != null && row["mstate"].ToString() != "")
                {
                    if ((row["mstate"].ToString() == "1") || (row["mstate"].ToString().ToLower() == "true"))
                    {
                        model.mstate = true;
                    }
                    else
                    {
                        model.mstate = false;
                    }
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["mtype"] != null)
                {
                    model.mtype = row["mtype"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Material> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mname,mcode,mcname,mccode,mstate,maker,cdate,mtype from Sys_Material");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_Material> r = new List<Sys_Material>();
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
        public int CreateCode(string where)
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,substring(mcode,len(mcode)-1,2))),0) as n from Sys_Material where  1=1 and mccode='" + where + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
