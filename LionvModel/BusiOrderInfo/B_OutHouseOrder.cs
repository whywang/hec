using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    /// </summary>
    [Serializable]
    public class B_OutHouseOrder
    {
        public B_OutHouseOrder()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _osid = "";
        private string _ocode = "";
        private int _state = 0;
        private string _estimatedate;
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
        public string osid
        {
            set { _osid = value; }
            get { return _osid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ocode
        {
            set { _ocode = value; }
            get { return _ocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string estimatedate
        {
            set { _estimatedate = value; }
            get { return _estimatedate; }
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
