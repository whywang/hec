using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data;
using LionvCommon;
using LionvIDal.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_jlProvinceDal : ISys_jlProvinceDal
    {
        #region  BasicMethod

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
       public Sys_jlProvince Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,jcode,jname,jlevel,pcode from Sys_jlProvince ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_jlProvince r = new Sys_jlProvince();
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
		public  Sys_jlProvince DataRowToModel(DataRow row)
		{
			 Sys_jlProvince model=new  Sys_jlProvince();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["jcode"]!=null)
				{
					model.jcode=row["jcode"].ToString();
				}
				if(row["jname"]!=null)
				{
					model.jname=row["jname"].ToString();
				}
				if(row["jlevel"]!=null && row["jlevel"].ToString()!="")
				{
					model.jlevel=int.Parse(row["jlevel"].ToString());
				}
				if(row["pcode"]!=null)
				{
					model.pcode=row["pcode"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_jlProvince> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,jcode,jname,jlevel,pcode ");
            strSql.AppendFormat(" FROM Sys_jlProvince where 1=1 {0}", strWhere);
            List<Sys_jlProvince> r = new List<Sys_jlProvince>();
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

		 

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod

    }
}
