using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_EmployeeDpt
    {
        public Sys_EmployeeDpt()
        { }
        #region Model
        private int _id;
        private string _eno;
        private int _eage = 0;
        private bool _esex = false;
        private string _etelephone = "";
        private string _eaddress = "";
        private string _eidentity = "";
        private string _eeducation = "";
        private string _enativeplace = "";
        private string _eheadimage = "";
        private string _eworkdate;
        private string _eemail = "";
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
        public string eno
        {
            set { _eno = value; }
            get { return _eno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int eage
        {
            set { _eage = value; }
            get { return _eage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool esex
        {
            set { _esex = value; }
            get { return _esex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string etelephone
        {
            set { _etelephone = value; }
            get { return _etelephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eaddress
        {
            set { _eaddress = value; }
            get { return _eaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eidentity
        {
            set { _eidentity = value; }
            get { return _eidentity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eeducation
        {
            set { _eeducation = value; }
            get { return _eeducation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string enativeplace
        {
            set { _enativeplace = value; }
            get { return _enativeplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eheadimage
        {
            set { _eheadimage = value; }
            get { return _eheadimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eworkdate
        {
            set { _eworkdate = value; }
            get { return _eworkdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eemail
        {
            set { _eemail = value; }
            get { return _eemail; }
        }
        #endregion Model

    }
}
