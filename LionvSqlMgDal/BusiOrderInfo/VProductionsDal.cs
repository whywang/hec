using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvMgModel;
using LionvCommon;
using MongoDB.Driver;
using LionvIMgDal.BusiOrderInfo;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace LionvSqlMgDal.BusiOrderInfo
{
    public class VProductionsDal : IVProductionsDal
    {
        private MongoCollection mconn = MongoDBHelper.GetMgConn("Vproductions");
        public void Add(VProductions v)
        {
            mconn.Save(v);
        }
        public VProductions Query(string gsid, string vtype)
        {
            VProductions v = mconn.FindOneByIdAs<VProductions>(gsid + vtype);
            return v;
        }
        public void Delete(string sid, int gnum, string vtype)
        {
            IMongoQuery imq =MongoDB.Driver.Builders.Query.EQ("_id", sid + gnum.ToString() + vtype);
            mconn.Remove(imq);
        }
        public void Update(string sid, int gnum)
        {
            var query = new QueryDocument();
            BsonDocument b = new BsonDocument();
            b.Add("$gt", gnum);
            query.Add("gnum", b);
            query.Add("sid", sid);
            MongoCursor<VProductions> mm = mconn.FindAs<VProductions>(query);
            foreach (VProductions v in mm)
            {
                var updatez = new UpdateDocument();
                string json = "{ \"gnum\" :" + (v.gnum - 1).ToString() + ",\"vid\":\"" + (v.sid + v.gnum + v.vtype) + "\"}";
                BsonDocument document = BsonDocument.Parse(json);
                updatez.Set("$set", document);
                mconn.Update(MongoDB.Driver.Builders.Query.EQ("_id", v.id), updatez);
            }
        }
        public void ReSetGnum(string sid)
        {
            //string r = "";
            //QueryDocument qc = new QueryDocument();
            //qc.Add("sid", sid);
            //mconn.CreateIndex(IndexKeys<VProductions>.Ascending(x=> x.gnum));
            // var mm = mconn.Distinct("gnum", MongoDB.Driver.Builders.Query.EQ("sid",sid));
            //mm.SetSortOrder(SortBy.Ascending("gnum"));
            //foreach (int v in mm)
            //{
            //    r = r + v + ";";
            //    //var updatez = new UpdateDocument();
            //    //string json = "{ \"gnum\" :" + (v.gnum - 1).ToString() + ",\"vid\":\"" + (v.sid + v.gnum + v.vtype) + "\"}";
            //    //BsonDocument document = BsonDocument.Parse(json);
            //    //updatez.Set("$set", document);
            //    //mconn.Update(MongoDB.Driver.Builders.Query.EQ("_id", v.id), updatez);
            //}
            //return r;
        }
    }
}
