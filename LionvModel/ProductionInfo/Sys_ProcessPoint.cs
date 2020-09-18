using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_ProcessPoint
    {
        public Sys_ProcessPoint()
        { }
        #region Model
        private int _id;
        private string _jname = "";
        private string _jcode = "";
        private string _pcode = "";
        private string _pname;
        private string _jtype = "";
        private string _precode = "";
        private decimal _usetime = 0M;
        private string _maker = "";
        private string _cdate = "";
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
        public string pcode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jtype
        {
            set { _jtype = value; }
            get { return _jtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string precode
        {
            set { _precode = value; }
            get { return _precode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal usetime
        {
            set { _usetime = value; }
            get { return _usetime; }
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
