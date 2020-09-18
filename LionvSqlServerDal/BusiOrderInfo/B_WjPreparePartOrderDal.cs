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
    public class B_WjPreparePartOrderDal : IB_WjPreparePartOrderDal
    {
       	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_WjPreparePartOrder");
			strSql.AppendFormat(" where 1=1 {0}",where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_WjPreparePartOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_WjPreparePartOrder(");
			strSql.Append("sid,wsid,osid,pcode,remark,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@wsid,@osid,@pcode,@remark,@maker,@cdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@wsid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.wsid;
			parameters[2].Value = model.osid;
			parameters[3].Value = model.pcode;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.maker;
			parameters[6].Value = model.cdate;
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
		public bool Update( B_WjPreparePartOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_WjPreparePartOrder set ");
			strSql.Append("wsid=@wsid,");
			strSql.Append("osid=@osid,");
			strSql.Append("pcode=@pcode,");
			strSql.Append("remark=@remark,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wsid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.wsid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.pcode;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.id;
			parameters[7].Value = model.sid;
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
            strSql.AppendFormat("delete from B_WjPreparePartOrder where 1=1 {0}", where);
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
		public  B_WjPreparePartOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,wsid,osid,pcode,remark,maker,cdate from B_WjPreparePartOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_WjPreparePartOrder r = new B_WjPreparePartOrder();
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
		public  B_WjPreparePartOrder DataRowToModel(DataRow row)
		{
			 B_WjPreparePartOrder model=new  B_WjPreparePartOrder();
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
				if(row["wsid"]!=null)
				{
					model.wsid=row["wsid"].ToString();
				}
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["pcode"]!=null)
				{
					model.pcode=row["pcode"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
        public List<B_WjPreparePartOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,wsid,osid,pcode,remark,maker,cdate ");
			strSql.Append(" FROM B_WjPreparePartOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_WjPreparePartOrder> r = new List<B_WjPreparePartOrder>();
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
        public int GetOrderNum(string sid)
        {
            int r = -1;
            string sql = "";
            sql = "select count(1) as n from B_WjPreparePartOrder where wsid='" + sid + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999:Convert.ToInt32(o)+1;
            return r;
        }
        public bool SavePreParePartOrder(B_WjPreparePartOrder bp, List<B_WjPreParePartGroupProduction> pbpp, ArrayList alui)
        {
            StringBuilder strSql = new StringBuilder();
            if (bp != null)
            {
                strSql.Append(" insert into  B_WjPreparePartOrder (sid,wsid,osid,pcode,remark,maker,cdate)");
                strSql.AppendFormat(" values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", bp.sid, bp.wsid, bp.osid, bp.pcode, bp.remark, bp.maker, bp.cdate);
            }
            if (pbpp.Count > 0)
            {
                foreach (B_WjPreParePartGroupProduction bgp in pbpp)
                {
                    strSql.Append(" insert into  B_WjPreParePartGroupProduction (psid,sid,wsid,osid,iname,icode,pnum,maker,cdate)");
                    strSql.AppendFormat(" values ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}');", "", bgp.sid, bgp.wsid, bgp.osid, bgp.iname, bgp.icode, bgp.pnum, bgp.maker, bgp.cdate);
                }
            }
            if (alui.Count > 0)
            {
                foreach (ArrayList al in alui)
                {
                    strSql.AppendFormat(" update  B_WjPartGroupProduction set  pnum ={0} where id={1};",al[1].ToString(),al[0].ToString());
                }
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
