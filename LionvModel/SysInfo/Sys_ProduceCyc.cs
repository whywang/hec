using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public   class Sys_ProduceCyc
    {
        public Sys_ProduceCyc()
        { }
        #region Model
        private int _id;
        private string _cname = "";
        private string _ccode = "";
        private string _fname = "";
        private string _fcode;
        private string _emname = "";
        private string _emcode = "";
        private int _cnum = 0;
        private string _bdname = "";
        private string _bdcode = "";
        private string _csql = "";
        private string _otype = "";
        private string _dcode = "";
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
        public string cname
        {
            set { _cname = value; }
            get { return _cname; }
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
        public string fname
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 工厂编码
        /// </summary>
        public string fcode
        {
            set { _fcode = value; }
            get { return _fcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emname
        {
            set { _emname = value; }
            get { return _emname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emcode
        {
            set { _emcode = value; }
            get { return _emcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int cnum
        {
            set { _cnum = value; }
            get { return _cnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdname
        {
            set { _bdname = value; }
            get { return _bdname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdcode
        {
            set { _bdcode = value; }
            get { return _bdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csql
        {
            set { _csql = value; }
            get { return _csql; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string otype
        {
            set { _otype = value; }
            get { return _otype; }
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
