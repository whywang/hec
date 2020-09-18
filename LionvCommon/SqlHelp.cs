using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using LionvModel.SysInfo;

namespace LionvCommon
{
    public abstract class SqlHelp
    {
        //数据库连接字符串
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["sqlconnstring"].ConnectionString;
        public static readonly string ConnectionStringb = ConfigurationManager.ConnectionStrings["sqlconnstringb"].ConnectionString;
        public static readonly string ConnectionStringm = ConfigurationManager.ConnectionStrings["sqlconnstringm"].ConnectionString;
        // 用于缓存参数的HASH表(定义为private是为了只在SQLHelper内部的方法来使用它，自己加的readonly为了防止parmCache=new Hashtable())
        private static readonly Hashtable parmCache = Hashtable.Synchronized(new Hashtable());/*一个用户访问IIS就是一个线程*/
        /// <summary>
        /// 将参数集合添加到static Hashtable缓存
        /// </summary>
        /// <param name="cacheKey">添加到缓存的变量</param>
        /// <param name="cmdParms">一个将要添加到缓存的sql参数集合</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
            /*hashtable是类级的静态变量，而Cache是当前应用程序的缓存*/
        }
        /// <summary>
        /// 从static Hashtable缓存中找回参数集合
        /// </summary>
        /// <param name="cacheKey">用于找回参数的关键字</param>
        /// <returns>缓存的参数集合</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        /// <summary>
        ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(string conString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {

            SqlCommand cmd = new SqlCommand();
          //  Sys_Employee u = (Sys_Employee)HttpContext.Current.Session["LUser"];
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    Log4.WriteLog(cmdText);
                    return val;
                }
                catch (SqlException e)
                {
                    Log4.WriteErrLog(cmdText + e.ToString());
                    return 0;
                }
            }
        }
        public static int ExecuteNonQuery2(string conString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {

            SqlCommand cmd = new SqlCommand();
 
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
 
                    return val;
                }
                catch (SqlException e)
                {
                    Log4.WriteLog(cmdText + e.ToString());
                    return 0;
                }
            }
        }

        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        ///<summary>
        ///多任务字段分析
        /// </summary>
        private static void PrepareCommand2(SqlCommand cmd, SqlParameter[] cmdParams)
        {
            if (cmdParams != null)
            {
                foreach (SqlParameter parm in cmdParams)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        ///<summary>
        ///多任务insert update执行方法
        /// </summary>
        /// <summary>
        public static int ExecuteNonQuery(CommandType cmdType, SqlParameter[] cmdParams, SqlParameter[] cmdParams1, string cmdText, string cmdText1)
        {
            int val = 0;
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;
                PrepareCommand2(cmd, cmdParams);
                cmd.Transaction = conn.BeginTransaction();
                val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = cmdText1;
                PrepareCommand2(cmd, cmdParams1);
                val = cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();

            }
            catch (SqlException e)
            {
                cmd.Transaction.Rollback();
                Log4.WriteErrLog(cmdText + e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        /// 用现有的数据库连接执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="conn">一个现有的数据库连接</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {

            SqlCommand cmd = new SqlCommand();
            Sys_Employee u = (Sys_Employee)HttpContext.Current.Session["LUser"];
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            try
            {
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                Log4.WriteLog(u.ename + "操作了" + cmdText);
                return val;
            }
            catch (SqlException e)
            {
                Log4.WriteErrLog(e.ToString());
                return 0;
            }
        }
        /// <summary>
        ///使用现有的SQL事务执行一个sql命令（不返回数据集）
        /// </summary>
        /// <remarks>
        ///举例:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个现有的事务</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQueryTran( string conString ,CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            int val = 0;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = cmdText;
                    PrepareCommand(cmd, cmd.Connection, trans, cmdType, cmdText, cmdParms);
                    val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    Log4.WriteLog(cmdText);
                    try
                    {
                        trans.Commit();
                    }
                    catch(Exception e)
                    {
                        trans.Rollback();
                        Log4.WriteErrLog("ExecuteNonQuery" + e.ToString());
                    }
                }
            }
       
            return val;
        }
        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <remarks>
        /// 举例:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connString);

            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                cmd.Parameters.Clear();
                return reader;
            }
            catch (Exception e)
            {
                Log4.WriteErrLog(cmdText + e.ToString());
                conn.Close();
                throw;
            }
        }
        /// <summary>
        /// 执行一个SQL命令
        /// </summary>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="cmdParms">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static DataSet ExecuteDataSet(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (SqlException e)
                {
                    Log4.WriteErrLog(cmdText + e.ToString());
                    return null;
                }
            }
        }
        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        ///例如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        ///<param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
                try
                {
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (SqlException e)
                {
                    Log4.WriteErrLog(cmdText + e.ToString());
                    return null;
                }
            }
        }
        /// <summary>
        /// 用指定的数据库连接执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">一个存在的数据库连接</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {

            SqlCommand cmd = new SqlCommand();

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
            catch (SqlException e)
            {
                Log4.WriteErrLog(cmdText + e.ToString());
                return null;
            }
        }
        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="cmdParms">执行命令所用参数的集合</param>
        /// <returns>数据集</returns>
        public static DataTable GetDataTable(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "table");
                    cmd.Parameters.Clear();
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        return dataSet.Tables[0];
                    return null;
                }
                catch (Exception e)
                {
                    Log4.WriteErrLog(cmdText + e.ToString());
                    return null;
                }
            }
        }
        public static DataTable GetDataTable2(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionStringb))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "table");
                    cmd.Parameters.Clear();
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        return dataSet.Tables[0];
                    return null;
                }
                catch (Exception e)
                {
                    Log4.WriteErrLog(cmdText + e.ToString());
                    return null;
                }
            }
        }
        public static int ExecuteNonQuery(string connString, StringBuilder strSql)
        {
            int n = -1;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                Sys_Employee u = (Sys_Employee)HttpContext.Current.Session["LUser"];
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strSql.ToString();
                try
                {
                    n = cmd.ExecuteNonQuery();
                    Log4.WriteLog(u.ename + "操作了" +  strSql.ToString());
                }

                catch (SqlException e)
                {
                    Log4.WriteErrLog(strSql + e.ToString());

                }
            }

            return n;
        }
        ///处理多条更新插入事务
        public static int ExecuteNonQuery(string conString, CommandType cmdType, List<SqlPara> sp)
        {
            int n = -1;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                Sys_Employee u = (Sys_Employee)HttpContext.Current.Session["LUser"];
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    try
                    {
                        foreach (SqlPara s in sp)
                        {

                            cmd.CommandText = s.SqlText;
                            if (s.CmdParms != null)
                            {
                                foreach (SqlParameter parm in s.CmdParms)
                                    cmd.Parameters.Add(parm);
                            }
                            n = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            Log4.WriteLog(u.ename + "操作了" + s.SqlText);
                        }
                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        Log4.WriteErrLog("ExecuteNonQuery" + e.ToString());
                        //throw new Exception(e.Message);

                    }
                }

            }
            return n;
        }
        ///处理多条更新插入事务
        public static int ExecuteNonQuery(string conString, CommandType cmdType, string sql)
        {
            int n = -1;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                Sys_Employee u = (Sys_Employee)HttpContext.Current.Session["LUser"];
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    try
                    {
                        cmd.CommandText = sql;
                        n = cmd.ExecuteNonQuery();
                        trans.Commit();
                        Log4.WriteLog(u.ename + "操作了" + sql);
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        Log4.WriteErrLog(sql + e.ToString());
                        //throw new Exception(e.Message);

                    }
                }

            }
            return n;
        }
        public static void DataTableToServer(DataTable dt, string tablename)
        {
            try
            {
                SqlBulkCopy sbc = new SqlBulkCopy(SqlHelp.ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                sbc.DestinationTableName = tablename;
                sbc.WriteToServer(dt);
            }
            catch (Exception e)
            {
                Log4.WriteErrLog("DataTableToServer" + e.ToString());
            }
        }
        public static void DataTableToServer1(DataTable dt, string tablename)
        {
            try
            {
                SqlBulkCopy sbc = new SqlBulkCopy(SqlHelp.ConnectionStringb, SqlBulkCopyOptions.UseInternalTransaction);
                sbc.DestinationTableName = tablename;
                sbc.WriteToServer(dt);
            }
            catch (Exception e)
            {
                Log4.WriteErrLog("DataTableToServer1" + e.ToString());
            }
        }
        public static bool isExist(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
                try
                {
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return Convert.ToInt32(val)>0?true : false;
                }
                catch (SqlException e)
                {
                    Log4.WriteErrLog(cmdText + e.ToString());
                    return false;
                }
            }
        }
        public static bool Exists(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParms);
                try
                {
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return Convert.ToInt32(val) > 0 ? true : false;
                }
                catch (SqlException e)
                {
                    Log4.WriteErrLog(cmdText + e.ToString());
                    return false;
                }
            }
        }
    }
    public class SqlPara
    {
        private string sqlText;

        public string SqlText
        {
            get { return sqlText; }
            set { sqlText = value; }
        }
        private SqlParameter[] cmdParms;

        public SqlParameter[] CmdParms
        {
            get { return cmdParms; }
            set { cmdParms = value; }
        }
    }
}
