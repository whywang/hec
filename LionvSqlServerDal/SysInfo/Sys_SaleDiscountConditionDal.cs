using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using System.Collections;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_SaleDiscountConditionDal : ISys_SaleDiscountConditionDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SaleDiscountCondition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SaleDiscountCondition(");
            strSql.Append("dname,dcode,tjname,tjcode,tjmethod,dvalue,dlv,dtv,dzk,dsort,maker,cdate,tjfw,tjlb)");
            strSql.Append(" values (");
            strSql.Append("@dname,@dcode,@tjname,@tjcode,@tjmethod,@dvalue,@dlv,@dtv,@dzk,@dsort,@maker,@cdate,@tjfw,@tjlb)");
            SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tjname", SqlDbType.NVarChar,30),
					new SqlParameter("@tjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tjmethod", SqlDbType.NVarChar,30),
					new SqlParameter("@dvalue", SqlDbType.Decimal,9),
					new SqlParameter("@dlv", SqlDbType.Decimal,9),
					new SqlParameter("@dtv", SqlDbType.Decimal,9),
					new SqlParameter("@dzk", SqlDbType.Decimal,9),
					new SqlParameter("@dsort", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tjfw", SqlDbType.NVarChar,30),
					new SqlParameter("@tjlb", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.tjname;
            parameters[3].Value = model.tjcode;
            parameters[4].Value = model.tjmethod;
            parameters[5].Value = model.dvalue;
            parameters[6].Value = model.dlv;
            parameters[7].Value = model.dtv;
            parameters[8].Value = model.dzk;
            parameters[9].Value = model.dsort;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.tjfw;
            parameters[13].Value = model.tjlb;
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
        public bool Update( Sys_SaleDiscountCondition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SaleDiscountCondition set ");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("tjname=@tjname,");
            strSql.Append("tjmethod=@tjmethod,");
            strSql.Append("dvalue=@dvalue,");
            strSql.Append("dlv=@dlv,");
            strSql.Append("dtv=@dtv,");
            strSql.Append("dzk=@dzk,");
            strSql.Append("dsort=@dsort,");
            strSql.Append("maker=@maker,");
            strSql.Append("tjfw=@tjfw,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("tjlb=@tjlb");
            strSql.Append(" where tjcode=@tjcode");
            SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tjname", SqlDbType.NVarChar,30),
					new SqlParameter("@tjmethod", SqlDbType.NVarChar,30),
					new SqlParameter("@dvalue", SqlDbType.Decimal,9),
					new SqlParameter("@dlv", SqlDbType.Decimal,9),
					new SqlParameter("@dtv", SqlDbType.Decimal,9),
					new SqlParameter("@dzk", SqlDbType.Decimal,9),
					new SqlParameter("@dsort", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@tjfw", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                     new SqlParameter("@tjlb", SqlDbType.NVarChar,30),
					new SqlParameter("@tjcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.tjname;
            parameters[3].Value = model.tjmethod;
            parameters[4].Value = model.dvalue;
            parameters[5].Value = model.dlv;
            parameters[6].Value = model.dtv;
            parameters[7].Value = model.dzk;
            parameters[8].Value = model.dsort;
            parameters[9].Value = model.maker;
            parameters[10].Value = model.tjfw;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.tjlb;
            parameters[13].Value = model.tjcode;

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
            strSql.Append("delete from Sys_SaleDiscountCondition ");
            strSql.AppendFormat(" where 1=1 {0}",where);
 
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
        public  Sys_SaleDiscountCondition Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  id,dname,dcode,tjname,tjcode,tjmethod,dvalue,dlv,dtv,dzk,dsort,maker,cdate,tjfw,tjlb  from Sys_SaleDiscountCondition ");
            strSql.AppendFormat(" where 1=1 {0}",where);
             Sys_SaleDiscountCondition r = new  Sys_SaleDiscountCondition();
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
        public  Sys_SaleDiscountCondition DataRowToModel(DataRow row)
        {
             Sys_SaleDiscountCondition model = new  Sys_SaleDiscountCondition();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["tjname"] != null)
                {
                    model.tjname = row["tjname"].ToString();
                }
                if (row["tjcode"] != null)
                {
                    model.tjcode = row["tjcode"].ToString();
                }
                if (row["tjmethod"] != null)
                {
                    model.tjmethod = row["tjmethod"].ToString();
                }
                if (row["dvalue"] != null && row["dvalue"].ToString() != "")
                {
                    model.dvalue = decimal.Parse(row["dvalue"].ToString());
                }
                if (row["dlv"] != null && row["dlv"].ToString() != "")
                {
                    model.dlv = decimal.Parse(row["dlv"].ToString());
                }
                if (row["dtv"] != null && row["dtv"].ToString() != "")
                {
                    model.dtv = decimal.Parse(row["dtv"].ToString());
                }
                if (row["dzk"] != null && row["dzk"].ToString() != "")
                {
                    model.dzk = decimal.Parse(row["dzk"].ToString());
                }
                if (row["dsort"] != null && row["dsort"].ToString() != "")
                {
                    model.dsort = int.Parse(row["dsort"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["tjfw"] != null)
                {
                    model.tjfw = row["tjfw"].ToString();
                }
                if (row["tjlb"] != null)
                {
                    model.tjlb = row["tjlb"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SaleDiscountCondition> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,dname,dcode,tjname,tjcode,tjmethod,dvalue,dlv,dtv,dzk,dsort,maker,cdate,tjfw,tjlb ");
            strSql.AppendFormat(" FROM Sys_SaleDiscountCondition  where 1=1 {0}",strWhere);
            List<Sys_SaleDiscountCondition> r = new List<Sys_SaleDiscountCondition>();
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
        public bool AddList(string dcode,List<Sys_SaleDiscountCondition> ls)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from Sys_SaleDiscountCondition where dcode='"+dcode+"'; ");
            if (ls != null)
            {
                foreach (Sys_SaleDiscountCondition s in ls)
                {
                    strSql.AppendFormat(" insert into  Sys_SaleDiscountCondition  (dname,dcode,dvalue,dlv,dtv,dzk) values('{0}','{1}',{2},{3},{4},{5});", s.dname,s.dcode,s.dvalue,s.dlv,s.dtv,s.dzk);
                }
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
        public int CreateCode()
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,tjcode)),0) as n from Sys_SaleDiscountCondition ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public ArrayList QuerySortNum(string acode)
        {
            ArrayList r = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  distinct(dsort) as n  ");
            strSql.AppendFormat(" FROM Sys_SaleDiscountCondition  where dcode='{0}'", acode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(dr["n"].ToString());
                }
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
