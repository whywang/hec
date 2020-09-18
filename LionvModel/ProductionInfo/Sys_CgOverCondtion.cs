using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_CgOverCondtion
    {
        public Sys_CgOverCondtion()
        { }
        #region Model
        private int _id;
        private string _ccode = "";
        private string _cname = "";
        private string _oname = "";
        private string _ocode = "";
        private string _cattr = "";
        private decimal _bvalue = 0;
        private decimal _tvalue = 0;
        private string _cfstr = "";
        private decimal _cfscale = 0;
        private decimal _cxs = 0;
        private string _cpricetype = "";
        private string _pricetx = "";
        private string _pricetxtype = "";
        private string _pcity;
        private string _maker = "";
        private string _cdate = "";
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
        public string ccode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cname
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oname
        {
            set { _oname = value; }
            get { return _oname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ocode
        {
            set { _ocode = value; }
            get { return _ocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cattr
        {
            set { _cattr = value; }
            get { return _cattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bvalue
        {
            set { _bvalue = value; }
            get { return _bvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tvalue
        {
            set { _tvalue = value; }
            get { return _tvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfstr
        {
            set { _cfstr = value; }
            get { return _cfstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal cfscale
        {
            set { _cfscale = value; }
            get { return _cfscale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal cxs
        {
            set { _cxs = value; }
            get { return _cxs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpricetype
        {
            set { _cpricetype = value; }
            get { return _cpricetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pricetx
        {
            set { _pricetx = value; }
            get { return _pricetx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pricetxtype
        {
            set { _pricetxtype = value; }
            get { return _pricetxtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcity
        {
            set { _pcity = value; }
            get { return _pcity; }
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
