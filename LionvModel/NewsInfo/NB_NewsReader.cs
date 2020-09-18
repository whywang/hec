using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.NewsInfo
{
   public class NB_NewsReader
    {
        public NB_NewsReader()
        { }
        #region Model
        private int _id;
        private int _nid = 0;
        private string _dname = "";
        private string _dcode = "";
        private string _ename = "";
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
        public int nid
        {
            set { _nid = value; }
            get { return _nid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ename
        {
            set { _ename = value; }
            get { return _ename; }
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
