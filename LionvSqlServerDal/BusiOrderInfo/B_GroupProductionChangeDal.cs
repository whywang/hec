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
   public class B_GroupProductionChangeDal:IB_GroupProductionChangeDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_GroupProductionChange");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
      
	 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_GroupProductionChange model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_GroupProductionChange where sid='{0}' and gnum={1};",model.sid,model.gnum);
			strSql.Append("insert into B_GroupProductionChange(");
			strSql.Append("sid,osid,gnum,gsid,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@osid,@gnum,@gsid,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.gnum;
			parameters[3].Value = model.gsid;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;

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
		public bool Update( B_GroupProductionChange model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_GroupProductionChange set ");
			strSql.Append("sid=@sid,");
			strSql.Append("osid=@osid,");
			strSql.Append("gnum=@gnum,");
			strSql.Append("gsid=@gsid,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.gnum;
			parameters[3].Value = model.gsid;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.id;

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
            strSql.AppendFormat("delete from B_GroupProductionChange where 1=1 {0}", where);
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
        public B_GroupProductionChange Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,osid,gnum,gsid,maker,cdate from B_GroupProductionChange ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_GroupProductionChange r = new B_GroupProductionChange();
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
		public  B_GroupProductionChange DataRowToModel(DataRow row)
		{
			 B_GroupProductionChange model=new  B_GroupProductionChange();
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
				if(row["gnum"]!=null && row["gnum"].ToString()!="")
				{
					model.gnum=int.Parse(row["gnum"].ToString());
				}
				if(row["gsid"]!=null)
				{
					model.gsid=row["gsid"].ToString();
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
        public List<B_GroupProductionChange> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,osid,gnum,gsid,maker,cdate ");
			strSql.Append(" FROM B_GroupProductionChange ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_GroupProductionChange> r = new List<B_GroupProductionChange>();
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

		#endregion  ExtensionMethod
    }
}
