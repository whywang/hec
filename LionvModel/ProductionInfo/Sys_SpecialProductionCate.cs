using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_SpecialProductionCate
    {
        #region Model
        private int _id;
        private string _tjlbname = "";
        private string _tjlbcode = "";
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
        public string tjlbname
        {
            set { _tjlbname = value; }
            get { return _tjlbname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjlbcode
        {
            set { _tjlbcode = value; }
            get { return _tjlbcode; }
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
