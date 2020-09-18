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
    class Sys_RepairDutyDal : ISys_RepairDutyDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string rcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_RepairDuty");
            strSql.AppendFormat(" where 1=1 {0} ", rcode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_RepairDuty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_RepairDuty(");
            strSql.Append("rcode,rdetail,rcname,rccode,rread,rtype,dcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@rcode,@rdetail,@rcname,@rccode,@rread,@rtype,@dcode,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@rcode", SqlDbType.NVarChar,10),
					new SqlParameter("@rdetail", SqlDbType.NVarChar,100),
					new SqlParameter("@rcname", SqlDbType.NVarChar,30),
					new SqlParameter("@rccode", SqlDbType.NVarChar,10),
					new SqlParameter("@rread", SqlDbType.Bit,1),
					new SqlParameter("@rtype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.rcode;
            parameters[1].Value = model.rdetail;
            parameters[2].Value = model.rcname;
            parameters[3].Value = model.rccode;
            parameters[4].Value = model.rread;
            parameters[5].Value = model.rtype;
            parameters[6].Value = model.dcode;
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
        public bool Update(Sys_RepairDuty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_RepairDuty set ");
            strSql.Append("rdetail=@rdetail,");
            strSql.Append("rcname=@rcname,");
            strSql.Append("rccode=@rccode,");
            strSql.Append("rread=@rread,");
            strSql.Append("rtype=@rtype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where rcode=@rcode");
            SqlParameter[] parameters = {
					new SqlParameter("@rdetail", SqlDbType.NVarChar,100),
					new SqlParameter("@rcname", SqlDbType.NVarChar,30),
					new SqlParameter("@rccode", SqlDbType.NVarChar,10),
					new SqlParameter("@rread", SqlDbType.Bit,1),
					new SqlParameter("@rtype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rcode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.rdetail;
            parameters[1].Value = model.rcname;
            parameters[2].Value = model.rccode;
            parameters[3].Value = model.rread;
            parameters[4].Value = model.rtype;
            parameters[5].Value = model.dcode;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.rcode;
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
        public bool Delete(string rcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RepairDuty ");
            strSql.AppendFormat(" where  rcode= '{0}';", rcode);
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
        public Sys_RepairDuty Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,rcode,rdetail,rcname,rccode,rread,rtype,dcode,maker,cdate from Sys_RepairDuty ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_RepairDuty r = new Sys_RepairDuty();
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
        public Sys_RepairDuty DataRowToModel(DataRow row)
        {
            Sys_RepairDuty model = new Sys_RepairDuty();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["rcode"] != null)
                {
                    model.rcode = row["rcode"].ToString();
                }
                if (row["rdetail"] != null)
                {
                    model.rdetail = row["rdetail"].ToString();
                }
                if (row["rcname"] != null)
                {
                    model.rcname = row["rcname"].ToString();
                }
                if (row["rread"] != null && row["rread"].ToString() != "")
                {
                    if ((row["rread"].ToString() == "1") || (row["rread"].ToString().ToLower() == "true"))
                    {
                        model.rread = true;
                    }
                    else
                    {
                        model.rread = false;
                    }
                }
                if (row["rtype"] != null)
                {
                    model.rtype = row["rtype"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["rccode"] != null)
                {
                    model.rccode = row["rccode"].ToString();
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
        public List<Sys_RepairDuty> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,rcode,rdetail,rcname,rccode,rread,rtype,dcode,maker,cdate  ");
            strSql.AppendFormat(" FROM Sys_RepairDuty where 1=1 {0}  ", strWhere);
            List<Sys_RepairDuty> r = new List<Sys_RepairDuty>();
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
        public int CreateCode(string rcode)
        { 
            int r = -1;
            string sql = "";
            if (rcode != "")
            {
                sql = "select isnull(max(convert(int,substring(rcode,len(rcode)-1,2))),0) as n from Sys_RepairDuty where rccode='" + rcode + "'";
            }
            else
            {
                sql = "select isnull(max(convert(int, rcode)),0) as n from Sys_RepairDuty where rccode='" + rcode + "'";
            }
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
