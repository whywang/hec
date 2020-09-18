using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_TPriceCate
    {
        #region Model
        private int _id;
        private string _lpname = "";
        private string _lpcode;
        private string _ptype = "";
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
        public string lpname
        {
            set { _lpname = value; }
            get { return _lpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lpcode
        {
            set { _lpcode = value; }
            get { return _lpcode; }
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
