using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvModel.SysInfo;

namespace LionvSqlServerDal.BusiCommon
{
    public class CB_OrderEventBtnDal : ICB_ButtonEventDal
    {
        #region  BasicMethod
  
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_OrderEventBtn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_OrderEventBtn(");
            strSql.Append("sid,emname,emcode,wfname,wfcode,bname,bcode,btype,state,ps,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@emname,@emcode,@wfname,@wfcode,@bname,@bcode,@btype,@state,@ps,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wfname", SqlDbType.NVarChar,30),
					new SqlParameter("@wfcode", SqlDbType.NVarChar,20),
					new SqlParameter("@bname", SqlDbType.NVarChar,30),
					new SqlParameter("@bcode", SqlDbType.NVarChar,20),
					new SqlParameter("@btype", SqlDbType.NVarChar,10),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.emname;
            parameters[2].Value = model.emcode;
            parameters[3].Value = model.wfname;
            parameters[4].Value = model.wfcode;
            parameters[5].Value = model.bname;
            parameters[6].Value = model.bcode;
            parameters[7].Value = model.btype;
            parameters[8].Value = model.state;
            parameters[9].Value = model.ps;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.cdate;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update( CB_OrderEventBtn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_OrderEventBtn set ");
            strSql.Append("sid=@sid,");
            strSql.Append("emname=@emname,");
            strSql.Append("emcode=@emcode,");
            strSql.Append("wfname=@wfname,");
            strSql.Append("wfcode=@wfcode,");
            strSql.Append("bname=@bname,");
            strSql.Append("bcode=@bcode,");
            strSql.Append("btype=@btype,");
            strSql.Append("state=@state,");
            strSql.Append("ps=@ps,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wfname", SqlDbType.NVarChar,30),
					new SqlParameter("@wfcode", SqlDbType.NVarChar,20),
					new SqlParameter("@bname", SqlDbType.NVarChar,30),
					new SqlParameter("@bcode", SqlDbType.NVarChar,20),
					new SqlParameter("@btype", SqlDbType.NVarChar,10),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.emname;
            parameters[2].Value = model.emcode;
            parameters[3].Value = model.wfname;
            parameters[4].Value = model.wfcode;
            parameters[5].Value = model.bname;
            parameters[6].Value = model.bcode;
            parameters[7].Value = model.btype;
            parameters[8].Value = model.state;
            parameters[9].Value = model.ps;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.id;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
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

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from CB_OrderEventBtn where 1=1 {0}", where);
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
        public CB_OrderEventBtn Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,emname,emcode,wfname,wfcode,bname,bcode,btype,state,ps,maker,cdate from CB_OrderEventBtn  ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_OrderEventBtn r = new CB_OrderEventBtn();
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
        public CB_OrderEventBtn DataRowToModel(DataRow row)
        {
            CB_OrderEventBtn model = new CB_OrderEventBtn();
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
                if (row["emname"] != null)
                {
                    model.emname = row["emname"].ToString();
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["wfname"] != null)
                {
                    model.wfname = row["wfname"].ToString();
                }
                if (row["wfcode"] != null)
                {
                    model.wfcode = row["wfcode"].ToString();
                }
                if (row["bname"] != null)
                {
                    model.bname = row["bname"].ToString();
                }
                if (row["bcode"] != null)
                {
                    model.bcode = row["bcode"].ToString();
                }
                if (row["btype"] != null)
                {
                    model.btype = row["btype"].ToString();
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
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
        public List<CB_OrderEventBtn> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,emname,emcode,wfname,wfcode,bname,bcode,btype,state,ps,maker,cdate");
            strSql.Append(" FROM CB_OrderEventBtn ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            List<CB_OrderEventBtn> r = new List<CB_OrderEventBtn>();
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
        public int FireWorkFlow(string sid, Sys_Button sbn, int bstate, string bms, string maker)
        {
            int r = 0;
            SqlParameter[] parms = { 
                                       new SqlParameter("@sid",sid),
                                       new SqlParameter("@bcode",sbn.bcode),
                                       new SqlParameter("@bstate",bstate),
                                       new SqlParameter("@maker",maker),
                                       new SqlParameter("@detail",bms)
                                   };
            r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, "WorkFlowSyn", parms);
            return r;
        }
        public string GetOrderState(string sid)
        {
            string r = "";
            CB_OrderEventBtn coeb=Query(" and sid='" + sid + "' and btype='true' order by id desc");
            if (coeb != null)
            {
                if (coeb.state == -1)
                {
                    r = "<font style='color:red'>" + coeb.bname.Replace("驳回", "") + "驳回</font>";
                }
                else
                {
                    r = coeb.bname;
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
