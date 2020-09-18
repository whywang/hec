using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using System.Data;
using LionvCommon;
using LionvModel.Account;
using System.Data.SqlClient;

namespace LionvSqlServerDal.Account
{
    public class Sbk_PaymentAccountDal : ISbk_PaymentAccountDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sbk_PaymentAccount");
            strSql.AppendFormat(" where 1=1 {0}", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sbk_PaymentAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sbk_PaymentAccount(");
            strSql.Append("sacode,pname,pcode,pbank,pperson,pbcode,telephone,dcode,maker,cdate,saname)");
            strSql.Append(" values (");
            strSql.Append("@sacode,@pname,@pcode,@pbank,@pperson,@pbcode,@telephone,@dcode,@maker,@cdate,@saname)");
    
            SqlParameter[] parameters = {
					new SqlParameter("@sacode", SqlDbType.NVarChar,30),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pbank", SqlDbType.NVarChar,30),
					new SqlParameter("@pperson", SqlDbType.NVarChar,30),
					new SqlParameter("@pbcode", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@saname", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sacode;
            parameters[1].Value = model.pname;
            parameters[2].Value = model.pcode;
            parameters[3].Value = model.pbank;
            parameters[4].Value = model.pperson;
            parameters[5].Value = model.pbcode;
            parameters[6].Value = model.telephone;
            parameters[7].Value = model.dcode;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.cdate;
            parameters[10].Value = model.saname;
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
        public bool Update( Sbk_PaymentAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sbk_PaymentAccount set ");
            strSql.Append("sacode=@sacode,");
            strSql.Append("pname=@pname,");
            strSql.Append("pbank=@pbank,");
            strSql.Append("pperson=@pperson,");
            strSql.Append("pbcode=@pbcode,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("saname=@saname,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where pcode=@pcode");
            SqlParameter[] parameters = {
					new SqlParameter("@sacode", SqlDbType.NVarChar,30),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pbank", SqlDbType.NVarChar,30),
					new SqlParameter("@pperson", SqlDbType.NVarChar,30),
					new SqlParameter("@pbcode", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@saname", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sacode;
            parameters[1].Value = model.pname;
            parameters[2].Value = model.pbank;
            parameters[3].Value = model.pperson;
            parameters[4].Value = model.pbcode;
            parameters[5].Value = model.telephone;
            parameters[6].Value = model.dcode;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.saname;
            parameters[9].Value = model.cdate;
            parameters[10].Value = model.pcode;

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
        /// 批量删除数据
        /// </summary>
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sbk_PaymentAccount ");
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
        public  Sbk_PaymentAccount Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sacode,saname,pname,pcode,pbank,pperson,pbcode,telephone,dcode,maker,cdate from Sbk_PaymentAccount ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sbk_PaymentAccount r = new Sbk_PaymentAccount();
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
        public  Sbk_PaymentAccount DataRowToModel(DataRow row)
        {
             Sbk_PaymentAccount model = new  Sbk_PaymentAccount();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sacode"] != null)
                {
                    model.sacode = row["sacode"].ToString();
                }
                if (row["saname"] != null)
                {
                    model.saname = row["saname"].ToString();
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["pbank"] != null)
                {
                    model.pbank = row["pbank"].ToString();
                }
                if (row["pperson"] != null)
                {
                    model.pperson = row["pperson"].ToString();
                }
                if (row["pbcode"] != null)
                {
                    model.pbcode = row["pbcode"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sbk_PaymentAccount> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sacode,saname,pname,pcode,pbank,pperson,pbcode,telephone,dcode,maker,cdate ");
            strSql.Append(" FROM Sbk_PaymentAccount ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sbk_PaymentAccount> r = new List<Sbk_PaymentAccount>();
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
            string sql = "select isnull(max(convert(int,pcode)),0) as n from Sbk_PaymentAccount ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
