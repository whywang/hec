using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_HelpMenu
    {
        #region Model
        private int _id;
        private string _hname = "";
        private string _hcode;
        private string _hpcode = "";
        private string _hpname = "";
        private bool _isend = true;
        private bool _htext = false;
        private string _cdate;
        private string _maker;
        private string _dcode = "";

        public string dcode
        {
            get { return _dcode; }
            set { _dcode = value; }
        }
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
        public string hname
        {
            set { _hname = value; }
            get { return _hname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hcode
        {
            set { _hcode = value; }
            get { return _hcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hpcode
        {
            set { _hpcode = value; }
            get { return _hpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hpname
        {
            set { _hpname = value; }
            get { return _hpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isend
        {
            set { _isend = value; }
            get { return _isend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool htext
        {
            set { _htext = value; }
            get { return _htext; }
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
