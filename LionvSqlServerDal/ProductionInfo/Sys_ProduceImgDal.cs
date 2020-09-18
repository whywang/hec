using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProduceImgDal : ISys_ProduceImgDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProduceImg");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ProduceImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProduceImg(");
            strSql.Append("iname,icode,iurl,ifurl,dcode)");
            strSql.Append(" values (");
            strSql.Append("@iname,@icode,@iurl,@ifurl,@dcode)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@iname", SqlDbType.NVarChar,20),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@iurl", SqlDbType.NVarChar,100),
                    new SqlParameter("@ifurl", SqlDbType.NVarChar,100),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.iname;
            parameters[1].Value = model.icode;
            parameters[2].Value = model.iurl;
            parameters[3].Value = model.ifurl;
            parameters[4].Value = model.dcode;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update( Sys_ProduceImg model)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            if (model.ifurl != "")
            {
                strSql.Append("update Sys_ProduceImg set ");
                strSql.Append("iname=@iname,");
                strSql.Append("ifurl=@ifurl");
                strSql.Append(" where icode=@icode");
                SqlParameter[] parameters = {
					new SqlParameter("@iname", SqlDbType.NVarChar,20),
					new SqlParameter("@ifurl", SqlDbType.NVarChar,100),
					new SqlParameter("@icode", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.iname;
                parameters[1].Value = model.ifurl;
                parameters[2].Value = model.icode;
                if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    r = true;
                }
            }
            if (model.iurl != "")
            {
                strSql.Append("update Sys_ProduceImg set ");
                strSql.Append("iname=@iname,");
                strSql.Append("iurl=@iurl");
                strSql.Append(" where icode=@icode");
                SqlParameter[] parameters = {
					new SqlParameter("@iname", SqlDbType.NVarChar,20),
					new SqlParameter("@iurl", SqlDbType.NVarChar,100),
					new SqlParameter("@icode", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.iname;
                parameters[1].Value = model.iurl;
                parameters[2].Value = model.icode;
                if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    r = true;
                }
            }
            return r;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string  where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProduceImg ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
             
        }
 

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  Sys_ProduceImg Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,iname,icode,iurl,ifurl from Sys_ProduceImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProduceImg r = new Sys_ProduceImg();
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
        public  Sys_ProduceImg DataRowToModel(DataRow row)
        {
            Sys_ProduceImg model = new  Sys_ProduceImg();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["iname"] != null)
                {
                    model.iname = row["iname"].ToString();
                }
                if (row["icode"] != null)
                {
                    model.icode = row["icode"].ToString();
                }
                if (row["iurl"] != null)
                {
                    model.iurl = row["iurl"].ToString();
                }
                if (row["ifurl"] != null)
                {
                    model.ifurl = row["ifurl"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProduceImg> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,iname,icode,iurl ,ifurl");
            strSql.AppendFormat(" FROM Sys_ProduceImg where 1=1 {0}", strWhere);
            List<Sys_ProduceImg> r = new List<Sys_ProduceImg>();
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
            sql = "select isnull(max(convert(int,icode)),0) as n from Sys_ProduceImg ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetProductionImg(string pcode, string icode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryImage where pcode like '{0}%';", pcode);
            sql.AppendFormat(" insert into Sys_RInventoryImage (pcode,icode) values ('{0}','{1}') ;", pcode, icode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetProductionImg(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryImage where pcode like '{0}%';", pcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetProductionImg(string pcode)
        {
            string r = "";
            r = LoodQuery(pcode);
            return r;
        }
        private string LoodQuery(string pcode)
        {
            string p = "";
            if (pcode.Length > 8)
            {

                string sql = "select icode from Sys_RInventoryImage where pcode='" + pcode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(pcode.Substring(0, pcode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
        #endregion  ExtensionMethod
    }
}
