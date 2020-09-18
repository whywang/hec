using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_SizeTransformR
    {
        #region Model
        private int _id;
        private string _rname = "";
        private string _rcode;
        private string _rtype;
        private decimal _dh = 0;
        private decimal _dw = 0;
        private string _dcode;
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
        public string rname
        {
            set { _rname = value; }
            get { return _rname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rcode
        {
            set { _rcode = value; }
            get { return _rcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rtype
        {
            set { _rtype = value; }
            get { return _rtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dh
        {
            set { _dh = value; }
            get { return _dh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dw
        {
            set { _dw = value; }
            get { return _dw; }
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
