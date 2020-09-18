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
    public class B_GroupProductionChangeRecordDal:IB_GroupProductionChangeRecordDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_GroupProductionChangeRecord");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_GroupProductionChangeRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_GroupProductionChangeRecord(");
			strSql.Append("csid,sid,gsid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,locktype,locks,itype,ptype,height,width,deep,fsize,smoney,sovermoney,sothermoney,gmoney,govermoney,gothermoney,cmoney,covermoney,cothermoney,sdiscount,gdiscount,cdiscount,pic,ichange,ps,isjc,idiscount,allprice,serverprice,picname,czyy,zsize,zjname,zjcode,zjmname,tbcz,lxcz,tsid,cpxz,tjxz,rimg,priceps,ghnum,cgnum,floor,moneyremark,cavecode,cavename,msts,mtts,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@csid,@sid,@gsid,@psid,@gnum,@iname,@icode,@mname,@uname,@inum,@place,@direction,@fix,@locktype,@locks,@itype,@ptype,@height,@width,@deep,@fsize,@smoney,@sovermoney,@sothermoney,@gmoney,@govermoney,@gothermoney,@cmoney,@covermoney,@cothermoney,@sdiscount,@gdiscount,@cdiscount,@pic,@ichange,@ps,@isjc,@idiscount,@allprice,@serverprice,@picname,@czyy,@zsize,@zjname,@zjcode,@zjmname,@tbcz,@lxcz,@tsid,@cpxz,@tjxz,@rimg,@priceps,@ghnum,@cgnum,@floor,@moneyremark,@cavecode,@cavename,@msts,@mtts,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@iname", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@uname", SqlDbType.NVarChar,10),
					new SqlParameter("@inum", SqlDbType.Float,8),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@direction", SqlDbType.NVarChar,30),
					new SqlParameter("@fix", SqlDbType.NVarChar,20),
					new SqlParameter("@locktype", SqlDbType.NVarChar,20),
					new SqlParameter("@locks", SqlDbType.NVarChar,20),
					new SqlParameter("@itype", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,20),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@fsize", SqlDbType.Int,4),
					new SqlParameter("@smoney", SqlDbType.Decimal,9),
					new SqlParameter("@sovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@sothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@gmoney", SqlDbType.Decimal,9),
					new SqlParameter("@govermoney", SqlDbType.Decimal,9),
					new SqlParameter("@gothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cmoney", SqlDbType.Decimal,9),
					new SqlParameter("@covermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@cdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@pic", SqlDbType.NVarChar,100),
					new SqlParameter("@ichange", SqlDbType.Int,4),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@isjc", SqlDbType.NVarChar,10),
					new SqlParameter("@idiscount", SqlDbType.Int,4),
					new SqlParameter("@allprice", SqlDbType.Money,8),
					new SqlParameter("@serverprice", SqlDbType.Money,8),
					new SqlParameter("@picname", SqlDbType.NVarChar,200),
					new SqlParameter("@czyy", SqlDbType.NVarChar,100),
					new SqlParameter("@zsize", SqlDbType.NVarChar,50),
					new SqlParameter("@zjname", SqlDbType.NVarChar,50),
					new SqlParameter("@zjcode", SqlDbType.NVarChar,50),
					new SqlParameter("@zjmname", SqlDbType.NVarChar,50),
					new SqlParameter("@tbcz", SqlDbType.NVarChar,50),
					new SqlParameter("@lxcz", SqlDbType.NVarChar,50),
					new SqlParameter("@tsid", SqlDbType.NVarChar,50),
					new SqlParameter("@cpxz", SqlDbType.NVarChar,50),
					new SqlParameter("@tjxz", SqlDbType.NVarChar,50),
					new SqlParameter("@rimg", SqlDbType.NVarChar,100),
					new SqlParameter("@priceps", SqlDbType.Decimal,9),
					new SqlParameter("@ghnum", SqlDbType.Decimal,9),
					new SqlParameter("@cgnum", SqlDbType.Decimal,9),
					new SqlParameter("@floor", SqlDbType.NVarChar,30),
					new SqlParameter("@moneyremark", SqlDbType.NVarChar,100),
					new SqlParameter("@cavecode", SqlDbType.NVarChar,30),
					new SqlParameter("@cavename", SqlDbType.NVarChar,30),
					new SqlParameter("@msts", SqlDbType.NVarChar,30),
					new SqlParameter("@mtts", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.csid;
			parameters[1].Value = model.sid;
			parameters[2].Value = model.gsid;
			parameters[3].Value = model.psid;
			parameters[4].Value = model.gnum;
			parameters[5].Value = model.iname;
			parameters[6].Value = model.icode;
			parameters[7].Value = model.mname;
			parameters[8].Value = model.uname;
			parameters[9].Value = model.inum;
			parameters[10].Value = model.place;
			parameters[11].Value = model.direction;
			parameters[12].Value = model.fix;
			parameters[13].Value = model.locktype;
			parameters[14].Value = model.locks;
			parameters[15].Value = model.itype;
			parameters[16].Value = model.ptype;
			parameters[17].Value = model.height;
			parameters[18].Value = model.width;
			parameters[19].Value = model.deep;
			parameters[20].Value = model.fsize;
			parameters[21].Value = model.smoney;
			parameters[22].Value = model.sovermoney;
			parameters[23].Value = model.sothermoney;
			parameters[24].Value = model.gmoney;
			parameters[25].Value = model.govermoney;
			parameters[26].Value = model.gothermoney;
			parameters[27].Value = model.cmoney;
			parameters[28].Value = model.covermoney;
			parameters[29].Value = model.cothermoney;
			parameters[30].Value = model.sdiscount;
			parameters[31].Value = model.gdiscount;
			parameters[32].Value = model.cdiscount;
			parameters[33].Value = model.pic;
			parameters[34].Value = model.ichange;
			parameters[35].Value = model.ps;
			parameters[36].Value = model.isjc;
			parameters[37].Value = model.idiscount;
			parameters[38].Value = model.allprice;
			parameters[39].Value = model.serverprice;
			parameters[40].Value = model.picname;
			parameters[41].Value = model.czyy;
			parameters[42].Value = model.zsize;
			parameters[43].Value = model.zjname;
			parameters[44].Value = model.zjcode;
			parameters[45].Value = model.zjmname;
			parameters[46].Value = model.tbcz;
			parameters[47].Value = model.lxcz;
			parameters[48].Value = model.tsid;
			parameters[49].Value = model.cpxz;
			parameters[50].Value = model.tjxz;
			parameters[51].Value = model.rimg;
			parameters[52].Value = model.priceps;
			parameters[53].Value = model.ghnum;
			parameters[54].Value = model.cgnum;
			parameters[55].Value = model.floor;
			parameters[56].Value = model.moneyremark;
			parameters[57].Value = model.cavecode;
			parameters[58].Value = model.cavename;
			parameters[59].Value = model.msts;
			parameters[60].Value = model.mtts;
			parameters[61].Value = model.maker;
			parameters[62].Value = model.cdate;

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
		public bool Update( B_GroupProductionChangeRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_GroupProductionChangeRecord set ");
			strSql.Append("csid=@csid,");
			strSql.Append("sid=@sid,");
			strSql.Append("gsid=@gsid,");
			strSql.Append("gnum=@gnum,");
			strSql.Append("iname=@iname,");
			strSql.Append("icode=@icode,");
			strSql.Append("mname=@mname,");
			strSql.Append("uname=@uname,");
			strSql.Append("inum=@inum,");
			strSql.Append("place=@place,");
			strSql.Append("direction=@direction,");
			strSql.Append("fix=@fix,");
			strSql.Append("locktype=@locktype,");
			strSql.Append("locks=@locks,");
			strSql.Append("itype=@itype,");
			strSql.Append("ptype=@ptype,");
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
			strSql.Append("idiscount=@idiscount,");
			strSql.Append("allprice=@allprice,");
			strSql.Append("serverprice=@serverprice,");
			strSql.Append("picname=@picname,");
			strSql.Append("czyy=@czyy,");
			strSql.Append("zsize=@zsize,");
			strSql.Append("zjname=@zjname,");
			strSql.Append("zjcode=@zjcode,");
			strSql.Append("zjmname=@zjmname,");
			strSql.Append("tbcz=@tbcz,");
			strSql.Append("lxcz=@lxcz,");
			strSql.Append("tsid=@tsid,");
			strSql.Append("cpxz=@cpxz,");
			strSql.Append("tjxz=@tjxz,");
			strSql.Append("rimg=@rimg,");
			strSql.Append("priceps=@priceps,");
			strSql.Append("ghnum=@ghnum,");
			strSql.Append("cgnum=@cgnum,");
			strSql.Append("floor=@floor,");
			strSql.Append("moneyremark=@moneyremark,");
			strSql.Append("cavecode=@cavecode,");
			strSql.Append("cavename=@cavename,");
			strSql.Append("msts=@msts,");
			strSql.Append("mtts=@mtts,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where psid=@psid");
			SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@iname", SqlDbType.NVarChar,30),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@uname", SqlDbType.NVarChar,10),
					new SqlParameter("@inum", SqlDbType.Float,8),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@direction", SqlDbType.NVarChar,30),
					new SqlParameter("@fix", SqlDbType.NVarChar,20),
					new SqlParameter("@locktype", SqlDbType.NVarChar,20),
					new SqlParameter("@locks", SqlDbType.NVarChar,20),
					new SqlParameter("@itype", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,20),
					new SqlParameter("@height", SqlDbType.Int,4),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@deep", SqlDbType.Int,4),
					new SqlParameter("@fsize", SqlDbType.Int,4),
					new SqlParameter("@smoney", SqlDbType.Decimal,9),
					new SqlParameter("@sovermoney", SqlDbType.Decimal,9),
					new SqlParameter("@sothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@gmoney", SqlDbType.Decimal,9),
					new SqlParameter("@govermoney", SqlDbType.Decimal,9),
					new SqlParameter("@gothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cmoney", SqlDbType.Decimal,9),
					new SqlParameter("@covermoney", SqlDbType.Decimal,9),
					new SqlParameter("@cothermoney", SqlDbType.Decimal,9),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@cdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@pic", SqlDbType.NVarChar,100),
					new SqlParameter("@ichange", SqlDbType.Int,4),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@isjc", SqlDbType.NVarChar,10),
					new SqlParameter("@idiscount", SqlDbType.Int,4),
					new SqlParameter("@allprice", SqlDbType.Money,8),
					new SqlParameter("@serverprice", SqlDbType.Money,8),
					new SqlParameter("@picname", SqlDbType.NVarChar,200),
					new SqlParameter("@czyy", SqlDbType.NVarChar,100),
					new SqlParameter("@zsize", SqlDbType.NVarChar,50),
					new SqlParameter("@zjname", SqlDbType.NVarChar,50),
					new SqlParameter("@zjcode", SqlDbType.NVarChar,50),
					new SqlParameter("@zjmname", SqlDbType.NVarChar,50),
					new SqlParameter("@tbcz", SqlDbType.NVarChar,50),
					new SqlParameter("@lxcz", SqlDbType.NVarChar,50),
					new SqlParameter("@tsid", SqlDbType.NVarChar,50),
					new SqlParameter("@cpxz", SqlDbType.NVarChar,50),
					new SqlParameter("@tjxz", SqlDbType.NVarChar,50),
					new SqlParameter("@rimg", SqlDbType.NVarChar,100),
					new SqlParameter("@priceps", SqlDbType.Decimal,9),
					new SqlParameter("@ghnum", SqlDbType.Decimal,9),
					new SqlParameter("@cgnum", SqlDbType.Decimal,9),
					new SqlParameter("@floor", SqlDbType.NVarChar,30),
					new SqlParameter("@moneyremark", SqlDbType.NVarChar,100),
					new SqlParameter("@cavecode", SqlDbType.NVarChar,30),
					new SqlParameter("@cavename", SqlDbType.NVarChar,30),
					new SqlParameter("@msts", SqlDbType.NVarChar,30),
					new SqlParameter("@mtts", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@psid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.csid;
			parameters[1].Value = model.sid;
			parameters[2].Value = model.gsid;
			parameters[3].Value = model.gnum;
			parameters[4].Value = model.iname;
			parameters[5].Value = model.icode;
			parameters[6].Value = model.mname;
			parameters[7].Value = model.uname;
			parameters[8].Value = model.inum;
			parameters[9].Value = model.place;
			parameters[10].Value = model.direction;
			parameters[11].Value = model.fix;
			parameters[12].Value = model.locktype;
			parameters[13].Value = model.locks;
			parameters[14].Value = model.itype;
			parameters[15].Value = model.ptype;
			parameters[16].Value = model.height;
			parameters[17].Value = model.width;
			parameters[18].Value = model.deep;
			parameters[19].Value = model.fsize;
			parameters[20].Value = model.smoney;
			parameters[21].Value = model.sovermoney;
			parameters[22].Value = model.sothermoney;
			parameters[23].Value = model.gmoney;
			parameters[24].Value = model.govermoney;
			parameters[25].Value = model.gothermoney;
			parameters[26].Value = model.cmoney;
			parameters[27].Value = model.covermoney;
			parameters[28].Value = model.cothermoney;
			parameters[29].Value = model.sdiscount;
			parameters[30].Value = model.gdiscount;
			parameters[31].Value = model.cdiscount;
			parameters[32].Value = model.pic;
			parameters[33].Value = model.ichange;
			parameters[34].Value = model.ps;
			parameters[35].Value = model.isjc;
			parameters[36].Value = model.idiscount;
			parameters[37].Value = model.allprice;
			parameters[38].Value = model.serverprice;
			parameters[39].Value = model.picname;
			parameters[40].Value = model.czyy;
			parameters[41].Value = model.zsize;
			parameters[42].Value = model.zjname;
			parameters[43].Value = model.zjcode;
			parameters[44].Value = model.zjmname;
			parameters[45].Value = model.tbcz;
			parameters[46].Value = model.lxcz;
			parameters[47].Value = model.tsid;
			parameters[48].Value = model.cpxz;
			parameters[49].Value = model.tjxz;
			parameters[50].Value = model.rimg;
			parameters[51].Value = model.priceps;
			parameters[52].Value = model.ghnum;
			parameters[53].Value = model.cgnum;
			parameters[54].Value = model.floor;
			parameters[55].Value = model.moneyremark;
			parameters[56].Value = model.cavecode;
			parameters[57].Value = model.cavename;
			parameters[58].Value = model.msts;
			parameters[59].Value = model.mtts;
			parameters[60].Value = model.maker;
			parameters[61].Value = model.cdate;
			parameters[62].Value = model.psid;

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
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_GroupProductionChangeRecord where 1=1 {0}", where);
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
		public  B_GroupProductionChangeRecord Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,csid,sid,gsid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,locktype,locks,itype,ptype,height,width,deep,fsize,smoney,sovermoney,sothermoney,gmoney,govermoney,gothermoney,cmoney,covermoney,cothermoney,sdiscount,gdiscount,cdiscount,pic,ichange,ps,isjc,idiscount,allprice,serverprice,picname,czyy,zsize,zjname,zjcode,zjmname,tbcz,lxcz,tsid,cpxz,tjxz,rimg,priceps,ghnum,cgnum,floor,moneyremark,cavecode,cavename,msts,mtts,maker,cdate from B_GroupProductionChangeRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_GroupProductionChangeRecord r = new B_GroupProductionChangeRecord();
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
		public  B_GroupProductionChangeRecord DataRowToModel(DataRow row)
		{
			 B_GroupProductionChangeRecord model=new  B_GroupProductionChangeRecord();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["csid"]!=null)
				{
					model.csid=row["csid"].ToString();
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["gsid"]!=null)
				{
					model.gsid=row["gsid"].ToString();
				}
				if(row["psid"]!=null)
				{
					model.psid=row["psid"].ToString();
				}
				if(row["gnum"]!=null && row["gnum"].ToString()!="")
				{
					model.gnum=int.Parse(row["gnum"].ToString());
				}
				if(row["iname"]!=null)
				{
					model.iname=row["iname"].ToString();
				}
				if(row["icode"]!=null)
				{
					model.icode=row["icode"].ToString();
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["uname"]!=null)
				{
					model.uname=row["uname"].ToString();
				}
				if(row["inum"]!=null && row["inum"].ToString()!="")
				{
					model.inum=decimal.Parse(row["inum"].ToString());
				}
				if(row["place"]!=null)
				{
					model.place=row["place"].ToString();
				}
				if(row["direction"]!=null)
				{
					model.direction=row["direction"].ToString();
				}
				if(row["fix"]!=null)
				{
					model.fix=row["fix"].ToString();
				}
				if(row["locktype"]!=null)
				{
					model.locktype=row["locktype"].ToString();
				}
				if(row["locks"]!=null)
				{
					model.locks=row["locks"].ToString();
				}
				if(row["itype"]!=null)
				{
					model.itype=row["itype"].ToString();
				}
				if(row["ptype"]!=null)
				{
					model.ptype=row["ptype"].ToString();
				}
				if(row["height"]!=null && row["height"].ToString()!="")
				{
					model.height=int.Parse(row["height"].ToString());
				}
				if(row["width"]!=null && row["width"].ToString()!="")
				{
					model.width=int.Parse(row["width"].ToString());
				}
				if(row["deep"]!=null && row["deep"].ToString()!="")
				{
					model.deep=int.Parse(row["deep"].ToString());
				}
				if(row["fsize"]!=null && row["fsize"].ToString()!="")
				{
					model.fsize=int.Parse(row["fsize"].ToString());
				}
				if(row["smoney"]!=null && row["smoney"].ToString()!="")
				{
					model.smoney=decimal.Parse(row["smoney"].ToString());
				}
				if(row["sovermoney"]!=null && row["sovermoney"].ToString()!="")
				{
					model.sovermoney=decimal.Parse(row["sovermoney"].ToString());
				}
				if(row["sothermoney"]!=null && row["sothermoney"].ToString()!="")
				{
					model.sothermoney=decimal.Parse(row["sothermoney"].ToString());
				}
				if(row["gmoney"]!=null && row["gmoney"].ToString()!="")
				{
					model.gmoney=decimal.Parse(row["gmoney"].ToString());
				}
				if(row["govermoney"]!=null && row["govermoney"].ToString()!="")
				{
					model.govermoney=decimal.Parse(row["govermoney"].ToString());
				}
				if(row["gothermoney"]!=null && row["gothermoney"].ToString()!="")
				{
					model.gothermoney=decimal.Parse(row["gothermoney"].ToString());
				}
				if(row["cmoney"]!=null && row["cmoney"].ToString()!="")
				{
					model.cmoney=decimal.Parse(row["cmoney"].ToString());
				}
				if(row["covermoney"]!=null && row["covermoney"].ToString()!="")
				{
					model.covermoney=decimal.Parse(row["covermoney"].ToString());
				}
				if(row["cothermoney"]!=null && row["cothermoney"].ToString()!="")
				{
					model.cothermoney=decimal.Parse(row["cothermoney"].ToString());
				}
				if(row["sdiscount"]!=null && row["sdiscount"].ToString()!="")
				{
					model.sdiscount=decimal.Parse(row["sdiscount"].ToString());
				}
				if(row["gdiscount"]!=null && row["gdiscount"].ToString()!="")
				{
					model.gdiscount=decimal.Parse(row["gdiscount"].ToString());
				}
				if(row["cdiscount"]!=null && row["cdiscount"].ToString()!="")
				{
					model.cdiscount=decimal.Parse(row["cdiscount"].ToString());
				}
				if(row["pic"]!=null)
				{
					model.pic=row["pic"].ToString();
				}
				if(row["ichange"]!=null && row["ichange"].ToString()!="")
				{
					model.ichange=int.Parse(row["ichange"].ToString());
				}
				if(row["ps"]!=null)
				{
					model.ps=row["ps"].ToString();
				}
				if(row["isjc"]!=null)
				{
					model.isjc=row["isjc"].ToString();
				}
				if(row["idiscount"]!=null && row["idiscount"].ToString()!="")
				{
					model.idiscount=int.Parse(row["idiscount"].ToString());
				}
				if(row["allprice"]!=null && row["allprice"].ToString()!="")
				{
					model.allprice=decimal.Parse(row["allprice"].ToString());
				}
				if(row["serverprice"]!=null && row["serverprice"].ToString()!="")
				{
					model.serverprice=decimal.Parse(row["serverprice"].ToString());
				}
				if(row["picname"]!=null)
				{
					model.picname=row["picname"].ToString();
				}
				if(row["czyy"]!=null)
				{
					model.czyy=row["czyy"].ToString();
				}
				if(row["zsize"]!=null)
				{
					model.zsize=row["zsize"].ToString();
				}
				if(row["zjname"]!=null)
				{
					model.zjname=row["zjname"].ToString();
				}
				if(row["zjcode"]!=null)
				{
					model.zjcode=row["zjcode"].ToString();
				}
				if(row["zjmname"]!=null)
				{
					model.zjmname=row["zjmname"].ToString();
				}
				if(row["tbcz"]!=null)
				{
					model.tbcz=row["tbcz"].ToString();
				}
				if(row["lxcz"]!=null)
				{
					model.lxcz=row["lxcz"].ToString();
				}
				if(row["tsid"]!=null)
				{
					model.tsid=row["tsid"].ToString();
				}
				if(row["cpxz"]!=null)
				{
					model.cpxz=row["cpxz"].ToString();
				}
				if(row["tjxz"]!=null)
				{
					model.tjxz=row["tjxz"].ToString();
				}
				if(row["rimg"]!=null)
				{
					model.rimg=row["rimg"].ToString();
				}
				if(row["priceps"]!=null && row["priceps"].ToString()!="")
				{
					model.priceps=decimal.Parse(row["priceps"].ToString());
				}
				if(row["ghnum"]!=null && row["ghnum"].ToString()!="")
				{
					model.ghnum=decimal.Parse(row["ghnum"].ToString());
				}
				if(row["cgnum"]!=null && row["cgnum"].ToString()!="")
				{
					model.cgnum=decimal.Parse(row["cgnum"].ToString());
				}
				if(row["floor"]!=null)
				{
					model.floor=row["floor"].ToString();
				}
				if(row["moneyremark"]!=null)
				{
					model.moneyremark=row["moneyremark"].ToString();
				}
				if(row["cavecode"]!=null)
				{
					model.cavecode=row["cavecode"].ToString();
				}
				if(row["cavename"]!=null)
				{
					model.cavename=row["cavename"].ToString();
				}
				if(row["msts"]!=null)
				{
					model.msts=row["msts"].ToString();
				}
				if(row["mtts"]!=null)
				{
					model.mtts=row["mtts"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_GroupProductionChangeRecord> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,csid,sid,gsid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,locktype,locks,itype,ptype,height,width,deep,fsize,smoney,sovermoney,sothermoney,gmoney,govermoney,gothermoney,cmoney,covermoney,cothermoney,sdiscount,gdiscount,cdiscount,pic,ichange,ps,isjc,idiscount,allprice,serverprice,picname,czyy,zsize,zjname,zjcode,zjmname,tbcz,lxcz,tsid,cpxz,tjxz,rimg,priceps,ghnum,cgnum,floor,moneyremark,cavecode,cavename,msts,mtts,maker,cdate ");
			strSql.Append(" FROM B_GroupProductionChangeRecord ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_GroupProductionChangeRecord> r = new List<B_GroupProductionChangeRecord>();
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
        public bool CopyGroupProduction(string sid, string csid, string gnum)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("SET IDENTITY_INSERT B_GroupProductionChangeRecord ON;");
            strSql.AppendFormat("insert into  B_GroupProductionChangeRecord (sid,csid,gsid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,locktype,locks,itype,ptype,height,width,deep,fsize ,smoney,sovermoney,sothermoney,gmoney,govermoney,gothermoney,cmoney,covermoney,cothermoney,sdiscount,gdiscount,cdiscount,pic,ichange,ps,isjc,idiscount,allprice,serverprice,picname,czyy,zsize,zjname,zjcode,zjmname,tbcz,lxcz,tsid,cpxz,tjxz,rimg,priceps,ghnum,cgnum,floor,moneyremark,cavecode,cavename,msts,mtts,maker,cdate ) select sid,'{0}',gsid,psid,gnum,iname,icode,mname,uname,inum,place,direction,fix,locktype,locks,itype,ptype,height,width,deep,fsize ,smoney,sovermoney,sothermoney,gmoney,govermoney,gothermoney,cmoney,covermoney,cothermoney,sdiscount,gdiscount,cdiscount,pic,ichange,ps,isjc,idiscount,allprice,serverprice,picname,czyy,zsize,zjname,zjcode,zjmname,tbcz,lxcz,tsid,cpxz,tjxz,rimg,priceps,ghnum,cgnum,floor,moneyremark,cavecode,cavename,msts,mtts,maker,cdate from B_GroupProduction where sid='{1}' and gnum={2};", csid, sid, gnum);
            //strSql.AppendFormat("SET IDENTITY_INSERT B_GroupProductionChangeRecord OFF;");
           //strSql.AppendFormat("SET IDENTITY_INSERT B_ProductionItemChangeRecorder ON;");
            strSql.AppendFormat("insert into  B_ProductionItemChangeRecorder (sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,aname,addattr,addsw,workline,maker,cdate) select sid,psid,pname,pcode,mname,ptype,height,width,deep,pnum,e_ptype,aname,addattr,addsw,workline,maker,cdate from B_ProductionItem where psid in(select psid from B_GroupProduction where sid='{1}' and gnum={2});", csid, sid, gnum);
           // strSql.AppendFormat("SET IDENTITY_INSERT B_ProductionItemChangeRecorder OFF;");
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
