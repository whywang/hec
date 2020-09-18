using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvModel.Account;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.Account
{
    public class B_CityPayOrderDal : IB_CityPayOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CityPayOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_CityPayOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_CityPayOrder(");
            strSql.Append("sid,pcode,dname,dcode,caccount,cbank,cperson,ctype,pperson,paccount,pbank,pmethod,pdate,pmoney,pstate,pimg,remark,maker,cdate,cbcode,pbcode,sacode)");
            strSql.Append(" values (");
            strSql.Append("@sid,@pcode,@dname,@dcode,@caccount,@cbank,@cperson,@ctype,@pperson,@paccount,@pbank,@pmethod,@pdate,@pmoney,@pstate,@pimg,@remark,@maker,@cdate,@cbcode,@pbcode,@sacode)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@caccount", SqlDbType.NVarChar,30),
					new SqlParameter("@cbank", SqlDbType.NVarChar,30),
					new SqlParameter("@cperson", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@pperson", SqlDbType.NVarChar,30),
					new SqlParameter("@paccount", SqlDbType.NVarChar,30),
					new SqlParameter("@pbank", SqlDbType.NVarChar,30),
					new SqlParameter("@pmethod", SqlDbType.NVarChar,30),
					new SqlParameter("@pdate", SqlDbType.DateTime),
					new SqlParameter("@pmoney", SqlDbType.Decimal,9),
					new SqlParameter("@pstate", SqlDbType.Int,4),
					new SqlParameter("@pimg", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@cbcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pbcode", SqlDbType.NVarChar,30),
					new SqlParameter("@sacode", SqlDbType.NVarChar,30),};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.pcode;
            parameters[2].Value = model.dname;
            parameters[3].Value = model.dcode;
            parameters[4].Value = model.caccount;
            parameters[5].Value = model.cbank;
            parameters[6].Value = model.cperson;
            parameters[7].Value = model.ctype;
            parameters[8].Value = model.pperson;
            parameters[9].Value = model.paccount;
            parameters[10].Value = model.pbank;
            parameters[11].Value = model.pmethod;
            parameters[12].Value = model.pdate;
            parameters[13].Value = model.pmoney;
            parameters[14].Value = model.pstate;
            parameters[15].Value = model.pimg;
            parameters[16].Value = model.remark;
            parameters[17].Value = model.maker;
            parameters[18].Value = model.cdate;
            parameters[19].Value = model.cbcode;
            parameters[20].Value = model.pbcode;
            parameters[21].Value = model.sacode;

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
        public bool Update( B_CityPayOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_CityPayOrder set ");
            strSql.Append("caccount=@caccount,");
            strSql.Append("cbank=@cbank,");
            strSql.Append("cperson=@cperson,");
            strSql.Append("ctype=@ctype,");
            strSql.Append("pperson=@pperson,");
            strSql.Append("paccount=@paccount,");
            strSql.Append("pbank=@pbank,");
            strSql.Append("pmethod=@pmethod,");
            strSql.Append("pdate=@pdate,");
            strSql.Append("pmoney=@pmoney,");
            strSql.Append("remark=@remark,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("cbcode=@cbcode,");
            strSql.Append("pbcode=@pbcode,");
            strSql.Append("sacode=@sacode ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
			
					new SqlParameter("@caccount", SqlDbType.NVarChar,30),
					new SqlParameter("@cbank", SqlDbType.NVarChar,30),
					new SqlParameter("@cperson", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@pperson", SqlDbType.NVarChar,30),
					new SqlParameter("@paccount", SqlDbType.NVarChar,30),
					new SqlParameter("@pbank", SqlDbType.NVarChar,30),
					new SqlParameter("@pmethod", SqlDbType.NVarChar,30),
					new SqlParameter("@pdate", SqlDbType.DateTime),
					new SqlParameter("@pmoney", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@cbcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pbcode", SqlDbType.NVarChar,30),
					new SqlParameter("@sacode", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
       
            parameters[0].Value = model.caccount;
            parameters[1].Value = model.cbank;
            parameters[2].Value = model.cperson;
            parameters[3].Value = model.ctype;
            parameters[4].Value = model.pperson;
            parameters[5].Value = model.paccount;
            parameters[6].Value = model.pbank;
            parameters[7].Value = model.pmethod;
            parameters[8].Value = model.pdate;
            parameters[9].Value = model.pmoney;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.maker;
            parameters[12].Value = model.cdate;
            parameters[10].Value = model.cbcode;
            parameters[11].Value = model.pbcode;
            parameters[12].Value = model.sacode;
            parameters[13].Value = model.sid;

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
            strSql.AppendFormat("delete from B_CityPayOrder where 1=1 {0}", where);
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
        public B_CityPayOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,pcode,dname,dcode,caccount,cbank,cperson,ctype,pperson,paccount,pbank,pmethod,pdate,pmoney,pstate,pimg,remark,maker,cdate,cbcode,pbcode,sacode from B_CityPayOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_CityPayOrder r = new B_CityPayOrder();
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
        public  B_CityPayOrder DataRowToModel(DataRow row)
        {
             B_CityPayOrder model = new  B_CityPayOrder();
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
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["caccount"] != null)
                {
                    model.caccount = row["caccount"].ToString();
                }
                if (row["cbank"] != null)
                {
                    model.cbank = row["cbank"].ToString();
                }
                if (row["cperson"] != null)
                {
                    model.cperson = row["cperson"].ToString();
                }
                if (row["ctype"] != null)
                {
                    model.ctype = row["ctype"].ToString();
                }
                if (row["pperson"] != null)
                {
                    model.pperson = row["pperson"].ToString();
                }
                if (row["paccount"] != null)
                {
                    model.paccount = row["paccount"].ToString();
                }
                if (row["pbank"] != null)
                {
                    model.pbank = row["pbank"].ToString();
                }
                if (row["pmethod"] != null)
                {
                    model.pmethod = row["pmethod"].ToString();
                }
                if (row["pdate"] != null && row["pdate"].ToString() != "")
                {
                    model.pdate =  row["pdate"].ToString() ;
                }
                if (row["pmoney"] != null && row["pmoney"].ToString() != "")
                {
                    model.pmoney = decimal.Parse(row["pmoney"].ToString());
                }
                if (row["pstate"] != null && row["pstate"].ToString() != "")
                {
                    model.pstate = int.Parse(row["pstate"].ToString());
                }
                if (row["pimg"] != null)
                {
                    model.pimg = row["pimg"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
                if (row["cbcode"] != null)
                {
                    model.cbcode = row["cbcode"].ToString();
                }
                if (row["pbcode"] != null)
                {
                    model.pbcode = row["pbcode"].ToString();
                }
                if (row["sacode"] != null)
                {
                    model.sacode = row["sacode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_CityPayOrder> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,pcode,dname,dcode,caccount,cbank,cperson,ctype,pperson,paccount,pbank,pmethod,pdate,pmoney,pstate,pimg,remark,maker,cdate,cbcode,pbcode,sacode ");
            strSql.Append(" FROM B_CityPayOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_CityPayOrder> r = new List<B_CityPayOrder>();
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
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddDraft(B_CityPayOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_CityPayOrder(");
            strSql.Append("sid,dname,dcode,pstate,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid, @dname,@dcode,@pstate,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@pstate", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.pstate;
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
        #region//获取分页订单
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_CityPayOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #endregion
        #endregion  ExtensionMethod
    }
}
