using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvCommonDal;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_SizeTransformDal : ISys_SizeTransformDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_SizeTransform");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SizeTransform model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SizeTransform(");
            strSql.Append("jname,jcode,jtype,fixmethod,mcomputermethod,dg,dk,dh,d1sl,d2sl,d1k,d2k,d1g,d2g,mtg,mtk,mth,mtsl,mtge,mtke,mthe,mtsle,lbg,lbk,lbh,lbsl,lbge,lbke,lbhe,lbsle,stlg,stlk,stlh,stlsl,stleg,stlek,stleh,stlesl,mtsg,mtsk,mtsh,mtssl,ltlg,ltlk,ltlh,ltlsl,ltleg,ltlek,ltleh,ltlesl,lbsg,lbsk,lbsh,lbssl,tlhg,tlhk,tlhh,tlhsl,tlh2g,tlh2k,tlh2h,tlh2sl,dzg,dzk,dzh,dzsl,dmxg,dmxk,dmxh,dmxsl,mentg,mentk,menth,mentsl,hmdxg,hmdxk,hmdxh,hmdxsl,lmdxg,lmdxk,lmdxh,lmdxsl,slg,slk,slh,slsl,sljs,slhlg,slhlk,slhlh,slhlsl,slslg,slslk,slslh,slslsl,mtbg,mtbk,mtbh,mtbsl,mtbeg,mtbek,mtbeh,mtbesl,tlhdg,tlhdk,tlhdh,tlhdsl,tlhcg,tlhck,tlhch,tlhcsl,tlhgg,tlhgk,tlhgh,tlhgsl,skxg,skxk,skxh,skxsl,blytg,blytk,blyth,blytsl,blyteg,blytek,blyteh,blytesl,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@jname,@jcode,@jtype,@fixmethod,@mcomputermethod,@dg,@dk,@dh,@d1sl,@d2sl,@d1k,@d2k,@d1g,@d2g,@mtg,@mtk,@mth,@mtsl,@mtge,@mtke,@mthe,@mtsle,@lbg,@lbk,@lbh,@lbsl,@lbge,@lbke,@lbhe,@lbsle,@stlg,@stlk,@stlh,@stlsl,@stleg,@stlek,@stleh,@stlesl,@mtsg,@mtsk,@mtsh,@mtssl,@ltlg,@ltlk,@ltlh,@ltlsl,@ltleg,@ltlek,@ltleh,@ltlesl,@lbsg,@lbsk,@lbsh,@lbssl,@tlhg,@tlhk,@tlhh,@tlhsl,@tlh2g,@tlh2k,@tlh2h,@tlh2sl,@dzg,@dzk,@dzh,@dzsl,@dmxg,@dmxk,@dmxh,@dmxsl,@mentg,@mentk,@menth,@mentsl,@hmdxg,@hmdxk,@hmdxh,@hmdxsl,@lmdxg,@lmdxk,@lmdxh,@lmdxsl,@slg,@slk,@slh,@slsl,@sljs,@slhlg,@slhlk,@slhlh,@slhlsl,@slslg,@slslk,@slslh,@slslsl,@mtbg,@mtbk,@mtbh,@mtbsl,@mtbeg,@mtbek,@mtbeh,@mtbesl,@tlhdg,@tlhdk,@tlhdh,@tlhdsl,@tlhcg,@tlhck,@tlhch,@tlhcsl,@tlhgg,@tlhgk,@tlhgh,@tlhgsl,@skxg,@skxk,@skxh,@skxsl,@blytg,@blytk,@blyth,@blytsl,@blyteg,@blytek,@blyteh,@blytesl,@maker,@cdate,@dcode)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@jname", SqlDbType.NVarChar,30),
					new SqlParameter("@jcode", SqlDbType.NVarChar,50),
					new SqlParameter("@jtype", SqlDbType.NVarChar,50),
					new SqlParameter("@fixmethod", SqlDbType.NVarChar,10),
					new SqlParameter("@mcomputermethod", SqlDbType.NVarChar,10),
					new SqlParameter("@dg", SqlDbType.Int,4),
					new SqlParameter("@dk", SqlDbType.Int,4),
					new SqlParameter("@dh", SqlDbType.Int,4),
					new SqlParameter("@d1sl", SqlDbType.Int,4),
					new SqlParameter("@d2sl", SqlDbType.Int,4),
					new SqlParameter("@d1k", SqlDbType.Float,8),
					new SqlParameter("@d2k", SqlDbType.Float,8),
					new SqlParameter("@d1g", SqlDbType.Float,8),
					new SqlParameter("@d2g", SqlDbType.Float,8),
					new SqlParameter("@mtg", SqlDbType.NVarChar,30),
					new SqlParameter("@mtk", SqlDbType.NVarChar,30),
					new SqlParameter("@mth", SqlDbType.NVarChar,30),
					new SqlParameter("@mtsl", SqlDbType.Int,4),
					new SqlParameter("@mtge", SqlDbType.NVarChar,30),
					new SqlParameter("@mtke", SqlDbType.NVarChar,30),
					new SqlParameter("@mthe", SqlDbType.NVarChar,30),
					new SqlParameter("@mtsle", SqlDbType.Int,4),
					new SqlParameter("@lbg", SqlDbType.NVarChar,30),
					new SqlParameter("@lbk", SqlDbType.NVarChar,30),
					new SqlParameter("@lbh", SqlDbType.NVarChar,30),
					new SqlParameter("@lbsl", SqlDbType.Int,4),
					new SqlParameter("@lbge", SqlDbType.NVarChar,30),
					new SqlParameter("@lbke", SqlDbType.NVarChar,30),
					new SqlParameter("@lbhe", SqlDbType.NVarChar,30),
					new SqlParameter("@lbsle", SqlDbType.Int,4),
					new SqlParameter("@stlg", SqlDbType.NVarChar,30),
					new SqlParameter("@stlk", SqlDbType.NVarChar,30),
					new SqlParameter("@stlh", SqlDbType.NVarChar,30),
					new SqlParameter("@stlsl", SqlDbType.Int,4),
					new SqlParameter("@stleg", SqlDbType.NVarChar,30),
					new SqlParameter("@stlek", SqlDbType.NVarChar,30),
					new SqlParameter("@stleh", SqlDbType.NVarChar,30),
					new SqlParameter("@stlesl", SqlDbType.Int,4),
					new SqlParameter("@mtsg", SqlDbType.NVarChar,30),
					new SqlParameter("@mtsk", SqlDbType.NVarChar,30),
					new SqlParameter("@mtsh", SqlDbType.NVarChar,30),
					new SqlParameter("@mtssl", SqlDbType.Int,4),
					new SqlParameter("@ltlg", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlk", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlh", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlsl", SqlDbType.Int,4),
					new SqlParameter("@ltleg", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlek", SqlDbType.NVarChar,30),
					new SqlParameter("@ltleh", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlesl", SqlDbType.Int,4),
					new SqlParameter("@lbsg", SqlDbType.NVarChar,30),
					new SqlParameter("@lbsk", SqlDbType.NVarChar,30),
					new SqlParameter("@lbsh", SqlDbType.NVarChar,30),
					new SqlParameter("@lbssl", SqlDbType.Int,4),
					new SqlParameter("@tlhg",SqlDbType.NVarChar,30 ),
					new SqlParameter("@tlhk", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhh", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhsl", SqlDbType.Int,4),
					new SqlParameter("@tlh2g", SqlDbType.NVarChar,30),
					new SqlParameter("@tlh2k", SqlDbType.NVarChar,30),
					new SqlParameter("@tlh2h", SqlDbType.NVarChar,30),
					new SqlParameter("@tlh2sl", SqlDbType.Int,4),
					new SqlParameter("@dzg", SqlDbType.NVarChar,30),
					new SqlParameter("@dzk", SqlDbType.NVarChar,30),
					new SqlParameter("@dzh", SqlDbType.NVarChar,30),
					new SqlParameter("@dzsl", SqlDbType.Int,4),
					new SqlParameter("@dmxg", SqlDbType.NVarChar,30),
					new SqlParameter("@dmxk", SqlDbType.NVarChar,30),
					new SqlParameter("@dmxh", SqlDbType.NVarChar,30),
					new SqlParameter("@dmxsl", SqlDbType.Int,4),
					new SqlParameter("@mentg", SqlDbType.NVarChar,30),
					new SqlParameter("@mentk", SqlDbType.NVarChar,30),
					new SqlParameter("@menth", SqlDbType.NVarChar,30),
					new SqlParameter("@mentsl", SqlDbType.Int,4),
					new SqlParameter("@hmdxg", SqlDbType.NVarChar,30),
					new SqlParameter("@hmdxk", SqlDbType.NVarChar,30),
					new SqlParameter("@hmdxh", SqlDbType.NVarChar,30),
					new SqlParameter("@hmdxsl", SqlDbType.Int,4),
					new SqlParameter("@lmdxg", SqlDbType.NVarChar,30),
					new SqlParameter("@lmdxk", SqlDbType.NVarChar,30),
					new SqlParameter("@lmdxh", SqlDbType.NVarChar,30),
					new SqlParameter("@lmdxsl", SqlDbType.Int,4),
					new SqlParameter("@slg", SqlDbType.NVarChar,30),
					new SqlParameter("@slk", SqlDbType.NVarChar,30),
					new SqlParameter("@slh", SqlDbType.NVarChar,30),
					new SqlParameter("@slsl", SqlDbType.Int,4),
					new SqlParameter("@sljs", SqlDbType.Int,4),
					new SqlParameter("@slhlg", SqlDbType.NVarChar,30),
					new SqlParameter("@slhlk", SqlDbType.NVarChar,30),
					new SqlParameter("@slhlh", SqlDbType.NVarChar,30),
					new SqlParameter("@slhlsl", SqlDbType.Int,4),
					new SqlParameter("@slslg", SqlDbType.NVarChar,30),
					new SqlParameter("@slslk",SqlDbType.NVarChar,30),
					new SqlParameter("@slslh", SqlDbType.NVarChar,30),
					new SqlParameter("@slslsl", SqlDbType.Int,4),
					new SqlParameter("@mtbg", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbk", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbh", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbsl", SqlDbType.Int,4),
					new SqlParameter("@mtbeg", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbek", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbeh", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbesl", SqlDbType.Int,4),
					new SqlParameter("@tlhdg", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhdk", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhdh", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhdsl", SqlDbType.Int,4),
					new SqlParameter("@tlhcg", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhck", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhch", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhcsl", SqlDbType.Int,4),
					new SqlParameter("@tlhgg", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhgk", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhgh", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhgsl", SqlDbType.Int,4),
					new SqlParameter("@skxg", SqlDbType.NVarChar,30),
					new SqlParameter("@skxk", SqlDbType.NVarChar,30),
					new SqlParameter("@skxh", SqlDbType.NVarChar,30),
					new SqlParameter("@skxsl", SqlDbType.Int,4),
					new SqlParameter("@blytg", SqlDbType.NVarChar,30),
					new SqlParameter("@blytk", SqlDbType.NVarChar,30),
					new SqlParameter("@blyth", SqlDbType.NVarChar,30),
					new SqlParameter("@blytsl", SqlDbType.Int,4),
					new SqlParameter("@blyteg", SqlDbType.NVarChar,30),
					new SqlParameter("@blytek", SqlDbType.NVarChar,30),
					new SqlParameter("@blyteh", SqlDbType.NVarChar,30),
					new SqlParameter("@blytesl", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.jname;
            parameters[1].Value = model.jcode;
            parameters[2].Value = model.jtype;
            parameters[3].Value = model.fixmethod;
            parameters[4].Value = model.mcomputermethod;
            parameters[5].Value = model.dg;
            parameters[6].Value = model.dk;
            parameters[7].Value = model.dh;
            parameters[8].Value = model.d1sl;
            parameters[9].Value = model.d2sl;
            parameters[10].Value = model.d1k;
            parameters[11].Value = model.d2k;
            parameters[12].Value = model.d1g;
            parameters[13].Value = model.d2g;
            parameters[14].Value = model.mtg;
            parameters[15].Value = model.mtk;
            parameters[16].Value = model.mth;
            parameters[17].Value = model.mtsl;
            parameters[18].Value = model.mtge;
            parameters[19].Value = model.mtke;
            parameters[20].Value = model.mthe;
            parameters[21].Value = model.mtsle;
            parameters[22].Value = model.lbg;
            parameters[23].Value = model.lbk;
            parameters[24].Value = model.lbh;
            parameters[25].Value = model.lbsl;
            parameters[26].Value = model.lbge;
            parameters[27].Value = model.lbke;
            parameters[28].Value = model.lbhe;
            parameters[29].Value = model.lbsle;
            parameters[30].Value = model.stlg;
            parameters[31].Value = model.stlk;
            parameters[32].Value = model.stlh;
            parameters[33].Value = model.stlsl;
            parameters[34].Value = model.stleg;
            parameters[35].Value = model.stlek;
            parameters[36].Value = model.stleh;
            parameters[37].Value = model.stlesl;
            parameters[38].Value = model.mtsg;
            parameters[39].Value = model.mtsk;
            parameters[40].Value = model.mtsh;
            parameters[41].Value = model.mtssl;
            parameters[42].Value = model.ltlg;
            parameters[43].Value = model.ltlk;
            parameters[44].Value = model.ltlh;
            parameters[45].Value = model.ltlsl;
            parameters[46].Value = model.ltleg;
            parameters[47].Value = model.ltlek;
            parameters[48].Value = model.ltleh;
            parameters[49].Value = model.ltlesl;
            parameters[50].Value = model.lbsg;
            parameters[51].Value = model.lbsk;
            parameters[52].Value = model.lbsh;
            parameters[53].Value = model.lbssl;
            parameters[54].Value = model.tlhg;
            parameters[55].Value = model.tlhk;
            parameters[56].Value = model.tlhh;
            parameters[57].Value = model.tlhsl;
            parameters[58].Value = model.tlh2g;
            parameters[59].Value = model.tlh2k;
            parameters[60].Value = model.tlh2h;
            parameters[61].Value = model.tlh2sl;
            parameters[62].Value = model.dzg;
            parameters[63].Value = model.dzk;
            parameters[64].Value = model.dzh;
            parameters[65].Value = model.dzsl;
            parameters[66].Value = model.dmxg;
            parameters[67].Value = model.dmxk;
            parameters[68].Value = model.dmxh;
            parameters[69].Value = model.dmxsl;
            parameters[70].Value = model.mentg;
            parameters[71].Value = model.mentk;
            parameters[72].Value = model.menth;
            parameters[73].Value = model.mentsl;
            parameters[74].Value = model.hmdxg;
            parameters[75].Value = model.hmdxk;
            parameters[76].Value = model.hmdxh;
            parameters[77].Value = model.hmdxsl;
            parameters[78].Value = model.lmdxg;
            parameters[79].Value = model.lmdxk;
            parameters[80].Value = model.lmdxh;
            parameters[81].Value = model.lmdxsl;
            parameters[82].Value = model.slg;
            parameters[83].Value = model.slk;
            parameters[84].Value = model.slh;
            parameters[85].Value = model.slsl;
            parameters[86].Value = model.sljs;
            parameters[87].Value = model.slhlg;
            parameters[88].Value = model.slhlk;
            parameters[89].Value = model.slhlh;
            parameters[90].Value = model.slhlsl;
            parameters[91].Value = model.slslg;
            parameters[92].Value = model.slslk;
            parameters[93].Value = model.slslh;
            parameters[94].Value = model.slslsl;
            parameters[95].Value = model.mtbg;
            parameters[96].Value = model.mtbk;
            parameters[97].Value = model.mtbh;
            parameters[98].Value = model.mtbsl;
            parameters[99].Value = model.mtbeg;
            parameters[100].Value = model.mtbek;
            parameters[101].Value = model.mtbeh;
            parameters[102].Value = model.mtbesl;
            parameters[103].Value = model.tlhdg;
            parameters[104].Value = model.tlhdk;
            parameters[105].Value = model.tlhdh;
            parameters[106].Value = model.tlhdsl;
            parameters[107].Value = model.tlhcg;
            parameters[108].Value = model.tlhck;
            parameters[109].Value = model.tlhch;
            parameters[110].Value = model.tlhcsl;
            parameters[111].Value = model.tlhgg;
            parameters[112].Value = model.tlhgk;
            parameters[113].Value = model.tlhgh;
            parameters[114].Value = model.tlhgsl;
            parameters[115].Value = model.skxg;
            parameters[116].Value = model.skxk;
            parameters[117].Value = model.skxh;
            parameters[118].Value = model.skxsl;
            parameters[119].Value = model.blytg;
            parameters[120].Value = model.blytk;
            parameters[121].Value = model.blyth;
            parameters[122].Value = model.blytsl;
            parameters[123].Value = model.blyteg;
            parameters[124].Value = model.blytek;
            parameters[125].Value = model.blyteh;
            parameters[126].Value = model.blytesl;
            parameters[127].Value = model.maker;
            parameters[128].Value = model.cdate;
            parameters[129].Value = model.dcode;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update( Sys_SizeTransform model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SizeTransform set ");
            strSql.Append("jname=@jname,");
            strSql.Append("jtype=@jtype,");
            strSql.Append("fixmethod=@fixmethod,");
            strSql.Append("mcomputermethod=@mcomputermethod,");
            strSql.Append("dg=@dg,");
            strSql.Append("dk=@dk,");
            strSql.Append("dh=@dh,");
            strSql.Append("d1sl=@d1sl,");
            strSql.Append("d2sl=@d2sl,");
            strSql.Append("d1k=@d1k,");
            strSql.Append("d2k=@d2k,");
            strSql.Append("d1g=@d1g,");
            strSql.Append("d2g=@d2g,");
            strSql.Append("mtg=@mtg,");
            strSql.Append("mtk=@mtk,");
            strSql.Append("mth=@mth,");
            strSql.Append("mtsl=@mtsl,");
            strSql.Append("mtge=@mtge,");
            strSql.Append("mtke=@mtke,");
            strSql.Append("mthe=@mthe,");
            strSql.Append("mtsle=@mtsle,");
            strSql.Append("lbg=@lbg,");
            strSql.Append("lbk=@lbk,");
            strSql.Append("lbh=@lbh,");
            strSql.Append("lbsl=@lbsl,");
            strSql.Append("lbge=@lbge,");
            strSql.Append("lbke=@lbke,");
            strSql.Append("lbhe=@lbhe,");
            strSql.Append("lbsle=@lbsle,");
            strSql.Append("stlg=@stlg,");
            strSql.Append("stlk=@stlk,");
            strSql.Append("stlh=@stlh,");
            strSql.Append("stlsl=@stlsl,");
            strSql.Append("stleg=@stleg,");
            strSql.Append("stlek=@stlek,");
            strSql.Append("stleh=@stleh,");
            strSql.Append("stlesl=@stlesl,");
            strSql.Append("mtsg=@mtsg,");
            strSql.Append("mtsk=@mtsk,");
            strSql.Append("mtsh=@mtsh,");
            strSql.Append("mtssl=@mtssl,");
            strSql.Append("ltlg=@ltlg,");
            strSql.Append("ltlk=@ltlk,");
            strSql.Append("ltlh=@ltlh,");
            strSql.Append("ltlsl=@ltlsl,");
            strSql.Append("ltleg=@ltleg,");
            strSql.Append("ltlek=@ltlek,");
            strSql.Append("ltleh=@ltleh,");
            strSql.Append("ltlesl=@ltlesl,");
            strSql.Append("lbsg=@lbsg,");
            strSql.Append("lbsk=@lbsk,");
            strSql.Append("lbsh=@lbsh,");
            strSql.Append("lbssl=@lbssl,");
            strSql.Append("tlhg=@tlhg,");
            strSql.Append("tlhk=@tlhk,");
            strSql.Append("tlhh=@tlhh,");
            strSql.Append("tlhsl=@tlhsl,");
            strSql.Append("tlh2g=@tlh2g,");
            strSql.Append("tlh2k=@tlh2k,");
            strSql.Append("tlh2h=@tlh2h,");
            strSql.Append("tlh2sl=@tlh2sl,");
            strSql.Append("dzg=@dzg,");
            strSql.Append("dzk=@dzk,");
            strSql.Append("dzh=@dzh,");
            strSql.Append("dzsl=@dzsl,");
            strSql.Append("dmxg=@dmxg,");
            strSql.Append("dmxk=@dmxk,");
            strSql.Append("dmxh=@dmxh,");
            strSql.Append("dmxsl=@dmxsl,");
            strSql.Append("mentg=@mentg,");
            strSql.Append("mentk=@mentk,");
            strSql.Append("menth=@menth,");
            strSql.Append("mentsl=@mentsl,");
            strSql.Append("hmdxg=@hmdxg,");
            strSql.Append("hmdxk=@hmdxk,");
            strSql.Append("hmdxh=@hmdxh,");
            strSql.Append("hmdxsl=@hmdxsl,");
            strSql.Append("lmdxg=@lmdxg,");
            strSql.Append("lmdxk=@lmdxk,");
            strSql.Append("lmdxh=@lmdxh,");
            strSql.Append("lmdxsl=@lmdxsl,");
            strSql.Append("slg=@slg,");
            strSql.Append("slk=@slk,");
            strSql.Append("slh=@slh,");
            strSql.Append("slsl=@slsl,");
            strSql.Append("sljs=@sljs,");
            strSql.Append("slhlg=@slhlg,");
            strSql.Append("slhlk=@slhlk,");
            strSql.Append("slhlh=@slhlh,");
            strSql.Append("slhlsl=@slhlsl,");
            strSql.Append("slslg=@slslg,");
            strSql.Append("slslk=@slslk,");
            strSql.Append("slslh=@slslh,");
            strSql.Append("slslsl=@slslsl,");
            strSql.Append("mtbg=@mtbg,");
            strSql.Append("mtbk=@mtbk,");
            strSql.Append("mtbh=@mtbh,");
            strSql.Append("mtbsl=@mtbsl,");
            strSql.Append("mtbeg=@mtbeg,");
            strSql.Append("mtbek=@mtbek,");
            strSql.Append("mtbeh=@mtbeh,");
            strSql.Append("mtbesl=@mtbesl,");
            strSql.Append("tlhdg=@tlhdg,");
            strSql.Append("tlhdk=@tlhdk,");
            strSql.Append("tlhdh=@tlhdh,");
            strSql.Append("tlhdsl=@tlhdsl,");
            strSql.Append("tlhcg=@tlhcg,");
            strSql.Append("tlhck=@tlhck,");
            strSql.Append("tlhch=@tlhch,");
            strSql.Append("tlhcsl=@tlhcsl,");
            strSql.Append("tlhgg=@tlhgg,");
            strSql.Append("tlhgk=@tlhgk,");
            strSql.Append("tlhgh=@tlhgh,");
            strSql.Append("tlhgsl=@tlhgsl,");
            strSql.Append("skxg=@skxg,");
            strSql.Append("skxk=@skxk,");
            strSql.Append("skxh=@skxh,");
            strSql.Append("skxsl=@skxsl,");
            strSql.Append("blytg=@blytg,");
            strSql.Append("blytk=@blytk,");
            strSql.Append("blyth=@blyth,");
            strSql.Append("blytsl=@blytsl,");
            strSql.Append("blyteg=@blyteg,");
            strSql.Append("blytek=@blytek,");
            strSql.Append("blyteh=@blyteh,");
            strSql.Append("blytesl=@blytesl,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where jcode=@jcode");
            SqlParameter[] parameters = {
					new SqlParameter("@jname", SqlDbType.NVarChar,30),
					new SqlParameter("@jtype", SqlDbType.NVarChar,50),
					new SqlParameter("@fixmethod", SqlDbType.NVarChar,10),
					new SqlParameter("@mcomputermethod", SqlDbType.NVarChar,10),
					new SqlParameter("@dg", SqlDbType.Int,4),
					new SqlParameter("@dk", SqlDbType.Int,4),
					new SqlParameter("@dh", SqlDbType.Int,4),
					new SqlParameter("@d1sl", SqlDbType.Int,4),
					new SqlParameter("@d2sl", SqlDbType.Int,4),
					new SqlParameter("@d1k", SqlDbType.Float,8),
					new SqlParameter("@d2k", SqlDbType.Float,8),
					new SqlParameter("@d1g", SqlDbType.Float,8),
					new SqlParameter("@d2g", SqlDbType.Float,8),
					new SqlParameter("@mtg", SqlDbType.NVarChar,30),
					new SqlParameter("@mtk", SqlDbType.NVarChar,30),
					new SqlParameter("@mth", SqlDbType.NVarChar,30),
					new SqlParameter("@mtsl", SqlDbType.Int,4),
					new SqlParameter("@mtge", SqlDbType.NVarChar,30),
					new SqlParameter("@mtke",SqlDbType.NVarChar,30),
					new SqlParameter("@mthe", SqlDbType.NVarChar,30),
					new SqlParameter("@mtsle", SqlDbType.Int,4),
					new SqlParameter("@lbg", SqlDbType.NVarChar,30),
					new SqlParameter("@lbk", SqlDbType.NVarChar,30),
					new SqlParameter("@lbh", SqlDbType.NVarChar,30),
					new SqlParameter("@lbsl", SqlDbType.Int,4),
					new SqlParameter("@lbge",SqlDbType.NVarChar,30 ),
					new SqlParameter("@lbke",SqlDbType.NVarChar,30),
					new SqlParameter("@lbhe", SqlDbType.NVarChar,30),
					new SqlParameter("@lbsle", SqlDbType.Int,4),
					new SqlParameter("@stlg", SqlDbType.NVarChar,30),
					new SqlParameter("@stlk", SqlDbType.NVarChar,30),
					new SqlParameter("@stlh", SqlDbType.NVarChar,30),
					new SqlParameter("@stlsl", SqlDbType.Int,4),
					new SqlParameter("@stleg", SqlDbType.NVarChar,30),
					new SqlParameter("@stlek", SqlDbType.NVarChar,30),
					new SqlParameter("@stleh", SqlDbType.NVarChar,30),
					new SqlParameter("@stlesl", SqlDbType.Int,4),
					new SqlParameter("@mtsg", SqlDbType.NVarChar,30),
					new SqlParameter("@mtsk", SqlDbType.NVarChar,30),
					new SqlParameter("@mtsh", SqlDbType.NVarChar,30),
					new SqlParameter("@mtssl", SqlDbType.Int,4),
					new SqlParameter("@ltlg", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlk", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlh", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlsl", SqlDbType.Int,4),
					new SqlParameter("@ltleg", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlek", SqlDbType.NVarChar,30),
					new SqlParameter("@ltleh", SqlDbType.NVarChar,30),
					new SqlParameter("@ltlesl", SqlDbType.Int,4),
					new SqlParameter("@lbsg", SqlDbType.NVarChar,30),
					new SqlParameter("@lbsk", SqlDbType.NVarChar,30),
					new SqlParameter("@lbsh", SqlDbType.NVarChar,30),
					new SqlParameter("@lbssl", SqlDbType.Int,4),
					new SqlParameter("@tlhg", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhk", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhh", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhsl", SqlDbType.Int,4),
					new SqlParameter("@tlh2g", SqlDbType.NVarChar,30),
					new SqlParameter("@tlh2k", SqlDbType.NVarChar,30),
					new SqlParameter("@tlh2h", SqlDbType.NVarChar,30),
					new SqlParameter("@tlh2sl", SqlDbType.Int,4),
					new SqlParameter("@dzg", SqlDbType.NVarChar,30),
					new SqlParameter("@dzk", SqlDbType.NVarChar,30),
					new SqlParameter("@dzh", SqlDbType.NVarChar,30),
					new SqlParameter("@dzsl", SqlDbType.Int,4),
					new SqlParameter("@dmxg", SqlDbType.NVarChar,30),
					new SqlParameter("@dmxk", SqlDbType.NVarChar,30),
					new SqlParameter("@dmxh", SqlDbType.NVarChar,30),
					new SqlParameter("@dmxsl", SqlDbType.Int,4),
					new SqlParameter("@mentg", SqlDbType.NVarChar,30),
					new SqlParameter("@mentk", SqlDbType.NVarChar,30),
					new SqlParameter("@menth", SqlDbType.NVarChar,30),
					new SqlParameter("@mentsl", SqlDbType.Int,4),
					new SqlParameter("@hmdxg", SqlDbType.NVarChar,30),
					new SqlParameter("@hmdxk", SqlDbType.NVarChar,30),
					new SqlParameter("@hmdxh", SqlDbType.NVarChar,30),
					new SqlParameter("@hmdxsl", SqlDbType.Int,4),
					new SqlParameter("@lmdxg", SqlDbType.NVarChar,30),
					new SqlParameter("@lmdxk", SqlDbType.NVarChar,30),
					new SqlParameter("@lmdxh", SqlDbType.NVarChar,30),
					new SqlParameter("@lmdxsl", SqlDbType.Int,4),
					new SqlParameter("@slg", SqlDbType.NVarChar,30),
					new SqlParameter("@slk", SqlDbType.NVarChar,30),
					new SqlParameter("@slh", SqlDbType.NVarChar,30),
					new SqlParameter("@slsl", SqlDbType.Int,4),
					new SqlParameter("@sljs", SqlDbType.Int,4),
					new SqlParameter("@slhlg", SqlDbType.NVarChar,30),
					new SqlParameter("@slhlk", SqlDbType.NVarChar,30),
					new SqlParameter("@slhlh", SqlDbType.NVarChar,30),
					new SqlParameter("@slhlsl", SqlDbType.Int,4),
					new SqlParameter("@slslg", SqlDbType.NVarChar,30),
					new SqlParameter("@slslk", SqlDbType.NVarChar,30),
					new SqlParameter("@slslh", SqlDbType.NVarChar,30),
					new SqlParameter("@slslsl", SqlDbType.Int,4),
					new SqlParameter("@mtbg", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbk", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbh", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbsl", SqlDbType.Int,4),
					new SqlParameter("@mtbeg", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbek", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbeh", SqlDbType.NVarChar,30),
					new SqlParameter("@mtbesl", SqlDbType.Int,4),
					new SqlParameter("@tlhdg", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhdk", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhdh", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhdsl", SqlDbType.Int,4),
					new SqlParameter("@tlhcg", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhck", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhch", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhcsl", SqlDbType.Int,4),
					new SqlParameter("@tlhgg", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhgk", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhgh", SqlDbType.NVarChar,30),
					new SqlParameter("@tlhgsl", SqlDbType.Int,4),
					new SqlParameter("@skxg", SqlDbType.NVarChar,30),
					new SqlParameter("@skxk", SqlDbType.NVarChar,30),
					new SqlParameter("@skxh", SqlDbType.NVarChar,30),
					new SqlParameter("@skxsl", SqlDbType.Int,4),
					new SqlParameter("@blytg", SqlDbType.NVarChar,30),
					new SqlParameter("@blytk", SqlDbType.NVarChar,30),
					new SqlParameter("@blyth", SqlDbType.NVarChar,30),
					new SqlParameter("@blytsl", SqlDbType.Int,4),
					new SqlParameter("@blyteg", SqlDbType.NVarChar,30),
					new SqlParameter("@blytek", SqlDbType.NVarChar,30),
					new SqlParameter("@blyteh", SqlDbType.NVarChar,30),
					new SqlParameter("@blytesl", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@jcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.jname;
            parameters[1].Value = model.jtype;
            parameters[2].Value = model.fixmethod;
            parameters[3].Value = model.mcomputermethod;
            parameters[4].Value = model.dg;
            parameters[5].Value = model.dk;
            parameters[6].Value = model.dh;
            parameters[7].Value = model.d1sl;
            parameters[8].Value = model.d2sl;
            parameters[9].Value = model.d1k;
            parameters[10].Value = model.d2k;
            parameters[11].Value = model.d1g;
            parameters[12].Value = model.d2g;
            parameters[13].Value = model.mtg;
            parameters[14].Value = model.mtk;
            parameters[15].Value = model.mth;
            parameters[16].Value = model.mtsl;
            parameters[17].Value = model.mtge;
            parameters[18].Value = model.mtke;
            parameters[19].Value = model.mthe;
            parameters[20].Value = model.mtsle;
            parameters[21].Value = model.lbg;
            parameters[22].Value = model.lbk;
            parameters[23].Value = model.lbh;
            parameters[24].Value = model.lbsl;
            parameters[25].Value = model.lbge;
            parameters[26].Value = model.lbke;
            parameters[27].Value = model.lbhe;
            parameters[28].Value = model.lbsle;
            parameters[29].Value = model.stlg;
            parameters[30].Value = model.stlk;
            parameters[31].Value = model.stlh;
            parameters[32].Value = model.stlsl;
            parameters[33].Value = model.stleg;
            parameters[34].Value = model.stlek;
            parameters[35].Value = model.stleh;
            parameters[36].Value = model.stlesl;
            parameters[37].Value = model.mtsg;
            parameters[38].Value = model.mtsk;
            parameters[39].Value = model.mtsh;
            parameters[40].Value = model.mtssl;
            parameters[41].Value = model.ltlg;
            parameters[42].Value = model.ltlk;
            parameters[43].Value = model.ltlh;
            parameters[44].Value = model.ltlsl;
            parameters[45].Value = model.ltleg;
            parameters[46].Value = model.ltlek;
            parameters[47].Value = model.ltleh;
            parameters[48].Value = model.ltlesl;
            parameters[49].Value = model.lbsg;
            parameters[50].Value = model.lbsk;
            parameters[51].Value = model.lbsh;
            parameters[52].Value = model.lbssl;
            parameters[53].Value = model.tlhg;
            parameters[54].Value = model.tlhk;
            parameters[55].Value = model.tlhh;
            parameters[56].Value = model.tlhsl;
            parameters[57].Value = model.tlh2g;
            parameters[58].Value = model.tlh2k;
            parameters[59].Value = model.tlh2h;
            parameters[60].Value = model.tlh2sl;
            parameters[61].Value = model.dzg;
            parameters[62].Value = model.dzk;
            parameters[63].Value = model.dzh;
            parameters[64].Value = model.dzsl;
            parameters[65].Value = model.dmxg;
            parameters[66].Value = model.dmxk;
            parameters[67].Value = model.dmxh;
            parameters[68].Value = model.dmxsl;
            parameters[69].Value = model.mentg;
            parameters[70].Value = model.mentk;
            parameters[71].Value = model.menth;
            parameters[72].Value = model.mentsl;
            parameters[73].Value = model.hmdxg;
            parameters[74].Value = model.hmdxk;
            parameters[75].Value = model.hmdxh;
            parameters[76].Value = model.hmdxsl;
            parameters[77].Value = model.lmdxg;
            parameters[78].Value = model.lmdxk;
            parameters[79].Value = model.lmdxh;
            parameters[80].Value = model.lmdxsl;
            parameters[81].Value = model.slg;
            parameters[82].Value = model.slk;
            parameters[83].Value = model.slh;
            parameters[84].Value = model.slsl;
            parameters[85].Value = model.sljs;
            parameters[86].Value = model.slhlg;
            parameters[87].Value = model.slhlk;
            parameters[88].Value = model.slhlh;
            parameters[89].Value = model.slhlsl;
            parameters[90].Value = model.slslg;
            parameters[91].Value = model.slslk;
            parameters[92].Value = model.slslh;
            parameters[93].Value = model.slslsl;
            parameters[94].Value = model.mtbg;
            parameters[95].Value = model.mtbk;
            parameters[96].Value = model.mtbh;
            parameters[97].Value = model.mtbsl;
            parameters[98].Value = model.mtbeg;
            parameters[99].Value = model.mtbek;
            parameters[100].Value = model.mtbeh;
            parameters[101].Value = model.mtbesl;
            parameters[102].Value = model.tlhdg;
            parameters[103].Value = model.tlhdk;
            parameters[104].Value = model.tlhdh;
            parameters[105].Value = model.tlhdsl;
            parameters[106].Value = model.tlhcg;
            parameters[107].Value = model.tlhck;
            parameters[108].Value = model.tlhch;
            parameters[109].Value = model.tlhcsl;
            parameters[110].Value = model.tlhgg;
            parameters[111].Value = model.tlhgk;
            parameters[112].Value = model.tlhgh;
            parameters[113].Value = model.tlhgsl;
            parameters[114].Value = model.skxg;
            parameters[115].Value = model.skxk;
            parameters[116].Value = model.skxh;
            parameters[117].Value = model.skxsl;
            parameters[118].Value = model.blytg;
            parameters[119].Value = model.blytk;
            parameters[120].Value = model.blyth;
            parameters[121].Value = model.blytsl;
            parameters[122].Value = model.blyteg;
            parameters[123].Value = model.blytek;
            parameters[124].Value = model.blyteh;
            parameters[125].Value = model.blytesl;
            parameters[126].Value = model.maker;
            parameters[127].Value = model.cdate;
            parameters[128].Value = model.jcode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
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
            strSql.AppendFormat("delete from Sys_SizeTransform where 1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  Sys_SizeTransform Query (string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Sys_SizeTransform ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_SizeTransform r = new  Sys_SizeTransform();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
        public  Sys_SizeTransform DataRowToModel(DataRow row)
        {
             Sys_SizeTransform model = new  Sys_SizeTransform();
            if (row != null)
            {

                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["jname"] != null)
                {
                    model.jname = row["jname"].ToString();
                }
                if (row["jcode"] != null)
                {
                    model.jcode = row["jcode"].ToString();
                }
                if (row["jtype"] != null)
                {
                    model.jtype = row["jtype"].ToString();
                }
                if (row["fixmethod"] != null)
                {
                    model.fixmethod = row["fixmethod"].ToString();
                }
                if (row["mcomputermethod"] != null)
                {
                    model.mcomputermethod = row["mcomputermethod"].ToString();
                }
                if (row["dg"] != null && row["dg"].ToString() != "")
                {
                    model.dg = int.Parse(row["dg"].ToString());
                }
                if (row["dk"] != null && row["dk"].ToString() != "")
                {
                    model.dk = int.Parse(row["dk"].ToString());
                }
                if (row["dh"] != null && row["dh"].ToString() != "")
                {
                    model.dh = int.Parse(row["dh"].ToString());
                }
                if (row["d1sl"] != null && row["d1sl"].ToString() != "")
                {
                    model.d1sl = int.Parse(row["d1sl"].ToString());
                }
                if (row["d2sl"] != null && row["d2sl"].ToString() != "")
                {
                    model.d2sl = int.Parse(row["d2sl"].ToString());
                }
                if (row["d1k"] != null && row["d1k"].ToString() != "")
                {
                    model.d1k = decimal.Parse(row["d1k"].ToString());
                }
                if (row["d2k"] != null && row["d2k"].ToString() != "")
                {
                    model.d2k = decimal.Parse(row["d2k"].ToString());
                }
                if (row["d1g"] != null && row["d1g"].ToString() != "")
                {
                    model.d1g = decimal.Parse(row["d1g"].ToString());
                }
                if (row["d2g"] != null && row["d2g"].ToString() != "")
                {
                    model.d2g = decimal.Parse(row["d2g"].ToString());
                }
                if (row["mtg"] != null && row["mtg"].ToString() != "")
                {
                    model.mtg = row["mtg"].ToString();
                }
                if (row["mtk"] != null && row["mtk"].ToString() != "")
                {
                    model.mtk = row["mtk"].ToString();
                }
                if (row["mth"] != null && row["mth"].ToString() != "")
                {
                    model.mth = row["mth"].ToString();
                }
                if (row["mtsl"] != null && row["mtsl"].ToString() != "")
                {
                    model.mtsl = int.Parse(row["mtsl"].ToString());
                }
                if (row["mtge"] != null && row["mtge"].ToString() != "")
                {
                    model.mtge = row["mtge"].ToString();
                }
                if (row["mtke"] != null && row["mtke"].ToString() != "")
                {
                    model.mtke = row["mtke"].ToString() ;
                }
                if (row["mthe"] != null && row["mthe"].ToString() != "")
                {
                    model.mthe = row["mthe"].ToString();
                }
                if (row["mtsle"] != null && row["mtsle"].ToString() != "")
                {
                    model.mtsle = int.Parse(row["mtsle"].ToString());
                }
                if (row["lbg"] != null && row["lbg"].ToString() != "")
                {
                    model.lbg =  row["lbg"].ToString() ;
                }
                if (row["lbk"] != null && row["lbk"].ToString() != "")
                {
                    model.lbk = row["lbk"].ToString() ;
                }
                if (row["lbh"] != null && row["lbh"].ToString() != "")
                {
                    model.lbh = row["lbh"].ToString();
                }
                if (row["lbsl"] != null && row["lbsl"].ToString() != "")
                {
                    model.lbsl = int.Parse(row["lbsl"].ToString());
                }
                if (row["lbge"] != null && row["lbge"].ToString() != "")
                {
                    model.lbge = row["lbge"].ToString();
                }
                if (row["lbke"] != null && row["lbke"].ToString() != "")
                {
                    model.lbke =  row["lbke"].ToString()  ;
                }
                if (row["lbhe"] != null && row["lbhe"].ToString() != "")
                {
                    model.lbhe = row["lbhe"].ToString();
                }
                if (row["lbsle"] != null && row["lbsle"].ToString() != "")
                {
                    model.lbsle = int.Parse(row["lbsle"].ToString());
                }
                if (row["stlg"] != null && row["stlg"].ToString() != "")
                {
                    model.stlg = row["stlg"].ToString();
                }
                if (row["stlk"] != null && row["stlk"].ToString() != "")
                {
                    model.stlk =  row["stlk"].ToString();
                }
                if (row["stlh"] != null && row["stlh"].ToString() != "")
                {
                    model.stlh =  row["stlh"].ToString();
                }
                if (row["stlsl"] != null && row["stlsl"].ToString() != "")
                {
                    model.stlsl = int.Parse(row["stlsl"].ToString());
                }
                if (row["stleg"] != null)
                {
                    model.stleg = row["stleg"].ToString();
                }
                if (row["stlek"] != null && row["stlek"].ToString() != "")
                {
                    model.stlek = row["stlek"].ToString();
                }
                if (row["stleh"] != null && row["stleh"].ToString() != "")
                {
                    model.stleh =  row["stleh"].ToString();
                }
                if (row["stlesl"] != null && row["stlesl"].ToString() != "")
                {
                    model.stlesl = int.Parse(row["stlesl"].ToString());
                }
                if (row["mtsg"] != null && row["mtsg"].ToString() != "")
                {
                    model.mtsg =  row["mtsg"].ToString();
                }
                if (row["mtsk"] != null && row["mtsk"].ToString() != "")
                {
                    model.mtsk =  row["mtsk"].ToString() ;
                }
                if (row["mtsh"] != null && row["mtsh"].ToString() != "")
                {
                    model.mtsh =  row["mtsh"].ToString();
                }
                if (row["mtssl"] != null && row["mtssl"].ToString() != "")
                {
                    model.mtssl = int.Parse(row["mtssl"].ToString());
                }
                if (row["ltlg"] != null && row["ltlg"].ToString() != "")
                {
                    model.ltlg =  row["ltlg"].ToString() ;
                }
                if (row["ltlk"] != null && row["ltlk"].ToString() != "")
                {
                    model.ltlk =  row["ltlk"].ToString();
                }
                if (row["ltlh"] != null && row["ltlh"].ToString() != "")
                {
                    model.ltlh =  row["ltlh"].ToString();
                }
                if (row["ltlsl"] != null && row["ltlsl"].ToString() != "")
                {
                    model.ltlsl = int.Parse(row["ltlsl"].ToString());
                }
                if (row["ltleg"] != null)
                {
                    model.ltleg = row["ltleg"].ToString();
                }
                if (row["ltlek"] != null && row["ltlek"].ToString() != "")
                {
                    model.ltlek =  row["ltlek"].ToString();
                }
                if (row["ltleh"] != null && row["ltleh"].ToString() != "")
                {
                    model.ltleh =  row["ltleh"].ToString();
                }
                if (row["ltlesl"] != null && row["ltlesl"].ToString() != "")
                {
                    model.ltlesl = int.Parse(row["ltlesl"].ToString());
                }
                if (row["lbsg"] != null && row["lbsg"].ToString() != "")
                {
                    model.lbsg = row["lbsg"].ToString();
                }
                if (row["lbsk"] != null && row["lbsk"].ToString() != "")
                {
                    model.lbsk = row["lbsk"].ToString( );
                }
                if (row["lbsh"] != null && row["lbsh"].ToString() != "")
                {
                    model.lbsh = row["lbsh"].ToString();
                }
                if (row["lbssl"] != null && row["lbssl"].ToString() != "")
                {
                    model.lbssl = int.Parse(row["lbssl"].ToString());
                }
                if (row["tlhg"] != null && row["tlhg"].ToString() != "")
                {
                    model.tlhg = row["tlhg"].ToString();
                }
                if (row["tlhk"] != null && row["tlhk"].ToString() != "")
                {
                    model.tlhk =  row["tlhk"].ToString( );
                }
                if (row["tlhh"] != null && row["tlhh"].ToString() != "")
                {
                    model.tlhh =  row["tlhh"].ToString();
                }
                if (row["tlhsl"] != null && row["tlhsl"].ToString() != "")
                {
                    model.tlhsl = int.Parse(row["tlhsl"].ToString());
                }
                if (row["tlh2g"] != null && row["tlh2g"].ToString() != "")
                {
                    model.tlh2g = row["tlh2g"].ToString();
                }
                if (row["tlh2k"] != null && row["tlh2k"].ToString() != "")
                {
                    model.tlh2k =  row["tlh2k"].ToString();
                }
                if (row["tlh2h"] != null && row["tlh2h"].ToString() != "")
                {
                    model.tlh2h =  row["tlh2h"].ToString();
                }
                if (row["tlh2sl"] != null && row["tlh2sl"].ToString() != "")
                {
                    model.tlh2sl = int.Parse(row["tlh2sl"].ToString());
                }
                if (row["dzg"] != null && row["dzg"].ToString() != "")
                {
                    model.dzg =  row["dzg"].ToString();
                }
                if (row["dzk"] != null && row["dzk"].ToString() != "")
                {
                    model.dzk =  row["dzk"].ToString();
                }
                if (row["dzh"] != null && row["dzh"].ToString() != "")
                {
                    model.dzh =  row["dzh"].ToString();
                }
                if (row["dzsl"] != null && row["dzsl"].ToString() != "")
                {
                    model.dzsl = int.Parse(row["dzsl"].ToString());
                }
                if (row["dmxg"] != null && row["dmxg"].ToString() != "")
                {
                    model.dmxg =  row["dmxg"].ToString();
                }
                if (row["dmxk"] != null && row["dmxk"].ToString() != "")
                {
                    model.dmxk = row["dmxk"].ToString();
                }
                if (row["dmxh"] != null && row["dmxh"].ToString() != "")
                {
                    model.dmxh =  row["dmxh"].ToString();
                }
                if (row["dmxsl"] != null && row["dmxsl"].ToString() != "")
                {
                    model.dmxsl = int.Parse(row["dmxsl"].ToString());
                }
                if (row["mentg"] != null && row["mentg"].ToString() != "")
                {
                    model.mentg =  row["mentg"].ToString();
                }
                if (row["mentk"] != null && row["mentk"].ToString() != "")
                {
                    model.mentk = row["mentk"].ToString();
                }
                if (row["menth"] != null && row["menth"].ToString() != "")
                {
                    model.menth =  row["menth"].ToString();
                }
                if (row["mentsl"] != null && row["mentsl"].ToString() != "")
                {
                    model.mentsl = int.Parse(row["mentsl"].ToString());
                }
                if (row["hmdxg"] != null && row["hmdxg"].ToString() != "")
                {
                    model.hmdxg = row["hmdxg"].ToString();
                }
                if (row["hmdxk"] != null && row["hmdxk"].ToString() != "")
                {
                    model.hmdxk =  row["hmdxk"].ToString();
                }
                if (row["hmdxh"] != null && row["hmdxh"].ToString() != "")
                {
                    model.hmdxh =  row["hmdxh"].ToString();
                }
                if (row["hmdxsl"] != null && row["hmdxsl"].ToString() != "")
                {
                    model.hmdxsl = int.Parse(row["hmdxsl"].ToString());
                }
                if (row["lmdxg"] != null && row["lmdxg"].ToString() != "")
                {
                    model.lmdxg =  row["lmdxg"].ToString();
                }
                if (row["lmdxk"] != null && row["lmdxk"].ToString() != "")
                {
                    model.lmdxk =  row["lmdxk"].ToString();
                }
                if (row["lmdxh"] != null && row["lmdxh"].ToString() != "")
                {
                    model.lmdxh =  row["lmdxh"].ToString();
                }
                if (row["lmdxsl"] != null && row["lmdxsl"].ToString() != "")
                {
                    model.lmdxsl = int.Parse(row["lmdxsl"].ToString());
                }
                if (row["slg"] != null && row["slg"].ToString() != "")
                {
                    model.slg = row["slg"].ToString();
                }
                if (row["slk"] != null && row["slk"].ToString() != "")
                {
                    model.slk = row["slk"].ToString();
                }
                if (row["slh"] != null && row["slh"].ToString() != "")
                {
                    model.slh = row["slh"].ToString();
                }
                if (row["slsl"] != null && row["slsl"].ToString() != "")
                {
                    model.slsl = int.Parse(row["slsl"].ToString());
                }
                if (row["sljs"] != null && row["sljs"].ToString() != "")
                {
                    model.sljs = int.Parse(row["sljs"].ToString());
                }
                if (row["slhlg"] != null && row["slhlg"].ToString() != "")
                {
                    model.slhlg = row["slhlg"].ToString();
                }
                if (row["slhlk"] != null && row["slhlk"].ToString() != "")
                {
                    model.slhlk =  row["slhlk"].ToString() ;
                }
                if (row["slhlh"] != null && row["slhlh"].ToString() != "")
                {
                    model.slhlh = row["slhlh"].ToString();
                }
                if (row["slhlsl"] != null && row["slhlsl"].ToString() != "")
                {
                    model.slhlsl = int.Parse(row["slhlsl"].ToString());
                }
                if (row["slslg"] != null && row["slslg"].ToString() != "")
                {
                    model.slslg = row["slslg"].ToString();
                }
                if (row["slslk"] != null && row["slslk"].ToString() != "")
                {
                    model.slslk =  row["slslk"].ToString() ;
                }
                if (row["slslh"] != null && row["slslh"].ToString() != "")
                {
                    model.slslh =  row["slslh"].ToString();
                }
                if (row["slslsl"] != null && row["slslsl"].ToString() != "")
                {
                    model.slslsl = int.Parse(row["slslsl"].ToString());
                }
                if (row["mtbg"] != null)
                {
                    model.mtbg = row["mtbg"].ToString();
                }
                if (row["mtbk"] != null && row["mtbk"].ToString() != "")
                {
                    model.mtbk =  row["mtbk"].ToString();
                }
                if (row["mtbh"] != null && row["mtbh"].ToString() != "")
                {
                    model.mtbh =  row["mtbh"].ToString();
                }
                if (row["mtbsl"] != null && row["mtbsl"].ToString() != "")
                {
                    model.mtbsl = int.Parse(row["mtbsl"].ToString());
                }
                if (row["mtbeg"] != null)
                {
                    model.mtbeg = row["mtbeg"].ToString();
                }
                if (row["mtbek"] != null && row["mtbek"].ToString() != "")
                {
                    model.mtbek = row["mtbek"].ToString();
                }
                if (row["mtbeh"] != null && row["mtbeh"].ToString() != "")
                {
                    model.mtbeh =  row["mtbeh"].ToString();
                }
                if (row["mtbesl"] != null && row["mtbesl"].ToString() != "")
                {
                    model.mtbesl = int.Parse(row["mtbesl"].ToString());
                }
                if (row["tlhdg"] != null && row["tlhdg"].ToString() != "")
                {
                    model.tlhdg =  row["tlhdg"].ToString();
                }
                if (row["tlhdk"] != null && row["tlhdk"].ToString() != "")
                {
                    model.tlhdk =  row["tlhdk"].ToString();
                }
                if (row["tlhdh"] != null && row["tlhdh"].ToString() != "")
                {
                    model.tlhdh = row["tlhdh"].ToString();
                }
                if (row["tlhdsl"] != null && row["tlhdsl"].ToString() != "")
                {
                    model.tlhdsl = int.Parse(row["tlhdsl"].ToString());
                }
                if (row["tlhcg"] != null && row["tlhcg"].ToString() != "")
                {
                    model.tlhcg =  row["tlhcg"].ToString();
                }
                if (row["tlhck"] != null && row["tlhck"].ToString() != "")
                {
                    model.tlhck =  row["tlhck"].ToString();
                }
                if (row["tlhch"] != null && row["tlhch"].ToString() != "")
                {
                    model.tlhch =  row["tlhch"].ToString();
                }
                if (row["tlhcsl"] != null && row["tlhcsl"].ToString() != "")
                {
                    model.tlhcsl = int.Parse(row["tlhcsl"].ToString());
                }
                if (row["tlhgg"] != null && row["tlhgg"].ToString() != "")
                {
                    model.tlhgg =  row["tlhgg"].ToString();
                }
                if (row["tlhgk"] != null && row["tlhgk"].ToString() != "")
                {
                    model.tlhgk = row["tlhgk"].ToString();
                }
                if (row["tlhgh"] != null && row["tlhgh"].ToString() != "")
                {
                    model.tlhgh = row["tlhgh"].ToString();
                }
                if (row["tlhgsl"] != null && row["tlhgsl"].ToString() != "")
                {
                    model.tlhgsl = int.Parse(row["tlhgsl"].ToString());
                }
                if (row["skxg"] != null && row["skxg"].ToString() != "")
                {
                    model.skxg =  row["skxg"].ToString();
                }
                if (row["skxk"] != null && row["skxk"].ToString() != "")
                {
                    model.skxk =  row["skxk"].ToString();
                }
                if (row["skxh"] != null && row["skxh"].ToString() != "")
                {
                    model.skxh =  row["skxh"].ToString();
                }
                if (row["skxsl"] != null && row["skxsl"].ToString() != "")
                {
                    model.skxsl = int.Parse(row["skxsl"].ToString());
                }
                if (row["blytg"] != null && row["blytg"].ToString() != "")
                {
                    model.blytg =  row["blytg"].ToString();
                }
                if (row["blytk"] != null && row["blytk"].ToString() != "")
                {
                    model.blytk =  row["blytk"].ToString();
                }
                if (row["blyth"] != null && row["blyth"].ToString() != "")
                {
                    model.blyth = row["blyth"].ToString();
                }
                if (row["blytsl"] != null && row["blytsl"].ToString() != "")
                {
                    model.blytsl = int.Parse(row["blytsl"].ToString());
                }
                if (row["blyteg"] != null && row["blyteg"].ToString() != "")
                {
                    model.blyteg =  row["blyteg"].ToString();
                }
                if (row["blytek"] != null && row["blytek"].ToString() != "")
                {
                    model.blytek =  row["blytek"].ToString();
                }
                if (row["blyteh"] != null && row["blyteh"].ToString() != "")
                {
                    model.blyteh =  row["blyteh"].ToString();
                }
                if (row["blytesl"] != null && row["blytesl"].ToString() != "")
                {
                    model.blytesl = int.Parse(row["blytesl"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SizeTransform> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.AppendFormat(" FROM Sys_SizeTransform where 1=1 {0}",where);
            List<Sys_SizeTransform> r = new List<Sys_SizeTransform>();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
        public List<Sys_SizeTransform> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        {
            List<Sys_SizeTransform> r = new List<Sys_SizeTransform>();
            DataTable dt = new Fy().BasePage("Sys_SizeTransform", "*", sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,jcode)),0) as n from Sys_SizeTransform ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetProductionJc(string pcode, string jcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventorySizeTransform where pcode like '{0}%';", pcode);
            sql.AppendFormat(" insert into Sys_RInventorySizeTransform (pcode,jcode) values ('{0}','{1}') ;", pcode,jcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetProductionJc(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventorySizeTransform where pcode like '{0}%';", pcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetProductionJc(string pcode)
        {
            string r = "";
            r = LoodQuery(pcode);
            return r;
        }
        private string LoodQuery(string pcode)
        {
            string p = "";
            if (pcode.Length > 8)
            {

                string sql = "select jcode from Sys_RInventorySizeTransform where pcode='" + pcode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(pcode.Substring(0, pcode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
        #endregion  ExtensionMethod
    }
}
