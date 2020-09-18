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
    public class Sys_CgNomalSizeDal : ISys_CgNomalSizeDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_CgNomalSize");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_CgNomalSize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_CgNomalSize(");
            strSql.Append("ncode,nname,ntype,olen,owid,odee,ofc,tlen,twid,tdee,cdate,maker,dcode)");
            strSql.Append(" values (");
            strSql.Append("@ncode,@nname,@ntype,@olen,@owid,@odee,@ofc,@tlen,@twid,@tdee,@cdate,@maker,@dcode)");
            SqlParameter[] parameters = {
					new SqlParameter("@ncode", SqlDbType.NVarChar,30),
					new SqlParameter("@nname", SqlDbType.NVarChar,30),
					new SqlParameter("@ntype", SqlDbType.NVarChar,20),
					new SqlParameter("@olen", SqlDbType.Decimal,9),
					new SqlParameter("@owid", SqlDbType.Decimal,9),
					new SqlParameter("@odee", SqlDbType.Decimal,9),
					new SqlParameter("@ofc", SqlDbType.Decimal,9),
					new SqlParameter("@tlen", SqlDbType.Decimal,9),
					new SqlParameter("@twid", SqlDbType.Decimal,9),
					new SqlParameter("@tdee", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.ncode;
            parameters[1].Value = model.nname;
            parameters[2].Value = model.ntype;
            parameters[3].Value = model.olen;
            parameters[4].Value = model.owid;
            parameters[5].Value = model.odee;
            parameters[6].Value = model.ofc;
            parameters[7].Value = model.tlen;
            parameters[8].Value = model.twid;
            parameters[9].Value = model.tdee;
            parameters[10].Value = model.cdate;
            parameters[11].Value = model.maker;
            parameters[12].Value = model.dcode;
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
        public bool Update( Sys_CgNomalSize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_CgNomalSize set ");
            strSql.Append("nname=@nname,");
            strSql.Append("ntype=@ntype,");
            strSql.Append("olen=@olen,");
            strSql.Append("owid=@owid,");
            strSql.Append("odee=@odee,");
            strSql.Append("ofc=@ofc,");
            strSql.Append("tlen=@tlen,");
            strSql.Append("twid=@twid,");
            strSql.Append("tdee=@tdee,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where ncode=@ncode");
            SqlParameter[] parameters = {
					new SqlParameter("@nname", SqlDbType.NVarChar,30),
					new SqlParameter("@ntype", SqlDbType.NVarChar,20),
					new SqlParameter("@olen", SqlDbType.Decimal,9),
					new SqlParameter("@owid", SqlDbType.Decimal,9),
					new SqlParameter("@odee", SqlDbType.Decimal,9),
					new SqlParameter("@ofc", SqlDbType.Decimal,9),
					new SqlParameter("@tlen", SqlDbType.Decimal,9),
					new SqlParameter("@twid", SqlDbType.Decimal,9),
					new SqlParameter("@tdee", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@ncode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.nname;
            parameters[1].Value = model.ntype;
            parameters[2].Value = model.olen;
            parameters[3].Value = model.owid;
            parameters[4].Value = model.odee;
            parameters[5].Value = model.ofc;
            parameters[6].Value = model.tlen;
            parameters[7].Value = model.twid;
            parameters[8].Value = model.tdee;
            parameters[9].Value = model.cdate;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.ncode;
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
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_CgNomalSize ");
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
        public  Sys_CgNomalSize Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ncode,nname,ntype,olen,owid,odee,ofc,tlen,twid,tdee,cdate,maker,dcode from Sys_CgNomalSize ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_CgNomalSize r = new Sys_CgNomalSize();
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
        public Sys_CgNomalSize DataRowToModel(DataRow row)
        {
            Sys_CgNomalSize model = new  Sys_CgNomalSize();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ncode"] != null)
                {
                    model.ncode = row["ncode"].ToString();
                }
                if (row["nname"] != null)
                {
                    model.nname = row["nname"].ToString();
                }
                if (row["ntype"] != null)
                {
                    model.ntype = row["ntype"].ToString();
                }
                if (row["olen"] != null && row["olen"].ToString() != "")
                {
                    model.olen = decimal.Parse(row["olen"].ToString());
                }
                if (row["owid"] != null && row["owid"].ToString() != "")
                {
                    model.owid = decimal.Parse(row["owid"].ToString());
                }
                if (row["odee"] != null && row["odee"].ToString() != "")
                {
                    model.odee = decimal.Parse(row["odee"].ToString());
                }
                if (row["ofc"] != null && row["ofc"].ToString() != "")
                {
                    model.ofc = decimal.Parse(row["ofc"].ToString());
                }
                if (row["tlen"] != null && row["tlen"].ToString() != "")
                {
                    model.tlen = decimal.Parse(row["tlen"].ToString());
                }
                if (row["twid"] != null && row["twid"].ToString() != "")
                {
                    model.twid = decimal.Parse(row["twid"].ToString());
                }
                if (row["tdee"] != null && row["tdee"].ToString() != "")
                {
                    model.tdee = decimal.Parse(row["tdee"].ToString());
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_CgNomalSize> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ncode,nname,ntype,olen,owid,odee,ofc,tlen,twid,tdee,cdate,maker,dcode ");
            strSql.AppendFormat(" FROM Sys_CgNomalSize where 1=1 {0}", where);
            List<Sys_CgNomalSize> r = new List<Sys_CgNomalSize>();
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
            sql = "select isnull(max(convert(int,ncode)),0) as n from Sys_CgNomalSize ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetProductionNs(string pcode, string ncode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryCgNomalSize where pcode like '{0}%';", pcode);
            sql.AppendFormat(" insert into Sys_RInventoryCgNomalSize (pcode,ncode) values ('{0}','{1}') ;", pcode, ncode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetProductionNs(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryCgNomalSize where pcode like '{0}%';", pcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetProductionNs(string pcode)
        {
            string r = "";
            r = LoodQuery(pcode);
            return r;
        }
        private string LoodQuery(string pcode)
        {
            string p = "";
            if (pcode.Length > 0)
            {

                string sql = "select ncode from Sys_RInventoryCgNomalSize where pcode='" + pcode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(pcode.Substring(0, pcode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
        #endregion  ExtensionMethod
    }
}
