using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public class B_OrderFacotory
    {
        public B_OrderFacotory()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _dname = "";
        private string _dcode = "";
        private string _otype = "";
        private string _overdate = "";
        private string _maker = "";
        private string _cdate ;
        private string _ddate = "";
        private string _fdate = "";
        private string _jdate = "";

        
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
        public string otype
        {
            set { _otype = value; }
            get { return _otype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string overdate
        {
            set { _overdate = value; }
            get { return _overdate; }
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
        public string ddate
        {
            get { return _ddate; }
            set { _ddate = value; }
        }
        public string fdate
        {
            get { return _fdate; }
            set { _fdate = value; }
        }
        public string jdate
        {
            get { return _jdate; }
            set { _jdate = value; }
        }
        #endregion Model

    }
}
