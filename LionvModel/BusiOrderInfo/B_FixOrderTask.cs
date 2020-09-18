using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_FixOrderTask
    {
      
        #region Model
        private int _id;
        private string _sid="";
        private string _azs="";
        private string _cdate;
        private string _odate;
        private decimal _oratio = 0;
        private decimal _tmoney = 0;
        private string _otype = "";
        private string _azstype = "";
        private string _maker = "";
        private string _remark = "";
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
        public string azs
        {
            set { _azs = value; }
            get { return _azs; }
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
        public decimal oratio 
        {
            set { _oratio = value; }
            get { return _oratio; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tmoney
        {
            set { _tmoney = value; }
            get { return _tmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string odate
        {
            set { _odate = value; }
            get { return _odate; }
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
        public string azstype
        {
            set { _azstype = value; }
            get { return _azstype; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}
