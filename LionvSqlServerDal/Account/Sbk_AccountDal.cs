using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvModel.Account;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.Account
{
   public class Sbk_AccountDal : ISbk_AccountDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sbk_Account");
            strSql.AppendFormat(" where 1=1 {0}",where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sbk_Account model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sbk_Account(");
            strSql.Append("acode,aname,dname,dcode,manager,telephone,atype,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@acode,@aname,@dname,@dcode,@manager,@telephone,@atype,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@manager", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,50),
					new SqlParameter("@atype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.acode;
            parameters[1].Value = model.aname;
            parameters[2].Value = model.dname;
            parameters[3].Value = model.dcode;
            parameters[4].Value = model.manager;
            parameters[5].Value = model.telephone;
            parameters[6].Value = model.atype;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;

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
        public bool Update( Sbk_Account model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sbk_Account set ");
            strSql.Append("aname=@aname,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("manager=@manager,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where acode=@acode");
            SqlParameter[] parameters = {
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@manager", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@acode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.aname;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.manager;
            parameters[4].Value = model.telephone;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.acode;

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
            strSql.Append("delete from Sbk_Account ");
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
        public  Sbk_Account Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,acode,aname,dname,dcode,manager,telephone,atype,credit,ucredit,umoney,maker,cdate from Sbk_Account ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sbk_Account r = new Sbk_Account();
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
        public  Sbk_Account DataRowToModel(DataRow row)
        {
             Sbk_Account model = new  Sbk_Account();
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
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["manager"] != null)
                {
                    model.manager = row["manager"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["atype"] != null)
                {
                    model.atype = row["atype"].ToString();
                }
                if (row["credit"] != null && row["credit"].ToString() != "")
                {
                    model.credit = decimal.Parse(row["credit"].ToString());
                }
                if (row["ucredit"] != null && row["ucredit"].ToString() != "")
                {
                    model.ucredit = decimal.Parse(row["ucredit"].ToString());
                }
                if (row["umoney"] != null && row["umoney"].ToString() != "")
                {
                    model.umoney = decimal.Parse(row["umoney"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sbk_Account> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,acode,aname,dname,dcode,manager,telephone,atype,credit,ucredit,umoney,maker,cdate ");
            strSql.Append(" FROM Sbk_Account ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sbk_Account> r = new List<Sbk_Account>();
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
            sql = "select isnull(max(acode),0) as n from Sbk_Account ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetCredit(string acode, decimal cnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update Sbk_Account set credit=credit+{0},ucredit=ucredit+{0} ", cnum);
            strSql.AppendFormat(" where acode='{0}' ;", acode);
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
        #endregion  ExtensionMethod
    }
}
