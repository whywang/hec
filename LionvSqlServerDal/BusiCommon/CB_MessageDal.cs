using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiCommon
{
   public class CB_MessageDal : ICB_MessageDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CB_Message");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_Message(");
            strSql.Append("sid,rcode,ename,url,ozt,vtext,ndate )");
            strSql.Append(" values (");
            strSql.Append("@sid,@rcode,@ename,@url,@ozt,@vtext,@ndate )");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ename", SqlDbType.NVarChar,30),
					new SqlParameter("@url", SqlDbType.NVarChar,100),
					new SqlParameter("@ozt", SqlDbType.NVarChar,30),
					new SqlParameter("@vtext", SqlDbType.NVarChar,100),
					new SqlParameter("@ndate", SqlDbType.DateTime) };
            parameters[0].Value = model.sid;
            parameters[1].Value = model.rcode;
            parameters[2].Value = model.ename;
            parameters[3].Value = model.url;
            parameters[4].Value = model.ozt;
            parameters[5].Value = model.vtext;
            parameters[6].Value = model.ndate;

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
        public bool Update( CB_Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_Message set ");
            strSql.Append("dstate=@dstate,");
            strSql.Append("dmaker=@dmaker,");
            strSql.Append("ddate=@ddate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@dstate", SqlDbType.Int,4),
					new SqlParameter("@dmaker", SqlDbType.NVarChar,30),
					new SqlParameter("@ddate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.dstate;
            parameters[1].Value = model.dmaker;
            parameters[2].Value = model.ddate;
            parameters[3].Value = model.id;

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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CB_Message ");
            strSql.AppendFormat(" where 1=1 {0}  ", where);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
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
        public  CB_Message Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,rcode,ename,url,ozt,vtext,ndate,dstate,dmaker,ddate,dcode from CB_Message ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_Message r = new CB_Message();
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
        public  CB_Message DataRowToModel(DataRow row)
        {
             CB_Message model = new  CB_Message();
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
                if (row["rcode"] != null)
                {
                    model.rcode = row["rcode"].ToString();
                }
                if (row["ename"] != null)
                {
                    model.ename = row["ename"].ToString();
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["ozt"] != null)
                {
                    model.ozt = row["ozt"].ToString();
                }
                if (row["vtext"] != null)
                {
                    model.vtext = row["vtext"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["ndate"] != null && row["ndate"].ToString() != "")
                {
                    model.ndate = row["ndate"].ToString() ;
                }
                if (row["dstate"] != null && row["dstate"].ToString() != "")
                {
                    model.dstate = int.Parse(row["dstate"].ToString());
                }
                if (row["dmaker"] != null)
                {
                    model.dmaker = row["dmaker"].ToString();
                }
                if (row["ddate"] != null && row["ddate"].ToString() != "")
                {
                    model.ddate = row["ddate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_Message> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,rcode,ename,url,ozt,vtext,ndate,dstate,dmaker,ddate,dcode ");
            strSql.AppendFormat(" FROM CB_Message where 1=1 {0}", strWhere);
            List<CB_Message> r = new List<CB_Message>();
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
        public void EventCreateMsg(string sid, string bname,string bcode, int zt)
        {
            SqlParameter[] parms = { new SqlParameter("@sid", sid), new SqlParameter("@bname", bname), new SqlParameter("@bcode", bcode), new SqlParameter("@zt", zt) };
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, "EventMsg", parms);
       
        }
        #endregion  ExtensionMethod
    }
}
