using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_yyFixOrderRecordDal : IB_yyFixOrderRecordDal
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_yyFixOrderRecord");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
           
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_yyFixOrderRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_yyFixOrderRecord(");
            strSql.Append("sid,fsid,fixer,ydate,ps,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@fsid,@fixer,@ydate,@ps,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@fsid", SqlDbType.NVarChar,50),
					new SqlParameter("@fixer", SqlDbType.NVarChar,20),
					new SqlParameter("@ydate", SqlDbType.DateTime,3),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.fsid;
            parameters[2].Value = model.fixer;
            parameters[3].Value = model.ydate;
            parameters[4].Value = model.ps;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update( B_yyFixOrderRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_yyFixOrderRecord set ");
            strSql.Append("id=@id,");
            strSql.Append("sid=@sid,");
            strSql.Append("fixer=@fixer,");
            strSql.Append("ydate=@ydate,");
            strSql.Append("ps=@ps,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where fsid=@fsid ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@fixer", SqlDbType.NVarChar,20),
					new SqlParameter("@ydate", SqlDbType.DateTime,3),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@fsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.fixer;
            parameters[3].Value = model.ydate;
            parameters[4].Value = model.ps;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.fsid;

            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
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
            strSql.AppendFormat("delete from B_yyFixOrderRecord where 1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
       


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  B_yyFixOrderRecord Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,fsid,fixer,ydate,ps,maker,cdate from B_yyFixOrderRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_yyFixOrderRecord r = new B_yyFixOrderRecord();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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
        public  B_yyFixOrderRecord DataRowToModel(DataRow row)
        {
            B_yyFixOrderRecord model = new  B_yyFixOrderRecord();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["fsid"] != null)
                {
                    model.fsid = row["fsid"].ToString();
                }
                if (row["fixer"] != null)
                {
                    model.fixer = row["fixer"].ToString();
                }
                if (row["ydate"] != null && row["ydate"].ToString() != "")
                {
                    model.ydate = row["ydate"].ToString( );
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
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
        public List<B_yyFixOrderRecord> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,fsid,fixer,ydate,ps,maker,cdate ");
            strSql.Append(" FROM B_yyFixOrderRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_yyFixOrderRecord> r = new List<B_yyFixOrderRecord>();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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

        #endregion  ExtensionMethod
    }
}
