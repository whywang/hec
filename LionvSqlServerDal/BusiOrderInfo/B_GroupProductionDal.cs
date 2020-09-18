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
    public class B_GroupProductionDal : IB_GroupProductionDal
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_GroupProduction");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
           
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_GroupProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_GroupProduction(");
            strSql.Append("sid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,itype,height,width,deep,fsize,smoney,sovermoney,sothermoney,gmoney,govermoney,gothermoney,cmoney,covermoney,cothermoney,sdiscount,gdiscount,cdiscount,pic,ichange,ps,maker,cdate,locktype,ptype,locks,allprice,serverprice,zsize,zjname,zjcode,zjmname,floor)");
            strSql.Append(" values (");
            strSql.Append("@sid,@psid,@gnum,@iname,@icode,@mname,@uname,@inum,@place,@direction,@fix,@itype,@height,@width,@deep,@fsize,@smoney,@sovermoney,@sothermoney,@gmoney,@govermoney,@gothermoney,@cmoney,@covermoney,@cothermoney,@sdiscount,@gdiscount,@cdiscount,@pic,@ichange,@ps,@maker,@cdate,@locktype,@ptype,@locks,@allprice,@serverprice,@zsize,@zjname,@zjcode,@zjmname,@floor)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@iname", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@uname", SqlDbType.NVarChar,10),
					new SqlParameter("@inum", SqlDbType.Float),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@direction", SqlDbType.NVarChar,30),
					new SqlParameter("@fix", SqlDbType.NVarChar,20),
					new SqlParameter("@itype", SqlDbType.NVarChar,20),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@fsize", SqlDbType.Int,4),
					new SqlParameter("@smoney", SqlDbType.Money,8),
					new SqlParameter("@sovermoney", SqlDbType.Money,8),
					new SqlParameter("@sothermoney", SqlDbType.Money,8),
					new SqlParameter("@gmoney", SqlDbType.Money,8),
					new SqlParameter("@govermoney", SqlDbType.Money,8),
					new SqlParameter("@gothermoney", SqlDbType.Money,8),
					new SqlParameter("@cmoney", SqlDbType.Money,8),
					new SqlParameter("@covermoney", SqlDbType.Money,8),
					new SqlParameter("@cothermoney", SqlDbType.Money,8),
					new SqlParameter("@sdiscount", SqlDbType.Money,8),
					new SqlParameter("@gdiscount", SqlDbType.Money,8),
					new SqlParameter("@cdiscount", SqlDbType.Money,8),
					new SqlParameter("@pic", SqlDbType.NVarChar,100),
					new SqlParameter("@ichange", SqlDbType.Int,4),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@locktype", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,20),
					new SqlParameter("@locks", SqlDbType.NVarChar,20),
					new SqlParameter("@allprice", SqlDbType.Money,8),
					new SqlParameter("@serverprice", SqlDbType.Money,8),
                    new SqlParameter("@zsize", SqlDbType.Int,4),
					new SqlParameter("@zjname", SqlDbType.NVarChar,30),
					new SqlParameter("@zjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@zjmname", SqlDbType.NVarChar,30),
					new SqlParameter("@floor", SqlDbType.NVarChar,30)
                                        };
            parameters[0].Value = model.sid;
            parameters[1].Value = model.psid;
            parameters[2].Value = model.gnum;
            parameters[3].Value = model.iname;
            parameters[4].Value = model.icode;
            parameters[5].Value = model.mname;
            parameters[6].Value = model.uname;
            parameters[7].Value = model.inum;
            parameters[8].Value = model.place;
            parameters[9].Value = model.direction;
            parameters[10].Value = model.fix;
            parameters[11].Value = model.itype;
            parameters[12].Value = model.height;
            parameters[13].Value = model.width;
            parameters[14].Value = model.deep;
            parameters[15].Value = model.fsize;
            parameters[16].Value = model.smoney;
            parameters[17].Value = model.sovermoney;
            parameters[18].Value = model.sothermoney;
            parameters[19].Value = model.gmoney;
            parameters[20].Value = model.govermoney;
            parameters[21].Value = model.gothermoney;
            parameters[22].Value = model.cmoney;
            parameters[23].Value = model.covermoney;
            parameters[24].Value = model.cothermoney;
            parameters[25].Value = model.sdiscount;
            parameters[26].Value = model.gdiscount;
            parameters[27].Value = model.cdiscount;
            parameters[28].Value = model.pic;
            parameters[29].Value = model.ichange;
            parameters[30].Value = model.ps;
            parameters[31].Value = model.maker;
            parameters[32].Value = model.cdate;
            parameters[33].Value = model.locktype;
            parameters[34].Value = model.ptype;
            parameters[35].Value = model.locks;
            parameters[36].Value = model.allprice;
            parameters[37].Value = model.serverprice;
            parameters[38].Value = model.zsize;
            parameters[39].Value = model.zjname;
            parameters[40].Value = model.zjcode;
            parameters[41].Value = model.zjmname;
            parameters[42].Value = model.floor;
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
        public bool Update(B_GroupProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_GroupProduction set ");
            strSql.Append("sid=@sid,");
            strSql.Append("gnum=@gnum,");
            strSql.Append("iname=@iname,");
            strSql.Append("icode=@icode,");
            strSql.Append("mname=@mname,");
            strSql.Append("uname=@uname,");
            strSql.Append("inum=@inum,");
            strSql.Append("place=@place,");
            strSql.Append("direction=@direction,");
            strSql.Append("fix=@fix,");
            strSql.Append("itype=@itype,");
            strSql.Append("height=@height,");
            strSql.Append("width=@width,");
            strSql.Append("deep=@deep,");
            strSql.Append("fsize=@fsize,");
            strSql.Append("smoney=@smoney,");
            strSql.Append("sovermoney=@sovermoney,");
            strSql.Append("sothermoney=@sothermoney,");
            strSql.Append("gmoney=@gmoney,");
            strSql.Append("govermoney=@govermoney,");
            strSql.Append("gothermoney=@gothermoney,");
            strSql.Append("cmoney=@cmoney,");
            strSql.Append("covermoney=@covermoney,");
            strSql.Append("cothermoney=@cothermoney,");
            strSql.Append("sdiscount=@sdiscount,");
            strSql.Append("gdiscount=@gdiscount,");
            strSql.Append("cdiscount=@cdiscount,");
            strSql.Append("pic=@pic,");
            strSql.Append("ichange=@ichange,");
            strSql.Append("ps=@ps,");
            strSql.Append("isjc=@isjc,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("locktype=@locktype,");
            strSql.Append("locks=@locks,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("allprice=@allprice,");
            strSql.Append("serverprice=@serverprice,");
            strSql.Append("zsize=@zsize,");
            strSql.Append("zjname=@zjname,");
            strSql.Append("zjcode=@zjcode,");
            strSql.Append("zjmname=@zjmname, ");
            strSql.Append("floor=@floor ");
            strSql.Append(" where psid=@psid ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@iname", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@uname", SqlDbType.NVarChar,10),
					new SqlParameter("@inum", SqlDbType.Int,4),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@direction", SqlDbType.NVarChar,30),
					new SqlParameter("@fix", SqlDbType.NVarChar,20),
					new SqlParameter("@itype", SqlDbType.NVarChar,20),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@fsize", SqlDbType.Int,4),
					new SqlParameter("@smoney", SqlDbType.Money,8),
					new SqlParameter("@sovermoney", SqlDbType.Money,8),
					new SqlParameter("@sothermoney", SqlDbType.Money,8),
					new SqlParameter("@gmoney", SqlDbType.Money,8),
					new SqlParameter("@govermoney", SqlDbType.Money,8),
					new SqlParameter("@gothermoney", SqlDbType.Money,8),
					new SqlParameter("@cmoney", SqlDbType.Money,8),
					new SqlParameter("@covermoney", SqlDbType.Money,8),
					new SqlParameter("@cothermoney", SqlDbType.Money,8),
					new SqlParameter("@sdiscount", SqlDbType.Money,8),
					new SqlParameter("@gdiscount", SqlDbType.Money,8),
					new SqlParameter("@cdiscount", SqlDbType.Money,8),
					new SqlParameter("@pic", SqlDbType.NVarChar,100),
					new SqlParameter("@ichange", SqlDbType.Int,4),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
                    new SqlParameter("@isjc", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@locktype", SqlDbType.NVarChar,20),
                    new SqlParameter("@locks", SqlDbType.NVarChar,20),
                    new SqlParameter("@ptype", SqlDbType.NVarChar,20),
                    new SqlParameter("@allprice", SqlDbType.Money,8),
					new SqlParameter("@serverprice", SqlDbType.Money,8),
                    new SqlParameter("@zsize", SqlDbType.Int,4),
                    new SqlParameter("@zjname", SqlDbType.NVarChar,30),
                    new SqlParameter("@zjcode", SqlDbType.NVarChar,30),
                    new SqlParameter("@zjmname", SqlDbType.NVarChar,30),
                    new SqlParameter("@floor", SqlDbType.NVarChar,30),
					new SqlParameter("@psid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gnum;
            parameters[2].Value = model.iname;
            parameters[3].Value = model.icode;
            parameters[4].Value = model.mname;
            parameters[5].Value = model.uname;
            parameters[6].Value = model.inum;
            parameters[7].Value = model.place;
            parameters[8].Value = model.direction;
            parameters[9].Value = model.fix;
            parameters[10].Value = model.itype;
            parameters[11].Value = model.height;
            parameters[12].Value = model.width;
            parameters[13].Value = model.deep;
            parameters[14].Value = model.fsize;
            parameters[15].Value = model.smoney;
            parameters[16].Value = model.sovermoney;
            parameters[17].Value = model.sothermoney;
            parameters[18].Value = model.gmoney;
            parameters[19].Value = model.govermoney;
            parameters[20].Value = model.gothermoney;
            parameters[21].Value = model.cmoney;
            parameters[22].Value = model.covermoney;
            parameters[23].Value = model.cothermoney;
            parameters[24].Value = model.sdiscount;
            parameters[25].Value = model.gdiscount;
            parameters[26].Value = model.cdiscount;
            parameters[27].Value = model.pic;
            parameters[28].Value = model.ichange;
            parameters[29].Value = model.ps;
            parameters[30].Value = model.isjc;
            parameters[31].Value = model.maker;
            parameters[32].Value = model.cdate;
            parameters[33].Value = model.locktype;
            parameters[34].Value = model.locks;
            parameters[35].Value = model.ptype;
            parameters[36].Value = model.allprice;
            parameters[37].Value = model.serverprice;
            parameters[38].Value = model.zsize;
            parameters[39].Value = model.zjname;
            parameters[40].Value = model.zjcode;
            parameters[41].Value = model.zjmname;
            parameters[42].Value = model.floor;
            parameters[43].Value = model.psid;
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
            strSql.AppendFormat("delete from B_ProductionItem where psid in (select psid from B_GroupProduction where 1=1 {0});", where);
            strSql.AppendFormat("delete from B_GroupProductionCompnent where psid in (select psid from B_GroupProduction where 1=1 {0});", where);
            strSql.AppendFormat("delete from B_GroupProductionMoney where psid in (select psid from B_GroupProduction where 1=1 {0});", where);
            strSql.AppendFormat("delete from B_GroupProduction where 1=1 {0};", where);
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
        public B_GroupProduction Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,gsid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,locktype,locks,itype,ptype,height,width,deep,fsize,pic,ichange,ps,isjc,idiscount,allprice,serverprice,picname,czyy,zsize,zjname,zjcode,zjmname,tbcz,lxcz,tsid,cpxz,tjxz,rimg,priceps,ghnum,cgnum,floor,moneyremark,cavecode,cavename,msts,mtts,csid,spec,ggy,gfx,jstname,jstcode,ytcz,sktlx,sktname,sktcode,sktcz,maker,cdate,mbname,mbcode,mbfx,mbnum,stype,xxline,mbytcz,slytcz,zmsname,zmscode,slbname,slbcode,slbnum,zjsname,zjscode,zjsmname,sktjc,skttjc,cbjc,sxjf,zyjf,fbtmname ,skttname,skttcz,skttcode,ykzt,ykyt,gdg,gdk,zmgdk,ydeep,ykhjft,ykhjfw,yksjft,yksjtw,ykhq,ykscb,ykycb,ykzcb,ykacb,msfmcz from B_GroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_GroupProduction r = new B_GroupProduction();
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
        public B_GroupProduction Query(DataTable dt, string where)
        {
            B_GroupProduction r = new B_GroupProduction();
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private  B_GroupProduction DataRowToModel(DataRow row)
        {
             B_GroupProduction model = new  B_GroupProduction();
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
                if (row["gnum"] != null && row["gnum"].ToString() != "")
                {
                    model.gnum = int.Parse(row["gnum"].ToString());
                }
                if (row["iname"] != null)
                {
                    model.iname = row["iname"].ToString();
                }
                if (row["icode"] != null)
                {
                    model.icode = row["icode"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["uname"] != null)
                {
                    model.uname = row["uname"].ToString();
                }
                if (row["inum"] != null && row["inum"].ToString() != "")
                {
                    model.inum = decimal.Parse(row["inum"].ToString());
                }
                if (row["place"] != null)
                {
                    model.place = row["place"].ToString();
                }
                if (row["direction"] != null)
                {
                    model.direction = row["direction"].ToString();
                }
                if (row["fix"] != null)
                {
                    model.fix = row["fix"].ToString();
                }
                if (row["locktype"] != null)
                {
                    model.locktype = row["locktype"].ToString();
                }
                if (row["locks"] != null)
                {
                    model.locks = row["locks"].ToString();
                }
                if (row["itype"] != null)
                {
                    model.itype = row["itype"].ToString();
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
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
                if (row["fsize"] != null && row["fsize"].ToString() != "")
                {
                    model.fsize = int.Parse(row["fsize"].ToString());
                }
                if (row["pic"] != null)
                {
                    model.pic = row["pic"].ToString();
                }
                if (row["ichange"] != null && row["ichange"].ToString() != "")
                {
                    model.ichange = int.Parse(row["ichange"].ToString());
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
                }
                if (row["isjc"] != null)
                {
                    model.isjc = row["isjc"].ToString();
                }
                if (row["idiscount"] != null && row["idiscount"].ToString() != "")
                {
                    model.idiscount = int.Parse(row["idiscount"].ToString());
                }
                if (row["allprice"] != null && row["allprice"].ToString() != "")
                {
                    model.allprice = decimal.Parse(row["allprice"].ToString());
                }
                if (row["serverprice"] != null && row["serverprice"].ToString() != "")
                {
                    model.serverprice = decimal.Parse(row["serverprice"].ToString());
                }
                if (row["picname"] != null)
                {
                    model.picname = row["picname"].ToString();
                }
                if (row["czyy"] != null)
                {
                    model.czyy = row["czyy"].ToString();
                }
                if (row["zsize"] != null)
                {
                    model.zsize =Convert.ToInt32( row["zsize"].ToString());
                }
                if (row["zjname"] != null)
                {
                    model.zjname = row["zjname"].ToString();
                }
                if (row["zjcode"] != null)
                {
                    model.zjcode = row["zjcode"].ToString();
                }
                if (row["zjmname"] != null)
                {
                    model.zjmname = row["zjmname"].ToString();
                }
                if (row["zjsname"] != null)
                {
                    model.zjsname = row["zjsname"].ToString();
                }
                if (row["zjscode"] != null)
                {
                    model.zjscode = row["zjscode"].ToString();
                }
                if (row["zjsmname"] != null)
                {
                    model.zjsmname = row["zjsmname"].ToString();
                }
                if (row["tbcz"] != null)
                {
                    model.tbcz = row["tbcz"].ToString();
                }
                if (row["lxcz"] != null)
                {
                    model.lxcz = row["lxcz"].ToString();
                }
                if (row["tsid"] != null)
                {
                    model.tsid = row["tsid"].ToString();
                }
                if (row["cpxz"] != null)
                {
                    model.cpxz = row["cpxz"].ToString();
                }
                if (row["tjxz"] != null)
                {
                    model.tjxz = row["tjxz"].ToString();
                }
                if (row["rimg"] != null)
                {
                    model.rimg = row["rimg"].ToString();
                }
                if (row["priceps"] != null && row["priceps"].ToString() != "")
                {
                    model.priceps =  row["priceps"].ToString() ;
                }
                if (row["ghnum"] != null && row["ghnum"].ToString() != "")
                {
                    model.ghnum = decimal.Parse(row["ghnum"].ToString());
                }
                if (row["cgnum"] != null && row["cgnum"].ToString() != "")
                {
                    model.cgnum = decimal.Parse(row["cgnum"].ToString());
                }
                if (row["floor"] != null)
                {
                    model.floor = row["floor"].ToString();
                }
                if (row["moneyremark"] != null)
                {
                    model.moneyremark = row["moneyremark"].ToString();
                }
                if (row["cavecode"] != null)
                {
                    model.cavecode = row["cavecode"].ToString();
                }
                if (row["cavename"] != null)
                {
                    model.cavename = row["cavename"].ToString();
                }
                if (row["msts"] != null)
                {
                    model.msts = row["msts"].ToString();
                }
                if (row["mtts"] != null)
                {
                    model.mtts = row["mtts"].ToString();
                }
                if (row["csid"] != null)
                {
                    model.csid = row["csid"].ToString();
                }
                if (row["spec"] != null)
                {
                    model.spec = row["spec"].ToString();
                }
                if (row["ggy"] != null)
                {
                    model.ggy = row["ggy"].ToString();
                }
                if (row["gfx"] != null)
                {
                    model.gfx = row["gfx"].ToString();
                }
                if (row["jstname"] != null)
                {
                    model.jstname = row["jstname"].ToString();
                }
                if (row["jstcode"] != null)
                {
                    model.jstcode = row["jstcode"].ToString();
                }
                if (row["ytcz"] != null)
                {
                    model.ytcz = row["ytcz"].ToString();
                }
                if (row["sktlx"] != null)
                {
                    model.sktlx = row["sktlx"].ToString();
                }
                if (row["sktname"] != null)
                {
                    model.sktname = row["sktname"].ToString();
                }
                if (row["sktcode"] != null)
                {
                    model.sktcode = row["sktcode"].ToString();
                }
                if (row["sktcz"] != null)
                {
                    model.sktcz = row["sktcz"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
                if (row["mbname"] != null)
                {
                    model.mbname = row["mbname"].ToString();
                }
                if (row["mbcode"] != null)
                {
                    model.mbcode = row["mbcode"].ToString();
                }
                if (row["mbfx"] != null)
                {
                    model.mbfx = row["mbfx"].ToString();
                }
                if (row["mbnum"] != null && row["mbnum"].ToString() != "")
                {
                    model.mbnum = int.Parse(row["mbnum"].ToString());
                }
                if (row["stype"] != null)
                {
                    model.stype = row["stype"].ToString();
                }
                if (row["xxline"] != null)
                {
                    model.xxline = row["xxline"].ToString();
                }
                if (row["slytcz"] != null)
                {
                    model.slytcz = row["slytcz"].ToString();
                }
                if (row["mbytcz"] != null)
                {
                    model.mbytcz = row["mbytcz"].ToString();
                }
                if (row["zmsname"] != null)
                {
                    model.zmsname = row["zmsname"].ToString();
                }
                if (row["zmscode"] != null)
                {
                    model.zmscode = row["zmscode"].ToString();
                }
                if (row["slbname"] != null)
                {
                    model.slbname = row["slbname"].ToString();
                }
                if (row["slbcode"] != null)
                {
                    model.slbcode = row["slbcode"].ToString();
                }
                if (row["slbnum"] != null)
                {
                    model.slbnum =int.Parse( row["slbnum"].ToString());
                }
                if (row["sktjc"] != null)
                {
                    model.sktjc = int.Parse(row["sktjc"].ToString());
                }
                if (row["cbjc"] != null)
                {
                    model.cbjc = int.Parse(row["cbjc"].ToString());
                }
                if (row["sxjf"] != null)
                {
                    model.sxjf = row["sxjf"].ToString();
                }
                if (row["zyjf"] != null)
                {
                    model.zyjf = row["zyjf"].ToString();
                }
                if (row["skttjc"] != null)
                {
                    model.skttjc = int.Parse(row["skttjc"].ToString());
                }
                if (row["fbtmname"] != null)
                {
                    model.fbtmname = row["fbtmname"].ToString();
                }
                if (row["skttname"] != null)
                {
                    model.skttname = row["skttname"].ToString();
                }
                if (row["skttcode"] != null)
                {
                    model.skttcode = row["skttcode"].ToString();
                }
                if (row["skttcz"] != null)
                {
                    model.skttcz = row["skttcz"].ToString();
                }
                if (row["ykzt"] != null)
                {
                    model.ykzt = row["ykzt"].ToString();
                }
                if (row["ykyt"] != null)
                {
                    model.ykyt = row["ykyt"].ToString();
                }
                if (row["gdg"] != null)
                {
                    model.gdg = int.Parse(row["gdg"].ToString());
                }
                if (row["gdk"] != null)
                {
                    model.gdk = int.Parse(row["gdk"].ToString());
                }
                 if (row["ydeep"] != null)
                {
                    model.ydeep = int.Parse(row["ydeep"].ToString());
                }
                if (row["zmgdk"] != null)
                {
                    model.zmgdk = int.Parse(row["zmgdk"].ToString());
                }
                 if (row["ykhjft"] != null)
                {
                    model.ykhjft = row["ykhjft"].ToString();
                }
                if (row["ykhjfw"] != null)
                {
                    model.ykhjfw = row["ykhjfw"].ToString();
                }
                if (row["yksjft"] != null)
                {
                    model.yksjft = row["yksjft"].ToString();
                }
                if (row["yksjtw"] != null)
                {
                    model.yksjtw = row["yksjtw"].ToString();
                }
                if (row["ykhq"] != null)
                {
                    model.ykhq = row["ykhq"].ToString();
                }
                 if (row["ykscb"] != null)
                {
                    model.ykscb = row["ykscb"].ToString();
                }
                if (row["ykycb"] != null)
                {
                    model.ykycb = row["ykycb"].ToString();
                }
                if (row["ykzcb"] != null)
                {
                    model.ykzcb = row["ykzcb"].ToString();
                }
                if (row["ykacb"] != null)
                {
                    model.ykacb = row["ykacb"].ToString();
                }
                if (row["msfmcz"] != null)
                {
                    model.msfmcz = row["msfmcz"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_GroupProduction> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,gsid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,locktype,locks,itype,ptype,height,width,deep,fsize,pic,ichange,ps,isjc,idiscount,allprice,serverprice,picname,czyy,zsize,zjname,zjcode,zjmname,tbcz,lxcz,tsid,cpxz,tjxz,rimg,priceps,ghnum,cgnum,floor,moneyremark,cavecode,cavename,msts,mtts,csid,spec,ggy,gfx,jstname,jstcode,ytcz,sktlx,sktname,sktcode,sktcz,maker,cdate,mbname,mbcode,mbfx,mbnum,stype,xxline,mbytcz,slytcz,zmsname,zmscode,slbname,slbcode,slbnum,zjsname,zjscode,zjsmname,sktjc,skttjc,cbjc,sxjf,zyjf,fbtmname,skttname,skttcz,skttcode,ykzt,ykyt,gdg,gdk,zmgdk,ydeep,ykhjft,ykhjfw,yksjft,yksjtw,ykhq,ykscb,ykycb,ykzcb,ykacb,msfmcz");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_GroupProduction> r = new List<B_GroupProduction>();
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
        public DataTable QueryTable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,gsid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,");
            strSql.Append("locktype,locks,itype,ptype,height,width,deep,fsize,pic,ichange,ps,isjc,idiscount,");
            strSql.Append("allprice,serverprice,picname,czyy,zsize,zjname,zjcode,zjmname,zjsname,zjscode,zjsmname,tbcz,lxcz,tsid,cpxz,tjxz,rimg,priceps,ghnum,cgnum,floor,moneyremark,cavecode,cavename,msts,mtts,csid,spec,ggy,gfx,jstname,jstcode,ytcz,sktlx,sktname,sktcode,sktcz,maker,cdate,mbname,mbcode,mbfx,mbnum,stype,xxline,mbytcz,slytcz,zmsname,zmscode,slbname,slbcode,slbnum,sktjc,skttjc,cbjc,sxjf,zyjf,fbtmname,skttname,skttcz,skttcode,ykzt,ykyt,gdg,gdk,zmgdk,ydeep,ykhjft,ykhjfw,yksjft,yksjtw,ykhq,ykscb,ykycb,ykzcb,ykacb,msfmcz");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            DataTable r = new DataTable();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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
        #endregion  BasicMethod
        #region  ExtensionMethod
        #region--add production's ,get current max order's production number
        public int GetGnum(string where)
        {
            int r = -1;
            string sql = "select isnull(max(gnum),0) as n from B_GroupProduction where 1=1 " + where;
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion

        #region--get order's production's sort code list
        public ArrayList GetGnumArr(string where)
        {
            ArrayList r = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  distinct(gnum) as gnum FROM B_GroupProduction");
            strSql.AppendFormat(" where 1=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(Convert.ToInt32(dr[0].ToString()));
                }
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion
        #region --save order's production list
        public int SaveList(List<B_GroupProduction> lb, string sid, int gnum)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            if (lb != null)
            {
                strSql.Append("delete from B_ProductionItem where psid in (select psid from B_GroupProduction where sid='" + sid + "' and gnum=" + gnum + ") ;");
                strSql.Append("delete from B_GroupProductionAttr where gsid in (select gsid from B_GroupProduction where sid='" + sid + "' and gnum=" + gnum + ") ;");
                strSql.Append("delete from B_GroupProductionMoney where psid in (select psid from B_GroupProduction where sid='" + sid + "' and gnum=" + gnum + ") ;");
                strSql.Append("delete from B_GroupProductionCompnent where psid in (select psid from B_GroupProduction where sid='" + sid + "' and gnum=" + gnum + ") ;");
                strSql.Append("delete from B_GroupProduction where sid='" + sid + "' and gnum=" + gnum + ";");
                foreach (B_GroupProduction b in lb)
                {
                    if (b.icode != "")
                    {
                        strSql.Append("insert into B_GroupProduction(");
                        strSql.Append("sid,psid,gnum,iname,icode,mname,inum,place,direction,fix,itype,height,width,");
                        strSql.Append("deep,fsize,ps,maker,cdate,locktype,ptype,isjc,uname,locks,pic,idiscount,picname,");
                        strSql.Append("czyy,zsize,zjname,zjcode,zjmname,tbcz,lxcz,tsid,gsid,cpxz,tjxz,floor,cavename,");
                        strSql.Append("cavecode,mtts,msts,csid,spec,ggy,gfx,jstname,jstcode,ytcz,sktlx,sktname,sktcode,");
                        strSql.Append("sktcz,mbname,mbcode,mbfx,mbnum,stype,xxline,slytcz,mbytcz,zmsname,zmscode,");
                        strSql.Append(" slbname,slbcode,slbnum,zjsname,zjscode,zjsmname,sktjc,cbjc,sxjf,zyjf,skttjc,fbtmname,");
                        strSql.Append(" skttname,skttcz,skttcode,ykzt,ykyt,gdg,gdk,zmgdk,ydeep,ykhjft,ykhjfw,yksjft,yksjtw,");
                        strSql.Append(" ykhq,ykscb,ykycb,ykzcb,msfmcz ,ykacb)");
                        strSql.Append(" values ('" + b.sid + "','" + b.psid + "','" + b.gnum + "','" + b.iname + "','" + b.icode + "','" + b.mname + "','" + b.inum + "','" + b.place + "', ");
                        strSql.Append("  '" + b.direction + "','" + b.fix + "','" + b.itype + "','" + b.height + "','" + b.width + "','" + b.deep + "','" + b.fsize + "','" + b.ps + "' ,");
                        strSql.Append("  '" + b.maker + "','" + b.cdate + "','" + b.locktype + "','" + b.ptype + "','" + b.isjc + "','" + b.uname + "','" + b.locks + "','" + b.pic + "',");
                        strSql.Append("  '" + b.idiscount + "','" + b.picname + "','" + b.czyy + "'," + b.zsize + ",'" + b.zjname + "','" + b.zjcode + "','" + b.zjmname + "','" + b.tbcz + "',");
                        strSql.Append("  '" + b.lxcz + "','" + b.tsid + "','" + b.gsid + "','" + b.cpxz + "','" + b.tjxz + "','" + b.floor + "','" + b.cavename + "','" + b.cavecode + "',");
                        strSql.Append("  '" + b.mtts + "','" + b.msts + "','" + b.csid + "','" + b.spec + "','" + b.ggy + "','" + b.gfx + "','" + b.jstname + "','" + b.jstcode + "',");
                        strSql.Append(" '" + b.ytcz + "','" + b.sktlx + "','" + b.sktname + "','" + b.sktcode + "','" + b.sktcz + "','" + b.mbname + "','" + b.mbcode + "','" + b.mbfx + "'," + b.mbnum + ",");
                        strSql.Append(" '" + b.stype + "','" + b.xxline + "','" + b.slytcz + "','" + b.mbytcz + "','" + b.zmsname + "','" + b.zmscode + "', ");
                        strSql.Append(" '" + b.slbname + "','" + b.slbcode + "','" + b.slbnum + "','" + b.zjsname + "','" + b.zjscode + "','" + b.zjsmname + "','" + b.sktjc + "','" + b.cbjc + "' , ");
                        strSql.Append(" '" + b.sxjf + "','" + b.zyjf + "','" + b.skttjc + "','" + b.fbtmname + "','" + b.skttname + "','" + b.skttcz + "','" + b.skttcode + "','" + b.ykzt + "','" + b.ykyt + "',  ");
                        strSql.Append(" '" + b.gdg + "','" + b.gdk + "','" + b.zmgdk + "','" + b.ydeep + "','" + b.ykhjft + "','" + b.ykhjfw + "','" + b.yksjft + "','" + b.yksjtw + "', ");
                        strSql.Append(" '" + b.ykhq + "','" + b.ykscb + "','" + b.ykycb + "','" + b.ykzcb + "','" + b.msfmcz + "','" + b.ykacb + "'); ");
                    }
                }
            }
            if (strSql.ToString() != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            }
            return r;
        }
        #endregion
        #region--get order's supply money
        #region--order's 木制品's statistic money and not contains special productin 不含特价
        public decimal GNomalProductionMoney(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select isnull(sum(gmoney),0)+isnull(sum(govermoney),0)+isnull(sum(gothermoney),0) as n from B_GroupProduction where  sid='{0}' and substring(icode,9,2)<>'04' and tsid='' and tjxz<>'2'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region--order's 木制品 production's nomal price (gmoney) 不含特价
        public decimal GNomalProductionMoneyB(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select isnull(sum(gmoney),0) as n from B_GroupProduction where  sid='{0}' and tsid=''  and substring(icode,1,2)<>'04'  and tjxz<>'2'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region--order 's 木制品 production’s unnomal price(overmoney +othermoney) 不含特价
        public decimal GNomalProductionMoneyO(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select isnull(sum(govermoney),0)+isnull(sum(gothermoney),0) as n from B_GroupProduction where  sid='{0}'  and substring(icode,1,2)<>'04' and tsid='' and tjxz<>'2'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region//供货订单金额（正常产品金额不含其它费用和超标费用）
        public decimal GNomalOnlyMoney(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select isnull(sum(gmoney),0)  as n from B_GroupProduction where  sid='{0}' and tsid='' and idiscount=0", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #endregion
        #region--statistic
        #region--statistic ms number
        public int TjProductionMsNum(string sid)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    isnull(sum(pnum),0) as n");
            strSql.Append(" FROM [B_ProductionItem]  ");
            strSql.AppendFormat(" where  sid='{0}' and substring(pcode ,1,2)='01'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region--statistic production lens
        public decimal TjProductionCNum(string where)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    isnull(sum(height*2+width),0)as n");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  1=1 {0} ", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString()) / 1000;
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region--statistic production number
        public decimal TjProductionQtNum(string where)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(inum),0) as n");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  1=1 {0} ", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region--统计产品数量
        public string TjProductionCateNumText(string sid, string where)
        {
            StringBuilder r = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(fj.inum),0) as n ,fj.itypename   from (  select distinct(itype),  gnum,inum,itypename from B_GroupProduction");
            strSql.AppendFormat(" where sid='{0}' {1}  and ((substring(icode,1,2)<>'04'and itype<>'04') or  (substring(icode,1,2)='04'and itype='04') ) group by  gnum,itype,inum ,itypename  ) as fj group by itypename", sid, where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.AppendFormat("{0}-{1};", dr["itypename"].ToString(), dr["n"].ToString());
                }
            }
            return r.ToString();
        }
        public int TjProductionNum(string sid)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  distinct(gnum) as n from B_GroupProduction");
            strSql.AppendFormat(" where  sid='{0}' ", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows.Count;
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region--statistic ms number
        public int TjProductionCateNum(string sid, string icode, string itype)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull(sum(inum),0) as n from B_GroupProduction");
            strSql.AppendFormat(" where  sid='{0}' and substring(icode,9,2)='{1}'", sid, icode);
            strSql.AppendFormat(" and itype='{0}'", itype);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region--statistic wj productin number comfort string wjname-wjnum
        public string[] Sjtj(string sid, string pcode)
        {
            string[] r = new string[2];
            string rname = "";
            string rnum = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iname , isnull(sum(inum),0) as inum");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  sid='{0}' and substring(icode,1,4)='{1}' group by iname", sid, pcode);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    rname = rname + dr["iname"].ToString() + ";";
                    rnum = rnum + dr["inum"].ToString() + ";";
                }
                rname = rname.Substring(0, rname.Length - 1);
                rnum = rnum.Substring(0, rnum.Length - 1);
            }
            else
            {

            }
            r[0] = rname;
            r[1] = rnum;
            return r;
        }
        public string QueryWjText(string sid)
        {
            StringBuilder r = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iname,icode , isnull(sum(gmoney),0) as wjmoney,isnull(sum(inum),0) as n,uname");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  1=1 and sid='{0}' and tsid='' and substring(icode,1,2)='04'  group by iname,icode ,uname ", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.AppendFormat("{0}-{1}-{2};&nbsp;&nbsp;&nbsp;&nbsp;", dr["iname"].ToString(), dr["n"].ToString(), dr["uname"].ToString());
                }
            }
            return r.ToString();
        }
        #endregion
        #region--statistic order's wj tablelist
        public DataTable QueryWj(string sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iname,icode , isnull(sum(gmoney),0) as wjmoney,isnull(sum(inum),0) as n");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  1=1 and sid='{0}' and tsid='' and substring(icode,1,2)='04'  group by iname,icode ", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            return dt;
        }
        #endregion
        #endregion
        #region----special price production
        #region//获取特价产品Gsid
        public ArrayList QueryGsidList(string sid)
        {
            ArrayList r = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select distinct(gsid) from B_GroupProduction where sid='" + sid + "' and (tjxz='1' or tjxz='2')", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(dr["gsid"].ToString());
                }
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion
        #region//初始化特价产品
        public void UpInitTjState(string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" update B_GroupProduction set tjxz='1' where sid='{0}' and (tjxz='1' or tjxz='2')", sid);
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        #endregion
        #region//更新特价产品
        public void UpdateTjState(string gsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" update B_GroupProduction set tjxz='2' where gsid='{0}' and tjxz='1' ", gsid);
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        #endregion
        #region//check order contain special production
        public bool CheckContainTj(string sid, int pnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_GroupProduction");
            strSql.AppendFormat(" where sid='{0}' and gnum='{1}' ", sid,pnum);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        #endregion
        #endregion
        #region--other extension function
        #region//设置备注图片
        public bool UpRemarkImg(string sid, int gnum, string url,string ptype)
        {
            StringBuilder strSql = new StringBuilder();
            if (ptype == "mt")
            {
                strSql.AppendFormat(" update B_GroupProduction set pic='{0}' where sid='{1}' and gnum={2};", url, sid, gnum);
            }
            else
            {
                strSql.AppendFormat(" update B_GroupProduction set rimg='{0}' where sid='{1}' and gnum={2};", url, sid, gnum);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion
        #endregion
        #region--sale price
        #region--update sale price 计算产品金额时更新产品销售价格
        public void UpSalePrice(string psid, decimal smoney, decimal somoney, decimal sqmoney)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_GroupProduction set ");
            strSql.Append("smoney=@smoney,");
            strSql.Append("sovermoney=@sovermoney,");
            strSql.Append("sothermoney=@sothermoney");
            strSql.Append(" where psid=@psid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@smoney", SqlDbType.Money,8),
                    new SqlParameter("@sovermoney", SqlDbType.Money,8),
                    new SqlParameter("@sothermoney", SqlDbType.Money,8),
                    new SqlParameter("@psid", SqlDbType.NVarChar,50)};

            parameters[0].Value = smoney;
            parameters[1].Value = somoney;
            parameters[2].Value = sqmoney;
            parameters[3].Value = psid;

            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
        }
        #endregion
        #region--update group sale price 编辑产品销售价格
        public int UpGroupSalePrice(ArrayList plist)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            if (plist != null)
            {
                for (int i = 0; i < plist.Count; i++)
                {
                    ArrayList pitem = (ArrayList)plist[i];
                    strSql.AppendFormat("update B_GroupProduction set  smoney={0} ,sovermoney={1},sothermoney={2}  where psid='{3}';", pitem[1], pitem[2], pitem[3], pitem[0]);
                }
            }
            if (strSql.ToString() != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            }
            return r;
        }
        #endregion
        #region--Query group sale price(木制品 非特价)
        public decimal[] QueryGroupSaleMzpPriceAttr(string sid, int gnum)
        {
            decimal[] r = new decimal[3];
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(smoney),0) as smoney,isnull( sum(sovermoney),0) as sovermoney ,isnull( sum(sothermoney),0) as sothermoney");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  sid='{0}' and gnum={1} and substring(icode,1,2)<>'04' and tjxz<>'2'", sid, gnum);

            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r[0] = Convert.ToDecimal(dt.Rows[0][0].ToString());
                r[1] = Convert.ToDecimal(dt.Rows[0][1].ToString());
                r[2] = Convert.ToDecimal(dt.Rows[0][2].ToString());
            }
            else
            {
                r[0] = 0;
                r[1] = 0;
                r[2] = 0;
            }
            return r;
        }
        #endregion
        #region--Query group sale money(五金)
        public decimal[] QueryGroupSaleWjPriceAttr(string sid, int gnum)
        {
            decimal[] r = new decimal[3];
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(smoney),0) as smoney,isnull( sum(sovermoney),0) as sovermoney ,isnull( sum(sothermoney),0) as sothermoney");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  sid='{0}' and gnum={1} and substring(icode,1,2)='04'", sid, gnum);

            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r[0] = Convert.ToDecimal(dt.Rows[0][0].ToString());
                r[1] = Convert.ToDecimal(dt.Rows[0][1].ToString());
                r[2] = Convert.ToDecimal(dt.Rows[0][2].ToString());

            }
            else
            {
                r[0] = 0;
                r[1] = 0;
                r[2] = 0;
            }
            return r;
        }
        #endregion
        #region--Query group sale summer price (木制品 非特价)
        public decimal QueryGourpSaleMzpSumMoney(string sid, int xh)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  (isnull( sum(smoney),0) +isnull( sum(sovermoney),0)+isnull( sum(sothermoney),0)) as omoney");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  sid='{0}' and gnum={1} and substring(icode,1,2)<>'04' and tjxz<>'2' ", sid, xh);

            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region--Query order sale summer price(五金)
        public decimal QuerySaleOrderWjSummerPrice(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select isnull(sum(smoney),0)+isnull(sum(sovermoney),0)+isnull(sum(sothermoney),0) as n from B_GroupProduction where  sid='{0}' and substring(icode,1,2)='04' and tsid='' and tjxz<>'2'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #region --Query order sale summer price(木制品 非特价)
        public decimal QuerySaleOrderMzpSummerPrice(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  (isnull( sum(smoney),0) +isnull( sum(sovermoney),0)+isnull( sum(sothermoney),0)) as omoney");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  sid='{0}' and substring(icode,1,2)<>'04' and tjxz<>'2' ", sid);

            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #endregion
        #region--supply price
        #region--update gh price 计算产品金额时更新产品供货价格
        public void UpGhPrice(string psid, decimal bzprice, decimal oprice, decimal sprice)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_GroupProduction set ");
            strSql.Append("gmoney=@gmoney,");
            strSql.Append("govermoney=@govermoney,");
            strSql.Append("gothermoney=@gothermoney");
            strSql.Append(" where psid=@psid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@gmoney", SqlDbType.Money,8),
                    new SqlParameter("@govermoney", SqlDbType.Money,8),
                    new SqlParameter("@gothermoney", SqlDbType.Money,8),
                    new SqlParameter("@psid", SqlDbType.NVarChar,50)};

            parameters[0].Value = bzprice;
            parameters[1].Value = oprice;
            parameters[2].Value = sprice;
            parameters[3].Value = psid;

            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);

        }
        #endregion
        #region--update group gh price 编辑产品供货价格
        public int UpGroupGhPrice(ArrayList plist)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            if (plist != null)
            {
                for (int i = 0; i < plist.Count; i++)
                {
                    ArrayList pitem = (ArrayList)plist[i];
                    strSql.AppendFormat("update B_GroupProduction set  gmoney={0} ,govermoney={1},gothermoney={2},moneyremark='{3}'  where psid='{4}';", pitem[1], pitem[2], pitem[3], pitem[4], pitem[0]);
                }
            }
            if (strSql.ToString() != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            }
            return r;
        }
        #endregion
        #region--Query group gh price(木制品 非特价)
        public decimal[] QueryGroupGhMzpPriceAttr(string sid, int gnum)
        {
            decimal[] r = new decimal[3];
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(gmoney),0) as gmoney,isnull( sum(govermoney),0) as govermoney ,isnull( sum(gothermoney),0) as gothermoney");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  sid='{0}' and gnum={1} and substring(icode,1,2)<>'04' and tjxz<>'2'", sid, gnum);

            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r[0] = Convert.ToDecimal(dt.Rows[0][0].ToString());
                r[1] = Convert.ToDecimal(dt.Rows[0][1].ToString());
                r[2] = Convert.ToDecimal(dt.Rows[0][2].ToString());
            }
            else
            {
                r[0] = 0;
                r[1] = 0;
                r[2] = 0;
            }
            return r;
        }
        #endregion
        #region--Query group gh money(五金)
        public decimal[] QueryGroupGhWjPriceAttr(string sid, int gnum)
        {
            decimal[] r = new decimal[3];
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(gmoney),0) as gmoney,isnull( sum(govermoney),0) as govermoney ,isnull( sum(gothermoney),0) as gothermoney");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  sid='{0}' and gnum={1} and substring(icode,9,2)='04'", sid, gnum);

            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r[0] = Convert.ToDecimal(dt.Rows[0][0].ToString());
                r[1] = Convert.ToDecimal(dt.Rows[0][1].ToString());
                r[2] = Convert.ToDecimal(dt.Rows[0][2].ToString());

            }
            else
            {
                r[0] = 0;
                r[1] = 0;
                r[2] = 0;
            }
            return r;
        }
        #endregion
        #region--Query group gh money(五金)
        public decimal QueryGroupGhWjPrice(string sid, int gnum)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select gmoney*inum as gmoney,govermoney*inum as govermoney ,gothermoney*inum as gothermoney");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where  sid='{0}' and gnum={1} and substring(icode,9,2)='04'", sid, gnum);

            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString()) + Convert.ToDecimal(dt.Rows[0][1].ToString()) + Convert.ToDecimal(dt.Rows[0][2].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #endregion

        #region//获取订单五金合计产品
        public DataTable QueryWjTable(string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sid, iname,icode,uname ,isnull(sum(inum),0) as inum ");
            strSql.Append(" FROM B_GroupProduction ");
            strSql.AppendFormat(" where sid='{0}' and substring(icode,9,3)='004' group by sid,iname,icode,uname", sid);
            DataTable r = new DataTable();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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
