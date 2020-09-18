using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_InventoryDetail
    {
        public Sys_InventoryDetail()
        { }
        #region Model
        private int _id;
        private string _iname = "";
        private string _icode = "";
        private string _icname = "";
        private string _iccode = "";
        private string _mname = "";
        private string _iunit = "";
        private decimal _isaleprice = 0;
        private decimal _isupplyprice = 0;
        private decimal _ipurchaseprice =0;
        private decimal _tcprice = 0;
        private string _iimage = "";
        private bool _istate = true;
        private string _mcode = "";
        private string _maker = "";
        private string  _cdate ="";
        private string _idef1 = "";
        private bool _idef2 = true;
        private int _idef3 = 0;
        private string _itc;
        private string _ptype="";
        private string _psize = "";

        public string ptype
        {
            get { return _ptype; }
            set { _ptype = value; }
        }
        public string itc
        {
            get { return _itc; }
            set { _itc = value; }
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
        public string iname
        {
            set { _iname = value; }
            get { return _iname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icode
        {
            set { _icode = value; }
            get { return _icode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icname
        {
            set { _icname = value; }
            get { return _icname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iccode
        {
            set { _iccode = value; }
            get { return _iccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iunit
        {
            set { _iunit = value; }
            get { return _iunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal isaleprice
        {
            set { _isaleprice = value; }
            get { return _isaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal isupplyprice
        {
            set { _isupplyprice = value; }
            get { return _isupplyprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ipurchaseprice
        {
            set { _ipurchaseprice = value; }
            get { return _ipurchaseprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tcprice
        {
            set { _tcprice = value; }
            get { return _tcprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iimage
        {
            set { _iimage = value; }
            get { return _iimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool istate
        {
            set { _istate = value; }
            get { return _istate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
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
        /// <summary>
        /// 
        /// </summary>
        public string idef1
        {
            set { _idef1 = value; }
            get { return _idef1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool idef2
        {
            set { _idef2 = value; }
            get { return _idef2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idef3
        {
            set { _idef3 = value; }
            get { return _idef3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string psize
        {
            set { _psize = value; }
            get { return _psize; }
        }
        #endregion Model
    }
}
