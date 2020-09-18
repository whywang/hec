using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LionvCommon;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_PartTypeDal : ISys_PartTypeDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string pcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_PartType");
            strSql.AppendFormat(" where 1=1 {0} ", pcode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_PartType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_PartType(");
            strSql.Append("pctype,pcname,pname,pcode,ptype,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@pctype,@pcname,@pname,@pcode,@ptype,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@pctype", SqlDbType.NVarChar,30),
					new SqlParameter("@pcname", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,20),
					new SqlParameter("@pcode", SqlDbType.NVarChar,10),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.pctype;
            parameters[1].Value = model.pcname;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.pcode;
            parameters[4].Value = model.ptype;
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
        public bool Update(Sys_PartType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_PartType set ");
            strSql.Append("pctype=@pctype,");
            strSql.Append("pcname=@pcname,");
            strSql.Append("pname=@pname,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where pcode=@pcode");
            SqlParameter[] parameters = {
					new SqlParameter("@pctype", SqlDbType.NVarChar,30),
					new SqlParameter("@pcname", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pcode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.pctype;
            parameters[1].Value = model.pcname;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.ptype;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.pcode;
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
            strSql.Append("delete from Sys_PartType ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
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
        public Sys_PartType Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,pctype,pcname,pname,pcode,ptype,pread,maker,cdate from Sys_PartType ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_PartType r = new Sys_PartType();
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
        public Sys_PartType DataRowToModel(DataRow row)
        {
            Sys_PartType model = new Sys_PartType();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["pctype"] != null)
                {
                    model.pctype = row["pctype"].ToString();
                }
                if (row["pcname"] != null)
                {
                    model.pcname = row["pcname"].ToString();
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["pread"] != null && row["pread"].ToString() != "")
                {
                    if ((row["pread"].ToString() == "1") || (row["pread"].ToString().ToLower() == "true"))
                    {
                        model.pread = true;
                    }
                    else
                    {
                        model.pread = false;
                    }
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
        public List<Sys_PartType> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pctype,pcname,pname,pcode,ptype,pread,maker,cdate  ");
            strSql.Append(" FROM Sys_PartType ");
            strSql.AppendFormat("   where 1=1 {0}", where);
            List<Sys_PartType> r = new List<Sys_PartType>();
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
            string sql = "";
            sql = "select isnull(max(convert(int,pcode)),0) as n from Sys_PartType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetInvPartType(string icode, string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryPartType where icode='{0}';", icode);
            sql.AppendFormat(" insert into Sys_RInventoryPartType ( icode,pcode) values ('{0}','{1}')", icode, pcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetInvPartType(string icode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryPartType where icode='{0}';", icode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetInvPartType(string icode)
        {
            string r = "";
            r = LoodQuery(icode);
            return r;
        }
        private string LoodQuery(string icode)
        {
            string p = "";
            if (icode.Length > 0)
            {

                string sql = "select pcode from Sys_RInventoryPartType where icode='" + icode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(icode.Substring(0, icode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
        public DataTable QueryCateList(string where)
        {
            DataTable r = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pctype,pcname   FROM Sys_PartType  ");
            strSql.AppendFormat("   where 1=1 {0} group by pctype,pcname", where);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt;
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
