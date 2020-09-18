using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_RefSizeTransform
    {
        #region Model
        private int _id;
        private string _rjname = "";
        private string _rjcode;
        private int _rheight = 0;
        private int _rwidth = 0;
        private int  _rdeep = 0;
        private string _rtype = "";
        private string _maker = "";
        private string  _cdate;
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
        public string rjname
        {
            set { _rjname = value; }
            get { return _rjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rjcode
        {
            set { _rjcode = value; }
            get { return _rjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  rheight
        {
            set { _rheight = value; }
            get { return _rheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  rwidth
        {
            set { _rwidth = value; }
            get { return _rwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  rdeep
        {
            set { _rdeep = value; }
            get { return _rdeep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rtype
        {
            set { _rtype = value; }
            get { return _rtype; }
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
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
