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
    public  class Sys_OrderCodeDal : ISys_OrderCodeDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_OrderCode");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_OrderCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_OrderCode(");
            strSql.Append("emcode,citytype,inum,years,prestr,cname,ccode,dcode,ctype,cqstr,ccstr,czstr,cystr,csjsstr,csource,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@emcode,@citytype,@inum,@years,@prestr,@cname,@ccode,@dcode,@ctype,@cqstr,@ccstr,@czstr,@cystr,@csjsstr,@csource,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,50),
					new SqlParameter("@citytype", SqlDbType.NVarChar,50),
					new SqlParameter("@inum", SqlDbType.Int,4),
					new SqlParameter("@years", SqlDbType.NVarChar,20),
					new SqlParameter("@prestr", SqlDbType.NVarChar,50),
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@cqstr", SqlDbType.Int,4),
					new SqlParameter("@ccstr", SqlDbType.Int,4),
					new SqlParameter("@czstr", SqlDbType.Int,4),
					new SqlParameter("@cystr", SqlDbType.NVarChar,30),
					new SqlParameter("@csjsstr", SqlDbType.Int,4),
					new SqlParameter("@csource", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.emcode;
            parameters[1].Value = model.citytype;
            parameters[2].Value = model.inum;
            parameters[3].Value = model.years;
            parameters[4].Value = model.prestr;
            parameters[5].Value = model.cname;
            parameters[6].Value = model.ccode;
            parameters[7].Value = model.dcode;
            parameters[8].Value = model.ctype;
            parameters[9].Value = model.cqstr;
            parameters[10].Value = model.ccstr;
            parameters[11].Value = model.czstr;
            parameters[12].Value = model.cystr;
            parameters[13].Value = model.csjsstr;
            parameters[14].Value = model.csource;
            parameters[15].Value = model.maker;
            parameters[16].Value = model.cdate;
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
        public bool Update( Sys_OrderCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_OrderCode set ");
            strSql.Append("emcode=@emcode,");
            strSql.Append("citytype=@citytype,");
            strSql.Append("inum=@inum,");
            strSql.Append("years=@years,");
            strSql.Append("prestr=@prestr,");
            strSql.Append("cname=@cname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("ctype=@ctype,");
            strSql.Append("cqstr=@cqstr,");
            strSql.Append("ccstr=@ccstr,");
            strSql.Append("czstr=@czstr,");
            strSql.Append("cystr=@cystr,");
            strSql.Append("csjsstr=@csjsstr,");
            strSql.Append("csource=@csource,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ccode=@ccode");
            SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,50),
					new SqlParameter("@citytype", SqlDbType.NVarChar,50),
					new SqlParameter("@inum", SqlDbType.Int,4),
					new SqlParameter("@years", SqlDbType.NVarChar,20),
					new SqlParameter("@prestr", SqlDbType.NVarChar,50),
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@cqstr", SqlDbType.Int,4),
					new SqlParameter("@ccstr", SqlDbType.Int,4),
					new SqlParameter("@czstr", SqlDbType.Int,4),
					new SqlParameter("@cystr", SqlDbType.NVarChar,30),
					new SqlParameter("@csjsstr", SqlDbType.Int,4),
					new SqlParameter("@csource", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ccode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.emcode;
            parameters[1].Value = model.citytype;
            parameters[2].Value = model.inum;
            parameters[3].Value = model.years;
            parameters[4].Value = model.prestr;
            parameters[5].Value = model.cname;
            parameters[6].Value = model.dcode;
            parameters[7].Value = model.ctype;
            parameters[8].Value = model.cqstr;
            parameters[9].Value = model.ccstr;
            parameters[10].Value = model.czstr;
            parameters[11].Value = model.cystr;
            parameters[12].Value = model.csjsstr;
            parameters[13].Value = model.csource;
            parameters[14].Value = model.maker;
            parameters[15].Value = model.cdate;
            parameters[16].Value = model.ccode;
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
            strSql.Append("delete from Sys_OrderCode ");
            strSql.AppendFormat(" where  1=1 {0};", where);
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
        public Sys_OrderCode Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,emcode,citytype,inum,years,prestr,cname,ccode,dcode,ctype,cqstr,ccstr,czstr,cystr,csjsstr,csource,maker,cdate from Sys_OrderCode ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_OrderCode r = new Sys_OrderCode();
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
        public Sys_OrderCode DataRowToModel(DataRow row)
        {
            Sys_OrderCode model = new  Sys_OrderCode();
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
                if (row["citytype"] != null)
                {
                    model.citytype = row["citytype"].ToString();
                }
                if (row["inum"] != null && row["inum"].ToString() != "")
                {
                    model.inum = int.Parse(row["inum"].ToString());
                }
                if (row["years"] != null)
                {
                    model.years = row["years"].ToString();
                }
                if (row["prestr"] != null)
                {
                    model.prestr = row["prestr"].ToString();
                }
                if (row["cname"] != null)
                {
                    model.cname = row["cname"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["ctype"] != null)
                {
                    model.ctype = row["ctype"].ToString();
                }
                if (row["cqstr"] != null && row["cqstr"].ToString() != "")
                {
                    model.cqstr = int.Parse(row["cqstr"].ToString());
                }
                if (row["ccstr"] != null && row["ccstr"].ToString() != "")
                {
                    model.ccstr = int.Parse(row["ccstr"].ToString());
                }
                if (row["czstr"] != null && row["czstr"].ToString() != "")
                {
                    model.czstr = int.Parse(row["czstr"].ToString());
                }
                if (row["cystr"] != null)
                {
                    model.cystr = row["cystr"].ToString();
                }
                if (row["csjsstr"] != null && row["csjsstr"].ToString() != "")
                {
                    model.csjsstr = int.Parse(row["csjsstr"].ToString());
                }
                if (row["csource"] != null)
                {
                    model.csource = row["csource"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_OrderCode> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,emcode,citytype,inum,years,prestr,cname,ccode,dcode,ctype,cqstr,ccstr,czstr,cystr,csjsstr,csource,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_OrderCode where 1=1 {0}", strWhere);
            List<Sys_OrderCode> r = new List<Sys_OrderCode>();
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
        public int CreatCode()
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,ccode)),0) as n from Sys_OrderCode ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
