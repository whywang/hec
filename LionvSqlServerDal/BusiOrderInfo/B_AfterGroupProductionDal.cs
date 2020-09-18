using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvModel.BusiOrderInfo;
using LionvCommon;
using System.Collections;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_AfterGroupProductionDal:IB_AfterGroupProductionDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_AfterGroupProduction");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
      
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_AfterGroupProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_AfterGroupProduction(");
            strSql.Append("sid,psid,gnum,itype,place,direction,fixs,mname,locks,glass,gsize,pname,height,width,deep,pnum,remark,maker,cdate,iheight,iwidth,ideep,stype,msname,sitype,ggy,pmsd)");
			strSql.Append(" values (");
            strSql.Append("@sid,@psid,@gnum,@itype,@place,@direction,@fixs,@mname,@locks,@glass,@gsize,@pname,@height,@width,@deep,@pnum,@remark,@maker,@cdate,@height,@width,@deep,@stype,@msname,@sitype,@ggy,@pmsd)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@itype", SqlDbType.NVarChar,30),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@direction", SqlDbType.NVarChar,30),
					new SqlParameter("@fixs", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@locks", SqlDbType.NVarChar,30),
					new SqlParameter("@glass", SqlDbType.NVarChar,200),
					new SqlParameter("@gsize", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,20),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@iheight", SqlDbType.Int,4),
					new SqlParameter("@iwidth", SqlDbType.Int,4),
					new SqlParameter("@ideep", SqlDbType.Int,4),
					new SqlParameter("@stype", SqlDbType.NVarChar,30),
					new SqlParameter("@msname", SqlDbType.NVarChar,30),
					new SqlParameter("@sitype", SqlDbType.NVarChar,30),
					new SqlParameter("@ggy", SqlDbType.NVarChar,30),
					new SqlParameter("@pmsd", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.psid;
			parameters[2].Value = model.gnum;
			parameters[3].Value = model.itype;
			parameters[4].Value = model.place;
			parameters[5].Value = model.direction;
			parameters[6].Value = model.fixs;
			parameters[7].Value = model.mname;
			parameters[8].Value = model.locks;
			parameters[9].Value = model.glass;
			parameters[10].Value = model.gsize;
			parameters[11].Value = model.pname;
			parameters[12].Value = model.height;
			parameters[13].Value = model.width;
			parameters[14].Value = model.deep;
			parameters[15].Value = model.pnum;
			parameters[16].Value = model.remark;
			parameters[17].Value = model.maker;
			parameters[18].Value = model.cdate;
            parameters[19].Value = model.iheight;
            parameters[20].Value = model.iwidth;
            parameters[21].Value = model.ideep;
            parameters[22].Value = model.stype;
            parameters[23].Value = model.msname;
            parameters[24].Value = model.sitype;
            parameters[25].Value = model.ggy;
            parameters[26].Value = model.pmsd;
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
		public bool Update( B_AfterGroupProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_AfterGroupProduction set ");
			strSql.Append("sid=@sid,");
			strSql.Append("itype=@itype,");
			strSql.Append("place=@place,");
			strSql.Append("direction=@direction,");
			strSql.Append("fixs=@fixs,");
			strSql.Append("mname=@mname,");
			strSql.Append("locks=@locks,");
			strSql.Append("glass=@glass,");
			strSql.Append("gsize=@gsize,");
			strSql.Append("pname=@pname,");
			strSql.Append("height=@height,");
			strSql.Append("width=@width,");
			strSql.Append("deep=@deep,");
			strSql.Append("pnum=@pnum,");
			strSql.Append("remark=@remark,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("iheight=@iheight,");
            strSql.Append("iwidth=@iwidth,");
            strSql.Append("ideep=@ideep, ");
            strSql.Append("stype=@stype,");
            strSql.Append("msname=@msname, ");
            strSql.Append("sitype=@sitype ,");
            strSql.Append("ggy=@ggy,");
            strSql.Append("pmsd=@pmsd ");
			strSql.Append(" where psid=@psid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@itype", SqlDbType.NVarChar,30),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@direction", SqlDbType.NVarChar,30),
					new SqlParameter("@fixs", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@locks", SqlDbType.NVarChar,30),
					new SqlParameter("@glass", SqlDbType.NVarChar,200),
					new SqlParameter("@gsize", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,20),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@iheight", SqlDbType.Int,4),
					new SqlParameter("@iwidth", SqlDbType.Int,4),
					new SqlParameter("@ideep", SqlDbType.Int,4),
                    new SqlParameter("@stype", SqlDbType.NVarChar,30),
                    new SqlParameter("@msname", SqlDbType.NVarChar,30),
                    new SqlParameter("@sitype", SqlDbType.NVarChar,30),
                    new SqlParameter("@ggy", SqlDbType.NVarChar,30),
                    new SqlParameter("@pmsd", SqlDbType.NVarChar,30),
					new SqlParameter("@psid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.itype;
			parameters[2].Value = model.place;
			parameters[3].Value = model.direction;
			parameters[4].Value = model.fixs;
			parameters[5].Value = model.mname;
			parameters[6].Value = model.locks;
			parameters[7].Value = model.glass;
			parameters[8].Value = model.gsize;
			parameters[9].Value = model.pname;
			parameters[10].Value = model.height;
			parameters[11].Value = model.width;
			parameters[12].Value = model.deep;
			parameters[13].Value = model.pnum;
			parameters[14].Value = model.remark;
			parameters[15].Value = model.maker;
			parameters[16].Value = model.cdate;
            parameters[17].Value = model.iheight;
            parameters[18].Value = model.iwidth;
            parameters[19].Value = model.ideep;
            parameters[20].Value = model.stype;
            parameters[21].Value = model.msname;
            parameters[22].Value = model.sitype;
            parameters[23].Value = model.ggy;
            parameters[24].Value = model.pmsd;
			parameters[25].Value = model.psid;

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
            strSql.AppendFormat("delete from B_AfterGroupProduction where 1=1 {0}", where);
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
		public  B_AfterGroupProduction Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sid,psid,gnum,itype,place,direction,fixs,mname,locks,glass,gsize,pname,height,width,deep,iheight,iwidth,ideep,pnum,remark,maker,cdate,stype,msname,sitype,ggy,adremark,workform ,pmsd from B_AfterGroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterGroupProduction r = new B_AfterGroupProduction();
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
		public  B_AfterGroupProduction DataRowToModel(DataRow row)
		{
			 B_AfterGroupProduction model=new  B_AfterGroupProduction();
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
				if(row["itype"]!=null)
				{
					model.itype=row["itype"].ToString();
				}
				if(row["place"]!=null)
				{
					model.place=row["place"].ToString();
				}
				if(row["direction"]!=null)
				{
					model.direction=row["direction"].ToString();
				}
				if(row["fixs"]!=null)
				{
					model.fixs=row["fixs"].ToString();
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["locks"]!=null)
				{
					model.locks=row["locks"].ToString();
				}
				if(row["glass"]!=null)
				{
					model.glass=row["glass"].ToString();
				}
                if (row["ggy"] != null)
                {
                    model.ggy = row["ggy"].ToString();
                }
				if(row["gsize"]!=null)
				{
					model.gsize=row["gsize"].ToString();
				}
				if(row["pname"]!=null)
				{
					model.pname=row["pname"].ToString();
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
                if (row["iheight"] != null && row["iheight"].ToString() != "")
                {
                    model.iheight = int.Parse(row["iheight"].ToString());
                }
                if (row["iwidth"] != null && row["iwidth"].ToString() != "")
                {
                    model.iwidth = int.Parse(row["iwidth"].ToString());
                }
                if (row["ideep"] != null && row["ideep"].ToString() != "")
                {
                    model.ideep = int.Parse(row["ideep"].ToString());
                }
				if(row["pnum"]!=null && row["pnum"].ToString()!="")
				{
					model.pnum=decimal.Parse(row["pnum"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["stype"] != null)
                {
                    model.stype = row["stype"].ToString();
                }
                if (row["msname"] != null)
                {
                    model.msname = row["msname"].ToString();
                }
                if (row["sitype"] != null)
                {
                    model.sitype = row["sitype"].ToString();
                }
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
				}
                if (row["adremark"] != null)
                {
                    model.adremark = row["adremark"].ToString();
                }
                if (row["workform"] != null)
                {
                    model.workform = row["workform"].ToString();
                }
                if (row["pmsd"] != null)
                {
                    model.pmsd = row["pmsd"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterGroupProduction> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sid,psid,gnum,itype,place,direction,fixs,mname,locks,glass,gsize,pname,height,width,deep,pnum,remark,maker,cdate,iheight,iwidth,ideep,stype,msname,sitype,ggy,adremark,workform ,pmsd ");
			strSql.Append(" FROM B_AfterGroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterGroupProduction> r = new List<B_AfterGroupProduction>();
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
            string sql = "select isnull(max(gnum),0) as n from B_AfterGroupProduction where 1=1 " + where;
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public ArrayList GetGnumArr(string where)
        {
            ArrayList r = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  distinct(gnum) as gnum FROM B_AfterGroupProduction");
            strSql.AppendFormat(" where 1=1 {0} order by gnum asc", where);
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
        public bool SetRemark(string sid, string gnum, string adremark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update B_AfterGroupProduction set adremark='{0}'where sid='{1}' and gnum={2}", adremark,sid,gnum);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool SetWorkFrom(string sid, ArrayList plist)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (ArrayList al in plist)
            {
                strSql.AppendFormat("update B_AfterGroupProduction set workform='{0}'where sid='{1}' and id={2};", al[1].ToString(), sid, al[0].ToString());
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
