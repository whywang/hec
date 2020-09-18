using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_Brands
    {
        #region Model
        private int _id;
        private string _pbname = "";
        private string _pbcode;
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
        public string pbname
        {
            set { _pbname = value; }
            get { return _pbname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pbcode
        {
            set { _pbcode = value; }
            get { return _pbcode; }
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
