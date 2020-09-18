using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AfterSearch_ProductionDal : IB_AfterSearch_ProductionDal
    {
        #region  BasicMethod


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_AfterSearch_Production Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 fid,sid,place,iname,icode,iunit,mname,direction,sjname,bjname,hyname,hight,width,deep,inum,isjc,fix,pmoney,remark from B_AfterSearch_Production ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            B_AfterSearch_Production r = new B_AfterSearch_Production();
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
        public  B_AfterSearch_Production DataRowToModel(DataRow row)
        {
            B_AfterSearch_Production model = new  B_AfterSearch_Production();
            if (row != null)
            {
                if (row["fid"] != null && row["fid"].ToString() != "")
                {
                    model.fid = int.Parse(row["fid"].ToString());
                }
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid = int.Parse(row["sid"].ToString());
                }
                if (row["place"] != null)
                {
                    model.place = row["place"].ToString();
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
                if (row["direction"] != null)
                {
                    model.direction = row["direction"].ToString();
                }
                if (row["sjname"] != null)
                {
                    model.sjname = row["sjname"].ToString();
                }
                if (row["bjname"] != null)
                {
                    model.bjname = row["bjname"].ToString();
                }
                if (row["hyname"] != null)
                {
                    model.hyname = row["hyname"].ToString();
                }
                if (row["hight"] != null && row["hight"].ToString() != "")
                {
                    model.hight = int.Parse(row["hight"].ToString());
                }
                if (row["width"] != null && row["width"].ToString() != "")
                {
                    model.width = int.Parse(row["width"].ToString());
                }
                if (row["deep"] != null && row["deep"].ToString() != "")
                {
                    model.deep = int.Parse(row["deep"].ToString());
                }
                if (row["inum"] != null && row["inum"].ToString() != "")
                {
                    model.inum = int.Parse(row["inum"].ToString());
                }
                if (row["isjc"] != null && row["isjc"].ToString() != "")
                {
                    model.isjc = int.Parse(row["isjc"].ToString());
                }
                if (row["fix"] != null)
                {
                    model.fix = row["fix"].ToString();
                }
                if (row["pmoney"] != null && row["pmoney"].ToString() != "")
                {
                    model.pmoney = decimal.Parse(row["pmoney"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_AfterSearch_Production> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fid,sid,place,iname,icode,iunit,mname,direction,sjname,bjname,hyname,hight,width,deep,inum,isjc,fix,pmoney,remark ");
            strSql.Append(" FROM B_AfterSearch_Production ");
            strSql.AppendFormat(" where 1=1 {0}",strWhere);
            List<B_AfterSearch_Production> r = new List<B_AfterSearch_Production>();
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
