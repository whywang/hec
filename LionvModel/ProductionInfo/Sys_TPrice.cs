using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_TPrice
    {
        #region Model
        private int _id;
        private string _ptname = "";
        private string _ptcode;
        private string _lpname = "";
        private string _lpcode = "";
        private bool _isfw = false;
        private string _fattr = "";
        private decimal  _lv = 0M;
        private decimal  _tv = 0M;
        private decimal  _price = 0M;
        private string _maker = "";
        private string  _cdate = "";
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
        public string ptname
        {
            set { _ptname = value; }
            get { return _ptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptcode
        {
            set { _ptcode = value; }
            get { return _ptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lpname
        {
            set { _lpname = value; }
            get { return _lpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lpcode
        {
            set { _lpcode = value; }
            get { return _lpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isfw
        {
            set { _isfw = value; }
            get { return _isfw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fattr
        {
            set { _fattr = value; }
            get { return _fattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  lv
        {
            set { _lv = value; }
            get { return _lv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  tv
        {
            set { _tv = value; }
            get { return _tv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  price
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
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
