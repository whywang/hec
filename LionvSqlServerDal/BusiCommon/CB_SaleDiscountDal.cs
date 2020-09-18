using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiCommon
{
   public class CB_SaleDiscountDal:ICB_SaleDiscountDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CB_SaleDiscount");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_SaleDiscount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_SaleDiscount(");
            strSql.Append("sid,dname,dcode,tjcode,tjname,dtype,dvalue,dzk,tjsort,tjfw)");
            strSql.Append(" values (");
            strSql.Append("@sid,@dname,@dcode,@tjcode,@tjname,@dtype,@dvalue,@dzk,@tjsort,@tjfw)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tjname", SqlDbType.NVarChar,30),
					new SqlParameter("@dtype", SqlDbType.NVarChar,10),
					new SqlParameter("@dvalue", SqlDbType.Decimal,9),
					new SqlParameter("@dzk", SqlDbType.Decimal,9),
					new SqlParameter("@tjsort", SqlDbType.Int,4),
					new SqlParameter("@tjfw", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.tjcode;
            parameters[4].Value = model.tjname;
            parameters[5].Value = model.dtype;
            parameters[6].Value = model.dvalue;
            parameters[7].Value = model.dzk;
            parameters[8].Value = model.tjsort;
            parameters[9].Value = model.tjfw;
            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update( CB_SaleDiscount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_SaleDiscount set ");
            strSql.Append("sid=@sid,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("tjname=@tjname,");
            strSql.Append("dtype=@dtype,");
            strSql.Append("dvalue=@dvalue,");
            strSql.Append("dzk=@dzk,");
            strSql.Append("tjsort=@tjsort");
            strSql.Append(" where tjcode=@tjcode");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tjname", SqlDbType.NVarChar,30),
					new SqlParameter("@dtype", SqlDbType.NVarChar,10),
					new SqlParameter("@dvalue", SqlDbType.Decimal,9),
					new SqlParameter("@dzk", SqlDbType.Decimal,9),
					new SqlParameter("@tjsort", SqlDbType.Int,4),
					new SqlParameter("@tjcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.tjname;
            parameters[4].Value = model.dtype;
            parameters[5].Value = model.dvalue;
            parameters[6].Value = model.dzk;
            parameters[7].Value = model.tjsort;
            parameters[8].Value = model.tjcode;

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
            strSql.AppendFormat("delete from CB_SaleDiscount where 1=1 {0}", where);
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
        public  CB_SaleDiscount Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select select  top 1 id,sid,dname,dcode,tjcode,tjname,dtype,dvalue,dzk,tjsort,tjfw from CB_SaleDiscount");
            strSql.AppendFormat(" where 1=1 {0}", where);
             CB_SaleDiscount r = new  CB_SaleDiscount();
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
        public  CB_SaleDiscount DataRowToModel(DataRow row)
        {
             CB_SaleDiscount model = new  CB_SaleDiscount();
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
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["tjcode"] != null)
                {
                    model.tjcode = row["tjcode"].ToString();
                }
                if (row["tjname"] != null)
                {
                    model.tjname = row["tjname"].ToString();
                }
                if (row["dtype"] != null)
                {
                    model.dtype = row["dtype"].ToString();
                }
                if (row["dvalue"] != null && row["dvalue"].ToString() != "")
                {
                    model.dvalue = decimal.Parse(row["dvalue"].ToString());
                }
                if (row["dzk"] != null && row["dzk"].ToString() != "")
                {
                    model.dzk = decimal.Parse(row["dzk"].ToString());
                }
                if (row["tjsort"] != null && row["tjsort"].ToString() != "")
                {
                    model.tjsort = int.Parse(row["tjsort"].ToString());
                }
                if (row["tjfw"] != null)
                {
                    model.tjfw = row["tjfw"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_SaleDiscount> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,dname,dcode,tjcode,tjname,dtype,dvalue,dzk,tjsort, tjfw ");
            strSql.Append(" FROM CB_SaleDiscount ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<CB_SaleDiscount> r = new List<CB_SaleDiscount>();
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

        #endregion  ExtensionMethod
    }
}
