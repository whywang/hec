using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public class B_yyFixOrderRecord
    {
        public B_yyFixOrderRecord()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _fsid = "";
        private string _fixer = "";
        private string _ydate;
        private string _ps = "";
        private string _maker = "";
        private string _cdate ;
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fsid
        {
            set { _fsid = value; }
            get { return _fsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fixer
        {
            set { _fixer = value; }
            get { return _fixer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ydate
        {
            set { _ydate = value; }
            get { return _ydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ps
        {
            set { _ps = value; }
            get { return _ps; }
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
