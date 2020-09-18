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
    public class B_InhousePackageDal : IB_InhousePackageDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_InhousePackage");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_InhousePackage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_InhousePackage(");
            strSql.Append("sid,isid,pid,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@isid,@bsid,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@isid", SqlDbType.NVarChar,50),
					new SqlParameter("@pid", SqlDbType.Int),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.isid;
            parameters[2].Value = model.pid;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
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
        public bool Update(B_InhousePackage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_InhousePackage set ");
            strSql.Append("sid=@sid,");
            strSql.Append("isid=@isid,");
            strSql.Append("pid=@pid,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@isid", SqlDbType.NVarChar,50),
					new SqlParameter("@pid", SqlDbType.Int),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.isid;
            parameters[2].Value = model.pid;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.id;
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
            strSql.AppendFormat("delete from B_InhousePackage where 1=1 {0}", where);
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
        public B_InhousePackage Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,isid,pid,maker,cdate from B_InhousePackage ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_InhousePackage r = new B_InhousePackage();
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
        private B_InhousePackage DataRowToModel(DataRow row)
        {
            B_InhousePackage model = new B_InhousePackage();
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
                if (row["isid"] != null)
                {
                    model.isid = row["isid"].ToString();
                }
                if (row["pid"] != null)
                {
                    model.pid =Convert.ToInt32( row["pid"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_InhousePackage> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,isid,pid,maker,cdate ");
            strSql.Append(" FROM B_InhousePackage ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_InhousePackage> r = new List<B_InhousePackage>();
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
