using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Collections;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_GroupProductionDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_GroupProduction model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_GroupProduction model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);

        B_GroupProduction Query(string where);
        B_GroupProduction Query(DataTable dt, string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_GroupProduction> QueryList(string where);
        DataTable QueryTable(string where);
        #endregion  成员方法
        #region  MethodEx
        void UpGhPrice(string psid, decimal bzprice, decimal oprice, decimal sprice);
     
        int GetGnum(string sid);
        int SaveList(List<B_GroupProduction> lb,string sid,int gnum) ;
    
        ArrayList GetGnumArr(string where);
        decimal[] QueryGroupGhWjPriceAttr(string sid, int gnum);
        decimal[] QueryGroupGhMzpPriceAttr(string sid, int gnum);
       
        /// <summary>
        /// 促销活动产品金额
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
   
        int UpGroupGhPrice(ArrayList plist);
        int TjProductionMsNum(string sid);
        decimal TjProductionCNum(string sid);
        decimal TjProductionQtNum(string sid);
        int TjProductionNum(string sid);
        string TjProductionCateNumText(string sid, string where);
        int TjProductionCateNum(string sid, string icode, string itype);
      
        /// <summary>
        /// 统计审核统计表锁具信息
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        string[] Sjtj(string sid,string pcode);
        
        bool UpRemarkImg(string sid, int gnum, string url,string ptype);
 
        DataTable QueryWj(string sid);
        string QueryWjText(string sid);
        decimal GNomalProductionMoney(string sid);
        decimal GNomalProductionMoneyB(string sid);
        decimal GNomalProductionMoneyO(string sid);
        decimal GNomalOnlyMoney(string sid);
        decimal QueryGroupGhWjPrice(string sid, int gnum);
        ArrayList QueryGsidList(string sid);
        void UpInitTjState(string sid);
        void UpdateTjState(string gsid);
        bool CheckContainTj(string sid, int pnum);
        void UpSalePrice(string psid, decimal smoney, decimal somoney, decimal sqmoney);
        int UpGroupSalePrice(ArrayList plist);
        decimal[] QueryGroupSaleMzpPriceAttr(string sid, int gnum);
        decimal[] QueryGroupSaleWjPriceAttr(string sid, int gnum);
        decimal QueryGourpSaleMzpSumMoney(string sid, int xh);
        decimal QuerySaleOrderWjSummerPrice(string sid);
        decimal QuerySaleOrderMzpSummerPrice(string sid);

        DataTable QueryWjTable(string sid);
        #endregion  MethodEx
    } 
}
