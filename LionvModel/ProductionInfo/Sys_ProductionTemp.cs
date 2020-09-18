using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public  class Sys_ProductionTemp
    {
        public Sys_ProductionTemp()
        { }
        #region Model
        private int _id;
        private string _tname = "";
        private string _tcode;
        private string _ptname = "";
        private string _ptcode = "";
        private int _tist = 0;
        private int _tfrist = 0;
        private int _tht = 0;
        private int _tlt = 0;
        private int _thlx = 0;
        private int _tslx = 0;
        private int _tdz = 0;
        private int _tmdx = 0;
        private int _tmtb = 0;
        private int _tytb = 0;
        private int _ttlh = 0;
        private int _tdmx = 0;
        private int _tsl = 0;
        private int _tblyt = 0;
        private int _tslhl = 0;
        private int _tslsl = 0;
        private string _ttemp;
        private string _maker;
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
        public string tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcode
        {
            set { _tcode = value; }
            get { return _tcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptname
        {
            set { _ptname = value; }
            get { return _ptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptcode
        {
            set { _ptcode = value; }
            get { return _ptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tist
        {
            set { _tist = value; }
            get { return _tist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tfrist
        {
            set { _tfrist = value; }
            get { return _tfrist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tht
        {
            set { _tht = value; }
            get { return _tht; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tlt
        {
            set { _tlt = value; }
            get { return _tlt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int thlx
        {
            set { _thlx = value; }
            get { return _thlx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tslx
        {
            set { _tslx = value; }
            get { return _tslx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tdz
        {
            set { _tdz = value; }
            get { return _tdz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tmdx
        {
            set { _tmdx = value; }
            get { return _tmdx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tmtb
        {
            set { _tmtb = value; }
            get { return _tmtb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tytb
        {
            set { _tytb = value; }
            get { return _tytb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ttlh
        {
            set { _ttlh = value; }
            get { return _ttlh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tdmx
        {
            set { _tdmx = value; }
            get { return _tdmx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tsl
        {
            set { _tsl = value; }
            get { return _tsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tblyt
        {
            set { _tblyt = value; }
            get { return _tblyt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tslhl
        {
            set { _tslhl = value; }
            get { return _tslhl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tslsl
        {
            set { _tslsl = value; }
            get { return _tslsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ttemp
        {
            set { _ttemp = value; }
            get { return _ttemp; }
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
