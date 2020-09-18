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
    public class Sys_DepmentDptDal : ISys_DepmentDptDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_DepmentDpt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_DepmentDpt(");
            strSql.Append("dcode,dmanager,dcontact,daddress,dfitment,dno,ddetail,iproduction,iadmin,logo,idepment,dperson,dmaker)");
            strSql.Append(" values (");
            strSql.Append("@dcode,@dmanager,@dcontact,@daddress,@dfitment,@dno,@ddetail,@iproduction,@iadmin,@logo,@idepment,@dperson,@dmaker)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@dmanager", SqlDbType.NVarChar,50),
					new SqlParameter("@dcontact", SqlDbType.NVarChar,50),
					new SqlParameter("@daddress", SqlDbType.NVarChar,50),
					new SqlParameter("@dfitment", SqlDbType.DateTime),
					new SqlParameter("@dno", SqlDbType.NVarChar,50),
					new SqlParameter("@ddetail", SqlDbType.NVarChar,100),
					new SqlParameter("@iproduction", SqlDbType.Bit,1),
					new SqlParameter("@iadmin", SqlDbType.Bit,1),
					new SqlParameter("@logo", SqlDbType.NVarChar,100),
					new SqlParameter("@idepment", SqlDbType.NVarChar,100),
					new SqlParameter("@dperson", SqlDbType.Int,4),
					new SqlParameter("@dmaker", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.dcode;
            parameters[1].Value = model.dmanager;
            parameters[2].Value = model.dcontact;
            parameters[3].Value = model.daddress;
            parameters[4].Value = model.dfitment;
            parameters[5].Value = model.dno;
            parameters[6].Value = model.ddetail;
            parameters[7].Value = model.iproduction;
            parameters[8].Value = model.iadmin;
            parameters[9].Value = model.logo;
            parameters[10].Value = model.idepment;
            parameters[11].Value = model.dperson;
            parameters[12].Value = model.dmaker;
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
        public bool Update(Sys_DepmentDpt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_DepmentDpt set ");
            strSql.Append("dmanager=@dmanager,");
            strSql.Append("dcontact=@dcontact,");
            strSql.Append("daddress=@daddress,");
            strSql.Append("dfitment=@dfitment,");
            strSql.Append("dno=@dno,");
            strSql.Append("ddetail=@ddetail,");
            strSql.Append("iproduction=@iproduction,");
            strSql.Append("iadmin=@iadmin,");
            strSql.Append("logo=@logo,");
            strSql.Append("idepment=@idepment,");
            strSql.Append("dperson=@dperson,");
            strSql.Append("dmaker=@dmaker");
            strSql.Append(" where dcode=@dcode");
            SqlParameter[] parameters = {
					new SqlParameter("@dmanager", SqlDbType.NVarChar,50),
					new SqlParameter("@dcontact", SqlDbType.NVarChar,50),
					new SqlParameter("@daddress", SqlDbType.NVarChar,50),
					new SqlParameter("@dfitment", SqlDbType.DateTime),
					new SqlParameter("@dno", SqlDbType.NVarChar,50),
					new SqlParameter("@ddetail", SqlDbType.NVarChar,100),
					new SqlParameter("@iproduction", SqlDbType.Bit,1),
					new SqlParameter("@iadmin", SqlDbType.Bit,1),
					new SqlParameter("@logo", SqlDbType.NVarChar,100),
					new SqlParameter("@idepment", SqlDbType.NVarChar,100),
					new SqlParameter("@dperson", SqlDbType.Int,4),
					new SqlParameter("@dmaker", SqlDbType.NVarChar,20),
 
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.dmanager;
            parameters[1].Value = model.dcontact;
            parameters[2].Value = model.daddress;
            parameters[3].Value = model.dfitment;
            parameters[4].Value = model.dno;
            parameters[5].Value = model.ddetail;
            parameters[6].Value = model.iproduction;
            parameters[7].Value = model.iadmin;
            parameters[8].Value = model.logo;
            parameters[9].Value = model.idepment;
            parameters[10].Value = model.dperson;
            parameters[11].Value = model.dmaker;
            parameters[12].Value = model.dcode;
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
            strSql.AppendFormat("delete from Sys_DepmentDtp where 1=1 {0}", where);
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
        public Sys_DepmentDpt Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,dcode,dmanager,dcontact,daddress,dfitment,dno,ddetail,iproduction,iadmin,logo,idepment,dperson,dmaker from Sys_DepmentDpt");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_DepmentDpt r = new Sys_DepmentDpt();
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
        private  Sys_DepmentDpt DataRowToModel(DataRow row)
        {
             Sys_DepmentDpt model = new  Sys_DepmentDpt();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["dmanager"] != null)
                {
                    model.dmanager = row["dmanager"].ToString();
                }
                if (row["dcontact"] != null)
                {
                    model.dcontact = row["dcontact"].ToString();
                }
                if (row["daddress"] != null)
                {
                    model.daddress = row["daddress"].ToString();
                }
                if (row["dfitment"] != null && row["dfitment"].ToString() != "")
                {
                    model.dfitment =  row["dfitment"].ToString( );
                }
                if (row["dno"] != null)
                {
                    model.dno = row["dno"].ToString();
                }
                if (row["ddetail"] != null)
                {
                    model.ddetail = row["ddetail"].ToString();
                }
                if (row["dperson"] != null && row["dperson"].ToString() != "")
                {
                    model.dperson = int.Parse(row["dperson"].ToString());
                }
                if (row["dmaker"] != null)
                {
                    model.dmaker = row["dmaker"].ToString();
                }
                if (row["iproduction"] != null && row["iproduction"].ToString() != "")
                {
                    if ((row["iproduction"].ToString() == "1") || (row["iproduction"].ToString().ToLower() == "true"))
                    {
                        model.iproduction = true;
                    }
                    else
                    {
                        model.iproduction = false;
                    }
                }
                if (row["iadmin"] != null && row["iadmin"].ToString() != "")
                {
                    if ((row["iadmin"].ToString() == "1") || (row["iadmin"].ToString().ToLower() == "true"))
                    {
                        model.iadmin = true;
                    }
                    else
                    {
                        model.iadmin = false;
                    }
                }
                if (row["logo"] != null)
                {
                    model.logo = row["logo"].ToString();
                }
                if (row["idepment"] != null)
                {
                    model.idepment = row["idepment"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_DepmentDpt> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Sys_DepmentDpt ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_DepmentDpt> r = new List<Sys_DepmentDpt>();
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

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
