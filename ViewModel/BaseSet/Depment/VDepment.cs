using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BaseSet.Depment
{
   public class VDepment
    {
        #region Model
        private int _id;
        private string _dname = "";
        private string _dcode = "";
        private string _dpname = "";
        private string _dpcode = "";
        private string _dcdate;
        private string _dabc;
        private bool _disused = false;
        private string _dattr = "";
        private string _dmaker = "";
        private bool _disend = false;
        private string _dmanager = "";
        private string _dcontact = "";
        private string _daddress = "";
        private string _dfitment;
        private string _dno = "";
        private string _ddetail;
        private int? _dperson = 0;
        private string _logo = "";
        private string _idepment = "";
        private string _iproduction = "";
        private string _iadmin = "";
        private string _khcode = "";
        private string _dsort = "";

        public string dsort
        {
            get { return _dsort; }
            set { _dsort = value; }
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
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
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
        public string dpname
        {
            set { _dpname = value; }
            get { return _dpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dpcode
        {
            set { _dpcode = value; }
            get { return _dpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dabc
        {
            set { _dabc = value; }
            get { return _dabc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcdate
        {
            set { _dcdate = value; }
            get { return _dcdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool disused
        {
            set { _disused = value; }
            get { return _disused; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dattr
        {
            set { _dattr = value; }
            get { return _dattr; }
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
        public bool disend
        {
            set { _disend = value; }
            get { return _disend; }
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
        public int? dperson
        {
            set { _dperson = value; }
            get { return _dperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iadmin
        {
            set { _iadmin = value; }
            get { return _iadmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iproduction
        {
            set { _iproduction = value; }
            get { return _iproduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string idepment
        {
            set { _idepment = value; }
            get { return _idepment; }
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
        public string khcode
        {
            set { _khcode = value; }
            get { return _khcode; }
        }
        #endregion Model
    }
}
