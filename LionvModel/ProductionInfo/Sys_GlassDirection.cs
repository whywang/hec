using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
  public  class Sys_GlassDirection
    {
        #region Model
        private int _id;
        private string _gdname = "";
        private string _gdcode;
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
        public string gdname
        {
            set { _gdname = value; }
            get { return _gdname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gdcode
        {
            set { _gdcode = value; }
            get { return _gdcode; }
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
