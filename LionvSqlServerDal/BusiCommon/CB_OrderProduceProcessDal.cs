using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiCommon
{
    public class CB_OrderProduceProcessDal : ICB_OrderProduceProcessDal
    {
        #region  BasicMethod
 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_OrderProduceProcess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_OrderProduceProcess(");
            strSql.Append("sid,jdname,jdcode,ydate,jsort,jtype,jstate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@jdname,@jdcode,@ydate,@jsort,@jtype,@jstate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@jdname", SqlDbType.NVarChar,30),
					new SqlParameter("@jdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ydate", SqlDbType.DateTime),
					new SqlParameter("@jsort", SqlDbType.Int,4),
					new SqlParameter("@jtype", SqlDbType.NVarChar,30),
					new SqlParameter("@jstate", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.jdname;
            parameters[2].Value = model.jdcode;
            parameters[3].Value = model.ydate;
            parameters[4].Value = model.jsort;
            parameters[5].Value = model.jtype;
            parameters[6].Value = model.jstate;
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
        public bool Update( CB_OrderProduceProcess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_OrderProduceProcess set ");
            strSql.Append("odate=@odate,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("jstate=@jstate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
 
					new SqlParameter("@odate", SqlDbType.DateTime),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@jstate", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@id", SqlDbType.Int,4)};
 
            parameters[0].Value = model.odate;
            parameters[1].Value = model.cdate;
            parameters[2].Value = model.jstate;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.id;

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
        public bool Delete(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CB_OrderProduceProcess ");
            strSql.AppendFormat(" where  1=1 {0}  ",idlist);
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
        public  CB_OrderProduceProcess Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,jdname,jdcode,ydate,odate,jsort,cdate,maker,jstate,jtype from CB_OrderProduceProcess ");
            strSql.AppendFormat(" where 1=1 {0}",where);
 
             CB_OrderProduceProcess r = new  CB_OrderProduceProcess();
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
        public  CB_OrderProduceProcess DataRowToModel(DataRow row)
        {
             CB_OrderProduceProcess model = new  CB_OrderProduceProcess();
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
                if (row["jdname"] != null)
                {
                    model.jdname = row["jdname"].ToString();
                }
                if (row["jdcode"] != null)
                {
                    model.jdcode = row["jdcode"].ToString();
                }
                if (row["ydate"] != null && row["ydate"].ToString() != "")
                {
                    model.ydate =  row["ydate"].ToString() ;
                }
                if (row["odate"] != null && row["odate"].ToString() != "")
                {
                    model.odate =  row["odate"].ToString() ;
                }
                if (row["jsort"] != null && row["jsort"].ToString() != "")
                {
                    model.jsort = int.Parse(row["jsort"].ToString());
                }
                if (row["jstate"] != null && row["jstate"].ToString() != "")
                {
                    model.jstate = int.Parse(row["jstate"].ToString());
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["jtype"] != null)
                {
                    model.jtype = row["jtype"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_OrderProduceProcess> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,jdname,jdcode,ydate,odate,jsort,cdate,maker,jstate,jtype  ");
            strSql.AppendFormat(" FROM CB_OrderProduceProcess where 1=1 {0}", strWhere);
            List<CB_OrderProduceProcess> r = new List<CB_OrderProduceProcess>();
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
        public void SaveList(string sid,List<CB_OrderProduceProcess> lp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CB_OrderProduceProcess ");
            strSql.AppendFormat(" where sid='{0}'  ;", sid);
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            if (lp.Count > 0)
            {
                foreach (CB_OrderProduceProcess p in lp)
                {
                    Add(p);
                }
            }
        }
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_OrderProducePlan", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        public bool SetLongTime(CB_OrderProduceProcess p)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  CB_OrderProduceProcess set ydate='{0}'",p.ydate);
            strSql.AppendFormat(" where id={0}  ", p.id );
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
        public bool UpState(string id,int znum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  CB_OrderProduceProcess set jstate='{0}'", znum);
            strSql.AppendFormat(" where id={0}", id);
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
        #endregion  ExtensionMethod
    }
}
