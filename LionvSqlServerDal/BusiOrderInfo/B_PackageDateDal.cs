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
    public class B_PackageDateDal : IB_PackageDateDal
    {
        #region  BasicMethod
        private bool CheckIExst(string bsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select count(1) as n from  B_PackageDate where bsid='{0}'",bsid);
            bool r=SqlHelp.isExist(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString());
            return r;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_PackageDate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_PackageDate(");
            strSql.Append("sid,bsid)");
            strSql.Append(" values (");
            strSql.Append("@sid,@bsid)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@bsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.bsid;

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
        public bool Update(B_PackageDate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_PackageDate set ");
            strSql.Append("sid=@sid,");
            strSql.Append("bdate=@bdate,");
            strSql.Append("insdate=@insdate,");
            strSql.Append("outsdate=@outsdate,");
            strSql.Append("incdate=@incdate,");
            strSql.Append("outcdate=@outcdate");
            strSql.Append(" where bsid=@bsid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@insdate", SqlDbType.DateTime),
					new SqlParameter("@outsdate", SqlDbType.DateTime),
					new SqlParameter("@incdate", SqlDbType.DateTime),
					new SqlParameter("@outcdate", SqlDbType.DateTime),
					new SqlParameter("@bsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.bdate;
            parameters[2].Value = model.insdate;
            parameters[3].Value = model.outsdate;
            parameters[4].Value = model.incdate;
            parameters[5].Value = model.outcdate;
            parameters[6].Value = model.bsid;

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
            strSql.AppendFormat("delete from B_PackageDate where 1=1 {0}", where);
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
        public B_PackageDate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,bsid,bdate,insdate,outsdate,incdate,outcdate from B_PackageDate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_PackageDate r = new B_PackageDate();
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
        public B_PackageDate DataRowToModel(DataRow row)
        {
            B_PackageDate model = new B_PackageDate();
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
                if (row["bsid"] != null)
                {
                    model.bsid = row["bsid"].ToString();
                }
                if (row["bdate"] != null && row["bdate"].ToString() != "")
                {
                    model.bdate = row["bdate"].ToString() ;
                }
                if (row["insdate"] != null && row["insdate"].ToString() != "")
                {
                    model.insdate = row["insdate"].ToString( );
                }
                if (row["outsdate"] != null && row["outsdate"].ToString() != "")
                {
                    model.outsdate =  row["outsdate"].ToString( );
                }
                if (row["incdate"] != null && row["incdate"].ToString() != "")
                {
                    model.incdate = row["incdate"].ToString() ;
                }
                if (row["outcdate"] != null && row["outcdate"].ToString() != "")
                {
                    model.outcdate =  row["outcdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_PackageDate> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,bsid,bdate,insdate,outsdate,incdate,outcdate ");
            strSql.Append(" FROM B_PackageDate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_PackageDate> r = new List<B_PackageDate>();
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
        #region//更新包日期
        public bool UpPackageState(string sid,string bsid, string v)
        {
            bool r = false;
            if (CheckIExst(bsid))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update B_PackageDate set {0}='{1}' where bsid='{2}'",v,DateTime.Now.ToString(),bsid);
                if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
                {
                    r = true;
                }
            }
            else
            {
                B_PackageDate b =new B_PackageDate ();
                b.sid=sid;
                b.bsid=bsid;
                if (Add(b) > 0)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.AppendFormat("update B_PackageDate set {0}='{1}' where bsid='{2}'",v,DateTime.Now.ToString(),bsid);
                    SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
                 
                    r = true;
                }
                else
                {
                    r = false;
                }
            } 
            return r;
        }
        #endregion
        #region//更新订单包日期
        public bool UpPackageState(string sid, string v)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update B_PackageDate set {0}='{1}' where sid='{2}'", v, DateTime.Now.ToString(), sid);
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            else
            {
                r = false;
            }
            return r;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
