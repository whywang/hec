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
    public class B_MzDesignTaskDal : IB_MzDesignTaskDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_MzDesignTask");
            strSql.AppendFormat(" where 1=1 {0}", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_MzDesignTask model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzDesignTask set curstate='false' where sid='" + model.sid + "';");
            strSql.Append("insert into B_MzDesignTask(");
            strSql.Append("sid,designer,dstate,curstate,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@designer,@dstate,@curstate,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@designer", SqlDbType.NVarChar,30),
					new SqlParameter("@dstate", SqlDbType.Int,4),
					new SqlParameter("@curstate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.designer;
            parameters[2].Value = model.dstate;
            parameters[3].Value = model.curstate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;

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
        public bool Update( B_MzDesignTask model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzDesignTask set curstate='false',dstate=0 where sid='" + model.sid + "';");
            strSql.Append("update B_MzDesignTask set curstate='true',cdate=getdate() where sid='" + model.sid + "' and designer='" + model.designer + "';");

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
        /// 批量删除数据
        /// </summary>
        public bool Delete (string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from B_MzDesignTask where 1=1 {0}", where);
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
        public  B_MzDesignTask Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,designer,dstate,curstate,maker,bdate,edate,cdate from B_MzDesignTask ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            B_MzDesignTask r = new B_MzDesignTask();
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
        public  B_MzDesignTask DataRowToModel(DataRow row)
        {
             B_MzDesignTask model = new  B_MzDesignTask();
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
                if (row["designer"] != null)
                {
                    model.designer = row["designer"].ToString();
                }
                if (row["dstate"] != null && row["dstate"].ToString() != "")
                {
                    model.dstate = int.Parse(row["dstate"].ToString());
                }
                if (row["curstate"] != null && row["curstate"].ToString() != "")
                {
                    if ((row["curstate"].ToString() == "1") || (row["curstate"].ToString().ToLower() == "true"))
                    {
                        model.curstate = true;
                    }
                    else
                    {
                        model.curstate = false;
                    }
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["bdate"] != null && row["bdate"].ToString() != "")
                {
                    model.bdate =  row["bdate"].ToString() ;
                }
                if (row["edate"] != null && row["edate"].ToString() != "")
                {
                    model.edate =  row["edate"].ToString() ;
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
        public List<B_MzDesignTask> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,designer,dstate,curstate,maker,bdate,edate,cdate ");
            strSql.Append(" FROM B_MzDesignTask ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_MzDesignTask> r = new List<B_MzDesignTask>();
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

        #endregion  ExtensionMethod
    }
}
