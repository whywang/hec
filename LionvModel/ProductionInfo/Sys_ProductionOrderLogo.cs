using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_ProductionOrderLogo
    {
        #region Model
        private int _id;
        private string _dcode;
        private string _xqurl = "";
        private string _xqt = "";
        private string _pgurl = "";
        private string _pgt = "";
        private string _spurl = "";
        private string _spt = "";
        private string _gpurl = "";
        private string _gpt = "";
        private string _bpurl = "";
        private string _bpt = "";
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
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xqurl
        {
            set { _xqurl = value; }
            get { return _xqurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xqt
        {
            set { _xqt = value; }
            get { return _xqt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pgurl
        {
            set { _pgurl = value; }
            get { return _pgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pgt
        {
            set { _pgt = value; }
            get { return _pgt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spurl
        {
            set { _spurl = value; }
            get { return _spurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spt
        {
            set { _spt = value; }
            get { return _spt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gpurl
        {
            set { _gpurl = value; }
            get { return _gpurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gpt
        {
            set { _gpt = value; }
            get { return _gpt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bpurl
        {
            set { _bpurl = value; }
            get { return _bpurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bpt
        {
            set { _bpt = value; }
            get { return _bpt; }
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
