using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using LionvCommon;
using System.Data.SqlClient;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_WjPartGroupProductionDal : IB_WjPartGroupProductionDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_WjPartGroupProduction");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_WjPartGroupProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_WjPartGroupProduction(");
			strSql.Append("sid,osid,gsid,gnum,psid,icode,iname,inum,pnum,maker,cdate,uname)");
			strSql.Append(" values (");
			strSql.Append("@sid,@osid,@gsid,@gnum,@psid,@icode,@iname,@inum,@pnum,@maker,@cdate,@uname)");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@inum", SqlDbType.Decimal,9),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@uname", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.gsid;
			parameters[3].Value = model.gnum;
			parameters[4].Value = model.psid;
			parameters[5].Value = model.icode;
			parameters[6].Value = model.iname;
			parameters[7].Value = model.inum;
			parameters[8].Value = model.pnum;
			parameters[9].Value = model.maker;
			parameters[10].Value = model.cdate;
            parameters[11].Value = model.uname;

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
		public bool Update( B_WjPartGroupProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_WjPartGroupProduction set ");
			strSql.Append("sid=@sid,");
			strSql.Append("osid=@osid,");
			strSql.Append("gsid=@gsid,");
			strSql.Append("gnum=@gnum,");
			strSql.Append("icode=@icode,");
			strSql.Append("iname=@iname,");
			strSql.Append("inum=@inum,");
			strSql.Append("pnum=@pnum,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("uname=@uname");
            strSql.Append(" where psid=@psid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@inum", SqlDbType.Decimal,9),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@uname", SqlDbType.NVarChar,30),
					new SqlParameter("@psid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.gsid;
			parameters[3].Value = model.gnum;
			parameters[4].Value = model.icode;
			parameters[5].Value = model.iname;
			parameters[6].Value = model.inum;
			parameters[7].Value = model.pnum;
			parameters[8].Value = model.maker;
			parameters[9].Value = model.cdate;
			parameters[10].Value = model.uname;
            parameters[11].Value = model.psid;
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
            strSql.AppendFormat("delete from B_WjPartGroupProduction where 1=1 {0}", where);
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
		public  B_WjPartGroupProduction Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,osid,gsid,gnum,psid,icode,iname,inum,pnum,maker,cdate,uname from B_WjPartGroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_WjPartGroupProduction r = new B_WjPartGroupProduction();
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
		public  B_WjPartGroupProduction DataRowToModel(DataRow row)
		{
			 B_WjPartGroupProduction model=new  B_WjPartGroupProduction();
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
				if(row["gsid"]!=null)
				{
					model.gsid=row["gsid"].ToString();
				}
				if(row["gnum"]!=null && row["gnum"].ToString()!="")
				{
					model.gnum=int.Parse(row["gnum"].ToString());
				}
				if(row["psid"]!=null)
				{
					model.psid=row["psid"].ToString();
				}
				if(row["icode"]!=null)
				{
					model.icode=row["icode"].ToString();
				}
				if(row["iname"]!=null)
				{
					model.iname=row["iname"].ToString();
				}
				if(row["inum"]!=null && row["inum"].ToString()!="")
				{
					model.inum=decimal.Parse(row["inum"].ToString());
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
					model.cdate= row["cdate"].ToString();
				}
                if (row["uname"] != null)
                {
                    model.uname = row["uname"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_WjPartGroupProduction> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sid,osid,gsid,gnum,psid,icode,iname,inum,pnum,maker,cdate,uname ");
			strSql.Append(" FROM B_WjPartGroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_WjPartGroupProduction> r = new List<B_WjPartGroupProduction>();
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
        public bool CheckPrePareState(string sid,string fv)
        {
            bool r = false;
            string sql = "";
            sql = "select isnull(sum(" + fv + "),0) as n from B_WjPartGroupProduction where sid='" + sid + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? false : Convert.ToInt32(o)>0?false:true;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
