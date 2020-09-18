using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionProcessCostPartDal : ISys_ProductionProcessCostPartDal
    {
        
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ProductionProcessCostPart");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_ProductionProcessCostPart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ProductionProcessCostPart(");
			strSql.Append("uname,ucode,bjtype)");
			strSql.Append(" values (");
            strSql.Append("@uname,@ucode,@bjtypee)");

			SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.NVarChar,30),
					new SqlParameter("@ucode", SqlDbType.NVarChar,30),
					new SqlParameter("@bjtype", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.uname;
			parameters[1].Value = model.ucode;
            parameters[2].Value = model.bjtype;

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
		public bool Update(Sys_ProductionProcessCostPart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ProductionProcessCostPart set ");
			strSql.Append("uname=@uname,");
			strSql.Append("ucode=@ucode,");
			strSql.Append("bjtype=@bjtype");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.NVarChar,30),
					new SqlParameter("@ucode", SqlDbType.NVarChar,30),
					new SqlParameter("@bjtype", SqlDbType.NVarChar,30),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.uname;
			parameters[1].Value = model.ucode;
			parameters[2].Value = model.bjtype;
			parameters[3].Value = model.id;

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
			strSql.Append("delete from Sys_ProductionProcessCostPart ");
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
        public Sys_ProductionProcessCostPart Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,uname,ucode,e_ptype from Sys_ProductionProcessCostPart ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionProcessCostPart r = new Sys_ProductionProcessCostPart();
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
		public Sys_ProductionProcessCostPart DataRowToModel(DataRow row)
		{
			Sys_ProductionProcessCostPart model=new Sys_ProductionProcessCostPart();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["uname"]!=null)
				{
					model.uname=row["uname"].ToString();
				}
				if(row["ucode"]!=null)
				{
					model.ucode=row["ucode"].ToString();
				}
				if(row["bjptype"]!=null)
				{
					model.bjtype=row["bjptype"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionProcessCostPart> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,uname,ucode,bjptype ");
            strSql.AppendFormat(" FROM Sys_ProductionProcessCostPart where 1=1 {0}", strWhere);
            List<Sys_ProductionProcessCostPart> r = new List<Sys_ProductionProcessCostPart>();
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
        public string QueryListStr(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,uname,ucode,bjtype ");
            strSql.AppendFormat(" FROM Sys_ProductionProcessCostPart where 1=1 {0}", strWhere);
            string r = "";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["bjtype"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = null;
            }
            return r;
        }
        public bool AddList(string uname, string ucode, string[] arr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_ProductionProcessCostPart where  ucode='{0}'; ", ucode);
            if (arr.Length > 0)
            {
                foreach (string s in arr)
                {
                    strSql.AppendFormat("insert into  Sys_ProductionProcessCostPart (uname,ucode,bjtype)values('{0}','{1}','{2}'); ",uname, ucode,s);
                }
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
