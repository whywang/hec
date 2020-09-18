using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using System.Data;

namespace LionvBll.SysInfo
{
   public class Sys_PartTypeBll
    {
       private readonly ISys_PartTypeDal dal = DataProductionAccess.CreateSys_PartType();
       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(string pcode)
       {
           return dal.Exists(pcode);
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add( Sys_PartType model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_PartType model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string pcode)
       {

           return dal.Delete(pcode);
       }
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_PartType Query(string where)
       {

           return dal.Query(where);
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Sys_PartType> QueryList(string strWhere)
       {
           return dal.QueryList(strWhere);
       }
       #endregion  BasicMethod
        #region  ExtensionMethod
       public int CreateCode()
       {
           return dal.CreateCode();
       }
       public int SetInvPartType(string icode, string pcode)
       {
           return dal.SetInvPartType(icode, pcode);
       }
       public int ReSetInvPartType(string icode)
       {
           return dal.ReSetInvPartType(icode);
       }
       public string GetInvPartType(string icode)
       {
           return dal.GetInvPartType(icode);
       }
       public Sys_PartType QueryInv(string icode)
       {
           Sys_PartType r = new Sys_PartType();
          string pcode= dal.GetInvPartType(icode);
          if (pcode != "")
          {
              r = dal.Query(" and pcode='" + pcode + "'");
          }
          else
          {
              r = null;
          }
           return r;
       }
       public DataTable QueryCateList(string where)
       {
           return dal.QueryCateList(where);
       }
        #endregion  ExtensionMethod
    }
}
