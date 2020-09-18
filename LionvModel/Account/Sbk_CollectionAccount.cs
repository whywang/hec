using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.Account
{
   public class Sbk_CollectionAccount
    {
        #region Model
        private int _id;
        private string _bcode="";
        private string _aname = "";
        private string _acode = "";
        private string _abank = "";
        private string _asubbank = "";
        private string _maker = "";
        private string _remark = "";
        private string _cdate;
        private string _aperson = "";

        public string aperson
        {
            get { return _aperson; }
            set { _aperson = value; }
        }
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
        public string bcode
        {
            set { _bcode = value; }
            get { return _bcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aname
        {
            set { _aname = value; }
            get { return _aname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string acode
        {
            set { _acode = value; }
            get { return _acode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string abank
        {
            set { _abank = value; }
            get { return _abank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string asubbank
        {
            set { _asubbank = value; }
            get { return _asubbank; }
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
