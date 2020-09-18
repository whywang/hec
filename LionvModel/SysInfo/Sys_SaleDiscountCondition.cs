using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_SaleDiscountCondition
    {
        #region Model
        private int _id;
        private string _dname = "";
        private string _dcode = "";
        private string _tjname = "";
        private string _tjcode;
        private string _tjmethod = "";
        private decimal _dvalue = 0M;
        private decimal _dlv = 0M;
        private decimal _dtv = 0M;
        private decimal _dzk;
        private int _dsort = 9999;
        private string _tjfw = "";
        private string _maker = "";
        private string _cdate;
        private string _tjlb = "";
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
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
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
        public string tjname
        {
            set { _tjname = value; }
            get { return _tjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjcode
        {
            set { _tjcode = value; }
            get { return _tjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjmethod
        {
            set { _tjmethod = value; }
            get { return _tjmethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjfw
        {
            set { _tjfw = value; }
            get { return _tjfw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dvalue
        {
            set { _dvalue = value; }
            get { return _dvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dlv
        {
            set { _dlv = value; }
            get { return _dlv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dtv
        {
            set { _dtv = value; }
            get { return _dtv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dzk
        {
            set { _dzk = value; }
            get { return _dzk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dsort
        {
            set { _dsort = value; }
            get { return _dsort; }
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
        public string tjlb
        {
            set { _tjlb = value; }
            get { return _tjlb; }
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
