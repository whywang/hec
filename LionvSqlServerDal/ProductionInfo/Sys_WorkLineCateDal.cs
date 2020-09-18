using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using System.Data.SqlClient;
using LionvModel.ProductionInfo;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
   public class Sys_WorkLineCateDal:ISys_WorkLineCateDal
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_WorkLineCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_WorkLineCate(");
            strSql.Append("wcname,wccode)");
            strSql.Append(" values (");
            strSql.Append("@wcname,@wccode)");
            SqlParameter[] parameters = {
					new SqlParameter("@wcname", SqlDbType.NVarChar,30),
					new SqlParameter("@wccode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.wcname;
            parameters[1].Value = model.wccode;

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
        public bool Update(Sys_WorkLineCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_WorkLineCate set ");
            strSql.Append("wcname=@wcname");
            strSql.Append(" where wccode=@wccode");
            SqlParameter[] parameters = {
					new SqlParameter("@wcname", SqlDbType.NVarChar,30),
					new SqlParameter("@wccode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.wcname;
            parameters[1].Value = model.wccode;

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
        public bool Delete(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_WorkLineCate ");
            strSql.AppendFormat(" where wccode='{0}';", where);
            strSql.Append("delete from Sys_WorkLine ");
            strSql.AppendFormat(" where wccode='{0}';", where);
            strSql.Append("delete from Sys_RInventoryWorkLine ");
            strSql.AppendFormat(" where wccode='{0}';", where);
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
        public Sys_WorkLineCate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wcname,wccode from Sys_WorkLineCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_WorkLineCate r = new Sys_WorkLineCate();
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
        public Sys_WorkLineCate DataRowToModel(DataRow row)
        {
            Sys_WorkLineCate model = new Sys_WorkLineCate();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["wcname"] != null)
                {
                    model.wcname = row["wcname"].ToString();
                }
                if (row["wccode"] != null)
                {
                    model.wccode = row["wccode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_WorkLineCate> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wcname,wccode ");
            strSql.Append(" FROM Sys_WorkLineCate ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_WorkLineCate> r = new List<Sys_WorkLineCate>();
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
            sql = "select isnull(max(convert(int, wccode)),0) as n from Sys_WorkLineCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetWorkLine(string wccode, string icode, string[] pcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventoryWorkLine ");
            strSql.AppendFormat(" where wccode='{0}' and icode='{1}';", wccode, icode);
            for (int i = 0; i < pcode.Length; i++)
            {
                strSql.AppendFormat(" insert into Sys_RInventoryWorkLine ( icode , pcode , wccode )values ('{0}','{1}','{2}');", icode, pcode[i],wccode);
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
        public bool ReSetWorkLine(string wccode, string icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventoryWorkLine ");
            strSql.AppendFormat(" where wccode='{0}' and icode='{1}';", wccode, icode);
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
        public string GetWorkLine(string wccode, string icode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pcode");
            strSql.Append(" FROM Sys_RInventoryWorkLine ");
            strSql.AppendFormat(" where  wccode='{0}' and icode='{1}'", wccode, icode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["pcode"].ToString() + ";";
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
