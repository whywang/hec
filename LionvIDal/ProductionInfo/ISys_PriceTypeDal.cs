using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_PriceTypeDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ptcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_PriceType model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_PriceType model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ptcode);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_PriceType Query(string where);
        Sys_PriceType DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_PriceType> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetPrice(string ptcode, string[] pcodearr, string plx, decimal price, decimal tcprice,decimal pprice ,string uname);
        decimal [] GetPrice(string ptcode, string pcode, string plx);
        int SetAgentsPrice(string dcode, string ptcode);
        int ReSetAgentsPrice(string dcode);
        string GetAgentsPrice(string dcode);
        string GetDlsPrice(string dcode, string ptx);
        int SetFactoryPrice(string ptcode, string dcode,string cdcode);
        int ReSetFactoryPrice(string dcode, string cdcode);
        string GetFactoryPrice(string dcode, string cdcode);
        decimal QueryGPrice(string dcode, string pcode, string mtcode);
        int SetAgentsSalePrice(string dcode, string ptcode);
        int ReSetAgentsSalePrice(string dcode);
        string GetAgentsSalePrice(string dcode);
        string GetDlsSalePrice(string dcode);
        #endregion  MethodEx
    }
}
