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
    public class Sys_TempletDal : ISys_TempletDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Templet");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
     
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_Templet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Templet(");
            strSql.Append("emcode,ttype,ttext,utype,dcode,maker,cdate,emname,ptype)");
            strSql.Append(" values (");
            strSql.Append("@emcode,@ttype,@ttext,@utype,@dcode,@maker,@cdate,@emname,@ptype)");
            SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,10),
					new SqlParameter("@ttype", SqlDbType.NVarChar,5),
					new SqlParameter("@ttext", SqlDbType.NVarChar,4000),
					new SqlParameter("@utype", SqlDbType.NVarChar,20),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@emname", SqlDbType.NVarChar,50),
					new SqlParameter("@ptype", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.emcode;
            parameters[1].Value = model.ttype;
            parameters[2].Value = model.ttext;
            parameters[3].Value = model.utype;
            parameters[4].Value = model.dcode;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.emname;
            parameters[8].Value = model.ptype;
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
        public bool Update(Sys_Templet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Templet set ");
            strSql.Append("emcode=@emcode,");
            strSql.Append("ttype=@ttype,");
            strSql.Append("ttext=@ttext,");
            strSql.Append("utype=@utype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("emname=@emname,");
            strSql.Append("ptype=@ptype");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,10),
					new SqlParameter("@ttype", SqlDbType.NVarChar,5),
					new SqlParameter("@ttext", SqlDbType.NVarChar,4000),
					new SqlParameter("@utype", SqlDbType.NVarChar,20),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                     new SqlParameter("@emname", SqlDbType.NVarChar,50),
                     new SqlParameter("@ptype", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)
                   };
            parameters[0].Value = model.emcode;
            parameters[1].Value = model.ttype;
            parameters[2].Value = model.ttext;
            parameters[3].Value = model.utype;
            parameters[4].Value = model.dcode;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.emname;
            parameters[8].Value = model.ptype;
            parameters[9].Value = model.id;

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
            strSql.Append("delete from Sys_Templet ");
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
        public  Sys_Templet Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,emname,emcode,ttype,ttext,utype,dcode,maker,cdate,limg,fname,ptype from Sys_Templet ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Templet r = new Sys_Templet();
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
        public  Sys_Templet DataRowToModel(DataRow row)
        {
             Sys_Templet model = new  Sys_Templet();
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
                if (row["ttype"] != null)
                {
                    model.ttype = row["ttype"].ToString();
                }
                if (row["ttext"] != null)
                {
                    model.ttext = row["ttext"].ToString();
                }
                if (row["utype"] != null)
                {
                    model.utype = row["utype"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["limg"] != null)
                {
                    model.limg = row["limg"].ToString();
                }
                if (row["emname"] != null)
                {
                    model.emname = row["emname"].ToString();
                }
                if (row["fname"] != null)
                {
                    model.fname = row["fname"].ToString();
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Templet> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,emname,emcode,ttype,ttext,utype,dcode,maker,cdate,limg ,fname ,ptype ");
            strSql.AppendFormat(" FROM Sys_Templet where 1=1 {0}", where);
            List<Sys_Templet> r = new List<Sys_Templet>();
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
        public bool UpImg(string url, string fname,int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  Sys_Templet set limg='{0}', fname='{1}'  ", url,fname);
            strSql.AppendFormat(" where id={0};", id);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
