using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_SaleDiscount
    {
        #region Model
        private int _id;
        private string _dname = "";
        private string _dcode;
        private string _dbdate;
        private string _dedate;
        private string _dtype = "";
        private string _drange = "";
        private string _dproduction = "";
        private string _cdate;
        private string _maker = "";
        private string _remark = "";
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
        public string dbdate
        {
            set { _dbdate = value; }
            get { return _dbdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dedate
        {
            set { _dedate = value; }
            get { return _dedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dtype
        {
            set { _dtype = value; }
            get { return _dtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string drange
        {
            set { _drange = value; }
            get { return _drange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dproduction
        {
            set { _dproduction = value; }
            get { return _dproduction; }
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
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}
