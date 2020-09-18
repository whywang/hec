using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_YySend
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _sperson = "";
        private string _pdate;
        private string _pbz = "";
        private string _cdate;
        private string _maker = "";
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
        public string sperson
        {
            set { _sperson = value; }
            get { return _sperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pdate
        {
            set { _pdate = value; }
            get { return _pdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pbz
        {
            set { _pbz = value; }
            get { return _pbz; }
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
        #endregion Model

    }
}
