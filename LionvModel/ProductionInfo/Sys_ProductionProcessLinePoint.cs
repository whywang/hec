using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_ProductionProcessLinePoint
    {
        #region Model
        private int _id;
        private string _lname = "";
        private string _lcode = "";
        private string _gname = "";
        private string _gcode = "";
        private string _ptype = "";
        private int _nsort = 0;
        private string _pregcode = "";
        private int _usetime = 0;
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
        public string lname
        {
            set { _lname = value; }
            get { return _lname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lcode
        {
            set { _lcode = value; }
            get { return _lcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gname
        {
            set { _gname = value; }
            get { return _gname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gcode
        {
            set { _gcode = value; }
            get { return _gcode; }
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
        public string pregcode
        {
            set { _pregcode = value; }
            get { return _pregcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int usetime
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
        /// <summary>
        /// 
        /// </summary>
        public int nsort
        {
            set { _nsort = value; }
            get { return _nsort; }
        }
        #endregion Model

    }
}
