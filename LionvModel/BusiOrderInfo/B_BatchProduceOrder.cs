using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_BatchProduceOrder
    {
        #region Model
        private int _id;
        private string _bsid = "";
        private string _btype = "";
        private string _bcode = "";
        private string _fname = "";
        private string _fcode = "";
        private int _bstate = 0;
        private string _maker = "";
        private string _cdate;
        private string _pdate;
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
        public string bsid
        {
            set { _bsid = value; }
            get { return _bsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string btype
        {
            set { _btype = value; }
            get { return _btype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bcode
        {
            set { _bcode = value; }
            get { return _bcode; }
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
        public int bstate
        {
            set { _bstate = value; }
            get { return _bstate; }
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
        public string pdate
        {
            set { _pdate = value; }
            get { return _pdate; }
        }
        #endregion Model

    }
}
