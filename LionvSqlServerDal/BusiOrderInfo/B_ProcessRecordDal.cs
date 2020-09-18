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
   public class B_ProcessRecordDal : IB_ProcessRecordDal
    {
        #region  BasicMethod

 

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_ProcessRecord");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
  
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_ProcessRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_ProcessRecord(");
            strSql.Append("id,sid,pname,pcode,bdate,edate,state,ptype,costtime,maker)");
            strSql.Append(" values (");
            strSql.Append("@id,@sid,@pname,@pcode,@bdate,@edate,@state,@ptype,@costtime,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,20),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@edate", SqlDbType.DateTime),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@costtime", SqlDbType.Float,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.pcode;
            parameters[4].Value = model.bdate;
            parameters[5].Value = model.edate;
            parameters[6].Value = model.state;
            parameters[7].Value = model.ptype;
            parameters[8].Value = model.costtime;
            parameters[9].Value = model.maker;
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
        public bool Update( B_ProcessRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_ProcessRecord set ");
            strSql.Append("sid=@sid,");
            strSql.Append("pname=@pname,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("bdate=@bdate,");
            strSql.Append("edate=@edate,");
            strSql.Append("state=@state,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("costtime=@costtime,");
            strSql.Append("maker=@maker");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,20),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@edate", SqlDbType.DateTime),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@costtime", SqlDbType.Float,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.pname;
            parameters[2].Value = model.pcode;
            parameters[3].Value = model.bdate;
            parameters[4].Value = model.edate;
            parameters[5].Value = model.state;
            parameters[6].Value = model.ptype;
            parameters[7].Value = model.costtime;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.id;
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
            strSql.AppendFormat("delete from B_ProcessRecord where 1=1 {0}", where);
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
        public  B_ProcessRecord Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,pname,pcode,bdate,edate,state,ptype,costtime,maker from B_ProcessRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_ProcessRecord r = new B_ProcessRecord();
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
        public  B_ProcessRecord DataRowToModel(DataRow row)
        {
            B_ProcessRecord model = new  B_ProcessRecord();
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
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["bdate"] != null && row["bdate"].ToString() != "")
                {
                    model.bdate =  row["bdate"].ToString( );
                }
                if (row["edate"] != null && row["edate"].ToString() != "")
                {
                    model.edate = row["edate"].ToString( );
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["costtime"] != null && row["costtime"].ToString() != "")
                {
                    model.costtime = decimal.Parse(row["costtime"].ToString());
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
        public List<B_ProcessRecord> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,pname,pcode,bdate,edate,state,ptype,costtime,maker ");
            strSql.Append(" FROM B_ProcessRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_ProcessRecord> r = new List<B_ProcessRecord>();
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
