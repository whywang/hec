using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_WorkEventDal : ISys_WorkEventDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from Sys_WorkEvent");
           strSql.AppendFormat(" where 1=1 {0} ", where);
           return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
       }
        /// <summary>
        /// 增加一条数据
        /// </summary>
      
        public int Add( Sys_WorkEvent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_WorkEvent(");
            strSql.Append("wname,wcode,wattr,wremcode,wprewcode,wprewname,wnextwcode,wnextwname,wrwname,wrwcode,emcode,wcondtion,wcycletime,wattrex,wrwtype)");
			strSql.Append(" values (");
            strSql.Append("@wname,@wcode,@wattr,@wremcode,@wprewcode,@wprewname,@wnextwcode,@wnextwname,@wrwname,@wrwcode,@emcode,@wcondtion,@wcycletime,@wattrex,@wrwtype);");
 
			SqlParameter[] parameters = {
					new SqlParameter("@wname", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,10),
					new SqlParameter("@wattr", SqlDbType.Int,4),
					new SqlParameter("@wremcode", SqlDbType.NVarChar,10),
					new SqlParameter("@wprewcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wprewname", SqlDbType.NVarChar,30),
					new SqlParameter("@wnextwcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wnextwname", SqlDbType.NVarChar,30),
					new SqlParameter("@wrwname", SqlDbType.NVarChar,30),
					new SqlParameter("@wrwcode", SqlDbType.NVarChar,20),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wcondtion", SqlDbType.NVarChar,200),
					new SqlParameter("@wcycletime", SqlDbType.Int,4),
                    new SqlParameter("@wattrex", SqlDbType.NVarChar,30),
                    new SqlParameter("@wrwtype", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.wname;
			parameters[1].Value = model.wcode;
			parameters[2].Value = model.wattr;
			parameters[3].Value = model.wremcode;
			parameters[4].Value = model.wprewcode;
			parameters[5].Value = model.wprewname;
			parameters[6].Value = model.wnextwcode;
			parameters[7].Value = model.wnextwname;
			parameters[8].Value = model.wrwname;
			parameters[9].Value = model.wrwcode;
			parameters[10].Value = model.emcode;
			parameters[11].Value = model.wcondtion;
            parameters[12].Value = model.wcycletime;
            parameters[13].Value = model.wattrex;
            parameters[14].Value = model.wrwtype;
            if (model.wprewcode != "")
            {
                strSql.AppendFormat(" update Sys_WorkEvent set wnextwcode='{0}' where wcode='{1}'", model.wcode, model.wprewcode);
            }
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
        public bool Update(Sys_WorkEvent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_WorkEvent set ");
            strSql.Append("wname=@wname,");
            strSql.Append("wattr=@wattr,");
            strSql.Append("wremcode=@wremcode,");
            strSql.Append("wprewcode=@wprewcode,");
            strSql.Append("wprewname=@wprewname,");
            strSql.Append("wnextwcode=@wnextwcode,");
            strSql.Append("wnextwname=@wnextwname,");
            strSql.Append("wrwname=@wrwname,");
            strSql.Append("wrwcode=@wrwcode,");
            strSql.Append("emcode=@emcode,");
            strSql.Append("wcondtion=@wcondtion,");
            strSql.Append("wcycletime=@wcycletime,");
            strSql.Append("wattrex=@wattrex,");
            strSql.Append("wrwtype=@wrwtype");
            strSql.Append(" where wcode=@wcode;");
            SqlParameter[] parameters = {
					new SqlParameter("@wname", SqlDbType.NVarChar,30),
					new SqlParameter("@wattr", SqlDbType.Int,4),
					new SqlParameter("@wremcode", SqlDbType.NVarChar,10),
					new SqlParameter("@wprewcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wprewname", SqlDbType.NVarChar,30),
					new SqlParameter("@wnextwcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wnextwname", SqlDbType.NVarChar,30),
					new SqlParameter("@wrwname", SqlDbType.NVarChar,30),
					new SqlParameter("@wrwcode", SqlDbType.NVarChar,20),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wcondtion", SqlDbType.NVarChar,200),
                    new SqlParameter("@wcycletime", SqlDbType.Int,4),
                    new SqlParameter("@wattrex", SqlDbType.NVarChar,30),
                    new SqlParameter("@wrwtype", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.wname;
            parameters[1].Value = model.wattr;
            parameters[2].Value = model.wremcode;
            parameters[3].Value = model.wprewcode;
            parameters[4].Value = model.wprewname;
            parameters[5].Value = model.wnextwcode;
            parameters[6].Value = model.wnextwname;
            parameters[7].Value = model.wrwname;
            parameters[8].Value = model.wrwcode;
            parameters[9].Value = model.emcode;
            parameters[10].Value = model.wcondtion;
            parameters[11].Value = model.wcycletime;
            parameters[12].Value = model.wattrex;
            parameters[13].Value = model.wrwtype;
            parameters[14].Value = model.wcode;
            strSql.AppendFormat("update   Sys_Button set wname='{0}'  where wcode='{1}';",model.wname, model.wcode);
            if (model.wprewcode != "")
            {
                strSql.AppendFormat(" update Sys_WorkEvent set wnextwcode='{0}' where wcode='{1}'", model.wcode, model.wprewcode);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string wcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_BackEvent where bcode in (select bcode from Sys_Button where wcode ='{0}');", wcode);
            strSql.AppendFormat("delete from Sys_Button where wcode='{0}' ;", wcode);
            strSql.AppendFormat("delete from Sys_WorkEvent where wcode='{0}';", wcode);
            strSql.AppendFormat("update Sys_WorkEvent set wnextwcode='' where wnextwcode='{0}';", wcode);
            strSql.AppendFormat("update Sys_WorkEvent set wprewcode='' where wprewcode='{0}';", wcode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, strSql) > 0)
            {
                r = true;
            }
            return r;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_WorkEvent Query(string where) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wname,wcode,wattr,wremcode,wprewcode,wprewname,wnextwcode,wnextwname,wrwname,wrwcode,emcode,wcondtion,wcycletime, wattrex,wrwtype from Sys_WorkEvent ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_WorkEvent r = new Sys_WorkEvent();
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
        private  Sys_WorkEvent DataRowToModel(DataRow row)
        {
             Sys_WorkEvent model = new Sys_WorkEvent();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["wname"] != null)
                {
                    model.wname = row["wname"].ToString();
                }
                if (row["wcode"] != null)
                {
                    model.wcode = row["wcode"].ToString();
                }
                if (row["wattr"] != null && row["wattr"].ToString() != "")
                {
                    model.wattr = int.Parse(row["wattr"].ToString());
                }
                if (row["wremcode"] != null && row["wremcode"].ToString() != "")
                {
                    model.wremcode = row["wremcode"].ToString();
                }
                if (row["wprewcode"] != null)
                {
                    model.wprewcode = row["wprewcode"].ToString();
                }
                if (row["wprewname"] != null)
                {
                    model.wprewname = row["wprewname"].ToString();
                }
                if (row["wnextwcode"] != null)
                {
                    model.wnextwcode = row["wnextwcode"].ToString();
                }
                if (row["wnextwname"] != null)
                {
                    model.wnextwname = row["wnextwname"].ToString();
                }
                if (row["wrwname"] != null)
                {
                    model.wrwname = row["wrwname"].ToString();
                }
                if (row["wrwcode"] != null)
                {
                    model.wrwcode = row["wrwcode"].ToString();
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["wcondtion"] != null)
                {
                    model.wcondtion = row["wcondtion"].ToString();
                }
                if (row["wattrex"] != null)
                {
                    model.wattrex = row["wattrex"].ToString();
                }
                if (row["wcycletime"] != null && row["wcycletime"].ToString() != "")
                {
                    model.wcycletime = int.Parse(row["wcycletime"].ToString());
                }
                if (row["wrwtype"] != null && row["wrwtype"].ToString() != "")
                {
                    model.wrwtype = row["wrwtype"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_WorkEvent> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,wname,wcode,wattr,wremcode,wprewcode,wprewname,wnextwcode,wnextwname,wrwname,wrwcode,emcode,wcondtion,wcycletime,wattrex,wrwtype from Sys_WorkEvent ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_WorkEvent> r = new List<Sys_WorkEvent>();
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

        #endregion  成员方法
        #region  MethodEx
        public int CreateCode()
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,wcode)),0) as n from Sys_WorkEvent ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  MethodEx
    }
}
