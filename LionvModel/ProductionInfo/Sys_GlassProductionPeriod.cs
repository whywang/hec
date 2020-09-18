using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_GlassProductionPeriod
    {
        #region Model
        private int _id;
        private string _gqname = "";
        private string _gqcode;
        private string _fname = "";
        private string _fcode = "";
        private int _gqnum = 0;
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
        public string gqname
        {
            set { _gqname = value; }
            get { return _gqname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gqcode
        {
            set { _gqcode = value; }
            get { return _gqcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fname
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fcode
        {
            set { _fcode = value; }
            get { return _fcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int gqnum
        {
            set { _gqnum = value; }
            get { return _gqnum; }
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
