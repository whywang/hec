using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvCommon;
using System.Data;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_InventoryDetailDal:ISys_InventoryDetailDal
	{ 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_InventoryDetail");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_InventoryDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_InventoryDetail(");
            strSql.Append("iname,icode,icname,iccode,mname,iunit,isaleprice,isupplyprice,ipurchaseprice,iimage,istate,mcode,maker,cdate,idef1,idef2,idef3,tcprice,ptype,psize)");
			strSql.Append(" values (");
            strSql.Append("@iname,@icode,@icname,@iccode,@mname,@iunit,@isaleprice,@isupplyprice,@ipurchaseprice,@iimage,@istate,@mcode,@maker,@cdate,@idef1,@idef2,@idef3,@tcprice,@ptype,@psize)");
			SqlParameter[] parameters = {
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,50),
					new SqlParameter("@icname", SqlDbType.NVarChar,50),
					new SqlParameter("@iccode", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@iunit", SqlDbType.NVarChar,4),
					new SqlParameter("@isaleprice", SqlDbType.Money,8),
					new SqlParameter("@isupplyprice", SqlDbType.Money,8),
					new SqlParameter("@ipurchaseprice", SqlDbType.Money,8),
					new SqlParameter("@iimage", SqlDbType.NVarChar,100),
					new SqlParameter("@istate", SqlDbType.Bit,1),
					new SqlParameter("@mcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@idef1", SqlDbType.NVarChar,50),
					new SqlParameter("@idef2", SqlDbType.Bit,1),
					new SqlParameter("@idef3", SqlDbType.Int,4),
					new SqlParameter("@tcprice", SqlDbType.Money,8),
					new SqlParameter("@ptype", SqlDbType.NVarChar,50),
					new SqlParameter("@psize", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.iname;
			parameters[1].Value = model.icode;
			parameters[2].Value = model.icname;
			parameters[3].Value = model.iccode;
			parameters[4].Value = model.mname;
			parameters[5].Value = model.iunit;
			parameters[6].Value = model.isaleprice;
			parameters[7].Value = model.isupplyprice;
			parameters[8].Value = model.ipurchaseprice;
			parameters[9].Value = model.iimage;
			parameters[10].Value = model.istate;
			parameters[11].Value = model.mcode;
			parameters[12].Value = model.maker;
			parameters[13].Value = model.cdate;
			parameters[14].Value = model.idef1;
			parameters[15].Value = model.idef2;
			parameters[16].Value = model.idef3;
            parameters[17].Value = model.tcprice;
            parameters[18].Value = model.ptype;
            parameters[19].Value = model.psize;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            }
            catch
            {
                r = -1;
            }
            return r;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_InventoryDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_InventoryDetail set ");
			strSql.Append("iname=@iname,");
			strSql.Append("icname=@icname,");
			strSql.Append("iccode=@iccode,");
			strSql.Append("mname=@mname,");
			strSql.Append("iunit=@iunit,");
			strSql.Append("isaleprice=@isaleprice,");
			strSql.Append("isupplyprice=@isupplyprice,");
			strSql.Append("ipurchaseprice=@ipurchaseprice,");
			strSql.Append("iimage=@iimage,");
			strSql.Append("istate=@istate,");
			strSql.Append("mcode=@mcode,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
			strSql.Append("idef1=@idef1,");
			strSql.Append("idef2=@idef2,");
			strSql.Append("idef3=@idef3,");
            strSql.Append("tcprice=@tcprice,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("psize=@psize");
            strSql.Append(" where icode=@icode");
			SqlParameter[] parameters = {
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@icname", SqlDbType.NVarChar,50),
					new SqlParameter("@iccode", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@iunit", SqlDbType.NVarChar,4),
					new SqlParameter("@isaleprice", SqlDbType.Money,8),
					new SqlParameter("@isupplyprice", SqlDbType.Money,8),
					new SqlParameter("@ipurchaseprice", SqlDbType.Money,8),
					new SqlParameter("@iimage", SqlDbType.NVarChar,100),
					new SqlParameter("@istate", SqlDbType.Bit,1),
					new SqlParameter("@mcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@idef1", SqlDbType.NVarChar,50),
					new SqlParameter("@idef2", SqlDbType.Bit,1),
					new SqlParameter("@idef3", SqlDbType.Int,4),
                    new SqlParameter("@tcprice",  SqlDbType.Money,8),
                    new SqlParameter("@ptype", SqlDbType.NVarChar,50),
                    new SqlParameter("@psize", SqlDbType.NVarChar,100),
					new SqlParameter("@icode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.iname;
			parameters[1].Value = model.icname;
			parameters[2].Value = model.iccode;
			parameters[3].Value = model.mname;
			parameters[4].Value = model.iunit;
			parameters[5].Value = model.isaleprice;
			parameters[6].Value = model.isupplyprice;
			parameters[7].Value = model.ipurchaseprice;
			parameters[8].Value = model.iimage;
			parameters[9].Value = model.istate;
			parameters[10].Value = model.mcode;
			parameters[11].Value = model.maker;
			parameters[12].Value = model.cdate;
			parameters[13].Value = model.idef1;
			parameters[14].Value = model.idef2;
			parameters[15].Value = model.idef3;
            parameters[16].Value = model.tcprice;
            parameters[17].Value = model.ptype;
            parameters[18].Value = model.psize;
			parameters[19].Value = model.icode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string  icode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_InventoryDetail ");
			strSql.AppendFormat(" where icode='{0}';",icode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            { 
                r = true;
            }
            return r;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_InventoryDetail Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,iname,icode,icname,iccode,mname,iunit,isaleprice,isupplyprice,ipurchaseprice,iimage,istate,mcode,maker,cdate,idef1,idef2,idef3,tcprice,ptype ,psize from Sys_InventoryDetail ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_InventoryDetail r = new Sys_InventoryDetail();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
		public  Sys_InventoryDetail DataRowToModel(DataRow row)
		{
			 Sys_InventoryDetail model=new  Sys_InventoryDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["iname"]!=null)
				{
					model.iname=row["iname"].ToString();
				}
				if(row["icode"]!=null)
				{
					model.icode=row["icode"].ToString();
				}
				if(row["icname"]!=null)
				{
					model.icname=row["icname"].ToString();
				}
				if(row["iccode"]!=null)
				{
					model.iccode=row["iccode"].ToString();
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["iunit"]!=null)
				{
					model.iunit=row["iunit"].ToString();
				}
				if(row["isaleprice"]!=null && row["isaleprice"].ToString()!="")
				{
					model.isaleprice=decimal.Parse(row["isaleprice"].ToString());
				}
				if(row["isupplyprice"]!=null && row["isupplyprice"].ToString()!="")
				{
					model.isupplyprice=decimal.Parse(row["isupplyprice"].ToString());
				}
				if(row["ipurchaseprice"]!=null && row["ipurchaseprice"].ToString()!="")
				{
					model.ipurchaseprice=decimal.Parse(row["ipurchaseprice"].ToString());
				}
                if (row["tcprice"] != null && row["tcprice"].ToString() != "")
                {
                    model.tcprice = decimal.Parse(row["tcprice"].ToString());
                }
				if(row["iimage"]!=null)
				{
					model.iimage=row["iimage"].ToString();
				}
				if(row["istate"]!=null && row["istate"].ToString()!="")
				{
					if((row["istate"].ToString()=="1")||(row["istate"].ToString().ToLower()=="true"))
					{
						model.istate=true;
					}
					else
					{
						model.istate=false;
					}
				}
				if(row["mcode"]!=null)
				{
					model.mcode=row["mcode"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
				if(row["idef1"]!=null)
				{
					model.idef1=row["idef1"].ToString();
				}
				if(row["idef2"]!=null && row["idef2"].ToString()!="")
				{
					if((row["idef2"].ToString()=="1")||(row["idef2"].ToString().ToLower()=="true"))
					{
						model.idef2=true;
					}
					else
					{
						model.idef2=false;
					}
				}
				if(row["idef3"]!=null && row["idef3"].ToString()!="")
				{
					model.idef3=int.Parse(row["idef3"].ToString());
				}
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["psize"] != null)
                {
                    model.psize = row["psize"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_InventoryDetail> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,iname,icode,icname,iccode,mname,iunit,isaleprice,isupplyprice,ipurchaseprice,iimage,istate,mcode,maker,cdate,idef1,idef2,idef3,tcprice,ptype,psize ");
			strSql.Append(" FROM Sys_InventoryDetail ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_InventoryDetail> r = new List<Sys_InventoryDetail>();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_InventoryDetail> QueryList(int num,string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top "+num+" id,iname,icode,icname,iccode,mname,iunit,isaleprice,isupplyprice,ipurchaseprice,iimage,istate,mcode,maker,cdate,idef1,idef2,idef3,tcprice,ptype,psize ");
            strSql.Append(" FROM Sys_InventoryDetail ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_InventoryDetail> r = new List<Sys_InventoryDetail>();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
        public int CreateCode(string iccode)
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,substring(icode,len(icode)-2,3))),0) as n from Sys_InventoryDetail where  1=1 and iccode='" + iccode + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetPricce(string sql)
        { 
            int r = 0;
            if (sql != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            return r;
        }
        public int SetState(string sql)
        {
            int r = 0;
            if (sql != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
