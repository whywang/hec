using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web;

namespace LionvCommon
{
    public class ISystem
    {
        public  bool CheckDataConnection()
        {
            bool r = false;
            if (CheckBaseData() && CheckBuisData())
            {
                r = true;
            }
            else
            {
                r = false;
            }
            return r;
        }
        private  bool CheckBaseData()
        {
            bool r = false;
            SqlConnection conn = new SqlConnection(SqlHelp.ConnectionString);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                r = true;
                conn.Close();
            }
            catch
            {
                r = false;
            }
            return r;
        }
        private  bool CheckBuisData()
        {
            bool r = false;
            SqlConnection conn = new SqlConnection(SqlHelp.ConnectionStringb);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                r = true;
                conn.Close();
            }
            catch
            {
                r = false;
            }
            return r;
        }
        public  int BackUpDateBase(string btype)
        {
            string bname = "";
            string burl =System.Web.HttpContext.Current.Server.MapPath("~")+"BackUp\\";
            if (Directory.Exists(burl))
            {
            }
            else
            {
                Directory.CreateDirectory(burl);
            }
            if (btype == "1")
            {
                bname = QueryBaseDb();
                burl = burl+bname+ DateTime.Now.ToString("yyyyMMdd") + ".bak";
                if (!File.Exists(burl))
                {
                    File.Create(burl);
                }
            }
            if (btype == "2")
            {
                bname = QueryBusiDb();
                burl = burl + bname + DateTime.Now.ToString("yyyyMMdd") + ".bak";
                if (!File.Exists(burl))
                {
                    File.Create(burl);
                }
            }
            string backUpSql = string.Format("use master;backup database {0} to disk = '{1}';", bname, burl);
            return SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringm, CommandType.Text, backUpSql, null);
        }
        public string QueryBaseDb()
        {
            string r = "";
            string[] agr = SqlHelp.ConnectionString.Split(';');
            if (agr.Length > 0)
            {
                foreach (string s in agr)
                {
                    string []ags =s.Split('=');
                    if (ags[0].ToLower() == "database")
                    {
                        r = ags[1];
                    }
                }
            }
            return r;
        }
        public string QueryBusiDb()
        {
            string r = "";
            string[] agr = SqlHelp.ConnectionStringb.Split(';');
            if (agr.Length > 0)
            {
                foreach (string s in agr)
                {
                    string[] ags = s.Split('=');
                    if (ags[0].ToLower() == "database")
                    {
                        r = ags[1];
                    }
                }
            }
            return r;
        }
    }
}
