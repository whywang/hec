using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.BusiCommon
{
   public class CB_OrderStateDal : ICB_OrderStateDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CB_OrderState");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
      
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_OrderState model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_OrderState(");
            strSql.Append("sid,ichange,imodify,iadd,iover,istop,ifast,imoney,ifactorydeliver,istoreget,ipackage,istoredeliver,icityget,idistribution,ifixed,imeasure)");
            strSql.Append(" values (");
            strSql.Append("@sid,@ichange,@imodify,@iadd,@iover,@istop,@ifast,@imoney,@ifactorydeliver,@istoreget,@ipackage,@istoredeliver,@icityget,@idistribution,@ifixed,@imeasure)");
  
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@ichange", SqlDbType.Int,4),
					new SqlParameter("@imodify", SqlDbType.Int,4),
					new SqlParameter("@iadd", SqlDbType.Int,4),
					new SqlParameter("@iover", SqlDbType.Int,4),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@ifast", SqlDbType.Int,4),
					new SqlParameter("@imoney", SqlDbType.Int,4),
					new SqlParameter("@ifactorydeliver", SqlDbType.Int,4),
					new SqlParameter("@istoreget", SqlDbType.Int,4),
					new SqlParameter("@ipackage", SqlDbType.Int,4),
					new SqlParameter("@istoredeliver", SqlDbType.Int,4),
					new SqlParameter("@icityget", SqlDbType.Int,4),
					new SqlParameter("@idistribution", SqlDbType.Int,4),
					new SqlParameter("@ifixed", SqlDbType.Int,4),
					new SqlParameter("@imeasure", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.ichange;
            parameters[2].Value = model.imodify;
            parameters[3].Value = model.iadd;
            parameters[4].Value = model.iover;
            parameters[5].Value = model.istop;
            parameters[6].Value = model.ifast;
            parameters[7].Value = model.imoney;
            parameters[8].Value = model.ifactorydeliver;
            parameters[9].Value = model.istoreget;
            parameters[10].Value = model.ipackage;
            parameters[11].Value = model.istoredeliver;
            parameters[12].Value = model.icityget;
            parameters[13].Value = model.idistribution;
            parameters[14].Value = model.ifixed;
            parameters[15].Value = model.imeasure;
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
        public bool Update( CB_OrderState model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_OrderState set ");
            strSql.Append("ichange=@ichange,");
            strSql.Append("imodify=@imodify,");
            strSql.Append("iadd=@iadd,");
            strSql.Append("iover=@iover,");
            strSql.Append("istop=@istop,");
            strSql.Append("ifast=@ifast,");
            strSql.Append("imoney=@imoney,");
            strSql.Append("ifactorydeliver=@ifactorydeliver,");
            strSql.Append("istoreget=@istoreget,");
            strSql.Append("ipackage=@ipackage,");
            strSql.Append("istoredeliver=@istoredeliver,");
            strSql.Append("icityget=@icityget,");
            strSql.Append("idistribution=@idistribution,");
            strSql.Append("ifixed=@ifixed");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ichange", SqlDbType.Int,4),
					new SqlParameter("@imodify", SqlDbType.Int,4),
					new SqlParameter("@iadd", SqlDbType.Int,4),
					new SqlParameter("@iover", SqlDbType.Int,4),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@ifast", SqlDbType.Int,4),
					new SqlParameter("@imoney", SqlDbType.Int,4),
					new SqlParameter("@ifactorydeliver", SqlDbType.Int,4),
					new SqlParameter("@istoreget", SqlDbType.Int,4),
					new SqlParameter("@ipackage", SqlDbType.Int,4),
					new SqlParameter("@istoredeliver", SqlDbType.Int,4),
					new SqlParameter("@icityget", SqlDbType.Int,4),
					new SqlParameter("@idistribution", SqlDbType.Int,4),
					new SqlParameter("@ifixed", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ichange;
            parameters[1].Value = model.imodify;
            parameters[2].Value = model.iadd;
            parameters[3].Value = model.iover;
            parameters[4].Value = model.istop;
            parameters[5].Value = model.ifast;
            parameters[6].Value = model.imoney;
            parameters[7].Value = model.ifactorydeliver;
            parameters[8].Value = model.istoreget;
            parameters[9].Value = model.ipackage;
            parameters[10].Value = model.istoredeliver;
            parameters[11].Value = model.icityget;
            parameters[12].Value = model.idistribution;
            parameters[13].Value = model.ifixed;
            parameters[14].Value = model.id;
            parameters[15].Value = model.sid;
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
            strSql.AppendFormat("delete from CB_OrderState where 1=1 {0}", where);
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
        public  CB_OrderState Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,ichange,imodify,iadd,iover,istop,ifast,imoney,inproduce,ifactorydeliver,istoreget,ipackage,istoredeliver,icityget,idistribution,ifixed,iwjbh,iwjfh ,isetlment,iinsap,iwjinsap,icsap,idmoney,ipdraw,inewpp ,iproduce,imeasure from CB_OrderState ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_OrderState r = new CB_OrderState();
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
        private CB_OrderState DataRowToModel(DataRow row)
        {
            CB_OrderState model = new  CB_OrderState();
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
                if (row["ichange"] != null && row["ichange"].ToString() != "")
                {
                    model.ichange = int.Parse(row["ichange"].ToString());
                }
                if (row["imodify"] != null && row["imodify"].ToString() != "")
                {
                    model.imodify = int.Parse(row["imodify"].ToString());
                }
                if (row["iadd"] != null && row["iadd"].ToString() != "")
                {
                    model.iadd = int.Parse(row["iadd"].ToString());
                }
                if (row["iover"] != null && row["iover"].ToString() != "")
                {
                    model.iover = int.Parse(row["iover"].ToString());
                }
                if (row["istop"] != null && row["istop"].ToString() != "")
                {
                    model.istop = int.Parse(row["istop"].ToString());
                }
                if (row["ifast"] != null && row["ifast"].ToString() != "")
                {
                    model.ifast = int.Parse(row["ifast"].ToString());
                }
                if (row["imoney"] != null && row["imoney"].ToString() != "")
                {
                    model.imoney = int.Parse(row["imoney"].ToString());
                }
                if (row["ifactorydeliver"] != null && row["ifactorydeliver"].ToString() != "")
                {
                    model.ifactorydeliver = int.Parse(row["ifactorydeliver"].ToString());
                }
                if (row["istoreget"] != null && row["istoreget"].ToString() != "")
                {
                    model.istoreget = int.Parse(row["istoreget"].ToString());
                }
                if (row["ipackage"] != null && row["ipackage"].ToString() != "")
                {
                    model.ipackage = int.Parse(row["ipackage"].ToString());
                }
                if (row["istoredeliver"] != null && row["istoredeliver"].ToString() != "")
                {
                    model.istoredeliver = int.Parse(row["istoredeliver"].ToString());
                }
                if (row["icityget"] != null && row["icityget"].ToString() != "")
                {
                    model.icityget = int.Parse(row["icityget"].ToString());
                }
                if (row["idistribution"] != null && row["idistribution"].ToString() != "")
                {
                    model.idistribution = int.Parse(row["idistribution"].ToString());
                }
                if (row["ifixed"] != null && row["ifixed"].ToString() != "")
                {
                    model.ifixed = int.Parse(row["ifixed"].ToString());
                }
                if (row["iwjbh"] != null && row["iwjbh"].ToString() != "")
                {
                    model.iwjbh = int.Parse(row["iwjbh"].ToString());
                }
                if (row["iwjfh"] != null && row["iwjfh"].ToString() != "")
                {
                    model.iwjfh = int.Parse(row["iwjfh"].ToString());
                }
                if (row["isetlment"] != null && row["isetlment"].ToString() != "")
                {
                    model.isetlment = int.Parse(row["isetlment"].ToString());
                }
                if (row["iinsap"] != null && row["iinsap"].ToString() != "")
                {
                    model.iinsap = int.Parse(row["iinsap"].ToString());
                }
                if (row["iwjinsap"] != null && row["iwjinsap"].ToString() != "")
                {
                    model.iwjinsap = int.Parse(row["iwjinsap"].ToString());
                }
                if (row["icsap"] != null && row["icsap"].ToString() != "")
                {
                    model.icsap = int.Parse(row["icsap"].ToString());
                }
                if (row["idmoney"] != null && row["idmoney"].ToString() != "")
                {
                    model.idmoney = int.Parse(row["idmoney"].ToString());
                }
                if (row["inewpp"] != null && row["inewpp"].ToString() != "")
                {
                    model.inewpp = int.Parse(row["inewpp"].ToString());
                }
                if (row["ipdraw"] != null && row["ipdraw"].ToString() != "")
                {
                    model.ipdraw = int.Parse(row["ipdraw"].ToString());
                }
                if (row["iproduce"] != null && row["iproduce"].ToString() != "")
                {
                    model.iproduce = int.Parse(row["iproduce"].ToString());
                }
                if (row["inproduce"] != null && row["inproduce"].ToString() != "")
                {
                    model.inproduce = int.Parse(row["inproduce"].ToString());
                }
                if (row["imeasure"] != null && row["imeasure"].ToString() != "")
                {
                    model.imeasure = int.Parse(row["imeasure"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_OrderState> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,ichange,imodify,iadd,iover,istop,ifast,imoney,inproduce,ifactorydeliver,istoreget,ipackage,istoredeliver,icityget,idistribution,ifixed ,iwjbh,iwjfh,isetlment,iinsap,iwjinsap,icsap,idmoney,ipdraw,inewpp ,iproduce,imeasure");
            strSql.Append(" FROM CB_OrderState ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<CB_OrderState> r = new List<CB_OrderState>();
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
        public int UpState(string sid, string feild, int value)
        {
            int r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  CB_OrderState set {0}={1} where sid='{2}'",feild,value,sid);
            r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            return r;
            
        }
        public bool BatchUpState(string[] sidarr, string feild, int value)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < sidarr.Length; i++)
            {
                if (sidarr[i] != "")
                {
                    strSql.AppendFormat("update  CB_OrderState set {0}={1} where sid='{2}'", feild, value, sidarr[i]);
                }
            }
            if (strSql.ToString() != "")
            {
                if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
                {
                    r = true;
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
