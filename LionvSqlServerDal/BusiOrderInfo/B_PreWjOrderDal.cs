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
    public class B_PreWjOrderDal:IB_PreWjOrderDal
    {
        #region  BasicMethod
         

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_PreWjOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_PreWjOrder(");
            strSql.Append("sid,wjcode,e_city,remark,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@sid,@wjcode,@e_city,@remark,@cdate,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@wjcode", SqlDbType.NVarChar,50),
					new SqlParameter("@e_city", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.wjcode;
            parameters[2].Value = model.e_city;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.maker;
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
        public bool Update(B_PreWjOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_PreWjOrder set ");
            strSql.Append("wjcode=@wjcode,");
            strSql.Append("e_city=@e_city,");
            strSql.Append("remark=@remark,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@wjcode", SqlDbType.NVarChar,50),
					new SqlParameter("@e_city", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.wjcode;
            parameters[1].Value = model.e_city;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.id;
            parameters[6].Value = model.sid;
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
            strSql.AppendFormat("delete from B_PreWjOrder where 1=1 {0}", where);
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
        public B_PreWjOrder Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,wjcode,e_city,remark,cdate,maker from B_PreWjOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_PreWjOrder r = new B_PreWjOrder();
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
        public B_PreWjOrder DataRowToModel(DataRow row)
        {
            B_PreWjOrder model = new B_PreWjOrder();
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
                if (row["wjcode"] != null)
                {
                    model.wjcode = row["wjcode"].ToString();
                }
                if (row["e_city"] != null)
                {
                    model.e_city = row["e_city"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
            }
            return model;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_PreWjOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #endregion  ExtensionMethod
    }
}
