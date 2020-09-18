using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_PackageInSapDal : IB_PackageInSapDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_PackageInSap model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_PackageInSap(");
            strSql.Append("bid,instore,outstore)");
            strSql.Append(" values (");
            strSql.Append("@bid,@instore,@outstore)");
            SqlParameter[] parameters = {
					new SqlParameter("@bid", SqlDbType.Int,4),
					new SqlParameter("@instore", SqlDbType.Int,4),
					new SqlParameter("@outstore", SqlDbType.Int,4)};
            parameters[0].Value = model.bid;
            parameters[1].Value = model.instore;
            parameters[2].Value = model.outstore;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters); ;
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
        public bool Update(B_PackageInSap model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_PackageInSap set ");
            strSql.Append("instore=@instore,");
            strSql.Append("outstore=@outstore");
            strSql.Append(" where bid=@bid");
            SqlParameter[] parameters = {
					new SqlParameter("@instore", SqlDbType.Int,4),
					new SqlParameter("@outstore", SqlDbType.Int,4),
					new SqlParameter("@bid", SqlDbType.Int,4)};
            parameters[0].Value = model.bid;
            parameters[1].Value = model.instore;
            parameters[2].Value = model.outstore;
            parameters[3].Value = model.bid;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_PackageInSap ");
            strSql.AppendFormat(" where 1=1 {0}",where);
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
        public B_PackageInSap Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,bid,instore,outstore from B_PackageInSap ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            B_PackageInSap r = new B_PackageInSap();
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
        public B_PackageInSap DataRowToModel(DataRow row)
        {
            B_PackageInSap model = new B_PackageInSap();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["bid"] != null && row["bid"].ToString() != "")
                {
                    model.bid = int.Parse(row["bid"].ToString());
                }
                if (row["instore"] != null && row["instore"].ToString() != "")
                {
                    model.instore = int.Parse(row["instore"].ToString());
                }
                if (row["outstore"] != null && row["outstore"].ToString() != "")
                {
                    model.outstore = int.Parse(row["outstore"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_PackageInSap> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,bid,instore,outstore ");
            strSql.Append(" FROM B_PackageInSap ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_PackageInSap> r = new List<B_PackageInSap>();
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
        public DataTable QueryViewList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage(" View_B_PackageInSap ", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
            if (dt != null)
            {
                r = dt;
            }
            else
            {
                r = null;
            }
            return r;
        }
       public bool UpPackageState(string[] idarr, string field, int fvalue)
        {
            StringBuilder strSql = new StringBuilder();
            InsertId(idarr);
            for (int i = 0; i < idarr.Length; i++)
            {
                strSql.AppendFormat(" update B_PackageInSap set {0}={1} where bid={2}", field, fvalue,Convert.ToInt32(idarr[i].Replace("B", "")));
            }
            if (strSql.ToString() != "")
            {
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
            else
            {
                return false;
            }
        }
       private void InsertId(string[] idarr)
       {
           for (int i = 0; i < idarr.Length; i++)
           {
               try
               {
                   StringBuilder strSql = new StringBuilder();
                   strSql.AppendFormat(" insert into B_PackageInSap (bid) values({0})", Convert.ToInt32(idarr[i].Replace("B", "")));
                   SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
               }
               catch
               {
                   continue;
               }
           }
       }
        #endregion  ExtensionMethod
    }
}
