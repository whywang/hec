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
    public class Sys_ProductionTempDal : ISys_ProductionTempDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionTemp");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionTemp(");
            strSql.Append("tname,tcode,ptname,ptcode,tist,tfrist,tht,tlt,thlx,tslx,tdz,tmdx,tmtb,tytb,ttlh,tdmx,tsl,tblyt,tslhl,tslsl,ttemp,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@tname,@tcode,@ptname,@ptcode,@tist,@tfrist,@tht,@tlt,@thlx,@tslx,@tdz,@tmdx,@tmtb,@tytb,@ttlh,@tdmx,@tsl,@tblyt,@tslhl,@tslsl,@ttemp,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tist", SqlDbType.Int,4),
					new SqlParameter("@tfrist", SqlDbType.Int,4),
					new SqlParameter("@tht", SqlDbType.Int,4),
					new SqlParameter("@tlt", SqlDbType.Int,4),
					new SqlParameter("@thlx", SqlDbType.Int,4),
					new SqlParameter("@tslx", SqlDbType.Int,4),
					new SqlParameter("@tdz", SqlDbType.Int,4),
					new SqlParameter("@tmdx", SqlDbType.Int,4),
					new SqlParameter("@tmtb", SqlDbType.Int,4),
					new SqlParameter("@tytb", SqlDbType.Int,4),
					new SqlParameter("@ttlh", SqlDbType.Int,4),
					new SqlParameter("@tdmx", SqlDbType.Int,4),
					new SqlParameter("@tsl", SqlDbType.Int,4),
					new SqlParameter("@tblyt", SqlDbType.Int,4),
					new SqlParameter("@tslhl", SqlDbType.Int,4),
					new SqlParameter("@tslsl", SqlDbType.Int,4),
					new SqlParameter("@ttemp", SqlDbType.NVarChar,-1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.tname;
            parameters[1].Value = model.tcode;
            parameters[2].Value = model.ptname;
            parameters[3].Value = model.ptcode;
            parameters[4].Value = model.tist;
            parameters[5].Value = model.tfrist;
            parameters[6].Value = model.tht;
            parameters[7].Value = model.tlt;
            parameters[8].Value = model.thlx;
            parameters[9].Value = model.tslx;
            parameters[10].Value = model.tdz;
            parameters[11].Value = model.tmdx;
            parameters[12].Value = model.tmtb;
            parameters[13].Value = model.tytb;
            parameters[14].Value = model.ttlh;
            parameters[15].Value = model.tdmx;
            parameters[16].Value = model.tsl;
            parameters[17].Value = model.tblyt;
            parameters[18].Value = model.tslhl;
            parameters[19].Value = model.tslsl;
            parameters[20].Value = model.ttemp;
            parameters[21].Value = model.maker;
            parameters[22].Value = model.cdate;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update(Sys_ProductionTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionTemp set ");
            strSql.Append("tname=@tname,");
            strSql.Append("ptname=@ptname,");
            strSql.Append("ptcode=@ptcode,");
            strSql.Append("tist=@tist,");
            strSql.Append("tfrist=@tfrist,");
            strSql.Append("tht=@tht,");
            strSql.Append("tlt=@tlt,");
            strSql.Append("thlx=@thlx,");
            strSql.Append("tslx=@tslx,");
            strSql.Append("tdz=@tdz,");
            strSql.Append("tmdx=@tmdx,");
            strSql.Append("tmtb=@tmtb,");
            strSql.Append("tytb=@tytb,");
            strSql.Append("ttlh=@ttlh,");
            strSql.Append("tdmx=@tdmx,");
            strSql.Append("tsl=@tsl,");
            strSql.Append("tblyt=@tblyt,");
            strSql.Append("tslhl=@tslhl,");
            strSql.Append("tslsl=@tslsl,");
            strSql.Append("ttemp=@ttemp,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tcode=@tcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tist", SqlDbType.Int,4),
					new SqlParameter("@tfrist", SqlDbType.Int,4),
					new SqlParameter("@tht", SqlDbType.Int,4),
					new SqlParameter("@tlt", SqlDbType.Int,4),
					new SqlParameter("@thlx", SqlDbType.Int,4),
					new SqlParameter("@tslx", SqlDbType.Int,4),
					new SqlParameter("@tdz", SqlDbType.Int,4),
					new SqlParameter("@tmdx", SqlDbType.Int,4),
					new SqlParameter("@tmtb", SqlDbType.Int,4),
					new SqlParameter("@tytb", SqlDbType.Int,4),
					new SqlParameter("@ttlh", SqlDbType.Int,4),
					new SqlParameter("@tdmx", SqlDbType.Int,4),
					new SqlParameter("@tsl", SqlDbType.Int,4),
					new SqlParameter("@tblyt", SqlDbType.Int,4),
					new SqlParameter("@tslhl", SqlDbType.Int,4),
					new SqlParameter("@tslsl", SqlDbType.Int,4),
					new SqlParameter("@ttemp", SqlDbType.NVarChar,-1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tname;
            parameters[1].Value = model.ptname;
            parameters[2].Value = model.ptcode;
            parameters[3].Value = model.tist;
            parameters[4].Value = model.tfrist;
            parameters[5].Value = model.tht;
            parameters[6].Value = model.tlt;
            parameters[7].Value = model.thlx;
            parameters[8].Value = model.tslx;
            parameters[9].Value = model.tdz;
            parameters[10].Value = model.tmdx;
            parameters[11].Value = model.tmtb;
            parameters[12].Value = model.tytb;
            parameters[13].Value = model.ttlh;
            parameters[14].Value = model.tdmx;
            parameters[15].Value = model.tsl;
            parameters[16].Value = model.tblyt;
            parameters[17].Value = model.tslhl;
            parameters[18].Value = model.tslsl;
            parameters[19].Value = model.ttemp;
            parameters[20].Value = model.maker;
            parameters[21].Value = model.cdate;
            parameters[22].Value = model.tcode;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionTemp ");
            strSql.Append(" where 1=1 " + where);
 
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
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
        public Sys_ProductionTemp Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tname,tcode,ptname,ptcode,tist,tfrist,tht,tlt,thlx,tslx,tdz,tmdx,tmtb,tytb,ttlh,tdmx,tsl,tblyt,tslhl,tslsl,ttemp,maker,cdate from Sys_ProductionTemp ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionTemp r = new Sys_ProductionTemp();
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
        public Sys_ProductionTemp DataRowToModel(DataRow row)
        {
            Sys_ProductionTemp model = new Sys_ProductionTemp();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tname"] != null)
                {
                    model.tname = row["tname"].ToString();
                }
                if (row["tcode"] != null)
                {
                    model.tcode = row["tcode"].ToString();
                }
                if (row["ptname"] != null)
                {
                    model.ptname = row["ptname"].ToString();
                }
                if (row["ptcode"] != null)
                {
                    model.ptcode = row["ptcode"].ToString();
                }
                if (row["tist"] != null && row["tist"].ToString() != "")
                {
                    model.tist = int.Parse(row["tist"].ToString());
                }
                if (row["tfrist"] != null && row["tfrist"].ToString() != "")
                {
                    model.tfrist = int.Parse(row["tfrist"].ToString());
                }
                if (row["tht"] != null && row["tht"].ToString() != "")
                {
                    model.tht = int.Parse(row["tht"].ToString());
                }
                if (row["tlt"] != null && row["tlt"].ToString() != "")
                {
                    model.tlt = int.Parse(row["tlt"].ToString());
                }
                if (row["thlx"] != null && row["thlx"].ToString() != "")
                {
                    model.thlx = int.Parse(row["thlx"].ToString());
                }
                if (row["tslx"] != null && row["tslx"].ToString() != "")
                {
                    model.tslx = int.Parse(row["tslx"].ToString());
                }
                if (row["tdz"] != null && row["tdz"].ToString() != "")
                {
                    model.tdz = int.Parse(row["tdz"].ToString());
                }
                if (row["tmdx"] != null && row["tmdx"].ToString() != "")
                {
                    model.tmdx = int.Parse(row["tmdx"].ToString());
                }
                if (row["tmtb"] != null && row["tmtb"].ToString() != "")
                {
                    model.tmtb = int.Parse(row["tmtb"].ToString());
                }
                if (row["tytb"] != null && row["tytb"].ToString() != "")
                {
                    model.tytb = int.Parse(row["tytb"].ToString());
                }
                if (row["ttlh"] != null && row["ttlh"].ToString() != "")
                {
                    model.ttlh = int.Parse(row["ttlh"].ToString());
                }
                if (row["tdmx"] != null && row["tdmx"].ToString() != "")
                {
                    model.tdmx = int.Parse(row["tdmx"].ToString());
                }
                if (row["tsl"] != null && row["tsl"].ToString() != "")
                {
                    model.tsl = int.Parse(row["tsl"].ToString());
                }
                if (row["tblyt"] != null && row["tblyt"].ToString() != "")
                {
                    model.tblyt = int.Parse(row["tblyt"].ToString());
                }
                if (row["tslhl"] != null && row["tslhl"].ToString() != "")
                {
                    model.tslhl = int.Parse(row["tslhl"].ToString());
                }
                if (row["tslsl"] != null && row["tslsl"].ToString() != "")
                {
                    model.tslsl = int.Parse(row["tslsl"].ToString());
                }
                if (row["ttemp"] != null && row["ttemp"].ToString() != "")
                {
                    model.ttemp =  row["ttemp"].ToString( );
                }
                if (row["maker"] != null && row["maker"].ToString() != "")
                {
                    model.maker = row["maker"].ToString() ;
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
        public List<Sys_ProductionTemp> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tname,tcode,ptname,ptcode,tist,tfrist,tht,tlt,thlx,tslx,tdz,tmdx,tmtb,tytb,ttlh,tdmx,tsl,tblyt,tslhl,tslsl,ttemp,maker,cdate ");
            strSql.Append(" FROM Sys_ProductionTemp ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionTemp> r = new List<Sys_ProductionTemp>();
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
        public int CreateCode(string where)
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int, tcode)),0) as n from Sys_ProductionTemp ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
