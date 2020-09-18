using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_SizeFomatCondition
    {
        private int _id;
        private string _sfcname = "";
        private string _sfccode = "";
        private string _sfname = "";
        private string _sfcode = "";
        private bool _isms = false;
        private bool _used = false;
        private string _fixd = "";
        private int _hlv = 0;
        private int _htv = 0;
        private int _wlv = 0;
        private int _wtv = 0;
        private int _dlv = 0;
        private int _dtv = 0;
        private string _ctype = "";
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
        public bool isms
        {
            set { _isms = value; }
            get { return _isms; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool used
        {
            set { _used = value; }
            get { return _used; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fixd
        {
            set { _fixd = value; }
            get { return _fixd; }
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
        public int hlv
        {
            set { _hlv = value; }
            get { return _hlv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int htv
        {
            set { _htv = value; }
            get { return _htv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int wlv
        {
            set { _wlv = value; }
            get { return _wlv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int wtv
        {
            set { _wtv = value; }
            get { return _wtv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dlv
        {
            set { _dlv = value; }
            get { return _dlv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dtv
        {
            set { _dtv = value; }
            get { return _dtv; }
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
    }
}
