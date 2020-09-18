using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LionvModel.ProductionInfo;
using System.Data;
using LionvIDal.ProductionInfo;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_SetMealDal : ISys_SetMealDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_SetMeal");
            strSql.AppendFormat(" where  1=1 {0}", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_SetMeal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SetMeal(");
            strSql.Append("tcname,tccode,tcbdate,tcedate,bjprice,wbprice,cgprice,tcnum,tcarea,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@tcname,@tccode,@tcbdate,@tcedate,@bjprice,@wbprice,@cgprice,@tcnum,@tcarea,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@tcname", SqlDbType.NVarChar,30),
					new SqlParameter("@tccode", SqlDbType.NVarChar,30),
					new SqlParameter("@tcbdate", SqlDbType.DateTime),
					new SqlParameter("@tcedate", SqlDbType.DateTime),
					new SqlParameter("@bjprice", SqlDbType.Decimal,9),
					new SqlParameter("@wbprice", SqlDbType.Decimal,9),
					new SqlParameter("@cgprice", SqlDbType.Decimal,9),
					new SqlParameter("@tcnum", SqlDbType.Int,4),
					new SqlParameter("@tcarea", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.tcname;
            parameters[1].Value = model.tccode;
            parameters[2].Value = model.tcbdate;
            parameters[3].Value = model.tcedate;
            parameters[4].Value = model.bjprice;
            parameters[5].Value = model.wbprice;
            parameters[6].Value = model.cgprice;
            parameters[7].Value = model.tcnum;
            parameters[8].Value = model.tcarea;
            parameters[9].Value = model.maker;
            parameters[10].Value = model.cdate;

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
        public bool Update( Sys_SetMeal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SetMeal set ");
            strSql.Append("tcname=@tcname,");
            strSql.Append("tcbdate=@tcbdate,");
            strSql.Append("tcedate=@tcedate,");
            strSql.Append("bjprice=@bjprice,");
            strSql.Append("wbprice=@wbprice,");
            strSql.Append("cgprice=@cgprice,");
            strSql.Append("tcnum=@tcnum,");
            strSql.Append("tcarea=@tcarea,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tccode=@tccode");
            SqlParameter[] parameters = {
					new SqlParameter("@tcname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcbdate", SqlDbType.DateTime),
					new SqlParameter("@tcedate", SqlDbType.DateTime),
					new SqlParameter("@bjprice", SqlDbType.Decimal,9),
					new SqlParameter("@wbprice", SqlDbType.Decimal,9),
					new SqlParameter("@cgprice", SqlDbType.Decimal,9),
					new SqlParameter("@tcnum", SqlDbType.Int,4),
					new SqlParameter("@tcarea", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tccode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tcname;
            parameters[1].Value = model.tcbdate;
            parameters[2].Value = model.tcedate;
            parameters[3].Value = model.bjprice;
            parameters[4].Value = model.wbprice;
            parameters[5].Value = model.cgprice;
            parameters[6].Value = model.tcnum;
            parameters[7].Value = model.tcarea;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.cdate;
            parameters[10].Value = model.tccode;

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
        public bool Delete(string tccode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_SetMeal ");
            strSql.AppendFormat(" where tccode='{0}'; ",tccode);
            strSql.Append("delete from Sys_SetMealProduction ");
            strSql.AppendFormat(" where tccode='{0}'; ", tccode);
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
        public  Sys_SetMeal Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tcname,tccode,tcbdate,tcedate,bjprice,wbprice,cgprice,tcnum,tcarea,maker,cdate from Sys_SetMeal ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SetMeal r=new Sys_SetMeal ();
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
        public  Sys_SetMeal DataRowToModel(DataRow row)
        {
             Sys_SetMeal model = new  Sys_SetMeal();
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
                if (row["tcbdate"] != null && row["tcbdate"].ToString() != "")
                {
                    model.tcbdate =  row["tcbdate"].ToString() ;
                }
                if (row["tcedate"] != null && row["tcedate"].ToString() != "")
                {
                    model.tcedate = row["tcedate"].ToString( );
                }
                if (row["bjprice"] != null && row["bjprice"].ToString() != "")
                {
                    model.bjprice = decimal.Parse(row["bjprice"].ToString());
                }
                if (row["wbprice"] != null && row["wbprice"].ToString() != "")
                {
                    model.wbprice = decimal.Parse(row["wbprice"].ToString());
                }
                if (row["cgprice"] != null && row["cgprice"].ToString() != "")
                {
                    model.cgprice = decimal.Parse(row["cgprice"].ToString());
                }
                if (row["tcnum"] != null && row["tcnum"].ToString() != "")
                {
                    model.tcnum = int.Parse(row["tcnum"].ToString());
                }
                if (row["tcarea"] != null)
                {
                    model.tcarea = row["tcarea"].ToString();
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
        public List<Sys_SetMeal> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tcname,tccode,tcbdate,tcedate,bjprice,wbprice,cgprice,tcnum,tcarea,maker,cdate ");
            strSql.Append(" FROM Sys_SetMeal ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_SetMeal> r = new List<Sys_SetMeal>();
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
            sql = "select isnull(max(tccode),0) as n from Sys_SetMeal  ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
