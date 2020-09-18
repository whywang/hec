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
    public partial class Sys_AgentFeeDal : ISys_AgentFeeDal
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_AgentFee");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_AgentFee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_AgentFee(");
            strSql.Append("acode,icode,fmoney,maker,tfmoney,cdate)");
            strSql.Append(" values (");
            strSql.Append("@acode,@icode,@fmoney,@maker,@tfmoney,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@fmoney", SqlDbType.Money,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@tfmoney",  SqlDbType.Money,8),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.acode;
            parameters[1].Value = model.icode;
            parameters[2].Value = model.fmoney;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.tfmoney;
            parameters[5].Value = model.cdate;
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
        public bool Update(Sys_AgentFee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_AgentFee set ");
            strSql.Append("acode=@acode,");
            strSql.Append("icode=@icode,");
            strSql.Append("fmoney=@fmoney,");
            strSql.Append("maker=@maker,");
            strSql.Append("tfmoney=@tfmoney,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@fmoney", SqlDbType.Money,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@tfmoney", SqlDbType.Money,8),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.acode;
            parameters[1].Value = model.icode;
            parameters[2].Value = model.fmoney;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.tfmoney;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.id;
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
            strSql.Append("delete from Sys_AgentFee ");
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
        public Sys_AgentFee Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,acode,icode,fmoney,tfmoney,maker,cdate from Sys_AgentFee ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_AgentFee r = new Sys_AgentFee();
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
        public Sys_AgentFee DataRowToModel(DataRow row)
        {
           Sys_AgentFee model = new Sys_AgentFee();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["icode"] != null)
                {
                    model.icode = row["icode"].ToString();
                }
                if (row["fmoney"] != null && row["fmoney"].ToString() != "")
                {
                    model.fmoney = decimal.Parse(row["fmoney"].ToString());
                }
                if (row["tfmoney"] != null && row["tfmoney"].ToString() != "")
                {
                    model.tfmoney = decimal.Parse(row["tfmoney"].ToString());
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
        public List<Sys_AgentFee> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,acode,icode,fmoney,tfmoney,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_AgentFee where 1=1 {0}", where);
            List<Sys_AgentFee> r = new List<Sys_AgentFee>();
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
        public string GetProductionFee(string acode, string icode)
        {
            string r = "";
            r = LoodQuery(acode,icode);
            return r;
        }
        private string LoodQuery(string acode, string icode)
        {
            string p = "";
            if (icode.Length > 0)
            {

                string sql = "select id from Sys_AgentFee where acode='" + acode + "' and icode='" + icode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(acode,icode.Substring(0, icode.Length - 2));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
        #endregion  ExtensionMethod
    }
}
