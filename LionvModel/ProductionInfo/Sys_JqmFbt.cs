using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_JqmFbt
    {
        #region Model
        private int _id;
        private string _fbname = "";
        private string _fbcode;
        private string _mcode = "";
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
        public string fbname
        {
            set { _fbname = value; }
            get { return _fbname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fbcode
        {
            set { _fbcode = value; }
            get { return _fbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
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
