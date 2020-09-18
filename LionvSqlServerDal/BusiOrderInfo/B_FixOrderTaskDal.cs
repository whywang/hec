using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using System.Collections;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_FixOrderTaskDal : IB_FixOrderTaskDal
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_FixOrderTask");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_FixOrderTask model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_FixOrderTask(");
            strSql.Append("sid,azs,cdate,oratio,otype,azstype,maker)");
            strSql.Append(" values (");
            strSql.Append("@sid,@azs,@cdate,@oratio,@otype,@azstype,@remark,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@azs", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@oratio", SqlDbType.Decimal),
                    new SqlParameter("@otype", SqlDbType.NVarChar,20),
                    new SqlParameter("@azstype", SqlDbType.NVarChar,20),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.azs;
            parameters[2].Value = model.cdate;
            parameters[3].Value = model.oratio;
            parameters[4].Value = model.otype;
            parameters[5].Value = model.azstype;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.maker;
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
        public bool Update(B_FixOrderTask model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_FixOrderTask set ");
            strSql.Append("azs=@azs,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@azs", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.azs;
            parameters[1].Value = model.cdate;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.sid;

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
            strSql.Append("delete from B_FixOrderTask ");
            strSql.AppendFormat(" where 1=1 {0}",where);
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
        public B_FixOrderTask Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,azs,cdate,oratio,otype,odate,azstype,tmoney,maker,remark from B_FixOrderTask ");
            strSql.AppendFormat(" where 1=1 {0}",where);
 
            B_FixOrderTask r = new B_FixOrderTask();
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
        public B_FixOrderTask DataRowToModel(DataRow row)
        {
            B_FixOrderTask model = new B_FixOrderTask();
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
                if (row["azs"] != null)
                {
                    model.azs = row["azs"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
                if (row["odate"] != null && row["odate"].ToString() != "")
                {
                    model.odate = row["odate"].ToString( );
                }
                if (row["oratio"] != null && row["oratio"].ToString() != "")
                {
                    model.oratio = decimal.Parse(row["oratio"].ToString());
                }
                if (row["tmoney"] != null && row["tmoney"].ToString() != "")
                {
                    model.tmoney = decimal.Parse(row["tmoney"].ToString());
                }
                if (row["otype"] != null && row["otype"].ToString() != "")
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["azstype"] != null)
                {
                    model.azstype = row["azstype"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_FixOrderTask> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,azs,cdate,oratio,otype,odate,azstype,tmoney,maker,remark ");
            strSql.Append(" FROM B_FixOrderTask ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_FixOrderTask> r = new List<B_FixOrderTask>();
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
        public bool SetAzs(string sid, string[] azslist,string maker)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            if (azslist.Length > 0)
            {
                strSql.AppendFormat(" delete from B_FixOrderTask where sid='{0}'", sid);
                for (int i = 0; i < azslist.Length; i++)
                {
                    strSql.AppendFormat(" insert into B_FixOrderTask  (sid,azs,cdate,oratio,otype,azstype,maker) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ;", sid, azslist[i], DateTime.Now.ToString(), 0, "","o", maker);
                }
            }
            if (strSql.ToString() != "")
            {
                int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
                if (rows > 0)
                {
                    r= true;
                }
                else
                {
                    r= false;
                }
            }
            return r;
        }
        public bool ASetAzs(string sid, string[] azslist, string maker)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            if (azslist.Length > 0)
            {
                strSql.AppendFormat(" delete from B_FixOrderTask where sid='{0}' and azstype='n';update B_FixOrderTask set azstype='x' where sid='{0}';", sid);
                for (int i = 0; i < azslist.Length; i++)
                {
                    if (!Exists(" and sid='" + sid + "' and azs='" + azslist[i] + "'"))
                    {
                        strSql.AppendFormat(" insert into B_FixOrderTask  (sid,azs,cdate,oratio,otype,azstype,maker) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ;", sid, azslist[i], DateTime.Now.ToString(), 0, "", "n", maker);
                    }
                    else
                    {
                        strSql.AppendFormat(" update B_FixOrderTask set azstype='o' where sid='{0}' and azs='{1}';", sid, azslist[i]);
                    }
                }
            }
            if (strSql.ToString() != "")
            {
                int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
                if (rows > 0)
                {
                    r = true;
                }
                else
                {
                    r = false;
                }
            }
            return r;
        }
        public bool SaveDisMoney(string sid, ArrayList alist,ArrayList wlist,decimal wmoney)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" update B_FixOrderTask set oratio=0,otype='',tmoney=0,remark='' where sid='{0}';", sid);
            if (alist.Count > 0)
            {
                for (int i = 0; i < alist.Count; i++)
                {
                    ArrayList al = (ArrayList)alist[i];
                    strSql.AppendFormat(" update B_FixOrderTask set oratio={0},otype='{1}',tmoney={2},remark='{3}' where sid='{4}' and azs='{5}';", Convert.ToDecimal(al[2].ToString()), al[1].ToString(),al[3].ToString(), al[4].ToString(),  sid, al[0].ToString());
                }
            }
            if (wlist.Count > 0)
            {
                decimal eazsmoney = wmoney /Convert.ToDecimal( wlist.Count);
                for (int i = 0; i < wlist.Count; i++)
                {
                    ArrayList azs = (ArrayList)wlist[i];
                    strSql.AppendFormat(" update B_FixOrderTask set oratio={0},otype='{1}',tmoney={2},remark='{3}'  where sid='{4}' and azs='{5}';", 0, "比例",  eazsmoney,azs[1].ToString(), sid, azs[0].ToString());
                }
            }
            if (strSql.ToString() != "")
            {
                int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
                if (rows > 0)
                {
                    r = true;
                }
                else
                {
                    r = false;
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
