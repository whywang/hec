﻿using System;
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
    public class B_PartQualityItemsDal : IB_PartQualityItemsDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_PartQualityItems");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_PartQualityItems model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_PartQualityItems(");
			strSql.Append("qsid,sid,psid,gnum,pname,pcode,height,width,deep,pnum,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@qsid,@sid,@psid,@gnum,@pname,@pcode,@height,@width,@deep,@pnum,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@qsid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.qsid;
			parameters[1].Value = model.sid;
			parameters[2].Value = model.psid;
			parameters[3].Value = model.gnum;
			parameters[4].Value = model.pname;
			parameters[5].Value = model.pcode;
			parameters[6].Value = model.height;
			parameters[7].Value = model.width;
			parameters[8].Value = model.deep;
			parameters[9].Value = model.pnum;
			parameters[10].Value = model.maker;
			parameters[11].Value = model.cdate;

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
		public bool Update( B_PartQualityItems model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_PartQualityItems set ");
			strSql.Append("qsid=@qsid,");
			strSql.Append("sid=@sid,");
			strSql.Append("psid=@psid,");
			strSql.Append("gnum=@gnum,");
			strSql.Append("pname=@pname,");
			strSql.Append("pcode=@pcode,");
			strSql.Append("height=@height,");
			strSql.Append("width=@width,");
			strSql.Append("deep=@deep,");
			strSql.Append("pnum=@pnum,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@qsid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.qsid;
			parameters[1].Value = model.sid;
			parameters[2].Value = model.psid;
			parameters[3].Value = model.gnum;
			parameters[4].Value = model.pname;
			parameters[5].Value = model.pcode;
			parameters[6].Value = model.height;
			parameters[7].Value = model.width;
			parameters[8].Value = model.deep;
			parameters[9].Value = model.pnum;
			parameters[10].Value = model.maker;
			parameters[11].Value = model.cdate;
			parameters[12].Value = model.id;

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
            strSql.AppendFormat("delete from B_PartQualityItems where 1=1 {0}", where);
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
        public B_PartQualityItems Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,qsid,sid,psid,gnum,pname,pcode,height,width,deep,pnum,maker,cdate from B_PartQualityItems ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_PartQualityItems r = new B_PartQualityItems();
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
		public  B_PartQualityItems DataRowToModel(DataRow row)
		{
			 B_PartQualityItems model=new  B_PartQualityItems();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["qsid"]!=null)
				{
					model.qsid=row["qsid"].ToString();
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["psid"]!=null)
				{
					model.psid=row["psid"].ToString();
				}
				if(row["gnum"]!=null && row["gnum"].ToString()!="")
				{
					model.gnum=int.Parse(row["gnum"].ToString());
				}
				if(row["pname"]!=null)
				{
					model.pname=row["pname"].ToString();
				}
				if(row["pcode"]!=null)
				{
					model.pcode=row["pcode"].ToString();
				}
				if(row["height"]!=null && row["height"].ToString()!="")
				{
					model.height=int.Parse(row["height"].ToString());
				}
				if(row["width"]!=null && row["width"].ToString()!="")
				{
					model.width=int.Parse(row["width"].ToString());
				}
				if(row["deep"]!=null && row["deep"].ToString()!="")
				{
					model.deep=int.Parse(row["deep"].ToString());
				}
				if(row["pnum"]!=null && row["pnum"].ToString()!="")
				{
					model.pnum=int.Parse(row["pnum"].ToString());
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
        public List<B_PartQualityItems> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,qsid,sid,psid,gnum,pname,pcode,height,width,deep,pnum,maker,cdate ");
			strSql.Append(" FROM B_PartQualityItems ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_PartQualityItems> r = new List<B_PartQualityItems>();
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
