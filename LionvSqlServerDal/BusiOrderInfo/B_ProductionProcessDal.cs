using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_ProductionProcessDal:IB_ProductionProcessDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_ProductionProcess");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_ProductionProcess model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_ProductionProcess(");
			strSql.Append("sid,gsid,psid,iname,icode,lname,lcode,gname,gcode,nsort,usetime,fusetime,bdate,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@gsid,@psid,@iname,@icode,@lname,@lcode,@gname,@gcode,@nsort,@usetime,@fusetime,@bdate,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@nsort", SqlDbType.Int,4),
					new SqlParameter("@usetime", SqlDbType.Int,4),
					new SqlParameter("@fusetime", SqlDbType.Int,4),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.gsid;
			parameters[2].Value = model.psid;
			parameters[3].Value = model.iname;
			parameters[4].Value = model.icode;
			parameters[5].Value = model.lname;
			parameters[6].Value = model.lcode;
			parameters[7].Value = model.gname;
			parameters[8].Value = model.gcode;
			parameters[9].Value = model.nsort;
			parameters[10].Value = model.usetime;
			parameters[11].Value = model.fusetime;
			parameters[12].Value = model.bdate;
			parameters[13].Value = model.cdate;

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
		public bool Update( B_ProductionProcess model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_ProductionProcess set ");
			strSql.Append("sid=@sid,");
			strSql.Append("gsid=@gsid,");
			strSql.Append("psid=@psid,");
			strSql.Append("iname=@iname,");
			strSql.Append("icode=@icode,");
			strSql.Append("lname=@lname,");
			strSql.Append("lcode=@lcode,");
			strSql.Append("gname=@gname,");
			strSql.Append("gcode=@gcode,");
			strSql.Append("nsort=@nsort,");
			strSql.Append("usetime=@usetime,");
			strSql.Append("fusetime=@fusetime,");
			strSql.Append("bdate=@bdate,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@nsort", SqlDbType.Int,4),
					new SqlParameter("@usetime", SqlDbType.Int,4),
					new SqlParameter("@fusetime", SqlDbType.Int,4),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.gsid;
			parameters[2].Value = model.psid;
			parameters[3].Value = model.iname;
			parameters[4].Value = model.icode;
			parameters[5].Value = model.lname;
			parameters[6].Value = model.lcode;
			parameters[7].Value = model.gname;
			parameters[8].Value = model.gcode;
			parameters[9].Value = model.nsort;
			parameters[10].Value = model.usetime;
			parameters[11].Value = model.fusetime;
			parameters[12].Value = model.bdate;
			parameters[13].Value = model.cdate;
			parameters[14].Value = model.id;

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
            strSql.AppendFormat("delete from B_ProductionProcess where 1=1 {0}", where);
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
        public B_ProductionProcess Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,gsid,psid,iname,icode,lname,lcode,gname,gcode,nsort,usetime,fusetime,bdate,cdate,fname,fcode from B_ProductionProcess ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_ProductionProcess r = new B_ProductionProcess();
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
		public  B_ProductionProcess DataRowToModel(DataRow row)
		{
			 B_ProductionProcess model=new  B_ProductionProcess();
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
				if(row["gsid"]!=null)
				{
					model.gsid=row["gsid"].ToString();
				}
				if(row["psid"]!=null)
				{
					model.psid=row["psid"].ToString();
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
				if(row["usetime"]!=null && row["usetime"].ToString()!="")
				{
					model.usetime=int.Parse(row["usetime"].ToString());
				}
				if(row["fusetime"]!=null && row["fusetime"].ToString()!="")
				{
					model.fusetime=int.Parse(row["fusetime"].ToString());
				}
				if(row["bdate"]!=null && row["bdate"].ToString()!="")
				{
					model.bdate=row["bdate"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
                if (row["fname"] != null)
                {
                    model.fname = row["fname"].ToString();
                }
                if (row["fcode"] != null)
                {
                    model.fcode = row["fcode"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_ProductionProcess> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,gsid,psid,iname,icode,lname,lcode,gname,gcode,nsort,usetime,fusetime,bdate,cdate,fname,fcode ");
			strSql.Append(" FROM B_ProductionProcess ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_ProductionProcess> r = new List<B_ProductionProcess>();
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
        public bool AddList(List<B_ProductionProcess> bpp)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (B_ProductionProcess model in bpp)
            {
                strSql.Append("insert into B_ProductionProcess(");
                strSql.Append("sid,gsid,psid,iname,icode,lname,lcode,gname,gcode,nsort,usetime,bdate,cdate,fname,fcode)");
                strSql.Append(" values (");
                strSql.AppendFormat(" '{0}',", model.sid);
                strSql.AppendFormat(" '{0}',", model.gsid);
                strSql.AppendFormat(" '{0}',", model.psid);
                strSql.AppendFormat(" '{0}',", model.iname);
                strSql.AppendFormat(" '{0}',", model.icode);
                strSql.AppendFormat(" '{0}',", model.lname);
                strSql.AppendFormat(" '{0}',", model.lcode);
                strSql.AppendFormat(" '{0}',", model.gname);
                strSql.AppendFormat(" '{0}',", model.gcode);
                strSql.AppendFormat(" '{0}',", model.nsort);
                strSql.AppendFormat(" {0},", model.usetime);
                strSql.AppendFormat(" '{0}',", model.bdate);
                strSql.AppendFormat(" '{0}',", model.cdate);
                strSql.AppendFormat(" '{0}',", model.fname);
                strSql.AppendFormat(" '{0}'", model.fcode);
                strSql.Append(" );");
            }

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
        public bool SetBatch(List<B_ProductionProcess> bpp)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (B_ProductionProcess model in bpp)
            {
                strSql.Append("update B_ProductionProcess set");
                strSql.AppendFormat(" zpc= '{0}',", model.zpc);
                strSql.AppendFormat(" cpc='{0}' ", model.cpc);
                strSql.AppendFormat(" where id={0}", model.id);
            }

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
		#endregion  ExtensionMethod
    }
}
