using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_OrderCode
    {
        #region Model
		private int _id;
		private string _emcode="";
		private string _citytype="";
		private int _inum=0;
		private string _years="";
		private string _prestr="";
		private string _cname="";
		private string _ccode="";
		private string _dcode;
		private string _ctype= "0";
		private int _cqstr=0;
		private int _ccstr=0;
		private int _czstr=0;
		private string _cystr= "0";
		private int _csjsstr=0;
		private string _csource="";
		private string _maker;
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
		public string emcode
		{
			set{ _emcode=value;}
			get{return _emcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string citytype
		{
			set{ _citytype=value;}
			get{return _citytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int inum
		{
			set{ _inum=value;}
			get{return _inum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string years
		{
			set{ _years=value;}
			get{return _years;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prestr
		{
			set{ _prestr=value;}
			get{return _prestr;}
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
		public string dcode
		{
			set{ _dcode=value;}
			get{return _dcode;}
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
		public int cqstr
		{
			set{ _cqstr=value;}
			get{return _cqstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ccstr
		{
			set{ _ccstr=value;}
			get{return _ccstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int czstr
		{
			set{ _czstr=value;}
			get{return _czstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cystr
		{
			set{ _cystr=value;}
			get{return _cystr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int csjsstr
		{
			set{ _csjsstr=value;}
			get{return _csjsstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csource
		{
			set{ _csource=value;}
			get{return _csource;}
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
