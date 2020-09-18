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
    public class Sys_ProductionOrderTempDal : ISys_ProductionOrderTempDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionOrderTemp");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ProductionOrderTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionOrderTemp(");
            strSql.Append("tname,tcode,xqt,sct,spt,gpt,bpt,xqf,scf,spf,gpf,bpf,dcode,ttype,tread,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@tname,@tcode,@xqt,@sct,@spt,@gpt,@bpt,@xqf,@scf,@spf,@gpf,@bpf,@dcode,@ttype,@tread,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30),
					new SqlParameter("@xqt", SqlDbType.NVarChar,2000),
					new SqlParameter("@sct", SqlDbType.NVarChar,2000),
					new SqlParameter("@spt", SqlDbType.NVarChar,2000),
					new SqlParameter("@gpt", SqlDbType.NVarChar,2000),
					new SqlParameter("@bpt", SqlDbType.NVarChar,2000),
                    new SqlParameter("@xqf", SqlDbType.NVarChar,2000),
					new SqlParameter("@scf", SqlDbType.NVarChar,2000),
					new SqlParameter("@spf", SqlDbType.NVarChar,2000),
					new SqlParameter("@gpf", SqlDbType.NVarChar,2000),
					new SqlParameter("@bpf", SqlDbType.NVarChar,2000),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
                    new SqlParameter("@ttype", SqlDbType.NVarChar,30),
                    new SqlParameter("@tread", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.tname;
            parameters[1].Value = model.tcode;
            parameters[2].Value = model.xqt;
            parameters[3].Value = model.sct;
            parameters[4].Value = model.spt;
            parameters[5].Value = model.gpt;
            parameters[6].Value = model.bpt;
            parameters[7].Value = model.xqf;
            parameters[8].Value = model.scf;
            parameters[9].Value = model.spf;
            parameters[10].Value = model.gpf;
            parameters[11].Value = model.bpf;
            parameters[12].Value = model.dcode;
            parameters[13].Value = model.ttype;
            parameters[14].Value = model.tread;
            parameters[15].Value = model.maker;
            parameters[16].Value = model.cdate;

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
        public bool Update( Sys_ProductionOrderTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionOrderTemp set ");
            strSql.Append("tname=@tname,");
            strSql.Append("xqt=@xqt,");
            strSql.Append("sct=@sct,");
            strSql.Append("spt=@spt,");
            strSql.Append("gpt=@gpt,");
            strSql.Append("bpt=@bpt,");
            strSql.Append("xqf=@xqf,");
            strSql.Append("scf=@scf,");
            strSql.Append("spf=@spf,");
            strSql.Append("gpf=@gpf,");
            strSql.Append("bpf=@bpf,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tcode=@tcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@xqt", SqlDbType.NVarChar,2000),
					new SqlParameter("@sct", SqlDbType.NVarChar,2000),
					new SqlParameter("@spt", SqlDbType.NVarChar,2000),
					new SqlParameter("@gpt", SqlDbType.NVarChar,2000),
					new SqlParameter("@bpt", SqlDbType.NVarChar,2000),
                    new SqlParameter("@xqf", SqlDbType.NVarChar,2000),
					new SqlParameter("@scf", SqlDbType.NVarChar,2000),
					new SqlParameter("@spf", SqlDbType.NVarChar,2000),
					new SqlParameter("@gpf", SqlDbType.NVarChar,2000),
					new SqlParameter("@bpf", SqlDbType.NVarChar,2000),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tname;
            parameters[1].Value = model.xqt;
            parameters[2].Value = model.sct;
            parameters[3].Value = model.spt;
            parameters[4].Value = model.gpt;
            parameters[5].Value = model.bpt;
            parameters[6].Value = model.xqf;
            parameters[7].Value = model.scf;
            parameters[8].Value = model.spf;
            parameters[9].Value = model.gpf;
            parameters[10].Value = model.bpf;
            parameters[11].Value = model.dcode;
            parameters[12].Value = model.maker;
            parameters[13].Value = model.cdate;
            parameters[14].Value = model.tcode;

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
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionOrderTemp ");
            strSql.AppendFormat(" where 1=1 '{0}' ;", where);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
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
        /// 得到一个对象实体
        /// </summary>
        public  Sys_ProductionOrderTemp Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tname,tcode,xqt,sct,spt,gpt,bpt,xqf,scf,spf,gpf,bpf,dcode,maker,cdate,tread,ttype from Sys_ProductionOrderTemp ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionOrderTemp r = new Sys_ProductionOrderTemp();
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
        public  Sys_ProductionOrderTemp DataRowToModel(DataRow row)
        {
             Sys_ProductionOrderTemp model = new  Sys_ProductionOrderTemp();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tname"] != null)
                {
                    model.tname = row["tname"].ToString();
                }
                if (row["tcode"] != null)
                {
                    model.tcode = row["tcode"].ToString();
                }
                if (row["xqt"] != null)
                {
                    model.xqt = row["xqt"].ToString();
                }
                if (row["sct"] != null)
                {
                    model.sct = row["sct"].ToString();
                }
                if (row["spt"] != null)
                {
                    model.spt = row["spt"].ToString();
                }
                if (row["gpt"] != null)
                {
                    model.gpt = row["gpt"].ToString();
                }
                if (row["bpt"] != null)
                {
                    model.bpt = row["bpt"].ToString();
                }
                if (row["xqf"] != null)
                {
                    model.xqf = row["xqf"].ToString();
                }
                if (row["scf"] != null)
                {
                    model.scf = row["scf"].ToString();
                }
                if (row["spf"] != null)
                {
                    model.spf = row["spf"].ToString();
                }
                if (row["gpf"] != null)
                {
                    model.gpf = row["gpf"].ToString();
                }
                if (row["bpf"] != null)
                {
                    model.bpf = row["bpf"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["ttype"] != null)
                {
                    model.ttype = row["ttype"].ToString();
                }
                if (row["tread"] != null && row["tread"].ToString() != "")
                {
                    if ((row["tread"].ToString() == "1") || (row["tread"].ToString().ToLower() == "true"))
                    {
                        model.tread = true;
                    }
                    else
                    {
                        model.tread = false;
                    }
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
        public List<Sys_ProductionOrderTemp> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tname,tcode,xqt,sct,spt,gpt,bpt,xqf,scf,spf,gpf,bpf,dcode,maker,cdate,tread,ttype ");
            strSql.Append(" FROM Sys_ProductionOrderTemp ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionOrderTemp> r = new List<Sys_ProductionOrderTemp>();
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
            string sql = "select isnull(max(convert(int,tcode)),0) as n from Sys_ProductionOrderTemp ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
