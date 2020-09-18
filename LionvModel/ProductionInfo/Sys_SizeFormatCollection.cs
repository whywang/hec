using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_SizeFormatCollection
    {
        #region Model
        private int _id;
        private string _sfcname;
        private string _sfccode;
        private string _sfname = "";
        private string _sfcode = "";
        private string _bjpname = "";
        private string _bjname;
        private string _bjcode;
        private string _bjtype;
        private string _hstr;
        private string _wstr;
        private string _dstr;
        private int _bjnum;
        private string _bjattr = "";
        private string _bjattrex = "";
        private string _bjtj = "";
        private string _ftype= "";
        private string _maker="";
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
        public string sfcname
        {
            set { _sfcname = value; }
            get { return _sfcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sfccode
        {
            set { _sfccode = value; }
            get { return _sfccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sfname
        {
            set { _sfname = value; }
            get { return _sfname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sfcode
        {
            set { _sfcode = value; }
            get { return _sfcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjpname
        {
            set { _bjpname = value; }
            get { return _bjpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjname
        {
            set { _bjname = value; }
            get { return _bjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjcode
        {
            set { _bjcode = value; }
            get { return _bjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjtype
        {
            set { _bjtype = value; }
            get { return _bjtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hstr
        {
            set { _hstr = value; }
            get { return _hstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wstr
        {
            set { _wstr = value; }
            get { return _wstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dstr
        {
            set { _dstr = value; }
            get { return _dstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bjnum
        {
            set { _bjnum = value; }
            get { return _bjnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjattr
        {
            set { _bjattr = value; }
            get { return _bjattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjattrex
        {
            set { _bjattrex = value; }
            get { return _bjattrex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjtj
        {
            set { _bjtj = value; }
            get { return _bjtj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ftype
        {
            set { _ftype = value; }
            get { return _ftype; }
        }
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
