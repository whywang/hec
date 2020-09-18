using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public  class Sys_AgentFee
    {
        public Sys_AgentFee()
        { }
        #region Model
        private int _id;
        private string _acode = "";
        private string _aname="";
        private string _iname = "";
        private string _icode = "";
        private decimal _fmoney=0;
        private decimal _tfmoney = 0;
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
        public string acode
        {
            set { _acode = value; }
            get { return _acode; }
        }
        public string aname
        {
            set { _aname = value; }
            get { return _aname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icode
        {
            set { _icode = value; }
            get { return _icode; }
        }
        public string iname
        {
            set { _iname = value; }
            get { return _iname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal fmoney
        {
            set { _fmoney = value; }
            get { return _fmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tfmoney
        {
            set { _tfmoney = value; }
            get { return _tfmoney; }
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
