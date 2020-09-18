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
   public class B_GroupProductionCompnentDal:IB_GroupProductionCompnentDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_GroupProductionCompnent");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(B_GroupProductionCompnent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_GroupProductionCompnent(");
			strSql.Append("sid,gsid,psid,iname,icode,mname,ptype,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@gsid,@psid,@iname,@icode,@mname,@ptype,@cdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,50),
					new SqlParameter("@ptype", SqlDbType.NVarChar,50),
                    new SqlParameter("@ptypeex", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.gsid;
			parameters[2].Value = model.psid;
			parameters[3].Value = model.iname;
			parameters[4].Value = model.icode;
			parameters[5].Value = model.mname;
			parameters[6].Value = model.ptype;
            parameters[7].Value = model.ptypeex;
			parameters[8].Value = model.cdate;

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
		public bool Update(B_GroupProductionCompnent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_GroupProductionCompnent set ");
			strSql.Append("sid=@sid,");
			strSql.Append("gsid=@gsid,");
			strSql.Append("psid=@psid,");
			strSql.Append("iname=@iname,");
			strSql.Append("icode=@icode,");
			strSql.Append("mname=@mname,");
			strSql.Append("ptype=@ptype,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,50),
					new SqlParameter("@ptype", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.gsid;
			parameters[2].Value = model.psid;
			parameters[3].Value = model.iname;
			parameters[4].Value = model.icode;
			parameters[5].Value = model.mname;
			parameters[6].Value = model.ptype;
			parameters[7].Value = model.cdate;
			parameters[8].Value = model.id;

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
            strSql.AppendFormat("delete from B_GroupProductionCompnent where 1=1 {0}", where);
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
        public B_GroupProductionCompnent Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sid,gsid,psid,iname,icode,mname,ptype,ptypeex,cdate from B_GroupProductionCompnent ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_GroupProductionCompnent r = new B_GroupProductionCompnent();
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
		public B_GroupProductionCompnent DataRowToModel(DataRow row)
		{
			B_GroupProductionCompnent model=new B_GroupProductionCompnent();
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
				if(row["gsid"]!=null)
				{
					model.gsid=row["gsid"].ToString();
				}
				if(row["psid"]!=null)
				{
					model.psid=row["psid"].ToString();
				}
				if(row["iname"]!=null)
				{
					model.iname=row["iname"].ToString();
				}
				if(row["icode"]!=null)
				{
					model.icode=row["icode"].ToString();
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["ptype"]!=null)
				{
					model.ptype=row["ptype"].ToString();
				}
                if (row["ptypeex"] != null)
                {
                    model.ptypeex = row["ptypeex"].ToString();
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
        public List<B_GroupProductionCompnent> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sid,gsid,psid,iname,icode,mname,ptype,ptypeex,cdate ");
            strSql.Append(" FROM B_GroupProductionCompnent ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_GroupProductionCompnent> r = new List<B_GroupProductionCompnent>();
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
        public string QueryNameString(string where)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct( iname) ");
            strSql.Append(" FROM B_GroupProductionCompnent ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r=r+dr["iname"].ToString()+"/";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = null;
            }
            return r;
        }
        public string QueryMnameString(string where)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct( mname) ");
            strSql.Append(" FROM B_GroupProductionCompnent ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["mname"].ToString() + "/";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = null;
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
