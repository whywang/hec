using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ComponentDal : ISys_ComponentDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Component");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_Component model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Component(");
            strSql.Append("cname,ccode,ccname,cccode,cisshow,cggtype,xsprice,ghprice,cgprice,mname,csize,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@cname,@ccode,@ccname,@cccode,@cisshow,@cggtype,@xsprice,@ghprice,@cgprice,@mname,@csize,@maker,@cdate)");
            
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,20),
					new SqlParameter("@ccname", SqlDbType.NVarChar,30),
					new SqlParameter("@cccode", SqlDbType.NVarChar,20),
					new SqlParameter("@cisshow", SqlDbType.Bit,1),
					new SqlParameter("@cggtype", SqlDbType.NVarChar,10),
					new SqlParameter("@xsprice", SqlDbType.Money,8),
					new SqlParameter("@ghprice", SqlDbType.Money,8),
					new SqlParameter("@cgprice", SqlDbType.Money,8),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@csize", SqlDbType.NVarChar,300),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.ccname;
            parameters[3].Value = model.cccode;
            parameters[4].Value = model.cisshow;
            parameters[5].Value = model.cggtype;
            parameters[6].Value = model.xsprice;
            parameters[7].Value = model.ghprice;
            parameters[8].Value = model.cgprice;
            parameters[9].Value = model.mname;
            parameters[10].Value = model.csize;
            parameters[11].Value = model.maker;
            parameters[12].Value = model.cdate;
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
        public bool Update( Sys_Component model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Component set ");
            strSql.Append("cname=@cname,");
            strSql.Append("ccname=@ccname,");
            strSql.Append("cccode=@cccode,");
            strSql.Append("cisshow=@cisshow,");
            strSql.Append("cggtype=@cggtype,");
            strSql.Append("xsprice=@xsprice,");
            strSql.Append("ghprice=@ghprice,");
            strSql.Append("cgprice=@cgprice,");
            strSql.Append("mname=@mname,");
            strSql.Append("csize=@csize,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ccode=@ccode");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccname", SqlDbType.NVarChar,30),
					new SqlParameter("@cccode", SqlDbType.NVarChar,20),
					new SqlParameter("@cisshow", SqlDbType.Bit,1),
					new SqlParameter("@cggtype", SqlDbType.NVarChar,10),
					new SqlParameter("@xsprice", SqlDbType.Money,8),
					new SqlParameter("@ghprice", SqlDbType.Money,8),
					new SqlParameter("@cgprice", SqlDbType.Money,8),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@csize", SqlDbType.NVarChar,300),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ccode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.ccname;
            parameters[2].Value = model.cccode;
            parameters[3].Value = model.cisshow;
            parameters[4].Value = model.cggtype;
            parameters[5].Value = model.xsprice;
            parameters[6].Value = model.ghprice;
            parameters[7].Value = model.cgprice;
            parameters[8].Value = model.mname;
            parameters[9].Value = model.csize;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.ccode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
 
        public bool Delete(string ccode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_Component where cccode='{0}'", ccode);
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
        public  Sys_Component Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,cname,ccode,ccname,cccode,cisshow,cggtype,xsprice,ghprice,cgprice,mname,csize,maker,cdate from Sys_Component ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Component r = new Sys_Component();
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
        public  Sys_Component DataRowToModel(DataRow row)
        {
             Sys_Component model = new Sys_Component();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["cname"] != null)
                {
                    model.cname = row["cname"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["ccname"] != null)
                {
                    model.ccname = row["ccname"].ToString();
                }
                if (row["cccode"] != null)
                {
                    model.cccode = row["cccode"].ToString();
                }
                if (row["cisshow"] != null && row["cisshow"].ToString() != "")
                {
                    if ((row["cisshow"].ToString() == "1") || (row["cisshow"].ToString().ToLower() == "true"))
                    {
                        model.cisshow = true;
                    }
                    else
                    {
                        model.cisshow = false;
                    }
                }
                if (row["cggtype"] != null)
                {
                    model.cggtype = row["cggtype"].ToString();
                }
                if (row["xsprice"] != null && row["xsprice"].ToString() != "")
                {
                    model.xsprice = decimal.Parse(row["xsprice"].ToString());
                }
                if (row["ghprice"] != null && row["ghprice"].ToString() != "")
                {
                    model.ghprice = decimal.Parse(row["ghprice"].ToString());
                }
                if (row["cgprice"] != null && row["cgprice"].ToString() != "")
                {
                    model.cgprice = decimal.Parse(row["cgprice"].ToString());
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["csize"] != null)
                {
                    model.csize = row["csize"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Component> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,cname,ccode,ccname,cccode,cisshow,cggtype,xsprice,ghprice,cgprice,mname,csize,maker,cdate ");
            strSql.Append(" FROM Sys_Component ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_Component> r = new List<Sys_Component>();
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
        public int CreateCode(string where)
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int, ccode)),0) as n from Sys_Component ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int AddList(List<Sys_Component> model)
        {
            int r=0;
            StringBuilder strSql = new StringBuilder();
            int bcode=CreateCode("");
            if (model != null)
            {
                foreach(Sys_Component s in model)
                {
                    if (Exists(" and cname='" + s.cname + "' and mname='" + s.mname + "'"))
                    {
                        strSql.AppendFormat(" update Sys_Component set cisshow='{0}', cggtype='{1}',xsprice={2},ghprice={3},cgprice={4},csize='{5}' where cname='{6}' and mname='{7}';", s.cisshow, s.cggtype, s.xsprice, s.ghprice, s.cgprice, s.csize, s.cname, s.mname);
                    }
                    else
                    {
                        strSql.AppendFormat(" insert Sys_Component ( cname , ccode , ccname , cccode , cisshow , cggtype , xsprice , ghprice , cgprice , mname , csize , maker , cdate ) values ('{0}','{1}','{2}','{3}','{4}','{5}', {6} ,{7} ,{8} ,'{9}','{10}','{11}','{12}');",s.cname,bcode.ToString().PadLeft(4,'0'),s.ccname,s.cccode, s.cisshow, s.cggtype, s.xsprice, s.ghprice, s.cgprice,s.mname, s.csize, s.maker, s.cdate);
                        bcode++;
                    }
                }
            }
            if (strSql.ToString() != "")
            {
                try
                {
                    r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
                }
                catch
                {
                    r = -1;
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
