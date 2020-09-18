using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_SectionPrice
    {
        #region Model
        private int _id;
        private string _jname = "";
        private string _jcode;
        private string _sname = "";
        private string _scode = "";
        private string _jattr = "";
        private bool _isfrist = false;
        private int _maxv = 0;
        private int _minv = 0;
        private decimal _price = 0;
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
        public string jname
        {
            set { _jname = value; }
            get { return _jname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jcode
        {
            set { _jcode = value; }
            get { return _jcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sname
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string scode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jattr
        {
            set { _jattr = value; }
            get { return _jattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isfrist
        {
            set { _isfrist = value; }
            get { return _isfrist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int maxv
        {
            set { _maxv = value; }
            get { return _maxv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int minv
        {
            set { _minv = value; }
            get { return _minv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal price
        {
            set { _price = value; }
            get { return _price; }
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
