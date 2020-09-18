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
    public class B_PackageDal : IB_PackageDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Package");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_Package model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Package(");
            strSql.Append("sid,bsid,sortnum,bnum,pname,pnum,height,width,deep,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@bsid,@sortnum,@bnum,@pname,@pnum,@height,@width,@deep,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@bsid", SqlDbType.NVarChar,50),
					new SqlParameter("@sortnum", SqlDbType.Int,4),
					new SqlParameter("@bnum", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pnum", SqlDbType.Int,4),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.bsid;
            parameters[2].Value = model.sortnum;
            parameters[3].Value = model.bnum;
            parameters[4].Value = model.pname;
            parameters[5].Value = model.pnum;
            parameters[6].Value = model.height;
            parameters[7].Value = model.width;
            parameters[8].Value = model.deep;
            parameters[9].Value = model.maker;
            parameters[10].Value = model.cdate;
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
        public bool Update( B_Package model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Package set ");
            strSql.Append("sid=@sid,");
            strSql.Append("sortnum=@sortnum,");
            strSql.Append("bnum=@bnum,");
            strSql.Append("pname=@pname,");
            strSql.Append("pnum=@pnum,");
            strSql.Append("height=@height,");
            strSql.Append("width=@width,");
            strSql.Append("deep=@deep,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@sortnum", SqlDbType.Int,4),
					new SqlParameter("@bnum", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pnum", SqlDbType.Int,4),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@bsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.sortnum;
            parameters[2].Value = model.bnum;
            parameters[3].Value = model.pname;
            parameters[4].Value = model.pnum;
            parameters[5].Value = model.height;
            parameters[6].Value = model.width;
            parameters[7].Value = model.deep;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.cdate;
            parameters[10].Value = model.id;
            parameters[11].Value = model.bsid;
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
            strSql.AppendFormat("delete from B_Package where 1=1 {0}", where);
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
        public  B_Package Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,bsid,bzid,sortnum,bnum,pname,pcode,pnum,height,width,deep,btype,maker,cdate ,bz,zbrk,zbck,csrk,csck from B_Package ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_Package r = new B_Package();
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
        public DataRow ViewQuery(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from View_B_Package ");
            strSql.AppendFormat(" where 1=1 {0}", where);

            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
            
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  B_Package DataRowToModel(DataRow row)
        {
            B_Package model = new  B_Package();
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
                if (row["bzid"] != null)
                {
                    model.sid = row["bzid"].ToString();
                }
                if (row["bsid"] != null)
                {
                    model.bsid = row["bsid"].ToString();
                }
                if (row["sortnum"] != null && row["sortnum"].ToString() != "")
                {
                    model.sortnum = int.Parse(row["sortnum"].ToString());
                }
                if (row["bnum"] != null && row["bnum"].ToString() != "")
                {
                    model.bnum = int.Parse(row["bnum"].ToString());
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["pnum"] != null && row["pnum"].ToString() != "")
                {
                    model.pnum = int.Parse(row["pnum"].ToString());
                }
                if (row["height"] != null && row["height"].ToString() != "")
                {
                    model.height = int.Parse(row["height"].ToString());
                }
                if (row["width"] != null && row["width"].ToString() != "")
                {
                    model.width = int.Parse(row["width"].ToString());
                }
                if (row["deep"] != null && row["deep"].ToString() != "")
                {
                    model.deep = int.Parse(row["deep"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["btype"] != null)
                {
                    model.btype = row["btype"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
                if (row["bz"] != null && row["bz"].ToString() != "")
                {
                    model.bz = int.Parse(row["bz"].ToString());
                }
                if (row["zbrk"] != null && row["zbrk"].ToString() != "")
                {
                    model.zbrk = int.Parse(row["zbrk"].ToString());
                }
                if (row["zbck"] != null && row["zbck"].ToString() != "")
                {
                    model.zbck = int.Parse(row["zbck"].ToString());
                }
                if (row["csrk"] != null && row["csrk"].ToString() != "")
                {
                    model.csrk = int.Parse(row["csrk"].ToString());
                }
                if (row["csck"] != null && row["csck"].ToString() != "")
                {
                    model.csck = int.Parse(row["csck"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_Package> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,bsid,sortnum,bzid,bnum,pname,pcode,pnum,height,width,deep,maker,cdate,btype,bz,zbrk,zbck,csrk,csck ");
            strSql.Append(" FROM B_Package ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_Package> r = new List<B_Package>();
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
        public DataTable QueryVList(string colv,string where,string sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.AppendFormat(" {0} ", colv);
            strSql.Append(" FROM View_B_Package ");
            strSql.AppendFormat(" where 1=1 {0} {1}", where,sort);
            List<B_Package> r = new List<B_Package>();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            return dt;
        }
        //获取保存编码
        public string QueryPackageCode(string bsid,string padstr,string ptype)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct( bzid)  FROM View_B_Package ");
            if (ptype == "")
            {
                strSql.AppendFormat(" where bsid='{0}'", bsid);
            }
            else
            {
                strSql.AppendFormat(" where bsid='{0}' and  btype='{1}'", bsid,ptype);
            }
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                int k = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    if (k == 1)
                    {
                        r = padstr + dr["bzid"].ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        r = r + "-" + padstr + dr["bzid"].ToString().PadLeft(8, '0');
                    }
                    k++;
                }
            }
            else
            {
                r = "";
            }
            return r;
        }
        public string QueryPackageCodeEx(string bsid, string padstr, string h,string w)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select bzid  FROM View_B_Package ");
            strSql.AppendFormat(" where bsid='{0}' and  height={1} and width={2}", bsid,h,w);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                int k = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    if (k == 1)
                    {
                        r = padstr + dr["bzid"].ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        r = r + "-" + padstr + dr["bzid"].ToString().PadLeft(8, '0');
                    }
                    k++;
                }
            }
            else
            {
                r = "";
            }
            return r;
        }
        public int PackageNum(string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull( max(bnum),0) as n");
            strSql.Append(" FROM  B_Package ");
            strSql.AppendFormat(" where sid='{0}'", sid);
            int r = 0;
            object o= SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb ,CommandType.Text, strSql.ToString(), null);
            if (o != null)
            {
                r = Convert.ToInt32(o);
            }
            return r;
        }
        #region//更行包状态
        public bool UpPackageState(string sid,int bnum,string field,string v)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Package set ");
            strSql.AppendFormat(" {0}={1} ",field,v);
            strSql.AppendFormat(" where sid='{0}' and bnum='{1}'",sid,bnum);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery2(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion
        #region//更行订单包状态
        public bool UpPackageState(string sid, string field, string v)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Package set ");
            strSql.AppendFormat(" {0}={1} ", field, v);
            strSql.AppendFormat(" where sid='{0}'", sid);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery2(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion
        #region//获取发货单包装信息
        public DataRow QuerySendPackage(string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_tj_SendPackage ");
            strSql.AppendFormat(" where sid='{0}'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                return  dt.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion
        public bool SavePackageList(ArrayList gsid, List<B_Package> lbp)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (string bsid in gsid)
            {
                strSql.AppendFormat("delete from B_Package where bsid='{0}';", bsid);
            }
            foreach (B_Package b in lbp)
            {
                strSql.Append("insert into B_Package(");
                strSql.Append("sid,bsid,sortnum,bnum,pname,pnum,height,width,deep,maker,cdate,pcode,bzid)");
                strSql.Append(" values (");
                strSql.AppendFormat("'{0}','{1}',{2},{3},'{4}',{5},{6},{7},{8},'{9}','{10}','{11}',{12})", b.sid, b.bsid, b.sortnum, b.bnum, b.pname, 1, b.height, b.width, b.deep, b.maker, b.cdate,b.pcode,b.bzid);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                UpUnPackge(gsid);
                r = true;
            }
            return r;
        }
        private void UpUnPackge(ArrayList al)
        {
            foreach (string bsid in al)
            {
                StringBuilder strSql = new StringBuilder();
                if (Exists(" and bnum=0 and bsid='" + bsid + "'") && Exists(" and bnum>0 and bsid='" + bsid + "'"))
                {
                    strSql.AppendFormat("update B_Package set bnum=(select bnum from B_Package where bnum>0 and bsid='{0}') where bsid='{0}' and bnum=0;", bsid);
                    SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
                }
            }
        }
        #endregion  ExtensionMethod
    }
}
