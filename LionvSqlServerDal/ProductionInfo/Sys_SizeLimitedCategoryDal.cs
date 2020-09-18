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
    public   class Sys_SizeLimitedCategoryDal:ISys_SizeLimitedCategoryDal
	{
 
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_SizeLimitedCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SizeLimitedCategory(");
			strSql.Append("scname,sccode)");
			strSql.Append(" values (");
			strSql.Append("@scname,@sccode)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@scname", SqlDbType.NVarChar,30),
					new SqlParameter("@sccode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.scname;
			parameters[1].Value = model.sccode;

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
		public bool Update(Sys_SizeLimitedCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SizeLimitedCategory set ");
			strSql.Append("scname=@scname");
            strSql.Append(" where sccode=@sccode");
			SqlParameter[] parameters = {
					new SqlParameter("@scname", SqlDbType.NVarChar,30),
					new SqlParameter("@sccode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.scname;
			parameters[1].Value = model.sccode;

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
		public bool Delete(string sccode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Sys_SizeLimited ");
            strSql.AppendFormat(" where sccode='{0}';", sccode);
            strSql.Append("delete from Sys_RInventorySizeLimited ");
            strSql.AppendFormat(" where sccode='{0}';", sccode);
            strSql.Append("delete from Sys_SizeLimitedCategory ");
            strSql.AppendFormat(" where sccode='{0}';", sccode);
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
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_SizeLimitedCategory Query(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,scname,sccode from Sys_SizeLimitedCategory ");
			strSql.AppendFormat(" where 1=1 {0}",id);
			Sys_SizeLimitedCategory r=new Sys_SizeLimitedCategory();
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
		public Sys_SizeLimitedCategory DataRowToModel(DataRow row)
		{
			Sys_SizeLimitedCategory model=new Sys_SizeLimitedCategory();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["scname"]!=null)
				{
					model.scname=row["scname"].ToString();
				}
				if(row["sccode"]!=null)
				{
					model.sccode=row["sccode"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SizeLimitedCategory> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,scname,sccode ");
			strSql.Append(" FROM Sys_SizeLimitedCategory ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_SizeLimitedCategory> r = new List<Sys_SizeLimitedCategory>();
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
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(sccode),0) as n from Sys_SizeLimitedCategory ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetSizeLimitedCate(string icode, string sccode)
        {
           StringBuilder strSql=new StringBuilder();
           strSql.Append("delete from Sys_RInventorySizeLimited ");
           strSql.AppendFormat(" where icode='{0}';", icode);
           strSql.Append("insert into  Sys_RInventorySizeLimited ");
           strSql.AppendFormat(" (icode,sccode) values ('{0}','{1}') ;", icode,sccode);
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
        public bool ReSetSizeLimitedCate(string icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventorySizeLimited ");
            strSql.AppendFormat(" where icode='{0}';", icode);
 
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
        public string GetSizeLimitedCate(string icode)
        {
            string r = "";
            r = LoodQuery(icode);
            return r;
        }
        private string LoodQuery(string icode)
        {
            string p = "";
            if (icode.Length > 8)
            {

                string sql = "select sccode from Sys_RInventorySizeLimited where icode='" + icode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(icode.Substring(0, icode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
		#endregion  ExtensionMethod
	}
}
