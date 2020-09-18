using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_Menu
    {
        public Sys_Menu()
        { }
        #region Model
        private int _id;
        private string _mname = "";
        private string _mcode = "";
        private string _mpcode = "";
        private string _mpname = "";
        private bool _mhaschild = false;
        private string _murl = "";
        private int _msort = 9999;
        private string _mtype = "1";
        private bool _mshow = true;
        private string _mdate ="";
        private string _mgroup = "";
        private string _mstyle = "";
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
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mpcode
        {
            set { _mpcode = value; }
            get { return _mpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mpname
        {
            set { _mpname = value; }
            get { return _mpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool mhaschild
        {
            set { _mhaschild = value; }
            get { return _mhaschild; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string murl
        {
            set { _murl = value; }
            get { return _murl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int msort
        {
            set { _msort = value; }
            get { return _msort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtype
        {
            set { _mtype = value; }
            get { return _mtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool mshow
        {
            set { _mshow = value; }
            get { return _mshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mdate
        {
            set { _mdate = value; }
            get { return _mdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mgroup
        {
            set { _mgroup = value; }
            get { return _mgroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mstyle
        {
            set { _mstyle = value; }
            get { return _mstyle; }
        }
        #endregion Model

    }
}
