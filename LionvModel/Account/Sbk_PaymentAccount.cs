using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.Account
{
   public class Sbk_PaymentAccount
    {
        #region Model
        private int _id;
        private string _sacode = "";
        private string _saname = "";
        private string _pname = "";
        private string _pcode = "";
        private string _pbank = "";
        private string _pperson = "";
        private string _pbcode = "";
        private string _telephone = "";
        private string _dcode = "";
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
        public string sacode
        {
            set { _sacode = value; }
            get { return _sacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saname
        {
            set { _saname = value; }
            get { return _saname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pbank
        {
            set { _pbank = value; }
            get { return _pbank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pperson
        {
            set { _pperson = value; }
            get { return _pperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pbcode
        {
            set { _pbcode = value; }
            get { return _pbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
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
