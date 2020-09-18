using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Account
{
   public class VCustomeAccount
    {
       /// <summary>
       /// 客户总金额
       /// </summary>
       public string amoney{get;set;}
       /// <summary>
       /// 可用金额
       /// </summary>
       public string kymoney { get; set; }
       /// <summary>
       /// 待收金额
       /// </summary>
       public string dsmoney { get; set; }
       /// <summary>
       /// 待退金额
       /// </summary>
       public string dfmoney { get; set; }
    }
}
