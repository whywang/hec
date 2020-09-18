using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.NewsInfo;
using LionvModel.NewsInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.NewsInfo
{
    public class NB_NewsDal : INB_NewsDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NB_News");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( NB_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NB_News(");
            strSql.Append("ntitle,ncontent,cdate,maker,ntype,nreadnum,nstate,nvrange,nsid,dcode,rtype,sdcode)");
            strSql.Append(" values (");
            strSql.Append("@ntitle,@ncontent,@cdate,@maker,@ntype,@nreadnum,@nstate,@nvrange,@nsid,@dcode,@rtype,@sdcode)");
            SqlParameter[] parameters = {
					new SqlParameter("@ntitle", SqlDbType.NVarChar,50),
					new SqlParameter("@ncontent", SqlDbType.NVarChar,-1),
					new SqlParameter("@cdate", SqlDbType.DateTime ),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@ntype", SqlDbType.NVarChar,20),
					new SqlParameter("@nreadnum", SqlDbType.Int,4),
					new SqlParameter("@nstate", SqlDbType.Bit,1),
					new SqlParameter("@nvrange", SqlDbType.NVarChar,100),
                    new SqlParameter("@nsid", SqlDbType.NVarChar,50),
                    new SqlParameter("@dcode", SqlDbType.NVarChar,50),
                    new SqlParameter("@rtype", SqlDbType.NVarChar,30),
                    new SqlParameter("@sdcode", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ntitle;
            parameters[1].Value = model.ncontent;
            parameters[2].Value = model.cdate;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.ntype;
            parameters[5].Value = model.nreadnum;
            parameters[6].Value = model.nstate;
            parameters[7].Value = model.nvrange;
            parameters[8].Value = model.nsid;
            parameters[9].Value = model.dcode;
            parameters[10].Value = model.rtype;
            parameters[11].Value = model.sdcode;
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
        public bool Update( NB_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NB_News set ");
            strSql.Append("ntitle=@ntitle,");
            strSql.Append("ncontent=@ncontent,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker,");
            strSql.Append("ntype=@ntype,");
            strSql.Append("nreadnum=@nreadnum,");
            strSql.Append("nstate=@nstate,");
            strSql.Append("nvrange=@nvrange,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("rtype=@rtype,");
            strSql.Append("sdcode=@sdcode");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ntitle", SqlDbType.NVarChar,50),
					new SqlParameter("@ncontent", SqlDbType.NVarChar,-1),
					new SqlParameter("@cdate", SqlDbType.DateTime ),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@ntype", SqlDbType.NVarChar,20),
					new SqlParameter("@nreadnum", SqlDbType.Int,4),
					new SqlParameter("@nstate", SqlDbType.Bit,1),
					new SqlParameter("@nvrange", SqlDbType.NVarChar,100),
                    new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rtype", SqlDbType.NVarChar,30),
                    new SqlParameter("@sdcode", SqlDbType.NVarChar,500),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.ntitle;
            parameters[1].Value = model.ncontent;
            parameters[2].Value = model.cdate;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.ntype;
            parameters[5].Value = model.nreadnum;
            parameters[6].Value = model.nstate;
            parameters[7].Value = model.nvrange;
            parameters[8].Value = model.dcode;
            parameters[9].Value = model.rtype;
            parameters[10].Value = model.sdcode;
            parameters[11].Value = model.id;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }

 
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from NB_News where 1=1 {0}", where);
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
        public NB_News Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ntitle,ncontent,cdate,maker,ntype,nreadnum,nstate,nvrange,nsid,dcode,rtype,sdcode from NB_News ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            NB_News r = new NB_News();
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
        public NB_News DataRowToModel(DataRow row)
        {
            NB_News model = new NB_News();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ntitle"] != null)
                {
                    model.ntitle = row["ntitle"].ToString();
                }
                if (row["ncontent"] != null)
                {
                    model.ncontent = row["ncontent"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["ntype"] != null)
                {
                    model.ntype = row["ntype"].ToString();
                }
                if (row["nreadnum"] != null && row["nreadnum"].ToString() != "")
                {
                    model.nreadnum = int.Parse(row["nreadnum"].ToString());
                }
                if (row["nstate"] != null && row["nstate"].ToString() != "")
                {
                    if ((row["nstate"].ToString() == "1") || (row["nstate"].ToString().ToLower() == "true"))
                    {
                        model.nstate = true;
                    }
                    else
                    {
                        model.nstate = false;
                    }
                }
                if (row["nvrange"] != null)
                {
                    model.nvrange = row["nvrange"].ToString();
                }
                if (row["nsid"] != null)
                {
                    model.nsid = row["nsid"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["sdcode"] != null)
                {
                    model.sdcode = row["sdcode"].ToString();
                }
                if (row["rtype"] != null)
                {
                    model.rtype = row["rtype"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NB_News> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ntitle,ncontent,cdate,maker,ntype,nreadnum,nstate,nvrange,nsid,dcode,rtype,sdcode ");
            strSql.Append(" FROM NB_News ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<NB_News> r = new List<NB_News>();
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



        public List<NB_News> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        {
            List<NB_News> r = new List<NB_News>();
            DataTable dt = new Fy().BusiPage("NB_News", "*", sort, where, pagesize, curpage, ref rcount, ref pcount);
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
