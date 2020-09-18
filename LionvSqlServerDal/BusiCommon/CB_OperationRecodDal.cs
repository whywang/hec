using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.BusiCommon
{
    public  class CB_OperationRecodDal : ICB_OperationRecodDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CB_OperationRecod");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_OperationRecod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_OperationRecod(");
            strSql.Append("sid,maker,ps,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@maker,@ps,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@ps", SqlDbType.NVarChar,200),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.maker;
            parameters[2].Value = model.ps;
            parameters[3].Value = model.cdate;
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
        public bool Update( CB_OperationRecod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_OperationRecod set ");
            strSql.Append("sid=@sid,");
            strSql.Append("maker=@maker,");
            strSql.Append("ps=@ps,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@ps", SqlDbType.NVarChar,200),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.maker;
            parameters[2].Value = model.ps;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.id;
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
            strSql.AppendFormat("delete from CB_OperationRecod where 1=1 {0}", where);
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
        public  CB_OperationRecod Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,maker,ps,cdate from CB_OperationRecod ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_OperationRecod r = new CB_OperationRecod();
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
        public CB_OperationRecod DataRowToModel(DataRow row)
        {
             CB_OperationRecod model = new  CB_OperationRecod();
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
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
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
        public List<CB_OperationRecod> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,maker,ps,cdate ");
            strSql.Append(" FROM CB_OperationRecod ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<CB_OperationRecod> r = new List<CB_OperationRecod>();
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
