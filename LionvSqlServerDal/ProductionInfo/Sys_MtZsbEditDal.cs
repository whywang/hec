using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_MtZsbEditDal : ISys_MtZsbEditDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_MtZsbEdit");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_MtZsbEdit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_MtZsbEdit(");
			strSql.Append("pcode,estate,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@pcode,@estate,@maker,@cdate)");
			 
			SqlParameter[] parameters = {
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@estate", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.pcode;
			parameters[1].Value = model.estate;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;

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
		public bool Update( Sys_MtZsbEdit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_MtZsbEdit set ");
			strSql.Append("pcode=@pcode,");
			strSql.Append("estate=@estate,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@estate", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.pcode;
			parameters[1].Value = model.estate;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.id;

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
		public bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_MtZsbEdit ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int)			};
            parameters[0].Value = id;

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
		/// 得到一个对象实体
		/// </summary>
        public Sys_MtZsbEdit Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pcode,estate,maker,cdate from Sys_MtZsbEdit ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_MtZsbEdit r = new Sys_MtZsbEdit();
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
		public  Sys_MtZsbEdit DataRowToModel(DataRow row)
		{
			 Sys_MtZsbEdit model=new  Sys_MtZsbEdit();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["pcode"]!=null)
				{
					model.pcode=row["pcode"].ToString();
				}
				if(row["estate"]!=null && row["estate"].ToString()!="")
				{
					model.estate=int.Parse(row["estate"].ToString());
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
        public List<Sys_MtZsbEdit> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,pcode,estate,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_MtZsbEdit where 1=1 {0}", strWhere);
            List<Sys_MtZsbEdit> r = new List<Sys_MtZsbEdit>();
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
        public bool Add(List<Sys_MtZsbEdit> model)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (Sys_MtZsbEdit m in model)
            {
                strSql.AppendFormat("delete from Sys_MtZsbEdit where pcode='{0}';", m.pcode);
                strSql.Append("insert into Sys_MtZsbEdit(");
                strSql.Append("pcode,estate,maker)");
                strSql.Append(" values (");
                strSql.AppendFormat("'{0}',{1},'{2}')", m.pcode, m.estate, m.maker);
            }
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
		#endregion  ExtensionMethod
    }
}
