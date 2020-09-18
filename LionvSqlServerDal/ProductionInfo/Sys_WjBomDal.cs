using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_WjBomDal : ISys_WjBomDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_WjBom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_WjBom(");
            strSql.Append("icode,bname,bcode,becode,bnum,cdate,bunit)");
            strSql.Append(" values (");
            strSql.Append("@icode,@bname,@bcode,@becode,@bnum,@cdate,@bunit)");
            SqlParameter[] parameters = {
					new SqlParameter("@icode", SqlDbType.NVarChar,20),
					new SqlParameter("@bname", SqlDbType.NVarChar,30),
					new SqlParameter("@bcode", SqlDbType.NVarChar,20),
					new SqlParameter("@becode", SqlDbType.NVarChar,20),
					new SqlParameter("@bnum", SqlDbType.Decimal,9),
                    new SqlParameter("@bprice", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@bunit", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.icode;
            parameters[1].Value = model.bname;
            parameters[2].Value = model.bcode;
            parameters[3].Value = model.becode;
            parameters[4].Value = model.bnum;
            parameters[5].Value = model.bprice;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.bunit;
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
        public bool Update( Sys_WjBom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_WjBom set ");
            strSql.Append("icode=@icode,");
            strSql.Append("bname=@bname,");
            strSql.Append("becode=@becode,");
            strSql.Append("bnum=@bnum,");
            strSql.Append("bprice=@bprice,");
            strSql.Append("bunit=@bunit,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where bcode=@bcode");
            SqlParameter[] parameters = {
					new SqlParameter("@icode", SqlDbType.NVarChar,20),
					new SqlParameter("@bname", SqlDbType.NVarChar,30),
					new SqlParameter("@becode", SqlDbType.NVarChar,20),
					new SqlParameter("@bnum", SqlDbType.Decimal,9),
                    new SqlParameter("@bprice", SqlDbType.Decimal,9),
                    new SqlParameter("@bunit", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@bcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.icode;
            parameters[1].Value = model.bname;
            parameters[2].Value = model.becode;
            parameters[3].Value = model.bnum;
            parameters[4].Value = model.bprice;
            parameters[5].Value = model.bunit;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.bcode;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters); ;
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
            strSql.Append("delete from Sys_WjBom ");
            strSql.AppendFormat(" where 1=1 {0} ",where);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
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
        public  Sys_WjBom Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,icode,bname,bcode,becode,bprice,bnum,cdate,bunit from Sys_WjBom ");
            strSql.AppendFormat(" where 1=1 {0}",where);
             Sys_WjBom r = new  Sys_WjBom();
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
        public  Sys_WjBom DataRowToModel(DataRow row)
        {
             Sys_WjBom model = new  Sys_WjBom();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["icode"] != null)
                {
                    model.icode = row["icode"].ToString();
                }
                if (row["bname"] != null)
                {
                    model.bname = row["bname"].ToString();
                }
                if (row["bcode"] != null)
                {
                    model.bcode = row["bcode"].ToString();
                }
                if (row["becode"] != null)
                {
                    model.becode = row["becode"].ToString();
                }
                if (row["bnum"] != null && row["bnum"].ToString() != "")
                {
                    model.bnum = decimal.Parse(row["bnum"].ToString());
                }
                if (row["bprice"] != null && row["bprice"].ToString() != "")
                {
                    model.bprice = decimal.Parse(row["bprice"].ToString());
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =row["cdate"].ToString();
                }
                if (row["bunit"] != null)
                {
                    model.bunit = row["bunit"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_WjBom> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,icode,bname,bcode,becode,bprice,bnum,cdate ,bunit");
            strSql.Append(" FROM Sys_WjBom ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_WjBom> r = new List<Sys_WjBom>();
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
        public int CreateCode( )
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int, bcode)),0) as n from Sys_WjBom ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetWjBom(string pcode, string[] bcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete  from  Sys_RWjProductionBom where pcode='{0}';",pcode);
            for (int i = 0; i < bcode.Length; i++)
            {
                strSql.AppendFormat(" insert into Sys_RWjProductionBom ( pcode,bcode) values ('{0}','{1}');", pcode,bcode[i]);
            }
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetWjBom(string pcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete  from  Sys_RWjProductionBom where pcode='{0}'", pcode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetWjBom(string pcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select bcode  from  Sys_RWjProductionBom where pcode='{0}'", pcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["bcode"].ToString() + ";";
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
