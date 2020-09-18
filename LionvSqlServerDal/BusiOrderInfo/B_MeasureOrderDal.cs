using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_MeasureOrderDal : IB_MeasureOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_MeasureOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_MeasureOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_MeasureOrder(");
            strSql.Append("sid,osid,scode,sdcode,zcode,city,citycode,dname,dcode,customer,telephone,address,aprovince,acity,gzname,gztelephone,mname,mdate,mremark,clperson,qtimg,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@osid,@scode,@sdcode,@zcode,@city,@citycode,@dname,@dcode,@customer,@telephone,@address,@aprovince,@acity,@gzname,@gztelephone,@mname,@mdate,@mremark,@clperson,@qtimg,@maker,@cdate);");
         
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@sdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@zcode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@gzname", SqlDbType.NVarChar,30),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@mdate", SqlDbType.DateTime),
					new SqlParameter("@mremark", SqlDbType.NVarChar,200),
					new SqlParameter("@clperson", SqlDbType.NVarChar,30),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.osid;
            parameters[2].Value = model.scode;
            parameters[3].Value = model.sdcode;
            parameters[4].Value = model.zcode;
            parameters[5].Value = model.city;
            parameters[6].Value = model.citycode;
            parameters[7].Value = model.dname;
            parameters[8].Value = model.dcode;
            parameters[9].Value = model.customer;
            parameters[10].Value = model.telephone;
            parameters[11].Value = model.address;
            parameters[12].Value = model.aprovince;
            parameters[13].Value = model.acity;
            parameters[14].Value = model.gzname;
            parameters[15].Value = model.gztelephone;
            parameters[16].Value = model.mname;
            parameters[17].Value = model.mdate;
            parameters[18].Value = model.mremark;
            parameters[19].Value = model.clperson;
            parameters[20].Value = model.qtimg;
            parameters[21].Value = model.maker;
            parameters[22].Value = model.cdate;
            strSql.AppendFormat(" delete from B_MeasureProduction where sid='{0}';",model.sid);
            if (model.bplist != null)
            {
                foreach (B_MeasureProduction bp in model.bplist)
                {
                    strSql.Append("insert into B_MeasureProduction(");
                    strSql.Append("sid,pcname,pccode,pcnum,maker,cdate)");
                    strSql.Append(" values (");
                    strSql.AppendFormat("'{0}','{1}','{2}',{3},'{4}','{5}');",bp.sid,bp.pcname,bp.pccode,bp.pcnum,bp.maker,bp.cdate);
                }
            }
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
        public bool Update(B_MeasureOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MeasureOrder set ");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("address=@address,");
            strSql.Append("aprovince=@aprovince,");
            strSql.Append("acity=@acity,");
            strSql.Append("gzname=@gzname,");
            strSql.Append("gztelephone=@gztelephone,");
            strSql.Append("mdate=@mdate,");
            strSql.Append("mremark=@mremark,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid ;");
            SqlParameter[] parameters = {
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@gzname", SqlDbType.NVarChar,30),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@mdate", SqlDbType.DateTime),
					new SqlParameter("@mremark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.customer;
            parameters[1].Value = model.telephone;
            parameters[2].Value = model.address;
            parameters[3].Value = model.aprovince;
            parameters[4].Value = model.acity;
            parameters[5].Value = model.gzname;
            parameters[6].Value = model.gztelephone;
            parameters[7].Value = model.mdate;
            parameters[8].Value = model.mremark;
            parameters[9].Value = model.maker;
            parameters[10].Value = model.cdate;
            parameters[11].Value = model.sid;
            strSql.AppendFormat(" delete from B_MeasureProduction where sid='{0}';", model.sid);
            if (model.bplist != null)
            {
                foreach (B_MeasureProduction bp in model.bplist)
                {
                    strSql.Append("insert into B_MeasureProduction(");
                    strSql.Append("sid,pcname,pccode,pcnum,maker,cdate)");
                    strSql.Append(" values (");
                    strSql.AppendFormat("'{0}','{1}','{2}',{3},'{4}','{5}');", bp.sid, bp.pcname, bp.pccode, bp.pcnum, bp.maker, bp.cdate);
                }
            }
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
            strSql.AppendFormat("delete from B_MeasureOrder where 1=1 {0}", where);
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
        public B_MeasureOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,osid,scode,sdcode,zcode,city,citycode,dname,dcode,customer,telephone,address,aprovince,acity,gzname,gztelephone,mname,mdate,mremark,clperson,qtimg,maker,cdate from B_MeasureOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_MeasureOrder r = new B_MeasureOrder();
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
        public  B_MeasureOrder DataRowToModel(DataRow row)
        {
            B_MeasureOrder model = new   B_MeasureOrder();
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
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["sdcode"] != null)
                {
                    model.sdcode = row["sdcode"].ToString();
                }
                if (row["zcode"] != null)
                {
                    model.zcode = row["zcode"].ToString();
                }
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["citycode"] != null)
                {
                    model.citycode = row["citycode"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["aprovince"] != null)
                {
                    model.aprovince = row["aprovince"].ToString();
                }
                if (row["acity"] != null)
                {
                    model.acity = row["acity"].ToString();
                }
                if (row["gzname"] != null)
                {
                    model.gzname = row["gzname"].ToString();
                }
                if (row["gztelephone"] != null)
                {
                    model.gztelephone = row["gztelephone"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["mdate"] != null && row["mdate"].ToString() != "")
                {
                    model.mdate =row["mdate"].ToString();
                }
                if (row["mremark"] != null)
                {
                    model.mremark = row["mremark"].ToString();
                }
                if (row["clperson"] != null)
                {
                    model.clperson = row["clperson"].ToString();
                }
                if (row["qtimg"] != null)
                {
                    model.qtimg = row["qtimg"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_MeasureOrder> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,osid,scode,sdcode,zcode,city,citycode,dname,dcode,customer,telephone,address,aprovince,acity,gzname,gztelephone,mname,mdate,mremark,clperson,qtimg,maker,cdate ");
            strSql.Append(" FROM B_MeasureOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_MeasureOrder> r = new List<B_MeasureOrder>();
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
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_MeasureOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        public bool SetMeasurePerson(string clperson, string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update   B_MeasureOrder set clperson='{0}' where sid='{1}'", clperson,sid);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
