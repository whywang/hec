using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionOrderLogoDal : ISys_ProductionOrderLogoDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string dcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionOrderLogo");
            strSql.AppendFormat(" where 1=1 {0} ",dcode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ProductionOrderLogo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionOrderLogo(");
            strSql.Append("dcode,xqurl,xqt,pgurl,pgt,spurl,spt,gpurl,gpt,bpurl,bpt,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@dcode,@xqurl,@xqt,@pgurl,@pgt,@spurl,@spt,@gpurl,@gpt,@bpurl,@bpt,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@xqurl", SqlDbType.NVarChar,200),
					new SqlParameter("@xqt", SqlDbType.NVarChar,30),
					new SqlParameter("@pgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@pgt", SqlDbType.NVarChar,30),
					new SqlParameter("@spurl", SqlDbType.NVarChar,200),
					new SqlParameter("@spt", SqlDbType.NVarChar,30),
					new SqlParameter("@gpurl", SqlDbType.NVarChar,200),
					new SqlParameter("@gpt", SqlDbType.NVarChar,30),
					new SqlParameter("@bpurl", SqlDbType.NVarChar,200),
					new SqlParameter("@bpt", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.dcode;
            parameters[1].Value = model.xqurl;
            parameters[2].Value = model.xqt;
            parameters[3].Value = model.pgurl;
            parameters[4].Value = model.pgt;
            parameters[5].Value = model.spurl;
            parameters[6].Value = model.spt;
            parameters[7].Value = model.gpurl;
            parameters[8].Value = model.gpt;
            parameters[9].Value = model.bpurl;
            parameters[10].Value = model.bpt;
            parameters[11].Value = model.maker;
            parameters[12].Value = model.cdate;

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
        public bool Update( Sys_ProductionOrderLogo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionOrderLogo set ");
            strSql.Append("xqurl=@xqurl,");
            strSql.Append("xqt=@xqt,");
            strSql.Append("pgurl=@pgurl,");
            strSql.Append("pgt=@pgt,");
            strSql.Append("spurl=@spurl,");
            strSql.Append("spt=@spt,");
            strSql.Append("gpurl=@gpurl,");
            strSql.Append("gpt=@gpt,");
            strSql.Append("bpurl=@bpurl,");
            strSql.Append("bpt=@bpt,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where dcode=@dcode");
            SqlParameter[] parameters = {
					new SqlParameter("@xqurl", SqlDbType.NVarChar,200),
					new SqlParameter("@xqt", SqlDbType.NVarChar,30),
					new SqlParameter("@pgurl", SqlDbType.NVarChar,200),
					new SqlParameter("@pgt", SqlDbType.NVarChar,30),
					new SqlParameter("@spurl", SqlDbType.NVarChar,200),
					new SqlParameter("@spt", SqlDbType.NVarChar,30),
					new SqlParameter("@gpurl", SqlDbType.NVarChar,200),
					new SqlParameter("@gpt", SqlDbType.NVarChar,30),
					new SqlParameter("@bpurl", SqlDbType.NVarChar,200),
					new SqlParameter("@bpt", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.xqurl;
            parameters[1].Value = model.xqt;
            parameters[2].Value = model.pgurl;
            parameters[3].Value = model.pgt;
            parameters[4].Value = model.spurl;
            parameters[5].Value = model.spt;
            parameters[6].Value = model.gpurl;
            parameters[7].Value = model.gpt;
            parameters[8].Value = model.bpurl;
            parameters[9].Value = model.bpt;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.dcode;

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
            strSql.Append("delete from Sys_ProductionOrderLogo ");
            strSql.AppendFormat(" where 1=1 {0} ; ", where);
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
        public  Sys_ProductionOrderLogo Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,dcode,xqurl,xqt,pgurl,pgt,spurl,spt,gpurl,gpt,bpurl,bpt,maker,cdate from Sys_ProductionOrderLogo ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionOrderLogo r = new Sys_ProductionOrderLogo();
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
        public  Sys_ProductionOrderLogo DataRowToModel(DataRow row)
        {
             Sys_ProductionOrderLogo model = new  Sys_ProductionOrderLogo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["xqurl"] != null)
                {
                    model.xqurl = row["xqurl"].ToString();
                }
                if (row["xqt"] != null)
                {
                    model.xqt = row["xqt"].ToString();
                }
                if (row["pgurl"] != null)
                {
                    model.pgurl = row["pgurl"].ToString();
                }
                if (row["pgt"] != null)
                {
                    model.pgt = row["pgt"].ToString();
                }
                if (row["spurl"] != null)
                {
                    model.spurl = row["spurl"].ToString();
                }
                if (row["spt"] != null)
                {
                    model.spt = row["spt"].ToString();
                }
                if (row["gpurl"] != null)
                {
                    model.gpurl = row["gpurl"].ToString();
                }
                if (row["gpt"] != null)
                {
                    model.gpt = row["gpt"].ToString();
                }
                if (row["bpurl"] != null)
                {
                    model.bpurl = row["bpurl"].ToString();
                }
                if (row["bpt"] != null)
                {
                    model.bpt = row["bpt"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionOrderLogo> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,dcode,xqurl,xqt,pgurl,pgt,spurl,spt,gpurl,gpt,bpurl,bpt,maker,cdate ");
            strSql.Append(" FROM Sys_ProductionOrderLogo ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionOrderLogo> r = new List<Sys_ProductionOrderLogo>();
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
        public bool UpdateLogo(Sys_ProductionOrderLogo spo, string ltype)
        {
            if (Exists(" and dcode='" + spo.dcode + "'"))
            {
                string sstr = "";
                if (ltype == "xq")
                {
                    sstr = " xqurl='"+spo.xqurl+"',xqt='"+spo.xqt+"'";
                }
                if (ltype == "pg")
                {
                    sstr = " pgurl='"+spo.pgurl+"',pgt='"+spo.pgt+"'";
                }
                if (ltype == "sp")
                {
                    sstr = " spurl='"+spo.spurl+"',spt='"+spo.spt+"'";
                }
                if (ltype == "gp")
                {
                    sstr = " gpurl='"+spo.gpurl+"',gpt='"+spo.gpt+"'";
                }
                if (ltype == "bp")
                {
                    sstr = " bpurl='"+spo.bpurl+"',bpt='"+spo.bpt+"'";
                }
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update  Sys_ProductionOrderLogo set {0} ", sstr);
                strSql.AppendFormat(" where dcode='{0}' ; ", spo.dcode);
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
            else
            {
                string sstr = "";
                if (ltype == "xq")
                {
                    sstr = " (xqurl,xqt,dcode) values('" + spo.xqurl + "','" + spo.xqt + "','" + spo.dcode + "')";
                }
                if (ltype == "pg")
                {
                    sstr = " (pgurl ,pgt,dcode) values( '" + spo.pgurl + "','" + spo.pgt + "','" + spo.dcode + "')";
                }
                if (ltype == "sp")
                {
                    sstr = " (spurl,spt,dcode) values('" + spo.spurl + "','" + spo.spt + "','" + spo.dcode + "')";
                }
                if (ltype == "gp")
                {
                    sstr = " (gpurl,gpt,dcode) values('" + spo.gpurl + "','" + spo.gpt + "','" + spo.dcode + "')";
                }
                if (ltype == "bp")
                {
                    sstr = " (bpurl,bpt,dcode) values ('" + spo.bpurl + "','" + spo.bpt + "','" + spo.dcode + "')";
                }
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("insert into Sys_ProductionOrderLogo   {0} ", sstr);
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
            
        }
        public bool DelLogo(string dcode, string ltype)
        {
            if (Exists(" and dcode='" + dcode + "'"))
            {
                string sstr = "";
                if (ltype == "xq")
                {
                    sstr = " xqurl='',xqt=''";
                }
                if (ltype == "pg")
                {
                    sstr = " pgurl='',pgt=''";
                }
                if (ltype == "sp")
                {
                    sstr = " spurl='',spt=''";
                }
                if (ltype == "gp")
                {
                    sstr = " gpurl='',gpt=''";
                }
                if (ltype == "bp")
                {
                    sstr = " bpurl='',bpt=''";
                }
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("update  Sys_ProductionOrderLogo set {0} ", sstr);
                strSql.AppendFormat(" where dcode='{0}' ; ", dcode);
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
            else
            {
                return false;
            }

        }
        #endregion  ExtensionMethod
    }
}
