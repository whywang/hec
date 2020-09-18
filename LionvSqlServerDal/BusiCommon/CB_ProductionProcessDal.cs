using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiCommon
{
   public class CB_ProductionProcessDal : ICB_ProductionProcessDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CB_ProductionProcess");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( CB_ProductionProcess model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CB_ProductionProcess(");
			strSql.Append("sid,psid,gnum,iname,icode,lname,lcode,gname,gcode,nsort,bdate,odate,cdate,gstate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@psid,@gnum,@iname,@icode,@lname,@lcode,@gname,@gcode,@nsort,@bdate,@odate,@cdate,@gstate)");

			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@lname", SqlDbType.NVarChar,50),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,50),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@nsort", SqlDbType.Int,4),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@odate", SqlDbType.DateTime),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@gstate", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.psid;
			parameters[2].Value = model.gnum;
			parameters[3].Value = model.iname;
			parameters[4].Value = model.icode;
			parameters[5].Value = model.lname;
			parameters[6].Value = model.lcode;
			parameters[7].Value = model.gname;
			parameters[8].Value = model.gcode;
			parameters[9].Value = model.nsort;
			parameters[10].Value = model.bdate;
			parameters[11].Value = model.odate;
			parameters[12].Value = model.cdate;
			parameters[13].Value = model.gstate;

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
		public bool Update( CB_ProductionProcess model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CB_ProductionProcess set ");
			strSql.Append("odate=@odate,");
			strSql.Append("gstate=@gstate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@odate", SqlDbType.DateTime),
					new SqlParameter("@gstate", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};

			parameters[0].Value = model.odate;
			parameters[1].Value = model.gstate;
			parameters[2].Value = model.id;

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
			strSql.Append("delete from CB_ProductionProcess ");
            strSql.AppendFormat(" where 1=1 {0}  ", where);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
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
        public CB_ProductionProcess Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,psid,gnum,iname,icode,lname,lcode,gname,gcode,nsort,bdate,odate,cdate,gstate from CB_ProductionProcess ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_ProductionProcess r = new CB_ProductionProcess();
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
		public  CB_ProductionProcess DataRowToModel(DataRow row)
		{
			 CB_ProductionProcess model=new  CB_ProductionProcess();
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
				if(row["gnum"]!=null && row["gnum"].ToString()!="")
				{
					model.gnum=int.Parse(row["gnum"].ToString());
				}
				if(row["iname"]!=null)
				{
					model.iname=row["iname"].ToString();
				}
				if(row["icode"]!=null)
				{
					model.icode=row["icode"].ToString();
				}
				if(row["lname"]!=null)
				{
					model.lname=row["lname"].ToString();
				}
				if(row["lcode"]!=null)
				{
					model.lcode=row["lcode"].ToString();
				}
				if(row["gname"]!=null)
				{
					model.gname=row["gname"].ToString();
				}
				if(row["gcode"]!=null)
				{
					model.gcode=row["gcode"].ToString();
				}
				if(row["nsort"]!=null && row["nsort"].ToString()!="")
				{
					model.nsort=int.Parse(row["nsort"].ToString());
				}
				if(row["bdate"]!=null && row["bdate"].ToString()!="")
				{
					model.bdate=row["bdate"].ToString();
				}
				if(row["odate"]!=null && row["odate"].ToString()!="")
				{
					model.odate=row["odate"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
				if(row["gstate"]!=null && row["gstate"].ToString()!="")
				{
					model.gstate=int.Parse(row["gstate"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<CB_ProductionProcess> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,psid,gnum,iname,icode,lname,lcode,gname,gcode,nsort,bdate,odate,cdate,gstate ");
            strSql.AppendFormat(" FROM CB_ProductionProcess where 1=1 {0}", strWhere);
            List<CB_ProductionProcess> r = new List<CB_ProductionProcess>();
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
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_Tj_ProductionProcess", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
            if (dt != null)
            {
                r = dt;
            }
            else
            {
                r = null;
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
