using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionProcessLinePointDal : ISys_ProductionProcessLinePointDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionProcessLinePoint");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcessLinePoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionProcessLinePoint(");
            strSql.Append("lname,lcode,gname,gcode,ptype,pregcode,usetime,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@lname,@lcode,@gname,@gcode,@ptype,@pregcode,@usetime,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@pregcode", SqlDbType.NVarChar,30),
					new SqlParameter("@usetime", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.lname;
            parameters[1].Value = model.lcode;
            parameters[2].Value = model.gname;
            parameters[3].Value = model.gcode;
            parameters[4].Value = model.ptype;
            parameters[5].Value = model.pregcode;
            parameters[6].Value = model.usetime;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;

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
        public bool Update(Sys_ProductionProcessLinePoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionProcessLinePoint set ");
            strSql.Append("lname=@lname,");
            strSql.Append("lcode=@lcode,");
            strSql.Append("gname=@gname,");
            strSql.Append("gcode=@gcode,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("pregcode=@pregcode,");
            strSql.Append("usetime=@usetime,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@pregcode", SqlDbType.NVarChar,30),
					new SqlParameter("@usetime", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.lname;
            parameters[1].Value = model.lcode;
            parameters[2].Value = model.gname;
            parameters[3].Value = model.gcode;
            parameters[4].Value = model.ptype;
            parameters[5].Value = model.pregcode;
            parameters[6].Value = model.usetime;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;
            parameters[9].Value = model.id;

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
        /// 批量删除数据
        /// </summary>
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionProcessLinePoint ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
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
        public Sys_ProductionProcessLinePoint Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lname,lcode,gname,gcode,ptype,pregcode,usetime,maker,cdate,nsort from Sys_ProductionProcessLinePoint ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionProcessLinePoint r = new Sys_ProductionProcessLinePoint();
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
        public Sys_ProductionProcessLinePoint DataRowToModel(DataRow row)
        {
            Sys_ProductionProcessLinePoint model = new Sys_ProductionProcessLinePoint();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["lname"] != null)
                {
                    model.lname = row["lname"].ToString();
                }
                if (row["lcode"] != null)
                {
                    model.lcode = row["lcode"].ToString();
                }
                if (row["gname"] != null)
                {
                    model.gname = row["gname"].ToString();
                }
                if (row["gcode"] != null)
                {
                    model.gcode = row["gcode"].ToString();
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["pregcode"] != null)
                {
                    model.pregcode = row["pregcode"].ToString();
                }
                if (row["usetime"] != null && row["usetime"].ToString() != "")
                {
                    model.usetime = int.Parse(row["usetime"].ToString());
                }
                if (row["nsort"] != null && row["nsort"].ToString() != "")
                {
                    model.nsort = int.Parse(row["nsort"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
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
        public List<Sys_ProductionProcessLinePoint> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,lname,lcode,gname,gcode,ptype,pregcode,usetime,maker,cdate,nsort ");
            strSql.Append(" FROM Sys_ProductionProcessLinePoint ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionProcessLinePoint> r = new List<Sys_ProductionProcessLinePoint>();
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
        public int AddList(string lcode, List<Sys_ProductionProcessLinePoint> model)
        {
            string pcode = "";
            int xh = 1;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_ProductionProcessLinePoint where lcode='{0}';", lcode);
            foreach (Sys_ProductionProcessLinePoint p in model)
            {
                string sn = "2";
                if (xh == 1)
                {
                    sn = "1";
                }
                if (xh == model.Count)
                {
                    sn = "3";
                }
                strSql.Append("insert into Sys_ProductionProcessLinePoint(");
                strSql.Append("lname,lcode,gname,gcode,ptype,pregcode,usetime,maker,cdate,nsort)");
                strSql.Append(" values (");
                strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}',", p.lname, p.lcode, p.gname, p.gcode, sn);
                strSql.AppendFormat(" '{0}',{1},'{2}','{3}',{4});", pcode, p.usetime, p.maker, p.cdate, p.nsort);
                pcode = p.gcode;
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
