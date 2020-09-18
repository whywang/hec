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
    public class B_PartQualityOrderDal : IB_PartQualityOrderDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_PartQualityOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_PartQualityOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_PartQualityOrder(");
			strSql.Append("qsid,sid,qcode,qstate,maker,cdate,remark)");
			strSql.Append(" values (");
			strSql.Append("@qsid,@sid,@qcode,@qstate,@maker,@cdate,@remark)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@qsid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@qcode", SqlDbType.NVarChar,50),
					new SqlParameter("@qstate", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.qsid;
			parameters[1].Value = model.sid;
			parameters[2].Value = model.qcode;
			parameters[3].Value = model.qstate;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.remark;

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
		public bool Update( B_PartQualityOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_PartQualityOrder set ");
			strSql.Append("sid=@sid,");
			strSql.Append("qcode=@qcode,");
			strSql.Append("qstate=@qstate,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
			strSql.Append("remark=@remark");
            strSql.Append(" where qsid=@qsid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@qcode", SqlDbType.NVarChar,50),
					new SqlParameter("@qstate", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@qsid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.qcode;
			parameters[2].Value = model.qstate;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.qsid;

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
            strSql.AppendFormat("delete from B_PartQualityOrder where 1=1 {0}", where);
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
		public  B_PartQualityOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,qsid,sid,qcode,qstate,maker,cdate,remark from B_PartQualityOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_PartQualityOrder r = new B_PartQualityOrder();
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
		public  B_PartQualityOrder DataRowToModel(DataRow row)
		{
			 B_PartQualityOrder model=new  B_PartQualityOrder();
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
				if(row["qcode"]!=null)
				{
					model.qcode=row["qcode"].ToString();
				}
				if(row["qstate"]!=null && row["qstate"].ToString()!="")
				{
					model.qstate=int.Parse(row["qstate"].ToString());
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString() ;
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_PartQualityOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,qsid,sid,qcode,qstate,maker,cdate,remark ");
			strSql.Append(" FROM B_PartQualityOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_PartQualityOrder> r = new List<B_PartQualityOrder>();
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
        public int QueryQorderNum(string strWhere)
        {
            int r = -1;
            string sql = "select  count(1) as n from B_PartQualityOrder where 1=1 "+strWhere;
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SaveQualityOrder(B_PartQualityOrder bpqo, List<B_PartQualityItems> lq)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_PartQualityOrder( qsid,sid,qcode,qstate,maker,cdate,remark) ");
            strSql.AppendFormat(" values ('{0}','{1}','{2}',{3},'{4}','{5}','{6}'); ", bpqo.qsid, bpqo.sid, bpqo.qcode, bpqo.qstate, bpqo.maker, bpqo.cdate, bpqo.remark);
            if (lq != null)
            {
                foreach (B_PartQualityItems bi in lq)
                {
                    strSql.Append("insert into B_PartQualityItems(qsid,sid,psid,gnum,pname,pcode,height,width,deep,pnum,maker,cdate) ");
                    strSql.AppendFormat(" values ('{0}','{1}','{2}',{3},'{4}','{5}',{6},{7},{8},{9},'{10}','{11}'); ", bi.qsid, bi.sid, bi.psid, bi.gnum, bi.pname, bi.pcode, bi.height, bi.width, bi.deep, bi.pnum, bi.maker, bi.cdate);
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
