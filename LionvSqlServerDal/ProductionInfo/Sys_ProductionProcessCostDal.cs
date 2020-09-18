using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;
using System.Collections;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionProcessCostDal : ISys_ProductionProcessCostDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionProcessCost");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcessCost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionProcessCost(");
            strSql.Append("uname,ucode,gname,gcode,mname,mcode,utype,unum,maker,mc,mk,mh,utj,ulg,utg,ulk,utk,ulh,uth,dcode,cdate)");
            strSql.Append(" values (");
            strSql.Append("@uname,@ucode,@gname,@gcode,@mname,@mcode,@utype,@unum,@maker,@mc,@mk,@mh,@utj,@ulg,@utg,@ulk,@utk,@ulh,@uth,@dcode,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.NVarChar,30),
					new SqlParameter("@ucode", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@utype", SqlDbType.NVarChar,10),
					new SqlParameter("@unum", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@mc", SqlDbType.NVarChar,30),
					new SqlParameter("@mk", SqlDbType.NVarChar,30),
					new SqlParameter("@mh", SqlDbType.NVarChar,30),
					new SqlParameter("@utj", SqlDbType.Int,4),
					new SqlParameter("@ulg", SqlDbType.Int,4),
					new SqlParameter("@utg", SqlDbType.Int,4),
					new SqlParameter("@ulk", SqlDbType.Int,4),
					new SqlParameter("@utk", SqlDbType.Int,4),
					new SqlParameter("@ulh", SqlDbType.Int,4),
					new SqlParameter("@uth", SqlDbType.Int,4),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.uname;
            parameters[1].Value = model.ucode;
            parameters[2].Value = model.gname;
            parameters[3].Value = model.gcode;
            parameters[4].Value = model.mname;
            parameters[5].Value = model.mcode;
            parameters[6].Value = model.utype;
            parameters[7].Value = model.unum;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.mc;
            parameters[10].Value = model.mk;
            parameters[11].Value = model.mh;
            parameters[12].Value = model.utj;
            parameters[13].Value = model.ulg;
            parameters[14].Value = model.utg;
            parameters[15].Value = model.ulk;
            parameters[16].Value = model.utk;
            parameters[17].Value = model.ulh;
            parameters[18].Value = model.uth;
            parameters[19].Value = model.dcode;
            parameters[20].Value = model.cdate;

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
        public bool Update(Sys_ProductionProcessCost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionProcessCost set ");
            strSql.Append("uname=@uname,");
            strSql.Append("gname=@gname,");
            strSql.Append("gcode=@gcode,");
            strSql.Append("mname=@mname,");
            strSql.Append("mcode=@mcode,");
            strSql.Append("utype=@utype,");
            strSql.Append("unum=@unum,");
            strSql.Append("maker=@maker,");
            strSql.Append("mc=@mc,");
            strSql.Append("mk=@mk,");
            strSql.Append("mh=@mh,");
            strSql.Append("utj=@utj,");
            strSql.Append("ulg=@ulg,");
            strSql.Append("utg=@utg,");
            strSql.Append("ulk=@ulk,");
            strSql.Append("utk=@utk,");
            strSql.Append("ulh=@ulh,");
            strSql.Append("uth=@uth,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ucode=@ucode");
            SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@utype", SqlDbType.NVarChar,10),
					new SqlParameter("@unum", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@mc", SqlDbType.NVarChar,30),
					new SqlParameter("@mk", SqlDbType.NVarChar,30),
					new SqlParameter("@mh", SqlDbType.NVarChar,30),
					new SqlParameter("@utj", SqlDbType.Int,4),
					new SqlParameter("@ulg", SqlDbType.Int,4),
					new SqlParameter("@utg", SqlDbType.Int,4),
					new SqlParameter("@ulk", SqlDbType.Int,4),
					new SqlParameter("@utk", SqlDbType.Int,4),
					new SqlParameter("@ulh", SqlDbType.Int,4),
					new SqlParameter("@uth", SqlDbType.Int,4),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ucode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.uname;
            parameters[1].Value = model.gname;
            parameters[2].Value = model.gcode;
            parameters[3].Value = model.mname;
            parameters[4].Value = model.mcode;
            parameters[5].Value = model.utype;
            parameters[6].Value = model.unum;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.mc;
            parameters[9].Value = model.mk;
            parameters[10].Value = model.mh;
            parameters[11].Value = model.utj;
            parameters[12].Value = model.ulg;
            parameters[13].Value = model.utg;
            parameters[14].Value = model.ulk;
            parameters[15].Value = model.utk;
            parameters[16].Value = model.ulh;
            parameters[17].Value = model.uth;
            parameters[18].Value = model.dcode;
            parameters[19].Value = model.cdate;
            parameters[20].Value = model.ucode;

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
        public bool Delete(string ucode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionProcessCost ");
            strSql.AppendFormat(" where ucode='{0}' ", ucode);
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
        public Sys_ProductionProcessCost Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,uname,ucode,gname,gcode,mname,mcode,utype,unum,maker,mc,mk,mh,utj,ulg,utg,ulk,utk,ulh,uth,dcode,cdate from Sys_ProductionProcessCost ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionProcessCost r = new Sys_ProductionProcessCost();
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
        public Sys_ProductionProcessCost DataRowToModel(DataRow row)
        {
            Sys_ProductionProcessCost model = new Sys_ProductionProcessCost();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["uname"] != null)
                {
                    model.uname = row["uname"].ToString();
                }
                if (row["ucode"] != null)
                {
                    model.ucode = row["ucode"].ToString();
                }
                if (row["gname"] != null)
                {
                    model.gname = row["gname"].ToString();
                }
                if (row["gcode"] != null)
                {
                    model.gcode = row["gcode"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["mcode"] != null)
                {
                    model.mcode = row["mcode"].ToString();
                }
                if (row["utype"] != null)
                {
                    model.utype = row["utype"].ToString();
                }
                if (row["unum"] != null && row["unum"].ToString() != "")
                {
                    model.unum = decimal.Parse(row["unum"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["mc"] != null)
                {
                    model.mc = row["mc"].ToString();
                }
                if (row["mk"] != null)
                {
                    model.mk = row["mk"].ToString();
                }
                if (row["mh"] != null)
                {
                    model.mh = row["mh"].ToString();
                }
                if (row["utj"] != null && row["utj"].ToString() != "")
                {
                    model.utj = int.Parse(row["utj"].ToString());
                }
                if (row["ulg"] != null && row["ulg"].ToString() != "")
                {
                    model.ulg = int.Parse(row["ulg"].ToString());
                }
                if (row["utg"] != null && row["utg"].ToString() != "")
                {
                    model.utg = int.Parse(row["utg"].ToString());
                }
                if (row["ulk"] != null && row["ulk"].ToString() != "")
                {
                    model.ulk = int.Parse(row["ulk"].ToString());
                }
                if (row["utk"] != null && row["utk"].ToString() != "")
                {
                    model.utk = int.Parse(row["utk"].ToString());
                }
                if (row["ulh"] != null && row["ulh"].ToString() != "")
                {
                    model.ulh = int.Parse(row["ulh"].ToString());
                }
                if (row["uth"] != null && row["uth"].ToString() != "")
                {
                    model.uth = int.Parse(row["uth"].ToString());
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionProcessCost> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,uname,ucode,gname,gcode,mname,mcode,utype,unum,maker,mc,mk,mh,utj,ulg,utg,ulk,utk,ulh,uth,dcode,cdate ");
            strSql.Append(" FROM Sys_ProductionProcessCost ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionProcessCost> r = new List<Sys_ProductionProcessCost>();
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
            sql = "select isnull(max(convert(int, ucode)),0) as n from Sys_ProductionProcessCost ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetGyCost(ArrayList pcode, string gcode, string[] ucode)
        {
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < pcode.Count; i++)
            {
                strSql.AppendFormat("delete from Sys_RInventoryProcessCost where pcode='{0}' and gcode='{1}';", pcode[i], gcode);
            }
            for (int i = 0; i < pcode.Count; i++)
            {
                for (int k = 0; k < ucode.Length; k++)
                {
                    strSql.AppendFormat("insert into Sys_RInventoryProcessCost (pcode,gcode,ucode) values('{0}','{1}','{2}') ; ", pcode[i], gcode, ucode[k]);
                }
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetGyCost(ArrayList pcode, string gcode)
        {
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < pcode.Count; i++)
            {
                strSql.AppendFormat("delete from Sys_RInventoryProcessCost where pcode='{0}' and gcode='{1}';", pcode[i], gcode);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetGyCost(string pcode, string gcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ucode   FROM Sys_RInventoryProcessCost");
            strSql.AppendFormat(" where pcode='{0}' and gcode='{1}'", pcode, gcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["ucode"].ToString() + ";";
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
