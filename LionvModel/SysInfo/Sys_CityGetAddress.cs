using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_CityGetAddress
    {
        #region Model
        private int _id;
        private string _sacode="";
        private string _gperson = "";
        private string _dname = "";
        private string _dcode = "";
        private string _address = "";
        private bool _isfrist=false;
        private string _maker = "";
        private string _cdate;
        private string _telephone = "";

        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
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
        public string sacode
        {
            set { _sacode = value; }
            get { return _sacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gperson
        {
            set { _gperson = value; }
            get { return _gperson; }
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
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isfrist
        {
            set { _isfrist = value; }
            get { return _isfrist; }
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
