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
    public class Sys_SaleDiscountDal:ISys_SaleDiscountDal
    {
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_SaleDiscount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SaleDiscount(");
            strSql.Append("dname,dcode,dbdate,dedate,dtype,drange,dproduction,cdate,maker,remark)");
            strSql.Append(" values (");
            strSql.Append("@dname,@dcode,@dbdate,@dedate,@dtype,@drange,@dproduction,@cdate,@maker,@remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@dbdate", SqlDbType.DateTime),
					new SqlParameter("@dedate", SqlDbType.DateTime),
					new SqlParameter("@dtype", SqlDbType.NVarChar,20),
					new SqlParameter("@drange", SqlDbType.NVarChar,5),
					new SqlParameter("@dproduction", SqlDbType.NVarChar,5),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.dbdate;
            parameters[3].Value = model.dedate;
            parameters[4].Value = model.dtype;
            parameters[5].Value = model.drange;
            parameters[6].Value = model.dproduction;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.remark;
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
        public bool Update( Sys_SaleDiscount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SaleDiscount set ");
            strSql.Append("dname=@dname,");
            strSql.Append("dbdate=@dbdate,");
            strSql.Append("dedate=@dedate,");
            strSql.Append("dtype=@dtype,");
            strSql.Append("remark=@remark,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where dcode=@dcode");
            SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dbdate", SqlDbType.DateTime),
					new SqlParameter("@dedate", SqlDbType.DateTime),
					new SqlParameter("@dtype", SqlDbType.NVarChar,20),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dbdate;
            parameters[2].Value = model.dedate;
            parameters[3].Value = model.dtype;
            parameters[4].Value = model.remark;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.dcode;

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
        public bool Delete(string dcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_RInventorySaleDiscount where dcode='{0}'; ",dcode);
            strSql.AppendFormat("delete from Sys_RDepSaleDiscount where dcode='{0}'; ", dcode);
            strSql.AppendFormat("delete from Sys_SaleDiscountCondition where dcode='{0}'; ", dcode);
            strSql.AppendFormat("delete from Sys_SaleDiscount where  dcode='{0}'; ", dcode);

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
        public  Sys_SaleDiscount Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,dname,dcode,dbdate,dedate,dtype,drange,dproduction,cdate,maker,remark from Sys_SaleDiscount ");
            strSql.AppendFormat(" where  1=1 {0}",where);
             Sys_SaleDiscount r = new Sys_SaleDiscount();
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
        public  Sys_SaleDiscount DataRowToModel(DataRow row)
        {
             Sys_SaleDiscount model = new  Sys_SaleDiscount();
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
                if (row["dbdate"] != null && row["dbdate"].ToString() != "")
                {
                    model.dbdate =row["dbdate"].ToString();
                }
                if (row["dedate"] != null && row["dedate"].ToString() != "")
                {
                    model.dedate = row["dedate"].ToString();
                }
                if (row["dtype"] != null)
                {
                    model.dtype = row["dtype"].ToString();
                }
                if (row["drange"] != null)
                {
                    model.drange = row["drange"].ToString();
                }
                if (row["dproduction"] != null)
                {
                    model.dproduction = row["dproduction"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SaleDiscount> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,dname,dcode,dbdate,dedate,dtype,drange,dproduction,cdate,maker,remark ");
            strSql.AppendFormat(" FROM Sys_SaleDiscount where 1=1 {0}",strWhere);
            List<Sys_SaleDiscount> r = new List<Sys_SaleDiscount>();
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
            string sql = "select isnull(max(convert(int,dcode)),0) as n from Sys_SaleDiscount ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetProdctionDiscount(string dcode,string icode,string []pcodes)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_RInventorySaleDiscount where dcode='{0}' and icode='{1}'; ", dcode, icode);
            for (int i = 0; i < pcodes.Length; i++)
            {
                strSql.AppendFormat("insert into Sys_RInventorySaleDiscount (dcode,icode,pcode) values('{0}','{1}','{2}'); ",dcode,icode,pcodes[i]);
            }
            if (pcodes.Length > 0)
            {
                strSql.Append("Update Sys_SaleDiscount set dproduction='1' where dcode='" + dcode + "'; ");
            }
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int ReSetProdctionDiscount(string dcode ,string icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventorySaleDiscount where dcode='" + dcode + "' and icode='"+icode+"'; ");
            if (!CheckProductionDiscount(dcode))
            {
                strSql.Append("Update Sys_SaleDiscount set dproduction='0' where dcode='" + dcode + "'; ");
            }
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private bool CheckProductionDiscount(string dcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_RInventorySaleDiscount");
            strSql.AppendFormat(" where dcode='{0}' ", dcode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        public string GetProdctionDiscount(string dcode,string icode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select pcode from Sys_RInventorySaleDiscount where dcode='" + dcode + "' and icode='"+icode+"'; ");
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r=r+dr["pcode"].ToString()+";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = null;
            }
            return r;
        }
        public bool CheckProductionDiscount(string dcode,string pcode)
        {
            bool r=false;
            StringBuilder strSql = new StringBuilder();
            if (pcode!="")
            {
                strSql.Append(" select dcode from Sys_RInventorySaleDiscount where dcode='" + dcode + "' and pcode='"+pcode+"' ");
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r= true;
                }
            }
            return r;
        }
        public int SetDepDiscount(string sdcode, string[] dcodes)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RDepSaleDiscount where sdcode='" + sdcode + "'; ");
            for (int i = 0; i < dcodes.Length; i++)
            {
                strSql.Append("insert into Sys_RDepSaleDiscount (sdcode,dcode) values('" + sdcode + "','" + dcodes[i] + "'); ");
            }
            if (dcodes.Length > 0)
            {
                strSql.Append("Update Sys_SaleDiscount set drange='1' where dcode='" + sdcode + "'; ");
            }
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int ReSetDepDiscount(string dcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RDepSaleDiscount where sdcode='" + dcode + "'; ");
            strSql.Append("Update Sys_SaleDiscount set drange='0' where dcode='" + dcode + "'; ");
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string GetDepDiscount(string dcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select dcode from Sys_RDepSaleDiscount where sdcode='" + dcode + "'; ");
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r =r+ dr["dcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = null;
            }
            return r;
        }
        public ArrayList QueryLoopSaleDiscount(string dcode)
        {
            ArrayList r = new ArrayList ();
            StringBuilder strSql = new StringBuilder();
            if (dcode.Length > 2)
            {
                strSql.Append(" select sdcode from Sys_RDepSaleDiscount where dcode='" + dcode + "'; ");
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                         r.Add( dr["sdcode"].ToString());
                    }
                    QueryLoop(dcode.Substring(0,dcode.Length-2), ref  r);
                }
                else
                {
                    QueryLoop(dcode.Substring(0, dcode.Length -2), ref  r);
                }
            }
            return r;
        }
        public ArrayList QueryLoop(string dcode,ref ArrayList r )
        {
            StringBuilder strSql = new StringBuilder();
            if (dcode.Length > 2)
            {
                strSql.Append(" select sdcode from Sys_RDepSaleDiscount where dcode='" + dcode + "'; ");
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        r.Add(dr["sdcode"].ToString());
                    }
                    QueryLoop(dcode.Substring(0, dcode.Length - 2), ref  r);
                }
                else
                {
                    QueryLoop(dcode.Substring(0, dcode.Length - 2), ref  r);
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
