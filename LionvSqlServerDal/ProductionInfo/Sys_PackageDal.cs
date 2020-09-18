using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvModel.ProductionInfo;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
   public  class Sys_PackageDal:ISys_PackageDal
    {
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Package");
			strSql.AppendFormat(" where 1=1 {0} ",where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_Package model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Package(");
			strSql.Append("pname,pcode,basenum,zjtype,istz,tznum,psort,maxnum,hlvalue,htvalue,klvalue,ktvalue,maker,cdate,cptype,dcode)");
			strSql.Append(" values (");
            strSql.Append("@pname,@pcode,@basenum,@zjtype,@istz,@tznum,@psort,@maxnum,@hlvalue,@htvalue,@klvalue,@ktvalue,@maker,@cdate,@cptype,@dcode)");
			SqlParameter[] parameters = {
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,20),
					new SqlParameter("@basenum", SqlDbType.Int,4),
					new SqlParameter("@zjtype", SqlDbType.NVarChar,30),
					new SqlParameter("@istz", SqlDbType.NVarChar,10),
					new SqlParameter("@tznum", SqlDbType.Int,4),
					new SqlParameter("@psort", SqlDbType.NVarChar,30),
					new SqlParameter("@maxnum", SqlDbType.Int,4),
					new SqlParameter("@hlvalue", SqlDbType.Int,4),
					new SqlParameter("@htvalue", SqlDbType.Int,4),
					new SqlParameter("@klvalue", SqlDbType.Int,4),
					new SqlParameter("@ktvalue", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@cptype",  SqlDbType.NVarChar,30),
					new SqlParameter("@dcode",  SqlDbType.NVarChar,30)};
			parameters[0].Value = model.pname;
			parameters[1].Value = model.pcode;
			parameters[2].Value = model.basenum;
			parameters[3].Value = model.zjtype;
			parameters[4].Value = model.istz;
			parameters[5].Value = model.tznum;
			parameters[6].Value = model.psort;
			parameters[7].Value = model.maxnum;
			parameters[8].Value = model.hlvalue;
			parameters[9].Value = model.htvalue;
			parameters[10].Value = model.klvalue;
			parameters[11].Value = model.ktvalue;
			parameters[12].Value = model.maker;
			parameters[13].Value = model.cdate;
            parameters[14].Value = model.cptype;
            parameters[15].Value = model.dcode;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            }
            catch
            {
                r = -1;
            }
            return r;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_Package model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Package set ");
			strSql.Append("pname=@pname,");
			strSql.Append("basenum=@basenum,");
			strSql.Append("zjtype=@zjtype,");
			strSql.Append("istz=@istz,");
			strSql.Append("tznum=@tznum,");
			strSql.Append("psort=@psort,");
			strSql.Append("maxnum=@maxnum,");
			strSql.Append("hlvalue=@hlvalue,");
			strSql.Append("htvalue=@htvalue,");
			strSql.Append("klvalue=@klvalue,");
			strSql.Append("ktvalue=@ktvalue,");
			strSql.Append("maker=@maker,");
            strSql.Append("cptype=@cptype,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where pcode=@pcode");
			SqlParameter[] parameters = {
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@basenum", SqlDbType.Int,4),
					new SqlParameter("@zjtype", SqlDbType.NVarChar,30),
					new SqlParameter("@istz", SqlDbType.NVarChar,10),
					new SqlParameter("@tznum", SqlDbType.Int,4),
					new SqlParameter("@psort", SqlDbType.NVarChar,30),
					new SqlParameter("@maxnum", SqlDbType.Int,4),
					new SqlParameter("@hlvalue", SqlDbType.Int,4),
					new SqlParameter("@htvalue", SqlDbType.Int,4),
					new SqlParameter("@klvalue", SqlDbType.Int,4),
					new SqlParameter("@ktvalue", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@cptype", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pcode", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.pname;
			parameters[1].Value = model.basenum;
			parameters[2].Value = model.zjtype;
			parameters[3].Value = model.istz;
			parameters[4].Value = model.tznum;
			parameters[5].Value = model.psort;
			parameters[6].Value = model.maxnum;
			parameters[7].Value = model.hlvalue;
			parameters[8].Value = model.htvalue;
			parameters[9].Value = model.klvalue;
			parameters[10].Value = model.ktvalue;
			parameters[11].Value = model.maker;
            parameters[12].Value = model.cptype;
			parameters[13].Value = model.cdate;
			parameters[14].Value = model.pcode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Package ");
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
		public Sys_Package Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,pname,pcode,basenum,zjtype,istz,tznum,psort,maxnum,hlvalue,htvalue,klvalue,ktvalue,maker,cdate,cptype,dcode from Sys_Package ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Package r = new Sys_Package();
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
		public Sys_Package DataRowToModel(DataRow row)
		{
			Sys_Package model=new Sys_Package();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["basenum"] != null && row["basenum"].ToString() != "")
                {
                    model.basenum = int.Parse(row["basenum"].ToString());
                }
                if (row["zjtype"] != null)
                {
                    model.zjtype = row["zjtype"].ToString();
                }
                if (row["istz"] != null)
                {
                    model.istz = row["istz"].ToString();
                }
                if (row["tznum"] != null && row["tznum"].ToString() != "")
                {
                    model.tznum = int.Parse(row["tznum"].ToString());
                }
                if (row["psort"] != null)
                {
                    model.psort = row["psort"].ToString();
                }
                if (row["maxnum"] != null && row["maxnum"].ToString() != "")
                {
                    model.maxnum = int.Parse(row["maxnum"].ToString());
                }
                if (row["hlvalue"] != null && row["hlvalue"].ToString() != "")
                {
                    model.hlvalue = int.Parse(row["hlvalue"].ToString());
                }
                if (row["htvalue"] != null && row["htvalue"].ToString() != "")
                {
                    model.htvalue = int.Parse(row["htvalue"].ToString());
                }
                if (row["klvalue"] != null && row["klvalue"].ToString() != "")
                {
                    model.klvalue = int.Parse(row["klvalue"].ToString());
                }
                if (row["ktvalue"] != null && row["ktvalue"].ToString() != "")
                {
                    model.ktvalue = int.Parse(row["ktvalue"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["cptype"] != null && row["cptype"].ToString() != "")
                {
                    model.cptype = row["cptype"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
            }
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Package> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,pname,pcode,basenum,zjtype,istz,tznum,psort,maxnum,hlvalue,htvalue,klvalue,ktvalue,maker,cdate,cptype,dcode  ");
            strSql.AppendFormat(" FROM Sys_Package where 1=1 {0}", strWhere);
            List<Sys_Package> r = new List<Sys_Package>();
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
            sql = "select isnull(max(convert(int,pcode)),0) as n from Sys_Package ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetInvPackage(string pcode, string icode,string[] ppcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryPackage where pcode= '{0}' and icode='{1}';", pcode,icode);
            for (int i = 0; i < ppcode.Length; i++)
            {
                sql.AppendFormat(" insert into Sys_RInventoryPackage (pcode,icode,ppcode) values ('{0}','{1}','{2}') ;", pcode, icode, ppcode[i]);
            }
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetInvPackage(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryPackage where pcode = '{0}';", pcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetInvPackage(string pcode, string icode)
        {
            string r = "";
            string sql = "select ppcode from Sys_RInventoryPackage where pcode='" + pcode + "' and icode='"+icode+"'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["ppcode"].ToString() + ";";
                }
                if (r.Length > 1)
                {
                    r = r.Substring(0, r.Length - 1);
                }
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}