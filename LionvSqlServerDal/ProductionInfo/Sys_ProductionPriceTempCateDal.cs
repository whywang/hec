using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public   class Sys_ProductionPriceTempCateDal : ISys_ProductionPriceTempCateDal
    {
        
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ppicode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionPriceTempCate");
            strSql.AppendFormat(" where 1=1 {0} ", ppicode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionPriceTempCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionPriceTempCate(");
            strSql.Append("ppiname,ppicode,ppms,maker,cdate,pread,ptype,dcode)");
            strSql.Append(" values (");
            strSql.Append("@ppiname,@ppicode,@ppms,@maker,@cdate,@pread,@ptype,@dcode)");
         
            SqlParameter[] parameters = {
					new SqlParameter("@ppiname", SqlDbType.NVarChar,30),
					new SqlParameter("@ppicode", SqlDbType.NVarChar,30),
					new SqlParameter("@ppms", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pread", SqlDbType.Bit,1),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ppiname;
            parameters[1].Value = model.ppicode;
            parameters[2].Value = model.ppms;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.pread;
            parameters[6].Value = model.ptype;
            parameters[7].Value = model.dcode;
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
        public bool Update(Sys_ProductionPriceTempCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionPriceTempCate set ");
            strSql.Append("ppiname=@ppiname,");
            strSql.Append("ppms=@ppms,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("pread=@pread,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("dcode=@dcode");
            strSql.Append(" where ppicode=@ppicode");
            SqlParameter[] parameters = {
					new SqlParameter("@ppiname", SqlDbType.NVarChar,30),
					new SqlParameter("@ppms", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@pread", SqlDbType.Bit,1),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@ppicode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.ppiname;
            parameters[1].Value = model.ppms;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.pread;
            parameters[5].Value = model.ptype;
            parameters[6].Value = model.dcode;
            parameters[7].Value = model.ppicode;

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
        public bool Delete(string ppicode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionPriceTempCate ");
            strSql.AppendFormat(" where ppicode='{0}'; ", ppicode);
            strSql.Append("delete from Sys_ProductionPriceTemp ");
            strSql.AppendFormat(" where ppcode='{0}' ; ", ppicode);
            strSql.Append("delete from Sys_RInventoryPriceTemp ");
            strSql.AppendFormat(" where ppcode='{0}' ; ", ppicode);
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
        public Sys_ProductionPriceTempCate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ppiname,ppicode,ppms,maker,cdate,pread,ptype,dcode from Sys_ProductionPriceTempCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionPriceTempCate r = new Sys_ProductionPriceTempCate();
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
        public Sys_ProductionPriceTempCate DataRowToModel(DataRow row)
        {
            Sys_ProductionPriceTempCate model = new Sys_ProductionPriceTempCate();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ppiname"] != null)
                {
                    model.ppiname = row["ppiname"].ToString();
                }
                if (row["ppicode"] != null)
                {
                    model.ppicode = row["ppicode"].ToString();
                }
                if (row["ppms"] != null)
                {
                    model.ppms = row["ppms"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
                if (row["pread"] != null && row["pread"].ToString() != "")
                {
                    if ((row["pread"].ToString() == "1") || (row["pread"].ToString().ToLower() == "true"))
                    {
                        model.pread = true;
                    }
                    else
                    {
                        model.pread = false;
                    }
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["dcode"] != null && row["dcode"].ToString() != "")
                {
                    model.dcode = row["dcode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionPriceTempCate> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ppiname,ppicode,ppms,maker,cdate ,pread,ptype,dcode");
            strSql.Append(" FROM Sys_ProductionPriceTempCate ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionPriceTempCate> r = new List<Sys_ProductionPriceTempCate>();
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
            sql = "select isnull(max(convert(int, ppicode)),0) as n from Sys_ProductionPriceTempCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetInvPtemp(string icode, string ptcode)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" delete from Sys_RInventoryPriceTemp where icode='{0}';", icode);
            strWhere.AppendFormat(" insert into Sys_RInventoryPriceTemp (icode,ppcode)values ('{0}','{1}');", icode, ptcode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strWhere.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetInvPtemp(string icode)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" delete from Sys_RInventoryPriceTemp where icode='{0}';", icode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strWhere.ToString(), null);
            if (rows > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetInvPtemp(string icode)
        {
            return LoopCate(icode);
        }
        private string LoopCate(string icode)
        {
            string r = "";
            if (icode.Length > 8)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 ppcode FROM Sys_RInventoryPriceTemp");
                strSql.AppendFormat(" where  icode='{0}'", icode);
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r = dt.Rows[0]["ppcode"].ToString();
                }
                else
                {
                    r = LoopCate(icode.Substring(0, icode.Length - 3));
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
