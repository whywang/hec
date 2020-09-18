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
   public class B_ProductionCostDal:IB_ProductionCostDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_ProductionCost");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_ProductionCost model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_ProdcutionCost(");
            strSql.Append("sid,psid,pid,pname,pcode,height,width,deep,pnum,bjtype,gname,gcode,uname,ucode,ccname,cccode,utype,unum,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@psid,@pid,@pname,@pcode,@height,@width,@deep,@pnum,@bjtype,@gname,@gcode,@uname,@ucode,@ccname,@cccode,@utype,@unum,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@height", SqlDbType.Decimal,9),
					new SqlParameter("@width", SqlDbType.Decimal,9),
					new SqlParameter("@deep", SqlDbType.Decimal,9),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@bjtype", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@uname", SqlDbType.NVarChar,30),
					new SqlParameter("@ucode", SqlDbType.NVarChar,30),
					new SqlParameter("@ccname", SqlDbType.NVarChar,30),
					new SqlParameter("@cccode", SqlDbType.NVarChar,30),
					new SqlParameter("@utype", SqlDbType.NVarChar,10),
					new SqlParameter("@unum", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.psid;
            parameters[2].Value = model.pid;
            parameters[3].Value = model.pname;
            parameters[4].Value = model.pcode;
            parameters[5].Value = model.height;
            parameters[6].Value = model.width;
            parameters[7].Value = model.deep;
            parameters[8].Value = model.pnum;
            parameters[9].Value = model.bjtype;
            parameters[10].Value = model.gname;
            parameters[11].Value = model.gcode;
            parameters[12].Value = model.uname;
            parameters[13].Value = model.ucode;
            parameters[14].Value = model.ccname;
            parameters[15].Value = model.cccode;
            parameters[16].Value = model.utype;
            parameters[17].Value = model.unum;
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
		public bool Update( B_ProductionCost model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_ProdcutionCost set ");
            strSql.Append("sid=@sid,");
            strSql.Append("psid=@psid,");
            strSql.Append("pid=@pid,");
            strSql.Append("pname=@pname,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("height=@height,");
            strSql.Append("width=@width,");
            strSql.Append("deep=@deep,");
            strSql.Append("pnum=@pnum,");
            strSql.Append("bjtype=@bjtype,");
            strSql.Append("gname=@gname,");
            strSql.Append("gcode=@gcode,");
            strSql.Append("uname=@uname,");
            strSql.Append("ucode=@ucode,");
            strSql.Append("ccname=@ccname,");
            strSql.Append("cccode=@cccode,");
            strSql.Append("utype=@utype,");
            strSql.Append("unum=@unum,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@height", SqlDbType.Decimal,9),
					new SqlParameter("@width", SqlDbType.Decimal,9),
					new SqlParameter("@deep", SqlDbType.Decimal,9),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@bjtype", SqlDbType.NVarChar,30),
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@uname", SqlDbType.NVarChar,30),
					new SqlParameter("@ucode", SqlDbType.NVarChar,30),
					new SqlParameter("@ccname", SqlDbType.NVarChar,30),
					new SqlParameter("@cccode", SqlDbType.NVarChar,30),
					new SqlParameter("@utype", SqlDbType.NVarChar,10),
					new SqlParameter("@unum", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.psid;
            parameters[2].Value = model.pid;
            parameters[3].Value = model.pname;
            parameters[4].Value = model.pcode;
            parameters[5].Value = model.height;
            parameters[6].Value = model.width;
            parameters[7].Value = model.deep;
            parameters[8].Value = model.pnum;
            parameters[9].Value = model.bjtype;
            parameters[10].Value = model.gname;
            parameters[11].Value = model.gcode;
            parameters[12].Value = model.uname;
            parameters[13].Value = model.ucode;
            parameters[14].Value = model.ccname;
            parameters[15].Value = model.cccode;
            parameters[16].Value = model.utype;
            parameters[17].Value = model.unum;
            parameters[18].Value = model.cdate;
            parameters[19].Value = model.id;


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
            strSql.AppendFormat("delete from B_ProductionCost where 1=1 {0}", where);
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
		public  B_ProductionCost Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sid,psid,pid,pname,pcode,height,width,deep,pnum,bjtype,gname,gcode,uname,ucode,ccname,cccode,utype,unum,cdate from B_ProdcutionCost ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_ProductionCost r = new B_ProductionCost();
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
		public  B_ProductionCost DataRowToModel(DataRow row)
		{
			 B_ProductionCost model=new  B_ProductionCost();
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
                if (row["psid"] != null)
                {
                    model.psid = row["psid"].ToString();
                }
                if (row["pid"] != null && row["pid"].ToString() != "")
                {
                    model.pid = int.Parse(row["pid"].ToString());
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["height"] != null && row["height"].ToString() != "")
                {
                    model.height = decimal.Parse(row["height"].ToString());
                }
                if (row["width"] != null && row["width"].ToString() != "")
                {
                    model.width = decimal.Parse(row["width"].ToString());
                }
                if (row["deep"] != null && row["deep"].ToString() != "")
                {
                    model.deep = decimal.Parse(row["deep"].ToString());
                }
                if (row["pnum"] != null && row["pnum"].ToString() != "")
                {
                    model.pnum = decimal.Parse(row["pnum"].ToString());
                }
                if (row["bjtype"] != null)
                {
                    model.bjtype = row["bjtype"].ToString();
                }
                if (row["gname"] != null)
                {
                    model.gname = row["gname"].ToString();
                }
                if (row["gcode"] != null)
                {
                    model.gcode = row["gcode"].ToString();
                }
                if (row["uname"] != null)
                {
                    model.uname = row["uname"].ToString();
                }
                if (row["ucode"] != null)
                {
                    model.ucode = row["ucode"].ToString();
                }
                if (row["ccname"] != null)
                {
                    model.ccname = row["ccname"].ToString();
                }
                if (row["cccode"] != null)
                {
                    model.cccode = row["cccode"].ToString();
                }
                if (row["utype"] != null)
                {
                    model.utype = row["utype"].ToString();
                }
                if (row["unum"] != null && row["unum"].ToString() != "")
                {
                    model.unum = decimal.Parse(row["unum"].ToString());
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
        public List<B_ProductionCost> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sid,psid,pid,pname,pcode,height,width,deep,pnum,bjtype,gname,gcode,uname,ucode,ccname,cccode,utype,unum,cdate ");
            strSql.Append(" FROM B_ProdcutionCost ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_ProductionCost> r = new List<B_ProductionCost>();
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
        public DataTable QueryVList(string colv, string where, string sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.AppendFormat(" {0} ", colv);
            strSql.Append(" FROM B_ProductionCost ");
            strSql.AppendFormat(" where 1=1 {0} {1}", where, sort);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            return dt;
        }
		#endregion  ExtensionMethod
    }
}
