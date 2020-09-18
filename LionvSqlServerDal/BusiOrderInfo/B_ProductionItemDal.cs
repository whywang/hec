using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;
using System.Collections;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_ProductionItemDal : IB_ProductionItemDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_ProductionItem");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
           
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_ProductionItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_ProductionItem(");
            strSql.Append("sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@psid,@pname,@pcode,@mname,@ptype,@height,@width,@deep,@pnum,@e_ptype,@maker,@cdate)");
         
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Decimal),
					new SqlParameter("@e_ptype", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.psid;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.pcode;
            parameters[4].Value = model.mname;
            parameters[5].Value = model.ptype;
            parameters[6].Value = model.height;
            parameters[7].Value = model.width;
            parameters[8].Value = model.deep;
            parameters[9].Value = model.pnum;
            parameters[10].Value = model.e_ptype;
            parameters[11].Value = model.maker;
            parameters[12].Value = model.cdate;
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
        public bool Update( B_ProductionItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_ProductionItem set ");
            strSql.Append("sid=@sid,");
            strSql.Append("psid=@psid,");
            strSql.Append("pname=@pname,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("mname=@mname,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("height=@height,");
            strSql.Append("width=@width,");
            strSql.Append("deep=@deep,");
            strSql.Append("pnum=@pnum,");
            strSql.Append("e_ptype=@e_ptype,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@pnum", SqlDbType.Decimal),
					new SqlParameter("@e_ptype", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.psid;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.pcode;
            parameters[4].Value = model.mname;
            parameters[5].Value = model.ptype;
            parameters[6].Value = model.height;
            parameters[7].Value = model.width;
            parameters[8].Value = model.deep;
            parameters[9].Value = model.pnum;
            parameters[10].Value = model.e_ptype;
            parameters[11].Value = model.maker;
            parameters[12].Value = model.cdate;
            parameters[13].Value = model.id;
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
            strSql.AppendFormat("delete from B_ProductionItem where 1=1 {0}", where);
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
        public B_ProductionItem Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,e_ptypeex,maker,workline,cdate,addattr,addsw,aname,hinterval,ftype from B_ProductionItem ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_ProductionItem r = new B_ProductionItem();
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
        public  B_ProductionItem DataRowToModel(DataRow row)
        {
             B_ProductionItem model = new  B_ProductionItem();
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
                if (row["psid"] != null)
                {
                    model.psid = row["psid"].ToString();
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["height"] != null && row["height"].ToString() != "")
                {
                    model.height = int.Parse(row["height"].ToString());
                }
                if (row["hinterval"] != null && row["hinterval"].ToString() != "")
                {
                    model.hinterval = int.Parse(row["hinterval"].ToString());
                }
                if (row["width"] != null && row["width"].ToString() != "")
                {
                    model.width = int.Parse(row["width"].ToString());
                }
                if (row["deep"] != null && row["deep"].ToString() != "")
                {
                    model.deep = int.Parse(row["deep"].ToString());
                }
                if (row["pnum"] != null && row["pnum"].ToString() != "")
                {
                    model.pnum = decimal.Parse(row["pnum"].ToString());
                }
                if (row["e_ptype"] != null)
                {
                    model.e_ptype = row["e_ptype"].ToString();
                }
                if (row["e_ptypeex"] != null)
                {
                    model.e_ptypeex = row["e_ptypeex"].ToString();
                }
                if (row["workline"] != null)
                {
                    model.workline = row["workline"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["addattr"] != null)
                {
                    model.addattr = row["addattr"].ToString();
                }
                if (row["addsw"] != null)
                {
                    model.addsw = row["addsw"].ToString();
                }
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["ftype"] != null)
                {
                    model.ftype = row["ftype"].ToString();
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
        public List<B_ProductionItem> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,e_ptypeex,workline,maker,cdate,addattr,addsw,aname,hinterval,ftype ");
            strSql.Append(" FROM B_ProductionItem ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_ProductionItem> r = new List<B_ProductionItem>();
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
        public int SaveItemList(List<B_ProductionItem> lb)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            foreach (B_ProductionItem bi in lb)
            {
                strSql.Append("insert into B_ProductionItem(");
                strSql.Append("sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,e_ptypeex,hinterval,ftype,maker,cdate)");
                strSql.Append(" values (");
                strSql.AppendFormat("'{0}',",bi.sid);
                strSql.AppendFormat("'{0}',",bi.psid);
                strSql.AppendFormat("'{0}',",bi.pname);
                strSql.AppendFormat("'{0}',",bi.pcode);
                strSql.AppendFormat("'{0}',",bi.mname);
                strSql.AppendFormat("'{0}',",bi.ptype);
                strSql.AppendFormat("'{0}',",bi.height);
                strSql.AppendFormat("'{0}',",bi.width);
                strSql.AppendFormat("'{0}',",bi.deep);
                strSql.AppendFormat("'{0}',",bi.pnum);
                strSql.AppendFormat("'{0}',",bi.e_ptype);
                strSql.AppendFormat("'{0}',", bi.e_ptypeex);
                strSql.AppendFormat("'{0}',", bi.hinterval);
                strSql.AppendFormat("'{0}',", bi.ftype);
                strSql.AppendFormat("'{0}',",bi.maker);
                strSql.AppendFormat("'{0}');",bi.cdate);
         
            }
            if (strSql.ToString() != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            }
            return r;
        }
        public int UpdateWorkLine(DataTable dt)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["产线"].ToString() != "")
                    {
                        strSql.AppendFormat(" update B_ProductionItem set workline='{0}' where id={1};", dr["产线"].ToString(), dr["产品ID"].ToString());
                    }
                }
            }
            if (strSql.ToString() != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            }
            return r;
        }
        public int TjItemNum(string sid, string etype)
        {
            int r = -1;
            string where = "";
            string[] arre = etype.Split(',');
            if (arre.Length > 0)
            {
                int i = 1;
                foreach (string w in arre)
                {
                    if (i == 1)
                    {
                        where = where + " and ( e_ptype='" + w + "'";
                    }
                    else
                    {
                        where = where + " or e_ptype='" + w + "'";
                    }
                    i++;
                }
                where = where + " ) ";
                string sql = "select isnull(sum( pnum),0) as n from  B_ProductionItem where sid='" + sid + "' " + where;
                object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
                r = o == null ? 9999 : Convert.ToInt32(o);
            }
            return r;
        }
        public int TjItemNum(string where)
        {
            int r = -1;
            string sql = "select isnull(sum( pnum),0) as n from  B_ProductionItem where 1=1 " + where;
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o);
            return r;
        }
        #region//编辑产品部件
        public int InsertAddUpdateItems(string sid,int gnum,List<B_ProductionItem> uitems, List<B_ProductionItem> iitems)
        {
            int r = 0;
            StringBuilder Sqlstr = new StringBuilder();
            StringBuilder Sqlwhere = new StringBuilder();
            B_ProductionItem bpinfo = Query(" and psid in(select psid from B_GroupProduction where sid='" + sid + "' and gnum=" + gnum + " and substring(icode,1,2)<>'01' and substring(icode,1,2)<>'04' and substring(icode,1,2)<>'05')");
            if (uitems.Count>0)
            {
                foreach(B_ProductionItem bpi in uitems)
                {
                    Sqlstr.AppendFormat(" update B_ProductionItem set height={0},width={1},deep={2},pnum={3},pname='{4}',pcode='{5}',ptype='{6}',e_ptype='{7}',e_ptypeex='{8}' where id={9};", bpi.height, bpi.width, bpi.deep, bpi.pnum,bpi.pname,bpi.pcode,bpi.ptype,bpi.e_ptype,bpi.e_ptypeex, bpi.id);
                    Sqlwhere.AppendFormat(" and id<>{0}", bpi.id);
                }
                Sqlstr.AppendFormat(" delete from B_ProductionItem where psid in(select psid from B_GroupProduction where sid='{0}' and gnum={1}) {2};", sid, gnum, Sqlwhere.ToString());
            }
            if(iitems.Count>0)
            {
                if (bpinfo != null)
                {
                    foreach (B_ProductionItem bpi in iitems)
                    {
                        Sqlstr.AppendFormat(" insert into B_ProductionItem (sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,e_ptypeex,aname,addattr,maker,cdate) values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9},'{10}','{11}','{12}','{13}','{14}','{15}');", sid, bpinfo.psid, bpinfo.pname, bpinfo.pcode, bpinfo.mname, bpinfo.ptype, bpi.height, bpi.width, bpi.deep, bpi.pnum, bpi.e_ptype, bpi.e_ptypeex, bpi.aname, bpi.addattr, "admin", DateTime.Now.ToString());
                    }
                }
            }
            if (Sqlstr.ToString() != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, Sqlstr.ToString(), null);
            }
            return r;
        }
        #endregion
        #region//售后编辑产品部件
        public int AfterUpdateItems(List<B_ProductionItem> epi, List<B_ProductionItem> dpi, ArrayList psids)
        {
            int r = 0;
            StringBuilder Sqlstr = new StringBuilder();
            StringBuilder Sqlwhere = new StringBuilder();
            if (epi.Count > 0)
            {
                foreach (B_ProductionItem pi in epi)
                {
                    Sqlstr.AppendFormat(" update B_ProductionItem set height={0},width={1},deep={2},pnum={3} where id={4};", pi.height, pi.width, pi.deep, pi.pnum, pi.id);
                }
            }
            if (epi.Count > 0)
            {
                foreach (B_ProductionItem pi in dpi)
                {
                    Sqlstr.AppendFormat(" delete from B_ProductionItem where id={0};", pi.id);
            
                }
            }
            if (psids.Count > 0)
            {
                foreach (string psid in psids)
                {
                    Sqlstr.AppendFormat(" delete from B_GroupProduction where psid='{0}';", psid);
                }
            }
            if (Sqlstr.ToString() != "")
            {
                r = SqlHelp.ExecuteNonQueryTran(SqlHelp.ConnectionStringb, CommandType.Text, Sqlstr.ToString(), null);
            }
            return r;
        }
        #endregion
        public DataTable QueryTable(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptypeex,e_ptype,workline,maker,cdate,addattr,addsw,aname,hinterval,ftype ");
            strSql.Append(" FROM B_ProductionItem ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_ProductionItem> r = new List<B_ProductionItem>();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public B_ProductionItem Query(DataTable dt, string where)
        {
            B_ProductionItem r = new B_ProductionItem();
            if (dt != null)
            {
                DataRow[] dts = dt.Select(" 1=1" + where);
                if (dts != null)
                {
                    if (dts.Count() > 0)
                    {
                        r = DataRowToModel(dts[0]);
                    }
                    else
                    {
                        r = null;
                    }
                }
                else
                {
                    r = null;
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
