using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AfterPartInHouseOrderDal : IB_AfterPartInHouseOrderDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_AfterPartInHouseOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_AfterPartInHouseOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_AfterPartInHouseOrder(");
			strSql.Append("sid,osid,pscode,scode,remark,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@osid,@pscode,@scode,@remark,@maker,@cdate);");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@pscode", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.pscode;
			parameters[3].Value = model.scode;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.maker;
			parameters[6].Value = model.cdate;
            strSql.Append(InsertSql(model.sid, model.osid, model.plist));
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
		public bool Update( B_AfterPartInHouseOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_AfterPartInHouseOrder set ");
			strSql.Append("osid=@osid,");
			strSql.Append("pscode=@pscode,");
			strSql.Append("scode=@scode,");
			strSql.Append("remark=@remark,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@pscode", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.osid;
			parameters[1].Value = model.pscode;
			parameters[2].Value = model.scode;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.id;
			parameters[7].Value = model.sid;

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
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_AfterPartInHouseOrder where 1=1 {0}", where);
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
		public  B_AfterPartInHouseOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,osid,pscode,scode,remark,maker,cdate from B_AfterPartInHouseOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterPartInHouseOrder r = new B_AfterPartInHouseOrder();
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
		public  B_AfterPartInHouseOrder DataRowToModel(DataRow row)
		{
			 B_AfterPartInHouseOrder model=new  B_AfterPartInHouseOrder();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["pscode"]!=null)
				{
					model.pscode=row["pscode"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterPartInHouseOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,osid,pscode,scode,remark,maker,cdate ");
			strSql.Append(" FROM B_AfterPartInHouseOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterPartInHouseOrder> r = new List<B_AfterPartInHouseOrder>();
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
        public int CreateNum(string sid, string plist)
        {
            int r = 0;
            string[] arrp = plist.Split(';');
            if (arrp.Length == QueryProductionNum(sid))
            {
                r = 0;
            }
            else
            {
                r=QueryOrderNum(sid);
            }
            return r;
        }
        private int QueryProductionNum(string sid)
        {
            int r = -1;
            string sql = "select  count(1)  as n from B_AfterGroupProduction where sid='" + sid + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 0:Convert.ToInt32(o);
            return r;
        }
        private int QueryOrderNum(string sid)
        {
            int r = -1;
            string sql = "select  count(1)  as n from B_AfterPartInHouseOrder where osid='" + sid + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 1 : Convert.ToInt32(o)+1;
            return r;
        }
        private string InsertSql(string sid,string osid, string plist)
        {
            string r = "";
            string[] arrp = plist.Split(';');
            StringBuilder sqlstr = new StringBuilder();
            foreach (string a in arrp)
            {
                sqlstr.AppendFormat(" insert into B_AfterPartInHouseProduction(sid,osid,psid) values('{0}','{1}','{2}');", sid, osid, a);
            }
            r = sqlstr.ToString();
            return r;
        }
		#endregion  ExtensionMethod
    }
}
