using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
     public  class Sys_ComponentCate
    {
        public Sys_ComponentCate()
        { }
        #region Model
        private int _id;
        private string _ccname;
        private string _cccode;
        private string _ctype;
        private string _maker;
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
        public string ccname
        {
            set { _ccname = value; }
            get { return _ccname; }
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
        public string ctype
        {
            set { _ctype = value; }
            get { return _ctype; }
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
