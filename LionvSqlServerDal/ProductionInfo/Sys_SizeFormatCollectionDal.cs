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
    public class Sys_SizeFormatCollectionDal : ISys_SizeFormatCollectionDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SizeFormatCollection");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SizeFormatCollection model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SizeFormatCollection(");
			strSql.Append("sfcname,sfccode,sfname,sfcode,bjpname,bjname,bjcode,bjtype,hstr,wstr,dstr,bjnum,bjattr,bjattrex,maker,cdate,bjtj,ftype)");
			strSql.Append(" values (");
            strSql.Append("@sfcname,@sfccode,@sfname,@sfcode,@bjpname,@bjname,@bjcode,@bjtype,@hstr,@wstr,@dstr,@bjnum,@bjattr,@bjattrex,@maker,@cdate,@bjtj,@ftype)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sfcname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfccode", SqlDbType.NVarChar,30),
					new SqlParameter("@sfname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bjpname", SqlDbType.NVarChar,30),
					new SqlParameter("@bjname", SqlDbType.NVarChar,30),
					new SqlParameter("@bjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bjtype", SqlDbType.NVarChar,30),
					new SqlParameter("@hstr", SqlDbType.NVarChar,100),
					new SqlParameter("@wstr", SqlDbType.NVarChar,100),
					new SqlParameter("@dstr", SqlDbType.NVarChar,100),
					new SqlParameter("@bjnum", SqlDbType.Int,4),
					new SqlParameter("@bjattr", SqlDbType.NVarChar,10),
					new SqlParameter("@bjattrex", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@bjtj", SqlDbType.NVarChar,10),
                    new SqlParameter("@ftype", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.sfcname;
			parameters[1].Value = model.sfccode;
			parameters[2].Value = model.sfname;
			parameters[3].Value = model.sfcode;
			parameters[4].Value = model.bjpname;
			parameters[5].Value = model.bjname;
			parameters[6].Value = model.bjcode;
			parameters[7].Value = model.bjtype;
			parameters[8].Value = model.hstr;
			parameters[9].Value = model.wstr;
			parameters[10].Value = model.dstr;
			parameters[11].Value = model.bjnum;
			parameters[12].Value = model.bjattr;
			parameters[13].Value = model.bjattrex;
			parameters[14].Value = model.maker;
			parameters[15].Value = model.cdate;
            parameters[16].Value = model.bjtj;
            parameters[17].Value = model.ftype;
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
		public bool Update( Sys_SizeFormatCollection model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SizeFormatCollection set ");
			strSql.Append("sfcname=@sfcname,");
			strSql.Append("sfccode=@sfccode,");
			strSql.Append("sfname=@sfname,");
			strSql.Append("sfcode=@sfcode,");
			strSql.Append("bjpname=@bjpname,");
			strSql.Append("bjname=@bjname,");
			strSql.Append("bjcode=@bjcode,");
			strSql.Append("bjtype=@bjtype,");
			strSql.Append("hstr=@hstr,");
			strSql.Append("wstr=@wstr,");
			strSql.Append("dstr=@dstr,");
			strSql.Append("bjnum=@bjnum,");
			strSql.Append("bjattr=@bjattr,");
			strSql.Append("bjattrex=@bjattrex,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sfcname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfccode", SqlDbType.NVarChar,30),
					new SqlParameter("@sfname", SqlDbType.NVarChar,30),
					new SqlParameter("@sfcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bjpname", SqlDbType.NVarChar,30),
					new SqlParameter("@bjname", SqlDbType.NVarChar,30),
					new SqlParameter("@bjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bjtype", SqlDbType.NVarChar,30),
					new SqlParameter("@hstr", SqlDbType.NVarChar,100),
					new SqlParameter("@wstr", SqlDbType.NVarChar,100),
					new SqlParameter("@dstr", SqlDbType.NVarChar,100),
					new SqlParameter("@bjnum", SqlDbType.Int,4),
					new SqlParameter("@bjattr", SqlDbType.NVarChar,10),
					new SqlParameter("@bjattrex", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sfcname;
			parameters[1].Value = model.sfccode;
			parameters[2].Value = model.sfname;
			parameters[3].Value = model.sfcode;
			parameters[4].Value = model.bjpname;
			parameters[5].Value = model.bjname;
			parameters[6].Value = model.bjcode;
			parameters[7].Value = model.bjtype;
			parameters[8].Value = model.hstr;
			parameters[9].Value = model.wstr;
			parameters[10].Value = model.dstr;
			parameters[11].Value = model.bjnum;
			parameters[12].Value = model.bjattr;
			parameters[13].Value = model.bjattrex;
			parameters[14].Value = model.maker;
			parameters[15].Value = model.cdate;
			parameters[16].Value = model.id;

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
		public bool Delete(string sfccode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Sys_SizeFormatCollection ");
            strSql.AppendFormat(" where sfccode='{0}' ;", sfccode);
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
        public Sys_SizeFormatCollection Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sfcname,sfccode,sfname,sfcode,bjpname,bjname,bjcode,bjtype,hstr,wstr,dstr,bjnum,bjattr,bjattrex,maker,cdate,bjtj ,ftype from Sys_SizeFormatCollection ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SizeFormatCollection r = new Sys_SizeFormatCollection();
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
		public  Sys_SizeFormatCollection DataRowToModel(DataRow row)
		{
			 Sys_SizeFormatCollection model=new  Sys_SizeFormatCollection();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sfcname"]!=null)
				{
					model.sfcname=row["sfcname"].ToString();
				}
				if(row["sfccode"]!=null)
				{
					model.sfccode=row["sfccode"].ToString();
				}
				if(row["sfname"]!=null)
				{
					model.sfname=row["sfname"].ToString();
				}
				if(row["sfcode"]!=null)
				{
					model.sfcode=row["sfcode"].ToString();
				}
				if(row["bjpname"]!=null)
				{
					model.bjpname=row["bjpname"].ToString();
				}
				if(row["bjname"]!=null)
				{
					model.bjname=row["bjname"].ToString();
				}
				if(row["bjcode"]!=null)
				{
					model.bjcode=row["bjcode"].ToString();
				}
				if(row["bjtype"]!=null)
				{
					model.bjtype=row["bjtype"].ToString();
				}
				if(row["hstr"]!=null)
				{
					model.hstr=row["hstr"].ToString();
				}
				if(row["wstr"]!=null)
				{
					model.wstr=row["wstr"].ToString();
				}
				if(row["dstr"]!=null)
				{
					model.dstr=row["dstr"].ToString();
				}
				if(row["bjnum"]!=null && row["bjnum"].ToString()!="")
				{
					model.bjnum=int.Parse(row["bjnum"].ToString());
				}
				if(row["bjattr"]!=null)
				{
					model.bjattr=row["bjattr"].ToString();
				}
				if(row["bjattrex"]!=null)
				{
					model.bjattrex=row["bjattrex"].ToString();
				}
                if (row["bjtj"] != null)
                {
                    model.bjtj = row["bjtj"].ToString();
                }
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["ftype"] != null)
                {
                    model.ftype = row["ftype"].ToString();
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
        public List<Sys_SizeFormatCollection> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sfcname,sfccode,sfname,sfcode,bjpname,bjname,bjcode,bjtype,hstr,wstr,dstr,bjnum,bjattr,bjattrex,maker,cdate,bjtj ,ftype");
            strSql.AppendFormat(" FROM Sys_SizeFormatCollection where 1=1 {0}", strWhere);
            List<Sys_SizeFormatCollection> r = new List<Sys_SizeFormatCollection>();
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
        public bool AddList(string sfccode,List<Sys_SizeFormatCollection>  lsc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_SizeFormatCollection ");
            strSql.AppendFormat(" where sfccode='{0}' ;", sfccode);
            if (lsc.Count() > 0)
            {
                foreach (Sys_SizeFormatCollection sc in lsc)
                {
                    strSql.Append("insert into  Sys_SizeFormatCollection (sfcname,sfccode,sfname,sfcode,bjpname,bjname,bjcode,bjtype,hstr,wstr,dstr,bjnum,bjattr,bjattrex,maker,cdate,bjtj,ftype) values ");
                    strSql.AppendFormat(" ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}','{16}','{17}');", sc.sfcname, sc.sfccode, sc.sfname, sc.sfcode, sc.bjpname, sc.bjname, sc.bjcode, sc.bjtype, sc.hstr, sc.wstr, sc.dstr, sc.bjnum, sc.bjattr, sc.bjattrex, sc.maker, sc.cdate, sc.bjtj,sc.ftype);
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
