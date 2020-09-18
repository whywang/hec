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
    public class B_OrderFacotoryDal : IB_OrderFacotoryDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_OrderFacotory");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_OrderFacotory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_OrderFacotory(");
            strSql.Append("sid,dname,dcode,fdate,overdate,otype,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@dname,@dcode,@fdate,@overdate,@otype,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@fdate", SqlDbType.DateTime),
					new SqlParameter("@overdate", SqlDbType.DateTime),
					new SqlParameter("@otype", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.fdate;
            parameters[4].Value = model.overdate;
            parameters[5].Value = model.otype;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
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
        public bool Update(B_OrderFacotory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_OrderFacotory set ");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("fdate=@fdate,");
            strSql.Append("overdate=@overdate,");
            strSql.Append("otype=@otype,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@fdate", SqlDbType.DateTime),
					new SqlParameter("@overdate", SqlDbType.DateTime),
					new SqlParameter("@otype", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@sid", SqlDbType.NVarChar,50),};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.fdate;
            parameters[3].Value = model.overdate;
            parameters[4].Value = model.otype;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.sid;
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
            strSql.AppendFormat("delete from B_OrderFacotory where 1=1 {0}", where);
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
        public B_OrderFacotory Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,dname,dcode,ddate,fdate,jdate,overdate,otype,maker,cdate from B_OrderFacotory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_OrderFacotory r = new B_OrderFacotory();
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
        public  B_OrderFacotory DataRowToModel(DataRow row)
        {
            B_OrderFacotory model = new  B_OrderFacotory();
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
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["ddate"] != null && row["ddate"].ToString() != "")
                {
                    model.ddate =  row["ddate"].ToString( );
                }
                if (row["fdate"] != null && row["fdate"].ToString() != "")
                {
                    model.fdate =  row["fdate"].ToString( );
                }
                if (row["jdate"] != null && row["jdate"].ToString() != "")
                {
                    model.jdate =  row["jdate"].ToString( );
                }
                if (row["overdate"] != null && row["overdate"].ToString() != "")
                {
                    model.overdate =  row["overdate"].ToString() ;
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_OrderFacotory> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,dname,dcode,ddate,fdate,jdate,overdate,otype,maker,cdate ");
            strSql.Append(" FROM B_OrderFacotory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_OrderFacotory> r = new List<B_OrderFacotory>();
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
