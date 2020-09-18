using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;
using LionvCommon;
using System.Data.SqlClient;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_WjPreParePartGroupProductionDal : IB_WjPreParePartGroupProductionDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_WjPreParePartGroupProduction");
            strSql.AppendFormat(" where 1=1 {0}", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_WjPreParePartGroupProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_WjPreParePartGroupProduction(");
			strSql.Append(" sid,wsid,osid,iname,icode,pnum,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append(" @sid,@wsid,@osid,@iname,@icode,@pnum,@maker,@cdate)");
			SqlParameter[] parameters = {
			 
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@wsid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
 
			parameters[0].Value = model.sid;
			parameters[1].Value = model.wsid;
			parameters[2].Value = model.osid;
			parameters[3].Value = model.iname;
			parameters[4].Value = model.icode;
			parameters[5].Value = model.pnum;
			parameters[6].Value = model.maker;
			parameters[7].Value = model.cdate;

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
		public bool Update( B_WjPreParePartGroupProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_WjPreParePartGroupProduction set ");
			strSql.Append("sid=@sid,");
			strSql.Append("wsid=@wsid,");
			strSql.Append("osid=@osid,");
			strSql.Append("iname=@iname,");
			strSql.Append("icode=@icode,");
			strSql.Append("pnum=@pnum,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@wsid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
		 
			parameters[1].Value = model.sid;
			parameters[2].Value = model.wsid;
			parameters[3].Value = model.osid;
			parameters[4].Value = model.iname;
			parameters[5].Value = model.icode;
			parameters[6].Value = model.pnum;
			parameters[7].Value = model.maker;
			parameters[8].Value = model.cdate;
			parameters[9].Value = model.id;

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
		/// 批量删除数据
		/// </summary>
        public bool Delete(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_WjPreParePartGroupProduction where 1=1 {0}", where);
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
		public  B_WjPreParePartGroupProduction Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id, sid,wsid,osid,iname,icode,pnum,maker,cdate from B_WjPreParePartGroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_WjPreParePartGroupProduction r = new B_WjPreParePartGroupProduction();
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
		public  B_WjPreParePartGroupProduction DataRowToModel(DataRow row)
		{
			 B_WjPreParePartGroupProduction model=new  B_WjPreParePartGroupProduction();
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
				if(row["wsid"]!=null)
				{
					model.wsid=row["wsid"].ToString();
				}
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["iname"]!=null)
				{
					model.iname=row["iname"].ToString();
				}
				if(row["icode"]!=null)
				{
					model.icode=row["icode"].ToString();
				}
				if(row["pnum"]!=null && row["pnum"].ToString()!="")
				{
					model.pnum=decimal.Parse(row["pnum"].ToString());
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_WjPreParePartGroupProduction> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, sid,wsid,osid,iname,icode,pnum,maker,cdate ");
			strSql.Append(" FROM B_WjPreParePartGroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_WjPreParePartGroupProduction> r = new List<B_WjPreParePartGroupProduction>();
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
        public int QueryWjNum(string sid, string icode)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull( sum(pnum),0) as n  from B_WjPreParePartGroupProduction ");
            strSql.AppendFormat(" where osid='{0}' and icode='{1}'", sid,icode);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0]["n"].ToString());
            }
            return (int)r;
        }
		#endregion  ExtensionMethod
    }
}
