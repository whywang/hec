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
    public class B_GroupProductionChangeRequstDal : IB_GroupProductionChangeRequstDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_GroupProductionChangeRequst");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_GroupProductionChangeRequst model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_GroupProductionChangeRequst(");
			strSql.Append("sid,osid,gnum,psid,iname,icode,height,width,deep,pnum,mname,remark,crequest,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@osid,@gnum,@psid,@iname,@icode,@height,@width,@deep,@pnum,@mname,@remark,@crequest,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@crequest", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.gnum;
			parameters[3].Value = model.psid;
			parameters[4].Value = model.iname;
			parameters[5].Value = model.icode;
			parameters[6].Value = model.height;
			parameters[7].Value = model.width;
			parameters[8].Value = model.deep;
			parameters[9].Value = model.pnum;
			parameters[10].Value = model.mname;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.crequest;
			parameters[13].Value = model.maker;
			parameters[14].Value = model.cdate;

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
		public bool Update( B_GroupProductionChangeRequst model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_GroupProductionChangeRequst set ");
			strSql.Append("sid=@sid,");
			strSql.Append("osid=@osid,");
			strSql.Append("gnum=@gnum,");
			strSql.Append("psid=@psid,");
			strSql.Append("iname=@iname,");
			strSql.Append("icode=@icode,");
			strSql.Append("height=@height,");
			strSql.Append("width=@width,");
			strSql.Append("deep=@deep,");
			strSql.Append("pnum=@pnum,");
			strSql.Append("mname=@mname,");
			strSql.Append("remark=@remark,");
			strSql.Append("crequest=@crequest,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@iname", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@crequest", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.gnum;
			parameters[3].Value = model.psid;
			parameters[4].Value = model.iname;
			parameters[5].Value = model.icode;
			parameters[6].Value = model.height;
			parameters[7].Value = model.width;
			parameters[8].Value = model.deep;
			parameters[9].Value = model.pnum;
			parameters[10].Value = model.mname;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.crequest;
			parameters[13].Value = model.maker;
			parameters[14].Value = model.cdate;
			parameters[15].Value = model.id;

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
		public bool Delete(string where )
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_GroupProductionChangeRequst where 1=1 {0}", where);
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
		public  B_GroupProductionChangeRequst Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,osid,gnum,psid,iname,icode,height,width,deep,pnum,mname,remark,crequest,maker,cdate from B_GroupProductionChangeRequst ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_GroupProductionChangeRequst r = new B_GroupProductionChangeRequst();
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
		public  B_GroupProductionChangeRequst DataRowToModel(DataRow row)
		{
			 B_GroupProductionChangeRequst model=new  B_GroupProductionChangeRequst();
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
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["gnum"]!=null && row["gnum"].ToString()!="")
				{
					model.gnum=int.Parse(row["gnum"].ToString());
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
					model.pnum=decimal.Parse(row["pnum"].ToString());
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["crequest"]!=null)
				{
					model.crequest=row["crequest"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_GroupProductionChangeRequst> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,osid,gnum,psid,iname,icode,height,width,deep,pnum,mname,remark,crequest,maker,cdate ");
            strSql.Append(" FROM B_GroupProductionChangeRequst ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_GroupProductionChangeRequst> r = new List<B_GroupProductionChangeRequst>();
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
        public int AddList(List<B_GroupProductionChangeRequst> model, string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from B_GroupProductionChangeRequst where sid='{0}';", sid );
            if(model!=null)
            {
                foreach(B_GroupProductionChangeRequst m in model)
                {
                     strSql.Append("insert into B_GroupProductionChangeRequst  (sid,osid,gnum,psid,iname,icode,height,width,deep,pnum,mname,remark,crequest,maker,cdate ) values");
                     strSql.AppendFormat("('{0}','{1}',{2},'{3}','{4}','{5}',{6},{7},{8},{9},'{10}','{11}','{12}','{13}','{14}');", m.sid, m.osid, m.gnum, m.psid, m.iname, m.icode, m.height, m.width, m.deep, m.pnum, m.mname, m.remark, m.crequest, m.maker, m.cdate);
                }
            }

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
		#endregion  ExtensionMethod
    }
}
