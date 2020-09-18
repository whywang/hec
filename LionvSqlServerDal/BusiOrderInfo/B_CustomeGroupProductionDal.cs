using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;
using System.Collections;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_CustomeGroupProductionDal : IB_CustomeGroupProductionDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_CustomeGroupProduction");
			strSql.Append(" where psid=@psid ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_CustomeGroupProduction model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into B_CustomeGroupProduction(");
            strSql.Append("sid,gsid,psid,gnum,itype,place,direction,locks,hing,pnum,psize,blgy,blname,msname,mtname,dtype,remark,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@gsid,@psid,@gnum,@itype,@place,@direction,@locks,@hing,@pnum,@psize,@blgy,@blname,@msname,@mtname,@dtype,@remark,@maker,@cdate)");
        
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@itype", SqlDbType.NVarChar,30),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@direction", SqlDbType.NVarChar,30),
					new SqlParameter("@locks", SqlDbType.NVarChar,30),
					new SqlParameter("@hing", SqlDbType.NVarChar,30),
					new SqlParameter("@pnum", SqlDbType.Int,4),
					new SqlParameter("@psize", SqlDbType.NVarChar,50),
					new SqlParameter("@blgy", SqlDbType.NVarChar,30),
					new SqlParameter("@blname", SqlDbType.NVarChar,30),
					new SqlParameter("@msname", SqlDbType.NVarChar,30),
					new SqlParameter("@mtname", SqlDbType.NVarChar,30),
					new SqlParameter("@dtype", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.psid;
            parameters[3].Value = model.gnum;
            parameters[4].Value = model.itype;
            parameters[5].Value = model.place;
            parameters[6].Value = model.direction;
            parameters[7].Value = model.locks;
            parameters[8].Value = model.hing;
            parameters[9].Value = model.pnum;
            parameters[10].Value = model.psize;
            parameters[11].Value = model.blgy;
            parameters[12].Value = model.blname;
            parameters[13].Value = model.msname;
            parameters[14].Value = model.mtname;
            parameters[15].Value = model.dtype;
            parameters[16].Value = model.remark;
            parameters[17].Value = model.maker;
            parameters[18].Value = model.cdate;

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
		public bool Update( B_CustomeGroupProduction model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_CustomeGroupProduction set ");
            strSql.Append("sid=@sid,");
            strSql.Append("gsid=@gsid,");
            strSql.Append("gnum=@gnum,");
            strSql.Append("itype=@itype,");
            strSql.Append("place=@place,");
            strSql.Append("direction=@direction,");
            strSql.Append("locks=@locks,");
            strSql.Append("hing=@hing,");
            strSql.Append("pnum=@pnum,");
            strSql.Append("psize=@psize,");
            strSql.Append("blgy=@blgy,");
            strSql.Append("blname=@blname,");
            strSql.Append("msname=@msname,");
            strSql.Append("mtname=@mtname,");
            strSql.Append("dtype=@dtype,");
            strSql.Append("remark=@remark,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where psid=@psid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@itype", SqlDbType.NVarChar,30),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@direction", SqlDbType.NVarChar,30),
					new SqlParameter("@locks", SqlDbType.NVarChar,30),
					new SqlParameter("@hing", SqlDbType.NVarChar,30),
					new SqlParameter("@pnum", SqlDbType.Int,4),
					new SqlParameter("@psize", SqlDbType.NVarChar,50),
					new SqlParameter("@blgy", SqlDbType.NVarChar,30),
					new SqlParameter("@blname", SqlDbType.NVarChar,30),
					new SqlParameter("@msname", SqlDbType.NVarChar,30),
					new SqlParameter("@mtname", SqlDbType.NVarChar,30),
					new SqlParameter("@dtype", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,300),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@psid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.gnum;
            parameters[3].Value = model.itype;
            parameters[4].Value = model.place;
            parameters[5].Value = model.direction;
            parameters[6].Value = model.locks;
            parameters[7].Value = model.hing;
            parameters[8].Value = model.pnum;
            parameters[9].Value = model.psize;
            parameters[10].Value = model.blgy;
            parameters[11].Value = model.blname;
            parameters[12].Value = model.msname;
            parameters[13].Value = model.mtname;
            parameters[14].Value = model.dtype;
            parameters[15].Value = model.remark;
            parameters[16].Value = model.maker;
            parameters[17].Value = model.cdate;
            parameters[18].Value = model.psid;

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
            strSql.AppendFormat("delete from B_CustomeGroupProduction where 1=1 {0}", where);
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
		public  B_CustomeGroupProduction Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sid,gsid,psid,gnum,itype,place,direction,locks,hing,pnum,psize,blgy,blname,msname,mtname,dtype,remark,maker,cdate from B_CustomeGroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_CustomeGroupProduction r = new B_CustomeGroupProduction();
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
		public  B_CustomeGroupProduction DataRowToModel(DataRow row)
		{
			 B_CustomeGroupProduction model=new  B_CustomeGroupProduction();
			if (row != null)
			{
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["gsid"] != null)
                {
                    model.gsid = row["gsid"].ToString();
                }
                if (row["psid"] != null)
                {
                    model.psid = row["psid"].ToString();
                }
                if (row["gnum"] != null && row["gnum"].ToString() != "")
                {
                    model.gnum = int.Parse(row["gnum"].ToString());
                }
                if (row["itype"] != null)
                {
                    model.itype = row["itype"].ToString();
                }
                if (row["place"] != null)
                {
                    model.place = row["place"].ToString();
                }
                if (row["direction"] != null)
                {
                    model.direction = row["direction"].ToString();
                }
                if (row["locks"] != null)
                {
                    model.locks = row["locks"].ToString();
                }
                if (row["hing"] != null)
                {
                    model.hing = row["hing"].ToString();
                }
                if (row["pnum"] != null && row["pnum"].ToString() != "")
                {
                    model.pnum = int.Parse(row["pnum"].ToString());
                }
                if (row["psize"] != null)
                {
                    model.psize = row["psize"].ToString();
                }
                if (row["blgy"] != null)
                {
                    model.blgy = row["blgy"].ToString();
                }
                if (row["blname"] != null)
                {
                    model.blname = row["blname"].ToString();
                }
                if (row["msname"] != null)
                {
                    model.msname = row["msname"].ToString();
                }
                if (row["mtname"] != null)
                {
                    model.mtname = row["mtname"].ToString();
                }
                if (row["dtype"] != null)
                {
                    model.dtype = row["dtype"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
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
        public List<B_CustomeGroupProduction> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sid,gsid,psid,gnum,itype,place,direction,locks,hing,pnum,psize,blgy,blname,msname,mtname,dtype,remark,maker,cdate ");
            strSql.Append(" FROM B_CustomeGroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_CustomeGroupProduction> r = new List<B_CustomeGroupProduction>();
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
        public int GetGnum(string where)
        {
            int r = -1;
            string sql = "select isnull(max(gnum),0) as n from B_CustomeGroupProduction where 1=1 " + where;
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public ArrayList GetGnumArr(string where)
        {
            ArrayList r = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  distinct(gnum) as gnum FROM B_CustomeGroupProduction");
            strSql.AppendFormat(" where 1=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(Convert.ToInt32(dr[0].ToString()));
                }
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
