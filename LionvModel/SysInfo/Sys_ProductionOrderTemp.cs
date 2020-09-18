using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_ProductionOrderTemp
    {
        #region Model
        private int _id;
        private string _tname = "";
        private string _tcode;
        private string _xqt = "";
        private string _sct = "";
        private string _spt = "";
        private string _gpt = "";
        private string _bpt = "";
        private string _xqf = "";
        private string _scf = "";
        private string _spf = "";
        private string _gpf = "";
        private string _bpf = "";
        private string _dcode = "";
        private string _ttype = "";
        private bool _tread = false;
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
        public string tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcode
        {
            set { _tcode = value; }
            get { return _tcode; }
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
        public string sct
        {
            set { _sct = value; }
            get { return _sct; }
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
        public string gpt
        {
            set { _gpt = value; }
            get { return _gpt; }
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
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ttype
        {
            set { _ttype = value; }
            get { return _ttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool tread
        {
            set { _tread = value; }
            get { return _tread; }
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
        /// <summary>
        /// 
        /// </summary>
        public string xqf
        {
            set { _xqf = value; }
            get { return _xqf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string scf
        {
            set { _scf = value; }
            get { return _scf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spf
        {
            set { _spf = value; }
            get { return _spf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gpf
        {
            set { _gpf = value; }
            get { return _gpf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bpf
        {
            set { _bpf = value; }
            get { return _bpf; }
        }
        #endregion Model
    }
}
