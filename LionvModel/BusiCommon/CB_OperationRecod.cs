using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
    [Serializable]
    public class CB_OperationRecod
    {
        public CB_OperationRecod()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _maker = "";
        private string _ps = "";
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
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
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
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model

    }
}
