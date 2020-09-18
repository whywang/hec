using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
   public class Sys_EmployeeDptDal:ISys_EmployeeDptDal
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_EmployeeDpt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_EmployeeDpt(");
            strSql.Append("eno,eage,esex,etelephone,eaddress,eidentity,eeducation,enativeplace,eheadimage,eworkdate,eemail)");
            strSql.Append(" values (");
            strSql.Append("@eno,@eage,@esex,@etelephone,@eaddress,@eidentity,@eeducation,@enativeplace,@eheadimage,@eworkdate,@eemail)");
            SqlParameter[] parameters = {
					new SqlParameter("@eno", SqlDbType.NVarChar,50),
					new SqlParameter("@eage", SqlDbType.Int,4),
					new SqlParameter("@esex", SqlDbType.Bit,1),
					new SqlParameter("@etelephone", SqlDbType.NVarChar,20),
					new SqlParameter("@eaddress", SqlDbType.NVarChar,50),
					new SqlParameter("@eidentity", SqlDbType.NVarChar,20),
					new SqlParameter("@eeducation", SqlDbType.NVarChar,50),
					new SqlParameter("@enativeplace", SqlDbType.NVarChar,50),
					new SqlParameter("@eheadimage", SqlDbType.NVarChar,50),
					new SqlParameter("@eworkdate", SqlDbType.Date,3),
					new SqlParameter("@eemail", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.eno;
            parameters[1].Value = model.eage;
            parameters[2].Value = model.esex;
            parameters[3].Value = model.etelephone;
            parameters[4].Value = model.eaddress;
            parameters[5].Value = model.eidentity;
            parameters[6].Value = model.eeducation;
            parameters[7].Value = model.enativeplace;
            parameters[8].Value = model.eheadimage;
            parameters[9].Value = model.eworkdate;
            parameters[10].Value = model.eemail;
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
        public bool Update(Sys_EmployeeDpt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_EmployeeDpt set ");
            strSql.Append("eno=@eno,");
            strSql.Append("eage=@eage,");
            strSql.Append("esex=@esex,");
            strSql.Append("etelephone=@etelephone,");
            strSql.Append("eaddress=@eaddress,");
            strSql.Append("eidentity=@eidentity,");
            strSql.Append("eeducation=@eeducation,");
            strSql.Append("enativeplace=@enativeplace,");
            strSql.Append("eheadimage=@eheadimage,");
            strSql.Append("eworkdate=@eworkdate,");
            strSql.Append("eemail=@eemail");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@eno", SqlDbType.NVarChar,50),
					new SqlParameter("@eage", SqlDbType.Int,4),
					new SqlParameter("@esex", SqlDbType.Bit,1),
					new SqlParameter("@etelephone", SqlDbType.NVarChar,20),
					new SqlParameter("@eaddress", SqlDbType.NVarChar,50),
					new SqlParameter("@eidentity", SqlDbType.NVarChar,20),
					new SqlParameter("@eeducation", SqlDbType.NVarChar,50),
					new SqlParameter("@enativeplace", SqlDbType.NVarChar,50),
					new SqlParameter("@eheadimage", SqlDbType.NVarChar,50),
					new SqlParameter("@eworkdate", SqlDbType.Date,3),
					new SqlParameter("@eemail", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.eno;
            parameters[1].Value = model.eage;
            parameters[2].Value = model.esex;
            parameters[3].Value = model.etelephone;
            parameters[4].Value = model.eaddress;
            parameters[5].Value = model.eidentity;
            parameters[6].Value = model.eeducation;
            parameters[7].Value = model.enativeplace;
            parameters[8].Value = model.eheadimage;
            parameters[9].Value = model.eworkdate;
            parameters[10].Value = model.eemail;
            parameters[11].Value = model.id;
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_EmployeeDpt ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;
            bool r = false;

            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_EmployeeDpt Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,eno,eage,esex,etelephone,eaddress,eidentity,eeducation,enativeplace,eheadimage,eworkdate,eemail from Sys_EmployeeDpt ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_EmployeeDpt r = new  Sys_EmployeeDpt();
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
        public Sys_EmployeeDpt DataRowToModel(DataRow row)
        {
             Sys_EmployeeDpt model = new  Sys_EmployeeDpt();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["eno"] != null)
                {
                    model.eno = row["eno"].ToString();
                }
                if (row["eage"] != null && row["eage"].ToString() != "")
                {
                    model.eage = int.Parse(row["eage"].ToString());
                }
                if (row["esex"] != null && row["esex"].ToString() != "")
                {
                    if ((row["esex"].ToString() == "1") || (row["esex"].ToString().ToLower() == "true"))
                    {
                        model.esex = true;
                    }
                    else
                    {
                        model.esex = false;
                    }
                }
                if (row["etelephone"] != null)
                {
                    model.etelephone = row["etelephone"].ToString();
                }
                if (row["eaddress"] != null)
                {
                    model.eaddress = row["eaddress"].ToString();
                }
                if (row["eidentity"] != null)
                {
                    model.eidentity = row["eidentity"].ToString();
                }
                if (row["eeducation"] != null)
                {
                    model.eeducation = row["eeducation"].ToString();
                }
                if (row["enativeplace"] != null)
                {
                    model.enativeplace = row["enativeplace"].ToString();
                }
                if (row["eheadimage"] != null)
                {
                    model.eheadimage = row["eheadimage"].ToString();
                }
                if (row["eworkdate"] != null && row["eworkdate"].ToString() != "")
                {
                    model.eworkdate =  row["eworkdate"].ToString() ;
                }
                if (row["eemail"] != null)
                {
                    model.eemail = row["eemail"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_EmployeeDpt> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,eno,eage,esex,etelephone,eaddress,eidentity,eeducation,enativeplace,eheadimage,eworkdate,eemail ");
            strSql.AppendFormat(" FROM Sys_EmployeeDpt where 1=1 {0}",strWhere);
            List<Sys_EmployeeDpt> r = new List<Sys_EmployeeDpt>();
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
