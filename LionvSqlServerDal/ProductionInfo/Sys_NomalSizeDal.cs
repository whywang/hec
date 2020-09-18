using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_NomalSizeDal:ISys_NomalSizeDal
	{
	
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_NomalSize");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_NomalSize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_NomalSize(");
			strSql.Append("nname,ncode,ng,nk,nh,nf,nsl,nattr,maker,cdate,nrelate,nrg,nrk,nrn,nrf,nrsl,dcode)");
			strSql.Append(" values (");
			strSql.Append("@nname,@ncode,@ng,@nk,@nh,@nf,@nsl,@nattr,@maker,@cdate,@nrelate,@nrg,@nrk,@nrn,@nrf,@nrsl,@dcode)");
			SqlParameter[] parameters = {
					new SqlParameter("@nname", SqlDbType.NVarChar,30),
					new SqlParameter("@ncode", SqlDbType.NVarChar,10),
					new SqlParameter("@ng", SqlDbType.Int,4),
					new SqlParameter("@nk", SqlDbType.Int,4),
					new SqlParameter("@nh", SqlDbType.Int,4),
					new SqlParameter("@nf", SqlDbType.Int,4),
					new SqlParameter("@nsl", SqlDbType.Int,4),
					new SqlParameter("@nattr", SqlDbType.NVarChar,5),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@nrelate", SqlDbType.Bit,1),
					new SqlParameter("@nrg", SqlDbType.Int,4),
					new SqlParameter("@nrk", SqlDbType.Int,4),
					new SqlParameter("@nrn", SqlDbType.Int,4),
					new SqlParameter("@nrf", SqlDbType.Int,4),
					new SqlParameter("@nrsl", SqlDbType.Int,4),
                    new SqlParameter("@dcode", SqlDbType.NVarChar,50),};
			parameters[0].Value = model.nname;
			parameters[1].Value = model.ncode;
			parameters[2].Value = model.ng;
			parameters[3].Value = model.nk;
			parameters[4].Value = model.nh;
			parameters[5].Value = model.nf;
			parameters[6].Value = model.nsl;
			parameters[7].Value = model.nattr;
			parameters[8].Value = model.maker;
			parameters[9].Value = model.cdate;
			parameters[10].Value = model.nrelate;
			parameters[11].Value = model.nrg;
			parameters[12].Value = model.nrk;
			parameters[13].Value = model.nrn;
			parameters[14].Value = model.nrf;
			parameters[15].Value = model.nrsl;
            parameters[16].Value = model.dcode;
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
		public bool Update( Sys_NomalSize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_NomalSize set ");
			strSql.Append("nname=@nname,");
			strSql.Append("ng=@ng,");
			strSql.Append("nk=@nk,");
			strSql.Append("nh=@nh,");
			strSql.Append("nf=@nf,");
			strSql.Append("nsl=@nsl,");
			strSql.Append("nattr=@nattr,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
			strSql.Append("nrelate=@nrelate,");
			strSql.Append("nrg=@nrg,");
			strSql.Append("nrk=@nrk,");
			strSql.Append("nrn=@nrn,");
			strSql.Append("nrf=@nrf,");
			strSql.Append("nrsl=@nrsl");
            strSql.Append(" where ncode=@ncode");
			SqlParameter[] parameters = {
					new SqlParameter("@nname", SqlDbType.NVarChar,30),
					new SqlParameter("@ng", SqlDbType.Int,4),
					new SqlParameter("@nk", SqlDbType.Int,4),
					new SqlParameter("@nh", SqlDbType.Int,4),
					new SqlParameter("@nf", SqlDbType.Int,4),
					new SqlParameter("@nsl", SqlDbType.Int,4),
					new SqlParameter("@nattr", SqlDbType.NVarChar,5),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@nrelate", SqlDbType.Bit,1),
					new SqlParameter("@nrg", SqlDbType.Int,4),
					new SqlParameter("@nrk", SqlDbType.Int,4),
					new SqlParameter("@nrn", SqlDbType.Int,4),
					new SqlParameter("@nrf", SqlDbType.Int,4),
					new SqlParameter("@nrsl", SqlDbType.Int,4),
					new SqlParameter("@ncode", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.nname;
			parameters[1].Value = model.ng;
			parameters[2].Value = model.nk;
			parameters[3].Value = model.nh;
			parameters[4].Value = model.nf;
			parameters[5].Value = model.nsl;
			parameters[6].Value = model.nattr;
			parameters[7].Value = model.maker;
			parameters[8].Value = model.cdate;
			parameters[9].Value = model.nrelate;
			parameters[10].Value = model.nrg;
			parameters[11].Value = model.nrk;
			parameters[12].Value = model.nrn;
			parameters[13].Value = model.nrf;
			parameters[14].Value = model.nrsl;
			parameters[15].Value = model.ncode;
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
		public bool Delete(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_NomalSize ");
			strSql.AppendFormat(" where 1=1 {0} ",where);
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
		public  Sys_NomalSize Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,nname,ncode,ng,nk,nh,nf,nsl,nattr,maker,cdate,nrelate,nrg,nrk,nrn,nrf,nrsl from Sys_NomalSize ");
			strSql.AppendFormat(" where 1=1 {0}",where);
			 Sys_NomalSize r=new  Sys_NomalSize();
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
		public  Sys_NomalSize DataRowToModel(DataRow row)
		{
			 Sys_NomalSize model=new  Sys_NomalSize();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["nname"]!=null)
				{
					model.nname=row["nname"].ToString();
				}
				if(row["ncode"]!=null)
				{
					model.ncode=row["ncode"].ToString();
				}
				if(row["ng"]!=null && row["ng"].ToString()!="")
				{
					model.ng=int.Parse(row["ng"].ToString());
				}
				if(row["nk"]!=null && row["nk"].ToString()!="")
				{
					model.nk=int.Parse(row["nk"].ToString());
				}
				if(row["nh"]!=null && row["nh"].ToString()!="")
				{
					model.nh=int.Parse(row["nh"].ToString());
				}
				if(row["nf"]!=null && row["nf"].ToString()!="")
				{
					model.nf=int.Parse(row["nf"].ToString());
				}
				if(row["nsl"]!=null && row["nsl"].ToString()!="")
				{
					model.nsl=int.Parse(row["nsl"].ToString());
				}
				if(row["nattr"]!=null)
				{
					model.nattr=row["nattr"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
				if(row["nrelate"]!=null && row["nrelate"].ToString()!="")
				{
					if((row["nrelate"].ToString()=="1")||(row["nrelate"].ToString().ToLower()=="true"))
					{
						model.nrelate=true;
					}
					else
					{
						model.nrelate=false;
					}
				}
				if(row["nrg"]!=null && row["nrg"].ToString()!="")
				{
					model.nrg=int.Parse(row["nrg"].ToString());
				}
				if(row["nrk"]!=null && row["nrk"].ToString()!="")
				{
					model.nrk=int.Parse(row["nrk"].ToString());
				}
				if(row["nrn"]!=null && row["nrn"].ToString()!="")
				{
					model.nrn=int.Parse(row["nrn"].ToString());
				}
				if(row["nrf"]!=null && row["nrf"].ToString()!="")
				{
					model.nrf=int.Parse(row["nrf"].ToString());
				}
				if(row["nrsl"]!=null && row["nrsl"].ToString()!="")
				{
					model.nrsl=int.Parse(row["nrsl"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_NomalSize> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,nname,ncode,ng,nk,nh,nf,nsl,nattr,maker,cdate,nrelate,nrg,nrk,nrn,nrf,nrsl ");
			strSql.AppendFormat(" FROM Sys_NomalSize where 1=1 {0}",where);
            List<Sys_NomalSize> r = new List<Sys_NomalSize>();
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
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,ncode)),0) as n from Sys_NomalSize ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetProductionNs(string pcode, string ncode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryNomalSize where pcode like '{0}%';", pcode);
            sql.AppendFormat(" insert into Sys_RInventoryNomalSize (pcode,ncode) values ('{0}','{1}') ;", pcode, ncode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetProductionNs(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryNomalSize where pcode like '{0}%';", pcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetProductionNs(string pcode)
        {
            string r = "";
            r = LoodQuery(pcode);
            return r;
        }
        private string LoodQuery(string pcode)
        {
            string p = "";
            if (pcode.Length > 8)
            {

                string sql = "select ncode from Sys_RInventoryNomalSize where pcode='" + pcode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(pcode.Substring(0, pcode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
		#endregion  ExtensionMethod
    }
}
