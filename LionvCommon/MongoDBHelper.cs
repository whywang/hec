using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MongoDB.Driver;

namespace LionvCommon
{
   public class MongoDBHelper
    {
            public static readonly string ConnStr = ConfigurationManager.ConnectionStrings["Mongoconn"].ConnectionString;
            public static MongoCollection GetMgConn(string Vproductions)
            {
                MongoServer mongodb = MongoServer.Create(InitDb().dbconnstr); // 连接数据库
                MongoDatabase mongoDataBase = mongodb.GetDatabase(InitDb().dbname); // 选择数据库名
                MongoCollection mongoCollection = mongoDataBase.GetCollection(Vproductions); // 选择集合，相当于表
                mongodb.Connect();
                return mongoCollection;
            }

            private static MgOptions InitDb()
            {
                MgOptions r = new MgOptions();
                int i = ConnStr.LastIndexOf("/");
                r.dbconnstr = ConnStr.Substring(0, i);
                r.dbname = ConnStr.Substring(i + 1, ConnStr.Length - i - 1);
                return r;
            }
    }

    public class MgOptions
    {
        private string _dbconnstr = "";

        public string dbconnstr
        {
            get { return _dbconnstr; }
            set { _dbconnstr = value; }
        }

        private string _dbname = "";

        public string dbname
        {
            get { return _dbname; }
            set { _dbname = value; }
        }
    }
}
