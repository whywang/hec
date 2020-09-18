using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_SpecialProductionDal : IB_SpecialProductionDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_SpecialProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_SpecialProduction(");
            strSql.Append("sid,gsid,tjname,tjcode,tsprice,tgprice)");
            strSql.Append(" values (");
            strSql.Append("@sid,@gsid,@tjname,@tjcode,@tsprice,@tgprice)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@tjname", SqlDbType.NVarChar,30),
					new SqlParameter("@tjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tsprice", SqlDbType.Decimal,9),
					new SqlParameter("@tgprice", SqlDbType.Decimal,9)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.tjname;
            parameters[3].Value = model.tjcode;
            parameters[4].Value = model.tsprice;
            parameters[5].Value = model.tgprice;

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
        public bool Update( B_SpecialProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_SpecialProduction set ");
            strSql.Append("sid=@sid,");
            strSql.Append("tjname=@tjname,");
            strSql.Append("tjcode=@tjcode,");
            strSql.Append("tsprice=@tsprice,");
            strSql.Append("tgprice=@tgprice");
            strSql.Append(" where gsid=@gsid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@tjname", SqlDbType.NVarChar,30),
					new SqlParameter("@tjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tsprice", SqlDbType.Decimal,9),
					new SqlParameter("@tgprice", SqlDbType.Decimal,9),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.tjname;
            parameters[2].Value = model.tjcode;
            parameters[3].Value = model.tsprice;
            parameters[4].Value = model.tgprice;
            parameters[5].Value = model.gsid;

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
        public bool Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_SpecialProduction ");
            strSql.AppendFormat(" where 1=1 {0}",id);

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
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
        public  B_SpecialProduction Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,gsid,tjname,tjcode,tsprice,tgprice from B_SpecialProduction ");
            B_SpecialProduction r = new B_SpecialProduction();
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
        public  B_SpecialProduction DataRowToModel(DataRow row)
        {
             B_SpecialProduction model = new  B_SpecialProduction();
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
                if (row["tjname"] != null)
                {
                    model.tjname = row["tjname"].ToString();
                }
                if (row["tjcode"] != null)
                {
                    model.tjcode = row["tjcode"].ToString();
                }
                if (row["tsprice"] != null && row["tsprice"].ToString() != "")
                {
                    model.tsprice = decimal.Parse(row["tsprice"].ToString());
                }
                if (row["tgprice"] != null && row["tgprice"].ToString() != "")
                {
                    model.tgprice = decimal.Parse(row["tgprice"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_SpecialProduction> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,gsid,tjname,tjcode,tsprice,tgprice ");
            strSql.Append(" FROM B_SpecialProduction ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_SpecialProduction> r = new List<B_SpecialProduction>();
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
        #region//获取特价产品单项金额
        public decimal QueryItemPrice(string gsid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select isnull(sum(tgprice),0) as n from B_SpecialProduction where  gsid='{0}'", gsid);
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
        #endregion
        #region//获取特价产品总金额
        public decimal QueryAllPrice(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select isnull(sum(tgprice),0) as n from B_SpecialProduction where sid='{0}'", sid);
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
        #endregion
        #endregion  ExtensionMethod
    }
}
