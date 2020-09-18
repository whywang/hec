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
   public class Sys_SpecialProductionDal : ISys_SpecialProductionDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_SpecialProduction");
            strSql.AppendFormat(" where 1=1 {0} ",where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_SpecialProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SpecialProduction(");
            strSql.Append("tjname,tjcode,tjarea,ctype,bjprice,wfprice,bdate,edate,econdition,maker,acode,aname,cdate)");
            strSql.Append(" values (");
            strSql.Append("@tjname,@tjcode,@tjarea,@ctype,@bjprice,@wfprice,@bdate,@edate,@econdition,@maker,@acode,@aname,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@tjname", SqlDbType.NVarChar,30),
					new SqlParameter("@tjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tjarea", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,10),
					new SqlParameter("@bjprice", SqlDbType.Decimal,9),
					new SqlParameter("@wfprice", SqlDbType.Decimal,9),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@edate", SqlDbType.DateTime),
					new SqlParameter("@econdition", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.tjname;
            parameters[1].Value = model.tjcode;
            parameters[2].Value = model.tjarea;
            parameters[3].Value = model.ctype;
            parameters[4].Value = model.bjprice;
            parameters[5].Value = model.wfprice;
            parameters[6].Value = model.bdate;
            parameters[7].Value = model.edate;
            parameters[8].Value = model.econdition;
            parameters[9].Value = model.maker;
            parameters[10].Value = model.acode;
            parameters[11].Value = model.aname;
            parameters[12].Value = model.cdate;

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
        public bool Update( Sys_SpecialProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SpecialProduction set ");
            strSql.Append("tjname=@tjname,");
            strSql.Append("tjarea=@tjarea,");
            strSql.Append("ctype=@ctype,");
            strSql.Append("bjprice=@bjprice,");
            strSql.Append("wfprice=@wfprice,");
            strSql.Append("bdate=@bdate,");
            strSql.Append("edate=@edate,");
            strSql.Append("econdition=@econdition,");
            strSql.Append("maker=@maker,");
            strSql.Append("aname=@aname,");
            strSql.Append("acode=@acode,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tjcode=@tjcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tjname", SqlDbType.NVarChar,30),
					new SqlParameter("@tjarea", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,10),
					new SqlParameter("@bjprice", SqlDbType.Decimal,9),
					new SqlParameter("@wfprice", SqlDbType.Decimal,9),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@edate", SqlDbType.DateTime),
					new SqlParameter("@econdition", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tjcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tjname;
            parameters[1].Value = model.tjarea;
            parameters[2].Value = model.ctype;
            parameters[3].Value = model.bjprice;
            parameters[4].Value = model.wfprice;
            parameters[5].Value = model.bdate;
            parameters[6].Value = model.edate;
            parameters[7].Value = model.econdition;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.aname;
            parameters[10].Value = model.acode;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.tjcode;

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
            strSql.Append("delete from Sys_SpecialProduction ");
            strSql.AppendFormat(" where tjcode='{0}' ;",where);
            strSql.Append("delete from Sys_RInventorySpecialProduction ");
            strSql.AppendFormat(" where tjcode='{0}' ", where);
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
        public  Sys_SpecialProduction Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,aname,acode,tjname,tjcode,tjarea,ctype,bjprice,wfprice,bdate,edate,econdition,maker,cdate from Sys_SpecialProduction ");
            strSql.AppendFormat(" where 1=1 {0}",where);
             Sys_SpecialProduction r = new  Sys_SpecialProduction();
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
        public  Sys_SpecialProduction DataRowToModel(DataRow row)
        {
             Sys_SpecialProduction model = new  Sys_SpecialProduction();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["tjname"] != null)
                {
                    model.tjname = row["tjname"].ToString();
                }
                if (row["tjcode"] != null)
                {
                    model.tjcode = row["tjcode"].ToString();
                }
                if (row["tjarea"] != null)
                {
                    model.tjarea = row["tjarea"].ToString();
                }
                if (row["ctype"] != null)
                {
                    model.ctype = row["ctype"].ToString();
                }
                if (row["bjprice"] != null && row["bjprice"].ToString() != "")
                {
                    model.bjprice = decimal.Parse(row["bjprice"].ToString());
                }
                if (row["wfprice"] != null && row["wfprice"].ToString() != "")
                {
                    model.wfprice = decimal.Parse(row["wfprice"].ToString());
                }
                if (row["bdate"] != null && row["bdate"].ToString() != "")
                {
                    model.bdate =  row["bdate"].ToString( );
                }
                if (row["edate"] != null && row["edate"].ToString() != "")
                {
                    model.edate =  row["edate"].ToString( );
                }
                if (row["econdition"] != null)
                {
                    model.econdition = row["econdition"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SpecialProduction> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,aname,acode,tjname,tjcode,tjarea,ctype,bjprice,wfprice,bdate,edate,econdition,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_SpecialProduction where 1=1 {0}", strWhere);
            List<Sys_SpecialProduction> r = new List<Sys_SpecialProduction>();
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
            sql = "select isnull(max(convert(int,tjcode)),0) as n from Sys_SpecialProduction ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetCateProduction(string tjcode, string icode, string[] pcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventorySpecialProduction where tjcode='{0}' and icode='{1}';", tjcode, icode);
            for (int i = 0; i < pcode.Length; i++)
            {
                strSql.AppendFormat(" insert into Sys_RInventorySpecialProduction  (tjcode,icode,pcode) values('{0}','{1}','{2}');", tjcode, icode,pcode[i]);
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
        public bool ReSetCateProduction(string tjcode, string icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventorySpecialProduction where tjcode='{0}' and icode='{1}';", tjcode, icode);
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
        public string GetCateProduction(string tjcode, string icode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  pcode ");
            strSql.AppendFormat(" FROM Sys_RInventorySpecialProduction where  tjcode='{0}' and icode='{1}';", tjcode, icode);
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
        #endregion  ExtensionMethod
    }
}
