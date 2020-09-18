using System;
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
    public class B_WorkScheduleDal : IB_WorkScheduleDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_WorkSchedule");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_WorkSchedule model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into B_WorkSchedule(");
            strSql.Append("dname,dcode,cyear,cmonth,curdate,btime,etime,title,color,classname,cdate)");
            strSql.Append(" values (");
            strSql.Append("@dname,@dcode,@cyear,@cmonth,@curdate,@btime,@etime,@title,@color,@classname,@cdate)");
        
            SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@cyear", SqlDbType.Int,4),
					new SqlParameter("@cmonth", SqlDbType.Int,4),
					new SqlParameter("@curdate", SqlDbType.Date,3),
					new SqlParameter("@btime", SqlDbType.DateTime),
					new SqlParameter("@etime", SqlDbType.DateTime),
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@color", SqlDbType.NVarChar,20),
					new SqlParameter("@classname", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.cyear;
            parameters[3].Value = model.cmonth;
            parameters[4].Value = model.curdate;
            parameters[5].Value = model.btime;
            parameters[6].Value = model.etime;
            parameters[7].Value = model.title;
            parameters[8].Value = model.color;
            parameters[9].Value = model.classname;
            parameters[10].Value = model.cdate;

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
		public bool Update( B_WorkSchedule model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_WorkSchedule set ");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("cyear=@cyear,");
            strSql.Append("cmonth=@cmonth,");
            strSql.Append("curdate=@curdate,");
            strSql.Append("btime=@btime,");
            strSql.Append("etime=@etime,");
            strSql.Append("title=@title,");
            strSql.Append("color=@color,");
            strSql.Append("classname=@classname,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@cyear", SqlDbType.Int,4),
					new SqlParameter("@cmonth", SqlDbType.Int,4),
					new SqlParameter("@curdate", SqlDbType.Date,3),
					new SqlParameter("@btime", SqlDbType.DateTime),
					new SqlParameter("@etime", SqlDbType.DateTime),
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@color", SqlDbType.NVarChar,20),
					new SqlParameter("@classname", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.dname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.cyear;
            parameters[3].Value = model.cmonth;
            parameters[4].Value = model.curdate;
            parameters[5].Value = model.btime;
            parameters[6].Value = model.etime;
            parameters[7].Value = model.title;
            parameters[8].Value = model.color;
            parameters[9].Value = model.classname;
            parameters[10].Value = model.cdate;
            parameters[11].Value = model.id;

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
            strSql.Append("delete from B_WorkSchedule ");
            strSql.AppendFormat(" where 1=1 {0}", where);
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
        public B_WorkSchedule Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,dname,dcode,cyear,cmonth,curdate,btime,etime,title,color,classname,cdate from B_WorkSchedule ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_WorkSchedule r = new B_WorkSchedule();
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
		public  B_WorkSchedule DataRowToModel(DataRow row)
		{
            B_WorkSchedule model = new B_WorkSchedule();
			if (row != null)
			{

                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["cyear"] != null && row["cyear"].ToString() != "")
                {
                    model.cyear = int.Parse(row["cyear"].ToString());
                }
                if (row["cmonth"] != null && row["cmonth"].ToString() != "")
                {
                    model.cmonth = int.Parse(row["cmonth"].ToString());
                }
                if (row["curdate"] != null && row["curdate"].ToString() != "")
                {
                    model.curdate =  row["curdate"].ToString() ;
                }
                if (row["btime"] != null && row["btime"].ToString() != "")
                {
                    model.btime =Convert.ToDateTime(  row["btime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") ;
                }
                if (row["etime"] != null && row["etime"].ToString() != "")
                {
                    model.etime =  row["etime"].ToString() ;
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["color"] != null)
                {
                    model.color = row["color"].ToString();
                }
                if (row["classname"] != null)
                {
                    model.classname = row["classname"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_WorkSchedule> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,dname,dcode,cyear,cmonth,curdate,btime,etime,title,color,classname,cdate ");
			strSql.Append(" FROM B_WorkSchedule ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_WorkSchedule> r = new List<B_WorkSchedule>();
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
        public bool SaveList(string dname,string dcode,int year,int month)
        {
            StringBuilder strSql = new StringBuilder();
            DateTime dt=Convert.ToDateTime(year.ToString()+"-"+month.ToString()+"-01");
            for (int i = 0; i < 31; i++)
            {
                DateTime cdt = dt.AddDays(i);
                if (cdt.Month == month)
                {
                    strSql.Append("insert into B_WorkSchedule(");
                    strSql.Append("dname,dcode,cyear,cmonth,curdate,btime,etime,title,color,classname,cdate)");
                    strSql.Append(" values (");
                    strSql.AppendFormat("'{0}',",dname);
                    strSql.AppendFormat("'{0}',",dcode);
                    strSql.AppendFormat("{0},",year);
                    strSql.AppendFormat("{0},",month);
                    strSql.AppendFormat("'{0}',",cdt.ToString("yyyy-MM-dd"));
                    strSql.AppendFormat("'{0}',",cdt.ToString("yyyy-MM-dd")+" 07:30:00");
                    strSql.AppendFormat("'{0}',", cdt.ToString("yyyy-MM-dd") + " 11:30:00");
                    strSql.AppendFormat("'{0}',","上午生产");
                    strSql.AppendFormat("'{0}',","green");
                    strSql.AppendFormat("'{0}',","");
                    strSql.AppendFormat("'{0}'",DateTime.Now.ToString());
                    strSql.Append(");");
                    strSql.Append("insert into B_WorkSchedule(");
                    strSql.Append("dname,dcode,cyear,cmonth,curdate,btime,etime,title,color,classname,cdate)");
                    strSql.Append(" values (");
                    strSql.AppendFormat("'{0}',", dname);
                    strSql.AppendFormat("'{0}',", dcode);
                    strSql.AppendFormat("{0},", year);
                    strSql.AppendFormat("{0},", month);
                    strSql.AppendFormat("'{0}',", cdt.ToString("yyyy-MM-dd"));
                    strSql.AppendFormat("'{0}',", cdt.ToString("yyyy-MM-dd") + " 13:30:00");
                    strSql.AppendFormat("'{0}',", cdt.ToString("yyyy-MM-dd") + " 17:30:00");
                    strSql.AppendFormat("'{0}',", "下午生产");
                    strSql.AppendFormat("'{0}',", "green");
                    strSql.AppendFormat("'{0}',", "");
                    strSql.AppendFormat("'{0}'", DateTime.Now.ToString());
                    strSql.Append(")");
        
                }
            }
            if (strSql.ToString() != "")
            {
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
            else
            {
                return false;
            }
        }
		#endregion  ExtensionMethod
    }
}
