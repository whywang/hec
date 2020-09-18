using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_DepmentDal : ISys_DepmentDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Depment");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_Depment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" update Sys_Depment set dsort=dsort+1 where dpcode='{0}' and dsort>={1};", model.dpcode,model.dsort);
            strSql.Append("insert into Sys_Depment(");
            strSql.Append("dname,dcode,dpname,dpcode,dcdate,disused,dattr,dmaker,disend,dcdep,maker,cdate,dread,dabc,khcode,dmattr,dsquare)");
            strSql.Append(" values (");
            strSql.Append("@dname,@dcode,@dpname,@dpcode,@dcdate,@disused,@dattr,@dmaker,@disend,@dcdep,@maker,@cdate,@dread,@dabc,@khcode,@dmattr,@dsquare);");
            SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@dpname", SqlDbType.NVarChar,50),
					new SqlParameter("@dpcode", SqlDbType.NVarChar,50),
					new SqlParameter("@dcdate", SqlDbType.DateTime),
					new SqlParameter("@disused", SqlDbType.Bit,1),
					new SqlParameter("@dattr", SqlDbType.NVarChar,2),
					new SqlParameter("@dmaker", SqlDbType.NVarChar,50),
					new SqlParameter("@disend", SqlDbType.Bit,1),
					new SqlParameter("@dcdep", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.NVarChar,50),
					new SqlParameter("@dread", SqlDbType.Bit,1),
					new SqlParameter("@dabc", SqlDbType.NVarChar,30),
					new SqlParameter("@khcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dsort", SqlDbType.Int),
					new SqlParameter("@dmattr", SqlDbType.NVarChar,30),
					new SqlParameter("@dsquare", SqlDbType.Decimal,8)};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.dpname;
            parameters[3].Value = model.dpcode;
            parameters[4].Value = model.dcdate;
            parameters[5].Value = model.disused;
            parameters[6].Value = model.dattr;
            parameters[7].Value = model.dmaker;
            parameters[8].Value = model.disend;
            parameters[9].Value = model.dcdep;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.dread;
            parameters[13].Value = model.dabc;
            parameters[14].Value = model.khcode;
            parameters[15].Value = model.dsort;
            parameters[16].Value = model.dmattr;
            parameters[17].Value = model.dsquare;
            strSql.AppendFormat(" update Sys_Depment set disend='false' where dcode='{0}';", model.dpcode);

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
        ///  1更新部门表
        ///  2更新下级部门上级部门名称
        ///  3更新员工表部门名称
        public bool Update(Sys_Depment model)
        {
            Sys_Depment sd=Query(" and dcode='" + model.dcode + "'");
            StringBuilder strSql = new StringBuilder();
            if (sd.dsort > model.dsort)
            {
                strSql.AppendFormat(" update Sys_Depment set dsort=dsort+1 where dpcode='{0}' and dsort>={1} and dsort<{2};", model.dpcode, model.dsort, sd.dsort);
            }
            if (sd.dsort < model.dsort)
            {
                strSql.AppendFormat(" update Sys_Depment set dsort=dsort-1 where dpcode='{0}' and dsort>{1} and dsort<={2};", model.dpcode, sd.dsort, model.dsort);
            }
            strSql.Append("update Sys_Depment set ");
            strSql.Append("dname=@dname,");
            strSql.Append("dpname=@dpname,");
            strSql.Append("dpcode=@dpcode,");
            strSql.Append("dcdate=@dcdate,");
            strSql.Append("disused=@disused,");
            strSql.Append("dattr=@dattr,");
            strSql.Append("dmaker=@dmaker,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("khcode=@khcode,");
            strSql.Append("dsort=@dsort,");
            strSql.Append("dmattr=@dmattr,");
            strSql.Append("dsquare=@dsquare");
            strSql.Append(" where dcode=@dcode;");
            SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@dpname", SqlDbType.NVarChar,50),
					new SqlParameter("@dpcode", SqlDbType.NVarChar,50),
					new SqlParameter("@dcdate", SqlDbType.DateTime),
					new SqlParameter("@disused", SqlDbType.Bit,1),
					new SqlParameter("@dattr", SqlDbType.NVarChar,2),
					new SqlParameter("@dmaker", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.NVarChar,50),
                    new SqlParameter("@khcode", SqlDbType.NVarChar,50),
                    new SqlParameter("@dsort", SqlDbType.Int),
                    new SqlParameter("@dmattr", SqlDbType.NVarChar,30),
                     new SqlParameter("@dsquare", SqlDbType.Decimal,8),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)
					};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dpname;
            parameters[2].Value = model.dpcode;
            parameters[3].Value = model.dcdate;
            parameters[4].Value = model.disused;
            parameters[5].Value = model.dattr;
            parameters[6].Value = model.dmaker;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;
            parameters[9].Value = model.khcode;
            parameters[10].Value = model.dsort;
            parameters[11].Value = model.dmattr;
            parameters[12].Value = model.dsquare;
            parameters[13].Value = model.dcode;
            bool r = false;
            strSql.AppendFormat(" update Sys_Depment set dpname='{0}' where dpcode='{1}';", model.dname, model.dcode);
            strSql.AppendFormat(" update Sys_Employee set dname='{0}' where dcode='{1}'", model.dname, model.dcode);
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
        /// 1删除部门及其子部门
        /// 2删除部门员工详情表
        /// 3删除部门员工
        /// 4判断是否父级部门是否还有子部门 如果没有更新父级不能isend属性
        public bool Delete(string dcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_Depment where dcode like'{0}%';", dcode);
            strSql.AppendFormat("delete from Sys_DepmentDpt where dcode like'{0}%';", dcode);
            strSql.AppendFormat("delete from Sys_EmployeeDpt where eno in (select eno from Sys_Employee where dcode like'{0}%');", dcode);
            strSql.AppendFormat("delete from Sys_Employee where dcode like'{0}%';", dcode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                IsHasParentDep(dcode);
                r = true;
            }
            return r;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_Depment Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,dname,dcode,dpname,dpcode,dcdate,disused,dattr,dmaker,disend,dcdep,maker,cdate,dread,dabc,khcode,dsort,dmattr,dsquare,dcity from Sys_Depment ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Depment r = new Sys_Depment();
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
        /// 获得数据列表
        /// </summary>
        public List<Sys_Depment> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,dname,dcode,dpname,dpcode,dcdate,disused,dattr,dmaker,disend ,dcdep,maker,cdate ,dread,dabc,khcode,dsort,dmattr,dsquare,dcity from Sys_Depment ");
            strSql.AppendFormat(" where 1=1 {0} order by dsort", where);
            List<Sys_Depment> r = new List<Sys_Depment>();
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
        public Sys_Depment DataRowToModel(DataRow row)
       {
            Sys_Depment model = new  Sys_Depment();
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
               if (row["dpname"] != null)
               {
                   model.dpname = row["dpname"].ToString();
               }
               if (row["dpcode"] != null)
               {
                   model.dpcode = row["dpcode"].ToString();
               }
               if (row["dabc"] != null)
               {
                   model.dabc = row["dabc"].ToString();
               }
               if (row["dcdate"] != null && row["dcdate"].ToString() != "")
               {
                   model.dcdate = row["dcdate"].ToString( );
               }
               if (row["disused"] != null && row["disused"].ToString() != "")
               {
                   if ((row["disused"].ToString() == "1") || (row["disused"].ToString().ToLower() == "true"))
                   {
                       model.disused = true;
                   }
                   else
                   {
                       model.disused = false;
                   }
               }
               if (row["dattr"] != null)
               {
                   model.dattr = row["dattr"].ToString();
               }
               if (row["dmaker"] != null)
               {
                   model.dmaker = row["dmaker"].ToString();
               }
               if (row["disend"] != null && row["disend"].ToString() != "")
               {
                   if ((row["disend"].ToString() == "1") || (row["disend"].ToString().ToLower() == "true"))
                   {
                       model.disend = true;
                   }
                   else
                   {
                       model.disend = false;
                   }
               }
               if (row["maker"] != null)
               {
                   model.maker = row["maker"].ToString();
               }
               if (row["dcdep"] != null)
               {
                   model.dcdep = row["dcdep"].ToString();
               }
               if (row["khcode"] != null)
               {
                   model.khcode = row["khcode"].ToString();
               }
               if (row["cdate"] != null)
               {
                   model.cdate = row["cdate"].ToString();
               }
               if (row["dread"] != null && row["dread"].ToString() != "")
               {
                   if ((row["dread"].ToString() == "1") || (row["dread"].ToString().ToLower() == "true"))
                   {
                       model.dread = true;
                   }
                   else
                   {
                       model.dread = false;
                   }
               }
               if (row["dsort"] != null)
               {
                   model.dsort = int.Parse(row["dsort"].ToString());
               }
               if (row["dmattr"] != null)
               {
                   model.dmattr =row["dmattr"].ToString();
               }
               if (row["dcity"] != null)
               {
                   model.dcity = row["dcity"].ToString();
               }
               if (row["dsquare"] != null && row["dsquare"].ToString() != "")
               {
                   model.dsquare = decimal.Parse(row["dsquare"].ToString());
               }
           }
           return model;
       }
        #endregion  成员方法
        #region  MethodEx
        public int CreateCode(string pdepcode)
        {
            int r = -1;
            string sql = "";
            if (pdepcode.Length < 0)
            {
                sql = "select isnull(max(convert(int,dcode)),0) as n from Sys_Depment where  dpcode='" + pdepcode + "'";
            }
            else
            {
                sql = "select isnull(max(convert(int,substring(dcode,len(dcode)-3,4))),0) as n from Sys_Depment where  dpcode='" + pdepcode + "'";
            }
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        private void IsHasParentDep(string depcode)
       {
           if(!Exists(" and dpcode='"+depcode.Substring(depcode.Length-4,4)+"'"))
           {
            string sql=" update Sys_Depment set disend='true' where dcode='"+depcode.Substring(depcode.Length-4,4)+"'";
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql, null);
           }
       }
        public bool SetProxyCity(string dcode, string ccode)
       {
           bool r = false;
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("delete  from Sys_RProxyCity where dcode='{0}';", dcode);
           string[] carr = ccode.Split(';');
           if (carr.Length > 0)
           {
               foreach (string c in carr)
               {
                   strSql.AppendFormat("insert into Sys_RProxyCity (dcode,ccode)values ('{0}','{1}') ;", dcode,c);
               }
           }
           if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
           {
               r = true;
           }
           return r;
       }
        public bool ReSetProxyCity(string dcode)
       {
           bool r = false;
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("delete  from Sys_RProxyCity where dcode='{0}';", dcode);
           if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
           {
               r = true;
           }
           return r;
       }
        public string GetProxyCity(string dcode)
       {
           string r = "";
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select ccode from Sys_RProxyCity ");
           strSql.AppendFormat(" where  dcode='{0}'", dcode);
           DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
           if (dt != null)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   r=r+dr["ccode"].ToString()+";";
               }
               r = r.Substring(0, r.Length - 1);
           }
           else
           {
               r = "";
           }
           return r;
       }
        #endregion  MethodEx
    }
}
