using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvModel.Account;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.Account
{
    public class Sys_BankDal : ISys_BankDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Bank");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_Bank model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Bank(");
			strSql.Append("bname)");
			strSql.Append(" values (");
			strSql.Append("@bname)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@bname", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.bname;

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
		public bool Update( Sys_Bank model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Bank set ");
			strSql.Append("bname=@bname");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@bname", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.bname;
			parameters[1].Value = model.id;

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
		public bool Delete(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from Sys_Bank where 1=1 {0}", where);
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
		public  Sys_Bank Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,bname from Sys_Bank ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Bank r = new Sys_Bank();
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
		public  Sys_Bank DataRowToModel(DataRow row)
		{
			 Sys_Bank model=new  Sys_Bank();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["bname"]!=null)
				{
					model.bname=row["bname"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Bank> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,bname ");
			strSql.Append(" FROM Sys_Bank ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_Bank> r = new List<Sys_Bank>();
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

		#endregion  ExtensionMethod
    }
}
