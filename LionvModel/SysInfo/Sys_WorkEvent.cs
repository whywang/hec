using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_WorkEvent
    {
        public Sys_WorkEvent()
        { }
        #region Model
        private int _id=0;
        private string _wname="";
        private string _wcode="";
        private int _wattr =1;
        private string _wremcode = "";
        private string _wprewcode = "";
        private string _wprewname = "";
        private string _wnextwcode = "";
        private string _wnextwname = "";
        private string _wrwname = "";
        private string _wrwcode = "";
        private string _emcode = "";
        private string _wcondtion = "";
        private int _wcycletime = 0;
        private string _wattrex = "";
        private string _wrwtype = "";

        public string wrwtype
        {
            get { return _wrwtype; }
            set { _wrwtype = value; }
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
        public string wname
        {
            set { _wname = value; }
            get { return _wname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wcode
        {
            set { _wcode = value; }
            get { return _wcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int wattr
        {
            set { _wattr = value; }
            get { return _wattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wremcode
        {
            set { _wremcode = value; }
            get { return _wremcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wprewcode
        {
            set { _wprewcode = value; }
            get { return _wprewcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wprewname
        {
            set { _wprewname = value; }
            get { return _wprewname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wnextwcode
        {
            set { _wnextwcode = value; }
            get { return _wnextwcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wnextwname
        {
            set { _wnextwname = value; }
            get { return _wnextwname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wrwname
        {
            set { _wrwname = value; }
            get { return _wrwname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wrwcode
        {
            set { _wrwcode = value; }
            get { return _wrwcode; }
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
        public string wcondtion
        {
            set { _wcondtion = value; }
            get { return _wcondtion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int wcycletime
        {
            set { _wcycletime = value; }
            get { return _wcycletime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wattrex
        {
            set { _wattrex = value; }
            get { return _wattrex; }
        }
        #endregion Model

    }
}
