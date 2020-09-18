using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public  class Sys_InventoryCategory
    {
        public Sys_InventoryCategory()
        { }
        #region Model
        private int _id;
        private string _icname = "";
        private string _iccode = "";
        private string _icpname = "";
        private string _icpcode = "";
        private bool _icsend = true;
        private bool _icstate = true;
        private string _icms = "";
        private string _maker = "";
        private string _cdate = "";
        private int _isort = 9999;
        private string _drange = "";
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
        public string icname
        {
            set { _icname = value; }
            get { return _icname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iccode
        {
            set { _iccode = value; }
            get { return _iccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icpname
        {
            set { _icpname = value; }
            get { return _icpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icpcode
        {
            set { _icpcode = value; }
            get { return _icpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool icsend
        {
            set { _icsend = value; }
            get { return _icsend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool icstate
        {
            set { _icstate = value; }
            get { return _icstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icms
        {
            set { _icms = value; }
            get { return _icms; }
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
        public int isort
        {
            set { _isort = value; }
            get { return _isort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string drange
        {
            set { _drange = value; }
            get { return _drange; }
        }
        #endregion Model
    }
}
