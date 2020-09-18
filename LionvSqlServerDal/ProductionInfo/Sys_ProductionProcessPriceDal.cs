using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionProcessPriceDal : ISys_ProductionProcessPriceDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcessPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionProcessPrice(");
            strSql.Append("gcode,pcode,gprice,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@gcode,@pcode,@gprice,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gprice", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.gcode;
            parameters[1].Value = model.pcode;
            parameters[2].Value = model.gprice;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;

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
        public bool Update(Sys_ProductionProcessPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionProcessPrice set ");
            strSql.Append("gcode=@gcode,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("gprice=@gprice,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gprice", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.gcode;
            parameters[1].Value = model.pcode;
            parameters[2].Value = model.gprice;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.id;

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
            strSql.Append("delete from Sys_ProductionProcessPrice ");
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
        public Sys_ProductionProcessPrice Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,gcode,pcode,gprice,maker,cdate,gname from Sys_ProductionProcessPrice ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionProcessPrice r = new Sys_ProductionProcessPrice();
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
        public Sys_ProductionProcessPrice DataRowToModel(DataRow row)
        {
            Sys_ProductionProcessPrice model = new Sys_ProductionProcessPrice();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["gcode"] != null)
                {
                    model.gcode = row["gcode"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["gprice"] != null && row["gprice"].ToString() != "")
                {
                    model.gprice = decimal.Parse(row["gprice"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["gname"] != null)
                {
                    model.gname = row["gname"].ToString();
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
        public List<Sys_ProductionProcessPrice> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,gcode,pcode,gprice,maker,cdate,gname ");
            strSql.AppendFormat(" FROM Sys_ProductionProcessPrice where 1=1 {0}", strWhere);
            List<Sys_ProductionProcessPrice> r = new List<Sys_ProductionProcessPrice>();
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
        public int AddList(List<Sys_ProductionProcessPrice> ls)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (Sys_ProductionProcessPrice p in ls)
            {
                strSql.AppendFormat("delete from Sys_ProductionProcessPrice where pcode='{0}' and gcode='{1}';", p.pcode, p.gcode);
                strSql.AppendFormat("insert into Sys_ProductionProcessPrice  (pcode,gcode,gprice,gname) values ('{0}','{1}',{2},'{3}');", p.pcode, p.gcode, p.gprice, p.gname);
            }
            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion  ExtensionMethod
    }
}
