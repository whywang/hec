using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
     public class Sys_PartType
    {
        public Sys_PartType()
        { }
        #region Model
        private int _id;
        private string _pctype = "";
        private string _pcname = "";
        private string _pname = "";
        private string _pcode = "";
        private string _ptype = "";
        private bool _pread = false;
        private string _maker = "";
        private string _cdate ="";
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
        public string pctype
        {
            set { _pctype = value; }
            get { return _pctype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcname
        {
            set { _pcname = value; }
            get { return _pcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pread
        {
            set { _pread = value; }
            get { return _pread; }
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
        public string pcode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
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
