using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvModel.BusiOrderInfo;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_BatchProduceOrderDal:IB_BatchProduceOrderDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_BatchProduceOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_BatchProduceOrder model)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_BatchProduceOrder(");
            strSql.Append("bsid,btype,bcode,fname,fcode,bstate,pdate,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@bsid,@btype,@bcode,@fname,@fcode,@bstate,@pdate,@maker,@cdate)");
          
            SqlParameter[] parameters = {
					new SqlParameter("@bsid", SqlDbType.NVarChar,50),
					new SqlParameter("@btype", SqlDbType.NVarChar,30),
					new SqlParameter("@bcode", SqlDbType.NVarChar,30),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@fcode", SqlDbType.NVarChar,50),
					new SqlParameter("@bstate", SqlDbType.Int,4),
					new SqlParameter("@pdate", SqlDbType.Date,3),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.bsid;
            parameters[1].Value = model.btype;
            parameters[2].Value = model.bcode;
            parameters[3].Value = model.fname;
            parameters[4].Value = model.fcode;
            parameters[5].Value = model.bstate;
            parameters[6].Value = model.pdate;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;

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
		public bool Update( B_BatchProduceOrder model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update B_BatchProduceOrder set ");
            strSql.Append("btype=@btype,");
            strSql.Append("bcode=@bcode,");
            strSql.Append("fname=@fname,");
            strSql.Append("fcode=@fcode,");
            strSql.Append("bstate=@bstate,");
            strSql.Append("pdate=@pdate,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where bsid=@bsid");
            SqlParameter[] parameters = {
					new SqlParameter("@btype", SqlDbType.NVarChar,30),
					new SqlParameter("@bcode", SqlDbType.NVarChar,30),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@fcode", SqlDbType.NVarChar,50),
					new SqlParameter("@bstate", SqlDbType.Int,4),
					new SqlParameter("@pdate", SqlDbType.Date,3),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@bsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.btype;
            parameters[1].Value = model.bcode;
            parameters[2].Value = model.fname;
            parameters[3].Value = model.fcode;
            parameters[4].Value = model.bstate;
            parameters[5].Value = model.pdate;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.bsid;

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
            strSql.AppendFormat("delete from B_BatchProduceOrder where 1=1 {0}", where);
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
        public B_BatchProduceOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,bsid,btype,bcode,fname,fcode,bstate,maker,cdate from B_BatchProduceOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_BatchProduceOrder r = new B_BatchProduceOrder();
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
		public  B_BatchProduceOrder DataRowToModel(DataRow row)
		{
			 B_BatchProduceOrder model=new  B_BatchProduceOrder();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["bsid"]!=null)
				{
					model.bsid=row["bsid"].ToString();
				}
				if(row["btype"]!=null)
				{
					model.btype=row["btype"].ToString();
				}
				if(row["bcode"]!=null)
				{
					model.bcode=row["bcode"].ToString();
				}
				if(row["fname"]!=null)
				{
					model.fname=row["fname"].ToString();
				}
				if(row["fcode"]!=null)
				{
					model.fcode=row["fcode"].ToString();
				}
				if(row["bstate"]!=null && row["bstate"].ToString()!="")
				{
					model.bstate=int.Parse(row["bstate"].ToString());
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_BatchProduceOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,bsid,btype,bcode,fname,fcode,bstate,maker,cdate ");
			strSql.Append(" FROM B_BatchProduceOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_BatchProduceOrder> r = new List<B_BatchProduceOrder>();
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
        #region//获取正常订单
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("B_BatchProduceOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #endregion
		#endregion  ExtensionMethod
    }
}
