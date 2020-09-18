using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_DepmentDpt
    {
        public Sys_DepmentDpt()
        { }
        #region Model
        private int _id;
        private string _dcode = "";
        private string _dmanager = "";
        private string _dcontact = "";
        private string _daddress = "";
        private string _dfitment;
        private string _dno = "";
        private string _ddetail;
        private int _dperson = 0;
        private string _dmaker = "";
        private bool _iproduction = false;
        private bool _iadmin = false;
        private string _logo = "";
        private string _idepment = "";
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
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dmanager
        {
            set { _dmanager = value; }
            get { return _dmanager; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcontact
        {
            set { _dcontact = value; }
            get { return _dcontact; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string daddress
        {
            set { _daddress = value; }
            get { return _daddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dfitment
        {
            set { _dfitment = value; }
            get { return _dfitment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dno
        {
            set { _dno = value; }
            get { return _dno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddetail
        {
            set { _ddetail = value; }
            get { return _ddetail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dperson
        {
            set { _dperson = value; }
            get { return _dperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dmaker
        {
            set { _dmaker = value; }
            get { return _dmaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool iproduction
        {
            set { _iproduction = value; }
            get { return _iproduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool iadmin
        {
            set { _iadmin = value; }
            get { return _iadmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string logo
        {
            set { _logo = value; }
            get { return _logo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string idepment
        {
            set { _idepment = value; }
            get { return _idepment; }
        }
        #endregion Model

    }
}
