using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.NewsInfo
{
   public class NB_News
    {
        public NB_News()
        { }
        #region Model
        private int _id;
        private string _ntitle = "";
        private string _ncontent = "";
        private string _cdate = "";
        private string _maker = "";
        private string _ntype = "";
        private int _nreadnum = 0;
        private bool _nstate = true;
        private string _nvrange = "";
        private string _nsid = "";
        private string _rtype = "";
        private string _dcode = "";
        private string _sdcode = "";//选中部门

        
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
        public string ntitle
        {
            set { _ntitle = value; }
            get { return _ntitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ncontent
        {
            set { _ncontent = value; }
            get { return _ncontent; }
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
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ntype
        {
            set { _ntype = value; }
            get { return _ntype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int nreadnum
        {
            set { _nreadnum = value; }
            get { return _nreadnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool nstate
        {
            set { _nstate = value; }
            get { return _nstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nvrange
        {
            set { _nvrange = value; }
            get { return _nvrange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nsid
        {
            set { _nsid = value; }
            get { return _nsid; }
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
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        public string sdcode
        {
            get { return _sdcode; }
            set { _sdcode = value; }
        }
        #endregion Model
    }
}
