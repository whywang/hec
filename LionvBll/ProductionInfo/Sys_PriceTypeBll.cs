using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_PriceTypeBll
    {
        private readonly ISys_PriceTypeDal r = DataProductionAccess.CreateSys_PriceType();
        #region  BasicMethod
        public bool Exists(string where)
        {
            return r.Exists(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_PriceType model)
        {
            return r.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_PriceType model)
        {
            return r.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string fcode)
        {

            return r.Delete(fcode);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_PriceType Query(string where)
        {

            return r.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_PriceType> QueryList(string where)
        {
            return r.QueryList(where);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return r.CreateCode();
        }
        public int SetPrice(string ptcode, string[] pcodearr, string plx, decimal price, decimal tcprice, decimal pprice, string uname)
        {
            return r.SetPrice(ptcode, pcodearr, plx, price, tcprice,pprice, uname);
        }
        public decimal[] GetPrice(string ptcode, string pcode, string plx)
        {
            return r.GetPrice( ptcode,  pcode,  plx);
        }
        #region//设置销售城市供货价格类型
        public int SetAgentsPrice(string dcode, string ptcode)
        {
            return r.SetAgentsPrice(dcode, ptcode);
        }
        #endregion
        #region//重置销售城市供货价格类型
        public int ReSetAgentsPrice(string dcode)
        {
            return r.ReSetAgentsPrice(dcode);
        }
        #endregion
        #region//获取销售城市供货价格类型
        public string GetAgentsPrice(string dcode)
        {
            return r.GetAgentsPrice(dcode);
        }
        #endregion

        #region//设置工厂价格类型
        public int SetFactoryPrice(string ptcode, string dcode,string cdcode)
        {
            return r.SetFactoryPrice(ptcode, dcode, cdcode);
        }
        public int ReSetFactoryPrice(string dcode,string cdcode)
        {
            return r.ReSetFactoryPrice(dcode,cdcode);
        }
        public string GetFactoryPrice(string dcode,string cdcode)
        {
            return r.GetFactoryPrice(dcode,cdcode);
        }
        #endregion
        #region//获取产品组供货价格
        public decimal QueryGPrice(string dcode, string pcode, string mtcode)
        {
            return r.QueryGPrice(dcode,pcode,mtcode);
        }
        #endregion

        #region 设置代理商销售价格
        public int SetAgentsSalePrice(string dcode, string ptcode)
        {
            return r.SetAgentsSalePrice(dcode, ptcode);
        }
        #endregion
        #region 重置代理商销售价格
        public int ReSetAgentsSalePrice(string dcode)
        { 
            return r.ReSetAgentsSalePrice(dcode);
        }
        #endregion
        #region 获取代理商供货价格
        public string GetAgentsSalePrice(string dcode)
        {
            return r.GetAgentsSalePrice(dcode);
        }
        public string GetDlsSalePrice(string dcode)
        {
            return r.GetDlsSalePrice(dcode);
        }
        #endregion

        #region//代理商模式获取价格体系
        public string GetDlsPrice(string dcode,string ptx)
        {
            return r.GetDlsPrice(dcode,ptx);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
