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
  
    public  class Sys_ProductionTempCateDal:ISys_ProductionTempCateDal
	{
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ProductionTempCate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_ProductionTempCate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ProductionTempCate(");
			strSql.Append("ptcode,ptname,ptms,ptattr,maker,cdate,pread,ptype,dcode,pisbk)");
			strSql.Append(" values (");
            strSql.Append("@ptcode,@ptname,@ptms,@ptattr,@maker,@cdate,@pread,@ptype,@dcode,@pisbk)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@ptcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptms", SqlDbType.NVarChar,100),
					new SqlParameter("@ptattr", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pread", SqlDbType.Bit,1),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
                    new SqlParameter("@pisbk", SqlDbType.Bit,1)};
			parameters[0].Value = model.ptcode;
			parameters[1].Value = model.ptname;
			parameters[2].Value = model.ptms;
			parameters[3].Value = model.ptattr;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
            parameters[6].Value = model.pread;
            parameters[7].Value = model.ptype;
            parameters[8].Value = model.dcode;
            parameters[9].Value = model.pisbk;
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
		public bool Update(Sys_ProductionTempCate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ProductionTempCate set ");
			strSql.Append("ptname=@ptname,");
			strSql.Append("ptms=@ptms,");
			strSql.Append("ptattr=@ptattr,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("pread=@pread,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("pisbk=@pisbk");
            strSql.Append(" where ptcode=@ptcode");
			SqlParameter[] parameters = {
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptms", SqlDbType.NVarChar,100),
					new SqlParameter("@ptattr", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pread", SqlDbType.Bit,1),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
                    new SqlParameter("@pisbk", SqlDbType.Bit,1),
                    new SqlParameter("@ptcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.ptname;
			parameters[1].Value = model.ptms;
			parameters[2].Value = model.ptattr;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
            parameters[5].Value = model.pread;
            parameters[6].Value = model.ptype;
            parameters[7].Value = model.dcode;
            parameters[8].Value = model.pisbk;
            parameters[9].Value = model.ptcode;
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
		public bool Delete(string ptcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_ProductionTempCate ");
            strSql.AppendFormat(" where ptcode='{0}' ; ", ptcode);
            strSql.Append("delete from Sys_ProductionTemp ");
            strSql.AppendFormat(" where ptcode='{0}' ; ", ptcode);
            strSql.Append("delete from Sys_RInventoryProductionTemp ");
            strSql.AppendFormat(" where ptcode='{0}' ; ", ptcode);
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
		public Sys_ProductionTempCate Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ptcode,ptname,ptms,ptattr,maker,cdate,pread,ptype,dcode,pisbk from Sys_ProductionTempCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionTempCate r = new Sys_ProductionTempCate();
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
		public Sys_ProductionTempCate DataRowToModel(DataRow row)
		{
			Sys_ProductionTempCate model=new Sys_ProductionTempCate();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ptcode"]!=null)
				{
					model.ptcode=row["ptcode"].ToString();
				}
				if(row["ptname"]!=null)
				{
					model.ptname=row["ptname"].ToString();
				}
				if(row["ptms"]!=null)
				{
					model.ptms=row["ptms"].ToString();
				}
				if(row["ptattr"]!=null)
				{
					model.ptattr=row["ptattr"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString() ;
				}
                if (row["pread"] != null && row["pread"].ToString() != "")
                {
                    if ((row["pread"].ToString() == "1") || (row["pread"].ToString().ToLower() == "true"))
                    {
                        model.pread = true;
                    }
                    else
                    {
                        model.pread = false;
                    }
                }
                if (row["pisbk"] != null && row["pisbk"].ToString() != "")
                {
                    if ((row["pisbk"].ToString() == "1") || (row["pisbk"].ToString().ToLower() == "true"))
                    {
                        model.pisbk = true;
                    }
                    else
                    {
                        model.pisbk = false;
                    }
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["dcode"] != null && row["dcode"].ToString() != "")
                {
                    model.dcode = row["dcode"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionTempCate> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,ptcode,ptname,ptms,ptattr,maker,cdate,pread,ptype,dcode,pisbk ");
			strSql.Append(" FROM Sys_ProductionTempCate ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionTempCate> r = new List<Sys_ProductionTempCate>();
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
        public int CreateCode(string where)
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int, ptcode)),0) as n from Sys_ProductionTempCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetInvTempCate(string icode, string ptcode)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" delete from Sys_RInventoryProductionTemp where icode='{0}';", icode);
            strWhere.AppendFormat(" insert into Sys_RInventoryProductionTemp (icode,ptcode)values ('{0}','{1}');", icode, ptcode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strWhere.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetInvTempCate(string icode)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" delete from Sys_RInventoryProductionTemp where icode='{0}';", icode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strWhere.ToString(), null);
            if (rows > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetInvTempCate(string icode)
        {
            return LoopCate(icode);
        }
        private string LoopCate(string icode)
        {
            string r = "";
            if (icode.Length > 8)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 ptcode FROM Sys_RInventoryProductionTemp");
                strSql.AppendFormat(" where  icode='{0}'", icode);
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r = dt.Rows[0]["ptcode"].ToString();
                }
                else
                {
                    r=LoopCate(icode.Substring(0, icode.Length - 3));
                }
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
