using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
   public class Sys_SizeFormatPartAttrDal:ISys_SizeFormatPartAttrDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SizeFormatPartAttr");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
	
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SizeFormatPartAttr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SizeFormatPartAttr(");
			strSql.Append("tname,tabc)");
			strSql.Append(" values (");
			strSql.Append("@tname,@tabc)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tabc", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.tname;
			parameters[1].Value = model.tabc;

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
		public bool Update( Sys_SizeFormatPartAttr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SizeFormatPartAttr set ");
			strSql.Append("tname=@tname,");
			strSql.Append("tabc=@tabc");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tabc", SqlDbType.NVarChar,30),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.tname;
			parameters[1].Value = model.tabc;
			parameters[2].Value = model.id;

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
			strSql.Append("delete from Sys_SizeFormatPartAttr ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Sys_SizeFormatPartAttr Query(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,tname,tabc from Sys_SizeFormatPartAttr ");
            strSql.AppendFormat("   where 1=1 {0}", strWhere);
            Sys_SizeFormatPartAttr r = new Sys_SizeFormatPartAttr();
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
		public  Sys_SizeFormatPartAttr DataRowToModel(DataRow row)
		{
			 Sys_SizeFormatPartAttr model=new  Sys_SizeFormatPartAttr();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["tname"]!=null)
				{
					model.tname=row["tname"].ToString();
				}
				if(row["tabc"]!=null)
				{
					model.tabc=row["tabc"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SizeFormatPartAttr> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,tname,tabc ");
			strSql.Append(" FROM Sys_SizeFormatPartAttr ");
            strSql.AppendFormat("   where 1=1 {0}", strWhere);
            List<Sys_SizeFormatPartAttr> r = new List<Sys_SizeFormatPartAttr>();
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
