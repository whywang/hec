using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_YySendDal : IB_YySendDal
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_YySend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_YySend(");
            strSql.Append("sid,sperson,pdate,pbz,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@sid,@sperson,@pdate,@pbz,@cdate,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@sperson", SqlDbType.NVarChar,30),
					new SqlParameter("@pdate", SqlDbType.DateTime),
					new SqlParameter("@pbz", SqlDbType.NVarChar,100),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.sperson;
            parameters[2].Value = model.pdate;
            parameters[3].Value = model.pbz;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.maker;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update( B_YySend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_YySend set ");
            strSql.Append("sid=@sid,");
            strSql.Append("sperson=@sperson,");
            strSql.Append("pdate=@pdate,");
            strSql.Append("pbz=@pbz,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@sperson", SqlDbType.NVarChar,30),
					new SqlParameter("@pdate", SqlDbType.DateTime),
					new SqlParameter("@pbz", SqlDbType.NVarChar,100),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.sperson;
            parameters[2].Value = model.pdate;
            parameters[3].Value = model.pbz;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.id;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
            strSql.AppendFormat("delete from B_YySend where 1=1 {0}", where);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
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
        public  B_YySend Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,sperson,pdate,pbz,cdate,maker from B_YySend ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_YySend r = new B_YySend();
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
        public  B_YySend DataRowToModel(DataRow row)
        {
             B_YySend model = new  B_YySend();
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
                if (row["sperson"] != null)
                {
                    model.sperson = row["sperson"].ToString();
                }
                if (row["pdate"] != null && row["pdate"].ToString() != "")
                {
                    model.pdate =  row["pdate"].ToString( );
                }
                if (row["pbz"] != null)
                {
                    model.pbz = row["pbz"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_YySend> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,sperson,pdate,pbz,cdate,maker ");
            strSql.Append(" FROM B_YySend ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_YySend> r = new List<B_YySend>();
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
