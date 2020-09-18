using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_SizeFormatCate
    {
        #region Model
        private int _id;
        private string _sfname = "";
        private string _sfcode = "";
        private string _bdcode = "";
        private string _sftype = "";
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
        public string sfname
        {
            set { _sfname = value; }
            get { return _sfname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sfcode
        {
            set { _sfcode = value; }
            get { return _sfcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sftype
        {
            set { _sftype = value; }
            get { return _sftype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdcode
        {
            set { _bdcode = value; }
            get { return _bdcode; }
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
