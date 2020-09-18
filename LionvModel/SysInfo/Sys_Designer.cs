using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_Designer
    {
        #region Model
        private int _id;
        private string _eno = "";
        private string _dname = "";
        private string _dtelephone = "";
        private string _dqq = "";
        private string _dintroduce = "";
        private string _dappraise = "";
        private string _dimg = "";
        private string _maker = "";
        private string _cdate;
        private List<Sys_DesignerProduction> _sdp;

        public List<Sys_DesignerProduction> sdp
        {
            get { return _sdp; }
            set { _sdp = value; }
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
        public string eno
        {
            set { _eno = value; }
            get { return _eno; }
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
        public string dtelephone
        {
            set { _dtelephone = value; }
            get { return _dtelephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dqq
        {
            set { _dqq = value; }
            get { return _dqq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dintroduce
        {
            set { _dintroduce = value; }
            get { return _dintroduce; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dappraise
        {
            set { _dappraise = value; }
            get { return _dappraise; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dimg
        {
            set { _dimg = value; }
            get { return _dimg; }
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
