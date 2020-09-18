using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_FixMoney
    {
           public B_FixMoney()
           { }
           #region Model
           private int _id;
           private string _sid;
           private decimal _amoney = 0;
           private decimal _dmoney = 0;
           private string _premark = "";
           private string _cdate;
           private string _maker = "";
           /// <summary>
           /// 
           /// </summary>
           public int id
           {
               set { _id = value; }
               get { return _id; }
           }
           /// <summary>
           /// 
           /// </summary>
           public string sid
           {
               set { _sid = value; }
               get { return _sid; }
           }
           /// <summary>
           /// 
           /// </summary>
           public decimal amoney
           {
               set { _amoney = value; }
               get { return _amoney; }
           }
           /// <summary>
           /// 
           /// </summary>
           public decimal dmoney
           {
               set { _dmoney = value; }
               get { return _dmoney; }
           }
           /// <summary>
           /// 
           /// </summary>
           public string premark
           {
               set { _premark = value; }
               get { return _premark; }
           }
           /// <summary>
           /// 
           /// </summary>
           public string cdate
           {
               set { _cdate = value; }
               get { return _cdate; }
           }
           /// <summary>
           /// 
           /// </summary>
           public string maker
           {
               set { _maker = value; }
               get { return _maker; }
           }
           #endregion Model
    }
}
