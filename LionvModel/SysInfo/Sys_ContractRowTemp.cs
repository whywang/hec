using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    public class Sys_ContractRowTemp
    {
        #region
        private int _id;
		private string _rname="";
		private string _rcode;
		private string _cname="";
		private string _ccode="";
		private string _ctype="";
		private string _ctext="";
		private string _maker="";
		private string _cdate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rname
		{
			set{ _rname=value;}
			get{return _rname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rcode
		{
			set{ _rcode=value;}
			get{return _rcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ccode
		{
			set{ _ccode=value;}
			get{return _ccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ctype
		{
			set{ _ctype=value;}
			get{return _ctype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ctext
		{
			set{ _ctext=value;}
			get{return _ctext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maker
		{
			set{ _maker=value;}
			get{return _maker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cdate
		{
			set{ _cdate=value;}
			get{return _cdate;}
		}
		#endregion Model

    }
}
