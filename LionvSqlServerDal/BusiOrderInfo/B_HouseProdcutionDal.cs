using LionvCommon;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_HouseProdcutionDal: IB_HouseProdcutionDal
    {
       public bool Exist(string where)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from B_HouseProdcution");
           strSql.AppendFormat(" where 1=1 {0} ", where);
           return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       }
        /// <summary>
		/// 更新一条数据
		/// </summary>
       public bool InUpdate(string[] idlist,string isid)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (string i in idlist)
            {
                strSql.Append("update B_HouseProdcution set ");
                strSql.AppendFormat(" istate=1,idate=getdate(),isid='{0}' where id={1};",isid,i);
            }
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
       public bool OutUpdate(string[] idlist,string osid)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (string i in idlist)
            {
                strSql.Append("update B_HouseProdcution set ");
                strSql.AppendFormat(" ostate=1,odate=getdate() ,osid='{0}' where id={1};",osid, i);
            }
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
        /// 获得数据列表
        /// </summary>
        public List<B_HouseProdcution> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,gnum,psid,psize,pname,mname,pnum,istate,ostate,idate,odate,osid ");
            strSql.Append(" FROM B_HouseProdcution ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_HouseProdcution> r = new List<B_HouseProdcution>();
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private B_HouseProdcution DataRowToModel(DataRow row)
        {
             B_HouseProdcution model = new B_HouseProdcution();
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
                if (row["osid"] != null)
                {
                    model.osid = row["osid"].ToString();
                }
                if (row["gnum"] != null && row["gnum"].ToString() != "")
                {
                    model.gnum = int.Parse(row["gnum"].ToString());
                }
                if (row["psid"] != null)
                {
                    model.psid = row["psid"].ToString();
                }
                if (row["psize"] != null)
                {
                    model.psize = row["psize"].ToString();
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["pnum"] != null && row["pnum"].ToString() != "")
                {
                    model.pnum = int.Parse(row["pnum"].ToString());
                }
                if (row["istate"] != null && row["istate"].ToString() != "")
                {
                    model.istate = int.Parse(row["istate"].ToString());
                }
                if (row["ostate"] != null && row["ostate"].ToString() != "")
                {
                    model.ostate = int.Parse(row["ostate"].ToString());
                }
                if (row["idate"] != null && row["idate"].ToString() != "")
                {
                    model.idate = row["idate"].ToString( );
                }
                if (row["odate"] != null && row["odate"].ToString() != "")
                {
                    model.odate =  row["odate"].ToString() ;
                }
            }
            return model;
        }

    }
}