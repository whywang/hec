using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvCommon;
using System.Data;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Collections;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_GroupProductionMoneyDal : IB_GroupProductionMoneyDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_GroupProductionMoney");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_GroupProductionMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_GroupProductionMoney(");
            strSql.Append("sid,gsid,psid,gnum,pname,pcode,squality,sdistype,sdiscount,smoney,sovermoney,sothermoney,dsmoney,dsovermoney,dsothermoney,gquality,gdistype,gdiscount,gmoney,govermoney,gothermoney,dgmoney,dgovermoney,dgothermoney,cquality,cdistype,cdiscount,cmoney,covermoney,cothermoney,dcmoney,dcovermoney,dcothermoney,cdate,pnum)");
            strSql.Append(" values (");
            strSql.Append("@sid,@gsid,@psid,@gnum,@pname,@pcode,@squality,@sdistype,@sdiscount,@smoney,@sovermoney,@sothermoney,@dsmoney,@dsovermoney,@dsothermoney,@gquality,@gdistype,@gdiscount,@gmoney,@govermoney,@gothermoney,@dgmoney,@dgovermoney,@dgothermoney,@cquality,@cdistype,@cdiscount,@cmoney,@covermoney,@cothermoney,@dcmoney,@dcovermoney,@dcothermoney,@cdate,@pnum)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,50),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@squality", SqlDbType.Decimal,9),
					new SqlParameter("@sdistype", SqlDbType.NVarChar,30),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@smoney", SqlDbType.Decimal,9),
					new SqlParameter("@sovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@sothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dsmoney", SqlDbType.Decimal,9),
					new SqlParameter("@dsovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dsothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@gquality", SqlDbType.Decimal,9),
					new SqlParameter("@gdistype", SqlDbType.NVarChar,30),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gmoney", SqlDbType.Decimal,9),
					new SqlParameter("@govermoney", SqlDbType.Decimal,9),
					new SqlParameter("@gothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dgmoney", SqlDbType.Decimal,9),
					new SqlParameter("@dgovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dgothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cquality", SqlDbType.Decimal,9),
					new SqlParameter("@cdistype", SqlDbType.NVarChar,30),
					new SqlParameter("@cdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@cmoney", SqlDbType.Decimal,9),
					new SqlParameter("@covermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dcmoney", SqlDbType.Decimal,9),
					new SqlParameter("@dcovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dcothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.psid;
            parameters[3].Value = model.gnum;
            parameters[4].Value = model.pname;
            parameters[5].Value = model.pcode;
            parameters[6].Value = model.squality;
            parameters[7].Value = model.sdistype;
            parameters[8].Value = model.sdiscount;
            parameters[9].Value = model.smoney;
            parameters[10].Value = model.sovermoney;
            parameters[11].Value = model.sothermoney;
            parameters[12].Value = model.dsmoney;
            parameters[13].Value = model.dsovermoney;
            parameters[14].Value = model.dsothermoney;
            parameters[15].Value = model.gquality;
            parameters[16].Value = model.gdistype;
            parameters[17].Value = model.gdiscount;
            parameters[18].Value = model.gmoney;
            parameters[19].Value = model.govermoney;
            parameters[20].Value = model.gothermoney;
            parameters[21].Value = model.dgmoney;
            parameters[22].Value = model.dgovermoney;
            parameters[23].Value = model.dgothermoney;
            parameters[24].Value = model.cquality;
            parameters[25].Value = model.cdistype;
            parameters[26].Value = model.cdiscount;
            parameters[27].Value = model.cmoney;
            parameters[28].Value = model.covermoney;
            parameters[29].Value = model.cothermoney;
            parameters[30].Value = model.dcmoney;
            parameters[31].Value = model.dcovermoney;
            parameters[32].Value = model.dcothermoney;
            parameters[33].Value = model.cdate;
            parameters[34].Value = model.pnum;
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
        public bool Update(B_GroupProductionMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_GroupProductionMoney set ");
            strSql.Append("sid=@sid,");
            strSql.Append("gsid=@gsid,");
            strSql.Append("gnum=@gnum,");
            strSql.Append("pname=@pname,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("squality=@squality,");
            strSql.Append("sdistype=@sdistype,");
            strSql.Append("sdiscount=@sdiscount,");
            strSql.Append("smoney=@smoney,");
            strSql.Append("sovermoney=@sovermoney,");
            strSql.Append("sothermoney=@sothermoney,");
            strSql.Append("dsmoney=@dsmoney,");
            strSql.Append("dsovermoney=@dsovermoney,");
            strSql.Append("dsothermoney=@dsothermoney,");
            strSql.Append("gquality=@gquality,");
            strSql.Append("gdistype=@gdistype,");
            strSql.Append("gdiscount=@gdiscount,");
            strSql.Append("gmoney=@gmoney,");
            strSql.Append("govermoney=@govermoney,");
            strSql.Append("gothermoney=@gothermoney,");
            strSql.Append("dgmoney=@dgmoney,");
            strSql.Append("dgovermoney=@dgovermoney,");
            strSql.Append("dgothermoney=@dgothermoney,");
            strSql.Append("cquality=@cquality,");
            strSql.Append("cdistype=@cdistype,");
            strSql.Append("cdiscount=@cdiscount,");
            strSql.Append("cmoney=@cmoney,");
            strSql.Append("covermoney=@covermoney,");
            strSql.Append("cothermoney=@cothermoney,");
            strSql.Append("dcmoney=@dcmoney,");
            strSql.Append("dcovermoney=@dcovermoney,");
            strSql.Append("dcothermoney=@dcothermoney,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("pnum=@pnum ");
            strSql.Append(" where psid=@psid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.NVarChar,50),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@squality", SqlDbType.Decimal,9),
					new SqlParameter("@sdistype", SqlDbType.NVarChar,30),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@smoney", SqlDbType.Decimal,9),
					new SqlParameter("@sovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@sothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dsmoney", SqlDbType.Decimal,9),
					new SqlParameter("@dsovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dsothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@gquality", SqlDbType.Decimal,9),
					new SqlParameter("@gdistype", SqlDbType.NVarChar,30),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gmoney", SqlDbType.Decimal,9),
					new SqlParameter("@govermoney", SqlDbType.Decimal,9),
					new SqlParameter("@gothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dgmoney", SqlDbType.Decimal,9),
					new SqlParameter("@dgovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dgothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cquality", SqlDbType.Decimal,9),
					new SqlParameter("@cdistype", SqlDbType.NVarChar,30),
					new SqlParameter("@cdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@cmoney", SqlDbType.Decimal,9),
					new SqlParameter("@covermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dcmoney", SqlDbType.Decimal,9),
					new SqlParameter("@dcovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@dcothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@pnum", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.gnum;
            parameters[3].Value = model.pname;
            parameters[4].Value = model.pcode;
            parameters[5].Value = model.squality;
            parameters[6].Value = model.sdistype;
            parameters[7].Value = model.sdiscount;
            parameters[8].Value = model.smoney;
            parameters[9].Value = model.sovermoney;
            parameters[10].Value = model.sothermoney;
            parameters[11].Value = model.dsmoney;
            parameters[12].Value = model.dsovermoney;
            parameters[13].Value = model.dsothermoney;
            parameters[14].Value = model.gquality;
            parameters[15].Value = model.gdistype;
            parameters[16].Value = model.gdiscount;
            parameters[17].Value = model.gmoney;
            parameters[18].Value = model.govermoney;
            parameters[19].Value = model.gothermoney;
            parameters[20].Value = model.dgmoney;
            parameters[21].Value = model.dgovermoney;
            parameters[22].Value = model.dgothermoney;
            parameters[23].Value = model.cquality;
            parameters[24].Value = model.cdistype;
            parameters[25].Value = model.cdiscount;
            parameters[26].Value = model.cmoney;
            parameters[27].Value = model.covermoney;
            parameters[28].Value = model.cothermoney;
            parameters[29].Value = model.dcmoney;
            parameters[30].Value = model.dcovermoney;
            parameters[31].Value = model.dcothermoney;
            parameters[32].Value = model.cdate;
            parameters[33].Value = model.psid;
            parameters[34].Value = model.pnum;
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
            strSql.Append("delete from B_GroupProductionMoney ");
            strSql.AppendFormat(" where 1=1 {0}", where);
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
        public B_GroupProductionMoney Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,gsid,psid,pnum,gnum,pname,pcode,squality,sdistype,sdiscount,smoney,sovermoney,sothermoney,dsmoney,dsovermoney,dsothermoney,gquality,gdistype,gdiscount,gmoney,govermoney,gothermoney,dgmoney,dgovermoney,dgothermoney,cquality,cdistype,cdiscount,cmoney,covermoney,cothermoney,dcmoney,dcovermoney,dcothermoney,cdate from B_GroupProductionMoney ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_GroupProductionMoney r = new B_GroupProductionMoney();
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
        public B_GroupProductionMoney DataRowToModel(DataRow row)
        {
            B_GroupProductionMoney model = new B_GroupProductionMoney();
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
                if (row["gsid"] != null)
                {
                    model.gsid = row["gsid"].ToString();
                }
                if (row["psid"] != null)
                {
                    model.psid = row["psid"].ToString();
                }
                if (row["pnum"] != null && row["pnum"].ToString() != "")
                {
                    model.pnum = int.Parse(row["pnum"].ToString());
                }
                if (row["gnum"] != null && row["gnum"].ToString() != "")
                {
                    model.gnum = int.Parse(row["gnum"].ToString());
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["squality"] != null && row["squality"].ToString() != "")
                {
                    model.squality = decimal.Parse(row["squality"].ToString());
                }
                if (row["sdistype"] != null)
                {
                    model.sdistype = row["sdistype"].ToString();
                }
                if (row["sdiscount"] != null && row["sdiscount"].ToString() != "")
                {
                    model.sdiscount = decimal.Parse(row["sdiscount"].ToString());
                }
                if (row["smoney"] != null && row["smoney"].ToString() != "")
                {
                    model.smoney = decimal.Parse(row["smoney"].ToString());
                }
                if (row["sovermoney"] != null && row["sovermoney"].ToString() != "")
                {
                    model.sovermoney = decimal.Parse(row["sovermoney"].ToString());
                }
                if (row["sothermoney"] != null && row["sothermoney"].ToString() != "")
                {
                    model.sothermoney = decimal.Parse(row["sothermoney"].ToString());
                }
                if (row["dsmoney"] != null && row["dsmoney"].ToString() != "")
                {
                    model.dsmoney = decimal.Parse(row["dsmoney"].ToString());
                }
                if (row["dsovermoney"] != null && row["dsovermoney"].ToString() != "")
                {
                    model.dsovermoney = decimal.Parse(row["dsovermoney"].ToString());
                }
                if (row["dsothermoney"] != null && row["dsothermoney"].ToString() != "")
                {
                    model.dsothermoney = decimal.Parse(row["dsothermoney"].ToString());
                }
                if (row["gquality"] != null && row["gquality"].ToString() != "")
                {
                    model.gquality = decimal.Parse(row["gquality"].ToString());
                }
                if (row["gdistype"] != null)
                {
                    model.gdistype = row["gdistype"].ToString();
                }
                if (row["gdiscount"] != null && row["gdiscount"].ToString() != "")
                {
                    model.gdiscount = decimal.Parse(row["gdiscount"].ToString());
                }
                if (row["gmoney"] != null && row["gmoney"].ToString() != "")
                {
                    model.gmoney = decimal.Parse(row["gmoney"].ToString());
                }
                if (row["govermoney"] != null && row["govermoney"].ToString() != "")
                {
                    model.govermoney = decimal.Parse(row["govermoney"].ToString());
                }
                if (row["gothermoney"] != null && row["gothermoney"].ToString() != "")
                {
                    model.gothermoney = decimal.Parse(row["gothermoney"].ToString());
                }
                if (row["dgmoney"] != null && row["dgmoney"].ToString() != "")
                {
                    model.dgmoney = decimal.Parse(row["dgmoney"].ToString());
                }
                if (row["dgovermoney"] != null && row["dgovermoney"].ToString() != "")
                {
                    model.dgovermoney = decimal.Parse(row["dgovermoney"].ToString());
                }
                if (row["dgothermoney"] != null && row["dgothermoney"].ToString() != "")
                {
                    model.dgothermoney = decimal.Parse(row["dgothermoney"].ToString());
                }
                if (row["cquality"] != null && row["cquality"].ToString() != "")
                {
                    model.cquality = decimal.Parse(row["cquality"].ToString());
                }
                if (row["cdistype"] != null)
                {
                    model.cdistype = row["cdistype"].ToString();
                }
                if (row["cdiscount"] != null && row["cdiscount"].ToString() != "")
                {
                    model.cdiscount = decimal.Parse(row["cdiscount"].ToString());
                }
                if (row["cmoney"] != null && row["cmoney"].ToString() != "")
                {
                    model.cmoney = decimal.Parse(row["cmoney"].ToString());
                }
                if (row["covermoney"] != null && row["covermoney"].ToString() != "")
                {
                    model.covermoney = decimal.Parse(row["covermoney"].ToString());
                }
                if (row["cothermoney"] != null && row["cothermoney"].ToString() != "")
                {
                    model.cothermoney = decimal.Parse(row["cothermoney"].ToString());
                }
                if (row["dcmoney"] != null && row["dcmoney"].ToString() != "")
                {
                    model.dcmoney = decimal.Parse(row["dcmoney"].ToString());
                }
                if (row["dcovermoney"] != null && row["dcovermoney"].ToString() != "")
                {
                    model.dcovermoney = decimal.Parse(row["dcovermoney"].ToString());
                }
                if (row["dcothermoney"] != null && row["dcothermoney"].ToString() != "")
                {
                    model.dcothermoney = decimal.Parse(row["dcothermoney"].ToString());
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
        public List<B_GroupProductionMoney> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,gsid,psid,gnum,pnum,pname,pcode,squality,sdistype,sdiscount,smoney,sovermoney,sothermoney,dsmoney,dsovermoney,dsothermoney,gquality,gdistype,gdiscount,gmoney,govermoney,gothermoney,dgmoney,dgovermoney,dgothermoney,cquality,cdistype,cdiscount,cmoney,covermoney,cothermoney,dcmoney,dcovermoney,dcothermoney,cdate ");
            strSql.Append(" FROM B_GroupProductionMoney ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_GroupProductionMoney> r = new List<B_GroupProductionMoney>();
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
        public bool SetProductionPrice(List<B_GroupProductionMoney> bfpms, string ptype)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (B_GroupProductionMoney bfpm in bfpms)
            {
                if (Exists(" and psid='" + bfpm.psid + "'"))
                {
                    switch (ptype)
                    {
                        case "xs":
                            strSql.AppendFormat(" update B_GroupProductionMoney set squality={0},sdistype='{1}',sdiscount={2},smoney={3},sovermoney={4},sothermoney={5},dsmoney={6},dsovermoney={7},dsothermoney={8} where psid='{9}';", bfpm.squality, bfpm.sdistype, bfpm.sdiscount, bfpm.smoney, bfpm.sovermoney, bfpm.sothermoney, bfpm.dsmoney, bfpm.dsovermoney, bfpm.dsothermoney, bfpm.psid);
                            break;
                        case "gh":
                            strSql.AppendFormat(" update B_GroupProductionMoney set gquality={0},gdistype='{1}',gdiscount={2},gmoney={3},govermoney={4},gothermoney={5},dgmoney={6},dgovermoney={7},dgothermoney={8} where psid='{9}';", bfpm.gquality, bfpm.gdistype, bfpm.gdiscount, bfpm.gmoney, bfpm.govermoney, bfpm.gothermoney, bfpm.dgmoney, bfpm.dgovermoney, bfpm.dgothermoney, bfpm.psid);
                            break;
                        case "cg":
                            strSql.AppendFormat(" update B_GroupProductionMoney set cquality={0},cdistype='{1}',cdiscount={2},cmoney={3},covermoney={4},cothermoney={5},dcmoney={6},dcovermoney={7},dcothermoney={8} where psid='{9}';", bfpm.cquality, bfpm.cdistype, bfpm.cdiscount, bfpm.cmoney, bfpm.covermoney, bfpm.cothermoney, bfpm.dcmoney, bfpm.dcovermoney, bfpm.dcothermoney, bfpm.psid);
                            break;
                    }
                }
                else
                {
                    switch (ptype)
                    {
                        case "xs":
                            strSql.Append(" insert into B_GroupProductionMoney ( sid,gsid,psid,gnum,pname,pcode,squality,sdistype,sdiscount,smoney,sovermoney,sothermoney,dsmoney,dsovermoney,dsothermoney,pnum) values");
                            strSql.AppendFormat(" ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}',{8},{9},{10},{11},{12},{13},{14},{15});", bfpm.sid, bfpm.gsid, bfpm.psid, bfpm.gnum, bfpm.pname, bfpm.pcode, bfpm.squality, bfpm.sdistype, bfpm.sdiscount, bfpm.smoney, bfpm.sovermoney, bfpm.sothermoney, bfpm.dsmoney, bfpm.dsovermoney, bfpm.dsothermoney, bfpm.pnum);
                            break;
                        case "gh":
                            strSql.Append(" insert into B_GroupProductionMoney ( sid,gsid,psid,gnum,pname,pcode,gquality,gdistype,gdiscount,gmoney,govermoney,gothermoney,dgmoney,dgovermoney,dgothermoney,pnum) values");
                            strSql.AppendFormat(" ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}',{8},{9},{10},{11},{12},{13},{14},{15});", bfpm.sid, bfpm.gsid, bfpm.psid, bfpm.gnum, bfpm.pname, bfpm.pcode, bfpm.gquality, bfpm.gdistype, bfpm.gdiscount, bfpm.gmoney, bfpm.govermoney, bfpm.gothermoney, bfpm.dgmoney, bfpm.dgovermoney, bfpm.dgothermoney, bfpm.pnum);
                            break;
                        case "cg":
                            strSql.Append(" insert into B_GroupProductionMoney ( sid,gsid,psid,gnum,pname,pcode,cquality,cdistype,cdiscount,cmoney,covermoney,cothermoney,dcmoney,dcovermoney,dcothermoney,pnum) values");
                            strSql.AppendFormat(" ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}',{8},{9},{10},{11},{12},{13},{14},{15});", bfpm.sid, bfpm.gsid, bfpm.psid, bfpm.gnum, bfpm.pname, bfpm.pcode, bfpm.cquality, bfpm.cdistype, bfpm.cdiscount, bfpm.cmoney, bfpm.covermoney, bfpm.cothermoney, bfpm.dcmoney, bfpm.dcovermoney, bfpm.dcothermoney, bfpm.pnum);
                            break;
                    }
                }
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
        //ptype 为价格类型（销售、供货、采购）；mtype未金额类型（标准金额、实际金额）
        public decimal QueryGroupMoney(string gsid, string ptype, string mtype)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            switch (ptype)
            {
                case "xs":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(smoney),0) + isnull(sum(sovermoney),0)+ isnull(sum(sothermoney),0) as amoney from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dsmoney),0) + isnull(sum(dsovermoney),0)+ isnull(sum(dsothermoney),0) as amoney from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    break;
                case "gh":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(gmoney),0) + isnull(sum(govermoney),0)+ isnull(sum(gothermoney),0) as amoney from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dgmoney),0) + isnull(sum(dgovermoney),0)+ isnull(sum(dgothermoney),0) as amoney from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    break;
                case "cg":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(cmoney),0) + isnull(sum(covermoney),0)+ isnull(sum(cothermoney),0) as amoney from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dcmoney),0) + isnull(sum(dcovermoney),0)+ isnull(sum(dcothermoney),0) as amoney from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    break;
            }
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0]["amoney"].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        //ptype 为价格类型（销售、供货、采购）；mtype未金额类型（标准金额、实际金额）
        public decimal[] QueryGroupMoneyDetail(string gsid, string ptype, string mtype)
        {
            decimal[] r = new decimal[3];
            StringBuilder strSql = new StringBuilder();
            switch (ptype)
            {
                case "xs":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(smoney),0) as nm, isnull(sum(sovermoney),0) as om, isnull(sum(sothermoney),0) as qm from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dsmoney),0)  as nm, isnull(sum(dsovermoney),0) as om, isnull(sum(dsothermoney),0) as qm from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    break;
                case "gh":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(gmoney),0) as nm, isnull(sum(govermoney),0) as om, isnull(sum(gothermoney),0) as qm from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dgmoney),0) as nm, isnull(sum(dgovermoney),0)as om, isnull(sum(dgothermoney),0) as qm from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    break;
                case "cg":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(cmoney),0) as nm, isnull(sum(covermoney),0)as om, isnull(sum(cothermoney),0) as qm from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dcmoney),0) as nm, isnull(sum(dcovermoney),0)+ isnull(sum(dcothermoney),0) as qm from B_GroupProductionMoney where gsid='{0}'", gsid);
                    }
                    break;
            }
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r[0] = Convert.ToDecimal(dt.Rows[0]["nm"].ToString());
                r[1] = Convert.ToDecimal(dt.Rows[0]["om"].ToString());
                r[2] = Convert.ToDecimal(dt.Rows[0]["qm"].ToString());
            }
            else
            {
                r[0] = 0;
                r[1] = 0;
                r[2] = 0;
            }
            return r;
        }
        //获取订单金额
        public decimal QueryOrderMoney(string sid, string ptype, string mtype)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            switch (ptype)
            {
                case "xs":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(smoney),0) + isnull(sum(sovermoney),0)+ isnull(sum(sothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}'", sid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dsmoney),0) + isnull(sum(dsovermoney),0)+ isnull(sum(dsothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}'", sid);
                    }
                    break;
                case "gh":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(gmoney),0) + isnull(sum(govermoney),0)+ isnull(sum(gothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}'", sid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dgmoney),0) + isnull(sum(dgovermoney),0)+ isnull(sum(dgothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}'", sid);
                    }
                    break;
                case "cg":
                    if (mtype == "n")
                    {
                        strSql.AppendFormat(" select isnull(sum(cmoney),0) + isnull(sum(covermoney),0)+ isnull(sum(cothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}'", sid);
                    }
                    if (mtype == "t")
                    {
                        strSql.AppendFormat(" select isnull(sum(dcmoney),0) + isnull(sum(dcovermoney),0)+ isnull(sum(dcothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}'", sid);
                    }
                    break;
            }
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0]["amoney"].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        //获取订单产品分类金额
        public decimal QueryClassOrderMoney(string sid, string ptype, string mtype, string ctype)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            switch (ptype)
            {
                case "xs":
                    if (mtype == "n")
                    {
                        if (ctype == "wj")
                        {
                            strSql.AppendFormat(" select isnull(sum(smoney),0) + isnull(sum(sovermoney),0)+ isnull(sum(sothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)='04'", sid);
                        }
                        if (ctype == "mzp")
                        {
                            strSql.AppendFormat(" select isnull(sum(smoney),0) + isnull(sum(sovermoney),0)+ isnull(sum(sothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)<>'04'", sid);
                        }
                    }
                    if (mtype == "t")
                    {
                        if (ctype == "wj")
                        {
                            strSql.AppendFormat(" select isnull(sum(dsmoney),0) + isnull(sum(dsovermoney),0)+ isnull(sum(dsothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}'  and substring( pcode,9,2)='04'", sid);
                        }
                        if (ctype == "mzp")
                        {
                            strSql.AppendFormat(" select isnull(sum(dsmoney),0) + isnull(sum(dsovermoney),0)+ isnull(sum(dsothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}'  and substring( pcode,9,2)<>'04'", sid);
                        }
                    }
                    break;
                case "gh":
                    if (mtype == "n")
                    {
                        if (ctype == "wj")
                        {
                            strSql.AppendFormat(" select isnull(sum(gmoney),0) + isnull(sum(govermoney),0)+ isnull(sum(gothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)='04'", sid);
                        }
                        if (ctype == "mzp")
                        {
                            strSql.AppendFormat(" select isnull(sum(gmoney),0) + isnull(sum(govermoney),0)+ isnull(sum(gothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)<>'04'", sid);
                        }
                    }
                    if (mtype == "t")
                    {
                        if (ctype == "wj")
                        {
                            strSql.AppendFormat(" select isnull(sum(dgmoney),0) + isnull(sum(dgovermoney),0)+ isnull(sum(dgothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)='04'", sid);
                        }
                        if (ctype == "mzp")
                        {
                            strSql.AppendFormat(" select isnull(sum(dgmoney),0) + isnull(sum(dgovermoney),0)+ isnull(sum(dgothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)<>'04'", sid);
                        }
                    }
                    break;
                case "cg":
                    if (mtype == "n")
                    {
                        if (ctype == "wj")
                        {
                            strSql.AppendFormat(" select isnull(sum(cmoney),0) + isnull(sum(covermoney),0)+ isnull(sum(cothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)='04'", sid);
                        }
                        if (ctype == "mzp")
                        {
                            strSql.AppendFormat(" select isnull(sum(cmoney),0) + isnull(sum(covermoney),0)+ isnull(sum(cothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)<>'04'", sid);
                        }
                    }
                    if (mtype == "t")
                    {
                        if (ctype == "wj")
                        {
                            strSql.AppendFormat(" select isnull(sum(dcmoney),0) + isnull(sum(dcovermoney),0)+ isnull(sum(dcothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)='04'", sid);
                        }
                        if (ctype == "mzp")
                        {
                            strSql.AppendFormat(" select isnull(sum(dcmoney),0) + isnull(sum(dcovermoney),0)+ isnull(sum(dcothermoney),0) as amoney from B_GroupProductionMoney where sid='{0}' and substring( pcode,9,2)<>'04'", sid);
                        }
                    }
                    break;
            }
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0]["amoney"].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        //更新价格
        public bool EditProductionMoney(ArrayList plist, string ptype)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (ArrayList al in plist)
            {
                switch (ptype)
                {
                    case "xs":
                        strSql.AppendFormat(" update B_GroupProductionMoney set dsmoney={0},dsovermoney={1},dsothermoney={2} where id={3};",al[1],al[2],al[3],al[0]);
                        break;
                    case "gh":
                        strSql.AppendFormat(" update B_GroupProductionMoney set dgmoney={0},dgovermoney={1},dgothermoney={2} where id={3}; ",al[1],al[2],al[3],al[0]);
                        break;
                    case "cg":
                        strSql.AppendFormat(" update B_GroupProductionMoney se dcmoney={0},dcovermoney={1},dcothermoney={2} where id={3};",al[1],al[2],al[3],al[0]);
                        break;
                }
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
        #endregion  ExtensionMethod
    }
}
