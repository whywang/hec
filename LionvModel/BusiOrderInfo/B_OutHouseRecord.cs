using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_OutHouseRecord
    {
        public B_OutHouseRecord()
        { }
        #region Model
        private int _id;
        private string _sid;
        private string _ccode;
        private int _bnum;
        private string _rperson;
        private string _rdate;
        private string _remarke;
        private string _maker;
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bnum
        {
            set { _bnum = value; }
            get { return _bnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rperson
        {
            set { _rperson = value; }
            get { return _rperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rdate
        {
            set { _rdate = value; }
            get { return _rdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remarke
        {
            set { _remarke = value; }
            get { return _remarke; }
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
