using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_Remark
    {
        public Sys_Remark()
        { }
        #region Model
        private int _id;
        private string _rcode = "";
        private string _rname = "";
        private string _rchangtext = "";
        private string _rfixtext = "";
        private string _maker = "";
        private string _cdate = "";
        private string _dcode = "";
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
        public string rcode
        {
            set { _rcode = value; }
            get { return _rcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rname
        {
            set { _rname = value; }
            get { return _rname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rchangtext
        {
            set { _rchangtext = value; }
            get { return _rchangtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rfixtext
        {
            set { _rfixtext = value; }
            get { return _rfixtext; }
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
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        #endregion Model
    }
}
