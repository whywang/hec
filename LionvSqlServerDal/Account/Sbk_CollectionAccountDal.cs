using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvCommon;
using System.Data;
using LionvModel.Account;
using System.Data.SqlClient;

namespace LionvSqlServerDal.Account
{
    public class Sbk_CollectionAccountDal : ISbk_CollectionAccountDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sbk_CollectionAccount");
            strSql.AppendFormat(" where 1=1 {0}", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sbk_CollectionAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sbk_CollectionAccount(");
            strSql.Append("bcode,aname,acode,abank,asubbank,maker,remark,cdate,aperson)");
            strSql.Append(" values (");
            strSql.Append("@bcode,@aname,@acode,@abank,@asubbank,@maker,@remark,@cdate,@aperson)");
         
            SqlParameter[] parameters = {
					new SqlParameter("@bcode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@abank", SqlDbType.NVarChar,30),
					new SqlParameter("@asubbank", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@remark", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@aperson", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.bcode;
            parameters[1].Value = model.aname;
            parameters[2].Value = model.acode;
            parameters[3].Value = model.abank;
            parameters[4].Value = model.asubbank;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.aperson;
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
        public bool Update( Sbk_CollectionAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sbk_CollectionAccount set ");
            strSql.Append("aname=@aname,");
            strSql.Append("acode=@acode,");
            strSql.Append("abank=@abank,");
            strSql.Append("asubbank=@asubbank,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("remark=@remark, ");
            strSql.Append("aperson=@aperson ");
            strSql.Append(" where bcode=@bcode");
            SqlParameter[] parameters = {
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@abank", SqlDbType.NVarChar,30),
					new SqlParameter("@asubbank", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.NVarChar,100),
                    new SqlParameter("@aperson", SqlDbType.NVarChar,30),
					new SqlParameter("@bcode", SqlDbType.NVarChar,30)
					};
            parameters[0].Value = model.aname;
            parameters[1].Value = model.acode;
            parameters[2].Value = model.abank;
            parameters[3].Value = model.asubbank;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.aperson;
            parameters[8].Value = model.bcode;

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
            strSql.Append("delete from Sbk_CollectionAccount ");
            strSql.AppendFormat(" where 1=1 {0} ;", where);
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
        public  Sbk_CollectionAccount Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,bcode,aname,acode,abank,asubbank,maker,cdate,remark,aperson from Sbk_CollectionAccount ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sbk_CollectionAccount r = new Sbk_CollectionAccount();
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
        public  Sbk_CollectionAccount DataRowToModel(DataRow row)
        {
             Sbk_CollectionAccount model = new  Sbk_CollectionAccount();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["bcode"] != null)
                {
                    model.bcode = row["bcode"].ToString();
                }
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["abank"] != null)
                {
                    model.abank = row["abank"].ToString();
                }
                if (row["asubbank"] != null)
                {
                    model.asubbank = row["asubbank"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["aperson"] != null)
                {
                    model.aperson = row["aperson"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sbk_CollectionAccount> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,bcode,aname,acode,abank,asubbank,maker,cdate,remark,aperson ");
            strSql.Append(" FROM Sbk_CollectionAccount ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sbk_CollectionAccount> r = new List<Sbk_CollectionAccount>();
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
            sql = "select isnull(max(bcode),0) as n from Sbk_CollectionAccount ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
