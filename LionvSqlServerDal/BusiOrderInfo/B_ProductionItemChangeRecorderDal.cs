using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvCommon;
using System.Data;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_ProductionItemChangeRecorderDal:IB_ProductionItemChangeRecorderDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_ProductionItemChangeRecorder");
             strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_ProductionItemChangeRecorder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_ProductionItemChangeRecorder(");
			strSql.Append("sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,aname,addattr,addsw,workline,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@psid,@pname,@pcode,@mname,@ptype,@height,@width,@deep,@pnum,@e_ptype,@aname,@addattr,@addsw,@workline,@maker,@cdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Int,4),
					new SqlParameter("@e_ptype", SqlDbType.NVarChar,20),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@addattr", SqlDbType.NVarChar,10),
					new SqlParameter("@addsw", SqlDbType.NVarChar,10),
					new SqlParameter("@workline", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.psid;
			parameters[2].Value = model.pname;
			parameters[3].Value = model.pcode;
			parameters[4].Value = model.mname;
			parameters[5].Value = model.ptype;
			parameters[6].Value = model.height;
			parameters[7].Value = model.width;
			parameters[8].Value = model.deep;
			parameters[9].Value = model.pnum;
			parameters[10].Value = model.e_ptype;
			parameters[11].Value = model.aname;
			parameters[12].Value = model.addattr;
			parameters[13].Value = model.addsw;
			parameters[14].Value = model.workline;
			parameters[15].Value = model.maker;
			parameters[16].Value = model.cdate;

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
		public bool Update( B_ProductionItemChangeRecorder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_ProductionItemChangeRecorder set ");
			strSql.Append("sid=@sid,");
			strSql.Append("psid=@psid,");
			strSql.Append("pname=@pname,");
			strSql.Append("pcode=@pcode,");
			strSql.Append("mname=@mname,");
			strSql.Append("ptype=@ptype,");
			strSql.Append("height=@height,");
			strSql.Append("width=@width,");
			strSql.Append("deep=@deep,");
			strSql.Append("pnum=@pnum,");
			strSql.Append("e_ptype=@e_ptype,");
			strSql.Append("aname=@aname,");
			strSql.Append("addattr=@addattr,");
			strSql.Append("addsw=@addsw,");
			strSql.Append("workline=@workline,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Int,4),
					new SqlParameter("@e_ptype", SqlDbType.NVarChar,20),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@addattr", SqlDbType.NVarChar,10),
					new SqlParameter("@addsw", SqlDbType.NVarChar,10),
					new SqlParameter("@workline", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.psid;
			parameters[2].Value = model.pname;
			parameters[3].Value = model.pcode;
			parameters[4].Value = model.mname;
			parameters[5].Value = model.ptype;
			parameters[6].Value = model.height;
			parameters[7].Value = model.width;
			parameters[8].Value = model.deep;
			parameters[9].Value = model.pnum;
			parameters[10].Value = model.e_ptype;
			parameters[11].Value = model.aname;
			parameters[12].Value = model.addattr;
			parameters[13].Value = model.addsw;
			parameters[14].Value = model.workline;
			parameters[15].Value = model.maker;
			parameters[16].Value = model.cdate;
			parameters[17].Value = model.id;

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
		/// 批量删除数据
		/// </summary>
        public bool Delete(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_ProductionItemChangeRecorder where 1=1 {0}", where);
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
        public B_ProductionItemChangeRecorder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,aname,addattr,addsw,workline,maker,cdate from B_ProductionItemChangeRecorder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_ProductionItemChangeRecorder r = new B_ProductionItemChangeRecorder();
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
		public  B_ProductionItemChangeRecorder DataRowToModel(DataRow row)
		{
			 B_ProductionItemChangeRecorder model=new  B_ProductionItemChangeRecorder();
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
				if(row["psid"]!=null)
				{
					model.psid=row["psid"].ToString();
				}
				if(row["pname"]!=null)
				{
					model.pname=row["pname"].ToString();
				}
				if(row["pcode"]!=null)
				{
					model.pcode=row["pcode"].ToString();
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["ptype"]!=null)
				{
					model.ptype=row["ptype"].ToString();
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
				if(row["e_ptype"]!=null)
				{
					model.e_ptype=row["e_ptype"].ToString();
				}
				if(row["aname"]!=null)
				{
					model.aname=row["aname"].ToString();
				}
				if(row["addattr"]!=null)
				{
					model.addattr=row["addattr"].ToString();
				}
				if(row["addsw"]!=null)
				{
					model.addsw=row["addsw"].ToString();
				}
				if(row["workline"]!=null)
				{
					model.workline=row["workline"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=DateTime.Parse(row["cdate"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_ProductionItemChangeRecorder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,aname,addattr,addsw,workline,maker,cdate ");
			strSql.Append(" FROM B_ProductionItemChangeRecorder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_ProductionItemChangeRecorder> r = new List<B_ProductionItemChangeRecorder>();
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
