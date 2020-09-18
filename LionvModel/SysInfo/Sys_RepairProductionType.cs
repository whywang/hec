using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_RepairProductionType
    {
        #region Model
        private int _id;
        private string _apname = "";
        private string _apcode = "";
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
        public string apname
        {
            set { _apname = value; }
            get { return _apname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string apcode
        {
            set { _apcode = value; }
            get { return _apcode; }
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
