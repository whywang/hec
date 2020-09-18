 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LionvModel.NewsInfo
{
    [Serializable]
    public class NB_DepNews
    { 
        #region Model
        private int _id;
        private int _nid = 0;
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
        public int nid
        {
            set { _nid = value; }
            get { return _nid; }
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