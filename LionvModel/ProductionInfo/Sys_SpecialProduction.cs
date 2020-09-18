using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_SpecialProduction
    {
        #region Model
        private int _id;
        private string _aname = "";
        private string _acode = "";
        private string _tjname = "";
        private string _tjcode = "";
        private string _tjarea = "";
        private string _ctype = "";
        private decimal _bjprice = 0;
        private decimal _wfprice = 0;
        private string _bdate="";
        private string _edate="";
        private string _econdition = "";
        private string _maker = "";
        private string _cdate;
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
        public string aname
        {
            set { _aname = value; }
            get { return _aname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string acode
        {
            set { _acode = value; }
            get { return _acode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjname
        {
            set { _tjname = value; }
            get { return _tjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjcode
        {
            set { _tjcode = value; }
            get { return _tjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjarea
        {
            set { _tjarea = value; }
            get { return _tjarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ctype
        {
            set { _ctype = value; }
            get { return _ctype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bjprice
        {
            set { _bjprice = value; }
            get { return _bjprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal wfprice
        {
            set { _wfprice = value; }
            get { return _wfprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdate
        {
            set { _bdate = value; }
            get { return _bdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string edate
        {
            set { _edate = value; }
            get { return _edate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string econdition
        {
            set { _econdition = value; }
            get { return _econdition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model

    }
}
