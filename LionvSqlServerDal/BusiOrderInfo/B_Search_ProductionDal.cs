using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_Search_ProductionDal : IB_Search_ProductionDal
    {
        #region  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  B_Search_Production Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 pid,oid,sid,iname,icode,iunit,mname,place,fix,direction,width,height,deep,fwidth,fheight,fdeep,fnum,fmoney,fchange,fcmoney,swidth,sheight,sdeep,snum,smoney,schange,scmoney,tname,tcode,tmname,tunit,twidth,theight,tdeep,tnum,tmoney,mtchange,mtcmoney,ltlw,ltlh,ltld,ltlsl,stlw,stlh,stld,stlsl,mtw,mth,mtd,mtsl,lbw,lbh,lbd,lbsl,blname,blcode,blnum,blmoney,P_Produce_Glasspmoney,sjname,sjnum,sjcode,sjmname,remark,pmoney,pjc,hyname,fsnum,ffwsmoney,ffwchange,fxsmoney,fxschange,fghmoeny,fghchange,dmfghmoney,dmfghchange,ssnum,sfwmoney,sfwchange,sxsmoney,sxschange,sghmoney,sghchange,dmsghmoney,dmsghchange,mtsnum,mtsmoney,mtschange,mtxsmoney,mtxschange,mtghmoney,mtghchange,dmmtghmoney,dmmtghchange from B_Search_Production ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_Search_Production r = new B_Search_Production();
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
        public  B_Search_Production DataRowToModel(DataRow row)
        {
             B_Search_Production model = new B_Search_Production();
            if (row != null)
            {
                if (row["pid"] != null && row["pid"].ToString() != "")
                {
                    model.pid = int.Parse(row["pid"].ToString());
                }
                if (row["oid"] != null && row["oid"].ToString() != "")
                {
                    model.oid = int.Parse(row["oid"].ToString());
                }
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid =  row["sid"].ToString() ;
                }
                if (row["iname"] != null)
                {
                    model.iname = row["iname"].ToString();
                }
                if (row["icode"] != null)
                {
                    model.icode = row["icode"].ToString();
                }
                if (row["iunit"] != null)
                {
                    model.iunit = row["iunit"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["place"] != null)
                {
                    model.place = row["place"].ToString();
                }
                if (row["fix"] != null)
                {
                    model.fix = row["fix"].ToString();
                }
                if (row["direction"] != null)
                {
                    model.direction = row["direction"].ToString();
                }
                if (row["width"] != null && row["width"].ToString() != "")
                {
                    model.width = int.Parse(row["width"].ToString());
                }
                if (row["height"] != null && row["height"].ToString() != "")
                {
                    model.height = int.Parse(row["height"].ToString());
                }
                if (row["deep"] != null && row["deep"].ToString() != "")
                {
                    model.deep = int.Parse(row["deep"].ToString());
                }
                if (row["fwidth"] != null && row["fwidth"].ToString() != "")
                {
                    model.fwidth = int.Parse(row["fwidth"].ToString());
                }
                if (row["fheight"] != null && row["fheight"].ToString() != "")
                {
                    model.fheight = int.Parse(row["fheight"].ToString());
                }
                if (row["fdeep"] != null && row["fdeep"].ToString() != "")
                {
                    model.fdeep = int.Parse(row["fdeep"].ToString());
                }
                if (row["fnum"] != null && row["fnum"].ToString() != "")
                {
                    model.fnum = int.Parse(row["fnum"].ToString());
                }
                if (row["fmoney"] != null && row["fmoney"].ToString() != "")
                {
                    model.fmoney = decimal.Parse(row["fmoney"].ToString());
                }
                if (row["fchange"] != null && row["fchange"].ToString() != "")
                {
                    model.fchange = int.Parse(row["fchange"].ToString());
                }
                if (row["fcmoney"] != null && row["fcmoney"].ToString() != "")
                {
                    model.fcmoney = decimal.Parse(row["fcmoney"].ToString());
                }
                if (row["swidth"] != null && row["swidth"].ToString() != "")
                {
                    model.swidth = int.Parse(row["swidth"].ToString());
                }
                if (row["sheight"] != null && row["sheight"].ToString() != "")
                {
                    model.sheight = int.Parse(row["sheight"].ToString());
                }
                if (row["sdeep"] != null && row["sdeep"].ToString() != "")
                {
                    model.sdeep = int.Parse(row["sdeep"].ToString());
                }
                if (row["snum"] != null && row["snum"].ToString() != "")
                {
                    model.snum = int.Parse(row["snum"].ToString());
                }
                if (row["smoney"] != null && row["smoney"].ToString() != "")
                {
                    model.smoney = decimal.Parse(row["smoney"].ToString());
                }
                if (row["schange"] != null && row["schange"].ToString() != "")
                {
                    model.schange = int.Parse(row["schange"].ToString());
                }
                if (row["scmoney"] != null && row["scmoney"].ToString() != "")
                {
                    model.scmoney = decimal.Parse(row["scmoney"].ToString());
                }
                if (row["tname"] != null)
                {
                    model.tname = row["tname"].ToString();
                }
                if (row["tcode"] != null)
                {
                    model.tcode = row["tcode"].ToString();
                }
                if (row["tmname"] != null)
                {
                    model.tmname = row["tmname"].ToString();
                }
                if (row["tunit"] != null)
                {
                    model.tunit = row["tunit"].ToString();
                }
                if (row["twidth"] != null && row["twidth"].ToString() != "")
                {
                    model.twidth = int.Parse(row["twidth"].ToString());
                }
                if (row["theight"] != null && row["theight"].ToString() != "")
                {
                    model.theight = int.Parse(row["theight"].ToString());
                }
                if (row["tdeep"] != null && row["tdeep"].ToString() != "")
                {
                    model.tdeep = int.Parse(row["tdeep"].ToString());
                }
                if (row["tnum"] != null && row["tnum"].ToString() != "")
                {
                    model.tnum = int.Parse(row["tnum"].ToString());
                }
                if (row["tmoney"] != null && row["tmoney"].ToString() != "")
                {
                    model.tmoney = decimal.Parse(row["tmoney"].ToString());
                }
                if (row["mtchange"] != null && row["mtchange"].ToString() != "")
                {
                    model.mtchange = int.Parse(row["mtchange"].ToString());
                }
                if (row["mtcmoney"] != null && row["mtcmoney"].ToString() != "")
                {
                    model.mtcmoney = decimal.Parse(row["mtcmoney"].ToString());
                }
                if (row["ltlw"] != null && row["ltlw"].ToString() != "")
                {
                    model.ltlw = int.Parse(row["ltlw"].ToString());
                }
                if (row["ltlh"] != null && row["ltlh"].ToString() != "")
                {
                    model.ltlh = int.Parse(row["ltlh"].ToString());
                }
                if (row["ltld"] != null && row["ltld"].ToString() != "")
                {
                    model.ltld = int.Parse(row["ltld"].ToString());
                }
                if (row["ltlsl"] != null && row["ltlsl"].ToString() != "")
                {
                    model.ltlsl = int.Parse(row["ltlsl"].ToString());
                }
                if (row["stlw"] != null && row["stlw"].ToString() != "")
                {
                    model.stlw = int.Parse(row["stlw"].ToString());
                }
                if (row["stlh"] != null && row["stlh"].ToString() != "")
                {
                    model.stlh = int.Parse(row["stlh"].ToString());
                }
                if (row["stld"] != null && row["stld"].ToString() != "")
                {
                    model.stld = int.Parse(row["stld"].ToString());
                }
                if (row["stlsl"] != null && row["stlsl"].ToString() != "")
                {
                    model.stlsl = int.Parse(row["stlsl"].ToString());
                }
                if (row["mtw"] != null && row["mtw"].ToString() != "")
                {
                    model.mtw = int.Parse(row["mtw"].ToString());
                }
                if (row["mth"] != null && row["mth"].ToString() != "")
                {
                    model.mth = int.Parse(row["mth"].ToString());
                }
                if (row["mtd"] != null && row["mtd"].ToString() != "")
                {
                    model.mtd = int.Parse(row["mtd"].ToString());
                }
                if (row["mtsl"] != null && row["mtsl"].ToString() != "")
                {
                    model.mtsl = int.Parse(row["mtsl"].ToString());
                }
                if (row["lbw"] != null && row["lbw"].ToString() != "")
                {
                    model.lbw = int.Parse(row["lbw"].ToString());
                }
                if (row["lbh"] != null && row["lbh"].ToString() != "")
                {
                    model.lbh = int.Parse(row["lbh"].ToString());
                }
                if (row["lbd"] != null && row["lbd"].ToString() != "")
                {
                    model.lbd = int.Parse(row["lbd"].ToString());
                }
                if (row["lbsl"] != null && row["lbsl"].ToString() != "")
                {
                    model.lbsl = int.Parse(row["lbsl"].ToString());
                }
                if (row["blname"] != null)
                {
                    model.blname = row["blname"].ToString();
                }
                if (row["blcode"] != null)
                {
                    model.blcode = row["blcode"].ToString();
                }
                if (row["blnum"] != null && row["blnum"].ToString() != "")
                {
                    model.blnum = int.Parse(row["blnum"].ToString());
                }
                if (row["blmoney"] != null && row["blmoney"].ToString() != "")
                {
                    model.blmoney = decimal.Parse(row["blmoney"].ToString());
                }
                if (row["P_Produce_Glasspmoney"] != null && row["P_Produce_Glasspmoney"].ToString() != "")
                {
                    model.glasspmoney = decimal.Parse(row["P_Produce_Glasspmoney"].ToString());
                }
                if (row["sjname"] != null)
                {
                    model.sjname = row["sjname"].ToString();
                }
                if (row["sjnum"] != null && row["sjnum"].ToString() != "")
                {
                    model.sjnum = int.Parse(row["sjnum"].ToString());
                }
                if (row["sjcode"] != null)
                {
                    model.sjcode = row["sjcode"].ToString();
                }
                if (row["sjmname"] != null)
                {
                    model.sjmname = row["sjmname"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["pmoney"] != null && row["pmoney"].ToString() != "")
                {
                    model.pmoney = decimal.Parse(row["pmoney"].ToString());
                }
                if (row["pjc"] != null && row["pjc"].ToString() != "")
                {
                    model.pjc = int.Parse(row["pjc"].ToString());
                }
                if (row["hyname"] != null)
                {
                    model.hyname = row["hyname"].ToString();
                }
                if (row["fsnum"] != null && row["fsnum"].ToString() != "")
                {
                    model.fsnum = int.Parse(row["fsnum"].ToString());
                }
                if (row["ffwsmoney"] != null && row["ffwsmoney"].ToString() != "")
                {
                    model.ffwsmoney = decimal.Parse(row["ffwsmoney"].ToString());
                }
                if (row["ffwchange"] != null && row["ffwchange"].ToString() != "")
                {
                    model.ffwchange = int.Parse(row["ffwchange"].ToString());
                }
                if (row["fxsmoney"] != null && row["fxsmoney"].ToString() != "")
                {
                    model.fxsmoney = decimal.Parse(row["fxsmoney"].ToString());
                }
                if (row["fxschange"] != null && row["fxschange"].ToString() != "")
                {
                    model.fxschange = int.Parse(row["fxschange"].ToString());
                }
                if (row["fghmoeny"] != null && row["fghmoeny"].ToString() != "")
                {
                    model.fghmoeny = decimal.Parse(row["fghmoeny"].ToString());
                }
                if (row["fghchange"] != null && row["fghchange"].ToString() != "")
                {
                    model.fghchange = int.Parse(row["fghchange"].ToString());
                }
                if (row["dmfghmoney"] != null && row["dmfghmoney"].ToString() != "")
                {
                    model.dmfghmoney = decimal.Parse(row["dmfghmoney"].ToString());
                }
                if (row["dmfghchange"] != null && row["dmfghchange"].ToString() != "")
                {
                    model.dmfghchange = int.Parse(row["dmfghchange"].ToString());
                }
                if (row["ssnum"] != null && row["ssnum"].ToString() != "")
                {
                    model.ssnum = int.Parse(row["ssnum"].ToString());
                }
                if (row["sfwmoney"] != null && row["sfwmoney"].ToString() != "")
                {
                    model.sfwmoney = decimal.Parse(row["sfwmoney"].ToString());
                }
                if (row["sfwchange"] != null && row["sfwchange"].ToString() != "")
                {
                    model.sfwchange = int.Parse(row["sfwchange"].ToString());
                }
                if (row["sxsmoney"] != null && row["sxsmoney"].ToString() != "")
                {
                    model.sxsmoney = decimal.Parse(row["sxsmoney"].ToString());
                }
                if (row["sxschange"] != null && row["sxschange"].ToString() != "")
                {
                    model.sxschange = int.Parse(row["sxschange"].ToString());
                }
                if (row["sghmoney"] != null && row["sghmoney"].ToString() != "")
                {
                    model.sghmoney = decimal.Parse(row["sghmoney"].ToString());
                }
                if (row["sghchange"] != null && row["sghchange"].ToString() != "")
                {
                    model.sghchange = int.Parse(row["sghchange"].ToString());
                }
                if (row["dmsghmoney"] != null && row["dmsghmoney"].ToString() != "")
                {
                    model.dmsghmoney = decimal.Parse(row["dmsghmoney"].ToString());
                }
                if (row["dmsghchange"] != null && row["dmsghchange"].ToString() != "")
                {
                    model.dmsghchange = int.Parse(row["dmsghchange"].ToString());
                }
                if (row["mtsnum"] != null && row["mtsnum"].ToString() != "")
                {
                    model.mtsnum = int.Parse(row["mtsnum"].ToString());
                }
                if (row["mtsmoney"] != null && row["mtsmoney"].ToString() != "")
                {
                    model.mtsmoney = decimal.Parse(row["mtsmoney"].ToString());
                }
                if (row["mtschange"] != null && row["mtschange"].ToString() != "")
                {
                    model.mtschange = int.Parse(row["mtschange"].ToString());
                }
                if (row["mtxsmoney"] != null && row["mtxsmoney"].ToString() != "")
                {
                    model.mtxsmoney = decimal.Parse(row["mtxsmoney"].ToString());
                }
                if (row["mtxschange"] != null && row["mtxschange"].ToString() != "")
                {
                    model.mtxschange = int.Parse(row["mtxschange"].ToString());
                }
                if (row["mtghmoney"] != null && row["mtghmoney"].ToString() != "")
                {
                    model.mtghmoney = decimal.Parse(row["mtghmoney"].ToString());
                }
                if (row["mtghchange"] != null && row["mtghchange"].ToString() != "")
                {
                    model.mtghchange = int.Parse(row["mtghchange"].ToString());
                }
                if (row["dmmtghmoney"] != null && row["dmmtghmoney"].ToString() != "")
                {
                    model.dmmtghmoney = int.Parse(row["dmmtghmoney"].ToString());
                }
                if (row["dmmtghchange"] != null && row["dmmtghchange"].ToString() != "")
                {
                    model.dmmtghchange = decimal.Parse(row["dmmtghchange"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_Search_Production> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pid,oid,sid,iname,icode,iunit,mname,place,fix,direction,width,height,deep,fwidth,fheight,fdeep,fnum,fmoney,fchange,fcmoney,swidth,sheight,sdeep,snum,smoney,schange,scmoney,tname,tcode,tmname,tunit,twidth,theight,tdeep,tnum,tmoney,mtchange,mtcmoney,ltlw,ltlh,ltld,ltlsl,stlw,stlh,stld,stlsl,mtw,mth,mtd,mtsl,lbw,lbh,lbd,lbsl,blname,blcode,blnum,blmoney,P_Produce_Glasspmoney,sjname,sjnum,sjcode,sjmname,remark,pmoney,pjc,hyname,fsnum,ffwsmoney,ffwchange,fxsmoney,fxschange,fghmoeny,fghchange,dmfghmoney,dmfghchange,ssnum,sfwmoney,sfwchange,sxsmoney,sxschange,sghmoney,sghchange,dmsghmoney,dmsghchange,mtsnum,mtsmoney,mtschange,mtxsmoney,mtxschange,mtghmoney,mtghchange,dmmtghmoney,dmmtghchange ");
            strSql.Append(" FROM B_Search_Production ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_Search_Production> r = new List<B_Search_Production>();
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

        #endregion  ExtensionMethod
    }
}
