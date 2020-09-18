using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_ProductionCapacity
    {
        #region Model
        private int _id;
        private string _cccode;
        private string _ccname;
        private string _dcode;
        private string _dname;
        private string _lcode;
        private string _lname;
        private int  _cnum;
        private string  _cdate;
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
        public string cccode
        {
            set { _cccode = value; }
            get { return _cccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccname
        {
            set { _ccname = value; }
            get { return _ccname; }
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
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
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
        public string lname
        {
            set { _lname = value; }
            get { return _lname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  cnum
        {
            set { _cnum = value; }
            get { return _cnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
