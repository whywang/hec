using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_GroupProductionAttrDal : IB_GroupProductionAttrDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_GroupProductionAttr");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
           
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_GroupProductionAttr model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_GroupProductionAttr(");
            strSql.Append("sid,gsid,acode,aname,amoney,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@gsid,@acode,@aname,@amoney,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@amoney", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.acode;
            parameters[3].Value = model.aname;
            parameters[4].Value = model.amoney;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;

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
        public bool Update( B_GroupProductionAttr model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_GroupProductionAttr set ");
            strSql.Append("sid=@sid,");
            strSql.Append("gsid=@gsid,");
            strSql.Append("acode=@acode,");
            strSql.Append("aname=@aname,");
            strSql.Append("amoney=@amoney,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@amoney", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.acode;
            parameters[3].Value = model.aname;
            parameters[4].Value = model.amoney;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.id;

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
            strSql.AppendFormat("delete from B_GroupProductionAttr where 1=1 {0}", where);
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
        public  B_GroupProductionAttr Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,gsid,acode,aname,amoney,maker,cdate from B_GroupProductionAttr ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_GroupProductionAttr r = new B_GroupProductionAttr();
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
        public  B_GroupProductionAttr DataRowToModel(DataRow row)
        {
             B_GroupProductionAttr model = new  B_GroupProductionAttr();
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
                if (row["gsid"] != null)
                {
                    model.gsid = row["gsid"].ToString();
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["amoney"] != null && row["amoney"].ToString() != "")
                {
                    model.amoney = decimal.Parse(row["amoney"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_GroupProductionAttr> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,gsid,acode,aname,amoney,maker,cdate ");
            strSql.Append(" FROM B_GroupProductionAttr ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_GroupProductionAttr> r = new List<B_GroupProductionAttr>();
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
        public int AddList(List<B_GroupProductionAttr> ml, string gsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete  FROM B_GroupProductionAttr where gsid='{0}';", gsid);
            if (ml != null)
            {
                foreach (B_GroupProductionAttr ba in ml)
                {
                    strSql.Append("insert into B_GroupProductionAttr ( sid , gsid , acode , aname , amoney , maker , cdate ) values");
                    strSql.AppendFormat("('{0}','{1}','{2}','{3}', {4} ,'{5}','{6}') ;",ba.sid,ba.gsid,ba.acode,ba.aname,ba.amoney,ba.maker,ba.cdate);
                }
            }
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            return rows;
        }
        public decimal QueryProductionMoney(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull(sum(amoney),0) as m from B_GroupProductionAttr ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            decimal r = 0;
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
