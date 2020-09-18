using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_SetMealProductionDal : ISys_SetMealProductionDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_SetMealProduction");
            strSql.AppendFormat(" where  1=1 {0}",where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_SetMealProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SetMealProduction(");
            strSql.Append("tcname,tccode,tcplb,tcblbcode,tcplnum,tcpnum,maker,cdate,tcpxz)");
            strSql.Append(" values (");
            strSql.Append("@tcname,@tccode,@tcplb,@tcblbcode,@tcplnum,@tcpnum,@maker,@cdate,@tcpxz)");
            SqlParameter[] parameters = {
					new SqlParameter("@tcname", SqlDbType.NVarChar,30),
					new SqlParameter("@tccode", SqlDbType.NVarChar,30),
					new SqlParameter("@tcplb", SqlDbType.NVarChar,30),
					new SqlParameter("@tcblbcode", SqlDbType.NVarChar,30),
                    new SqlParameter("@tcplnum", SqlDbType.Int,4),
					new SqlParameter("@tcpnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tcpxz", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.tcname;
            parameters[1].Value = model.tccode;
            parameters[2].Value = model.tcplb;
            parameters[3].Value = model.tcblbcode;
            parameters[4].Value = model.tcplnum;
            parameters[5].Value = model.tcpnum;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.tcpxz;
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
        public bool Update( Sys_SetMealProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SetMealProduction set ");
            strSql.Append("tcname=@tcname,");
            strSql.Append("tccode=@tccode,");
            strSql.Append("tcplb=@tcplb,");
            strSql.Append("tcplnum=@tcplnum,");
            strSql.Append("tcpnum=@tcpnum,");
            strSql.Append("maker=@maker,");
            strSql.Append("tcpxz=@tcpxz,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tcblbcode=@tcblbcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tcname", SqlDbType.NVarChar,30),
					new SqlParameter("@tccode", SqlDbType.NVarChar,30),
					new SqlParameter("@tcplb", SqlDbType.NVarChar,30),
                    new SqlParameter("@tcplnum", SqlDbType.Int,4),
					new SqlParameter("@tcpnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
                    new SqlParameter("@tcpxz", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tcblbcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tcname;
            parameters[1].Value = model.tccode;
            parameters[2].Value = model.tcplb;
            parameters[3].Value = model.tcplnum;
            parameters[4].Value = model.tcpnum;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.tcpxz;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.tcblbcode;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string tcblbcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_SetMealProduction ");
            strSql.Append(" where tcblbcode=@tcblbcode ");
            SqlParameter[] parameters = {
					new SqlParameter("@tcblbcode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = tcblbcode;

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
        /// 得到一个对象实体
        /// </summary>
        public  Sys_SetMealProduction Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tcname,tccode,tcplb,tcblbcode,tcpnum,tcplnum,tcpxz,maker,cdate from Sys_SetMealProduction ");
            strSql.AppendFormat(" where 1=1 {0}",where);
             Sys_SetMealProduction r = new  Sys_SetMealProduction();
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
        public  Sys_SetMealProduction DataRowToModel(DataRow row)
        {
             Sys_SetMealProduction model = new  Sys_SetMealProduction();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tcname"] != null)
                {
                    model.tcname = row["tcname"].ToString();
                }
                if (row["tccode"] != null)
                {
                    model.tccode = row["tccode"].ToString();
                }
                if (row["tcplb"] != null)
                {
                    model.tcplb = row["tcplb"].ToString();
                }
                if (row["tcblbcode"] != null)
                {
                    model.tcblbcode = row["tcblbcode"].ToString();
                }
                if (row["tcpnum"] != null && row["tcpnum"].ToString() != "")
                {
                    model.tcpnum = int.Parse(row["tcpnum"].ToString());
                }
                if (row["tcplnum"] != null && row["tcplnum"].ToString() != "")
                {
                    model.tcplnum = int.Parse(row["tcplnum"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["tcpxz"] != null)
                {
                    model.tcpxz = row["tcpxz"].ToString();
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
        public List<Sys_SetMealProduction> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tcname,tccode,tcplb,tcblbcode,tcpnum,tcplnum,tcpxz,maker,cdate ");
            strSql.Append(" FROM Sys_SetMealProduction ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_SetMealProduction> r = new List<Sys_SetMealProduction>();
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
            string sql = "";
            sql = "select isnull(max(tcblbcode),0) as n from Sys_SetMealProduction  ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetSmProductin(string tcv,string iv,string []pv)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventorySetMeal where tcpcode='{0}' and icode='{1}'; ",tcv,iv);
            if (pv.Length > 0)
            {
                for (int i = 0; i < pv.Length; i++)
                {
                    strSql.AppendFormat(" insert into Sys_RInventorySetMeal  (tcpcode,icode,pcode) values ('{0}','{1}','{2}'); ", tcv, iv, pv[i]);
                }
                object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
                if (obj == null)
                {
                    r=false;
                }
                else
                {
                    r=true;
                }
            }
            else
            {
                r = false;
            }
            return r;
        }
        public bool ReSetSmProductin(string tcv, string iv)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventorySetMeal where tcpcode='{0}' and icode='{1}'; ", tcv, iv);
            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (obj == null)
            {
                r = false;
            }
            else
            {
                r = true;
            }
          
            return r;
        }
        public string GetSmProductin(string tcv, string iv)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_RInventorySetMeal ");
            strSql.AppendFormat(" where tcpcode='{0}' and icode='{1}'", tcv,iv);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                     r=r+dr["pcode"].ToString()+";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }

        public bool SetSmProductinAdd(string tcv, string iv, string[] pv)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventorySetMealAdd where tcpcode='{0}' and icode='{1}'; ", tcv, iv);
            if (pv.Length > 0)
            {
                for (int i = 0; i < pv.Length; i++)
                {
                    strSql.AppendFormat(" insert into Sys_RInventorySetMealAdd  (tcpcode,icode,pcode) values ('{0}','{1}','{2}'); ", tcv, iv, pv[i]);
                }
                object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
                if (obj == null)
                {
                    r = false;
                }
                else
                {
                    r = true;
                }
            }
            else
            {
                r = false;
            }
            return r;
        }
        public bool ReSetSmProductinAdd(string tcv, string iv)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventorySetMealAdd where tcpcode='{0}' and icode='{1}'; ", tcv, iv);
            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (obj == null)
            {
                r = false;
            }
            else
            {
                r = true;
            }

            return r;
        }
        public string GetSmProductinAdd(string tcv, string iv)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_RInventorySetMealAdd ");
            strSql.AppendFormat(" where tcpcode='{0}' and icode='{1}'", tcv, iv);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r =r+ dr["pcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
