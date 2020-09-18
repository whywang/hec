using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Drawing;

namespace LionvCommonBll
{
    public class CommonBll
    {
        //创建sid
        public static string GetSid()
        {
            string r = "";
            Random ran = new Random();
            int RandKey = ran.Next(1000, 9999);
            r = Guid.NewGuid().ToString();
            r = r +"-"+ RandKey.ToString();
            return r;
        }
        //查询条件部门和人员名称替代
        public static string SqlWhereReplace(Sys_Employee u, string where)
        {
            string r = "";
            r = where.Replace("[dcode]", u.dcode).Replace("[ename]", u.ename).Replace("[eno]", u.eno) ;
            return r;
        }
        //起始日期未当月第一天
        public static string GetBdate()
        {
            DateTime d = DateTime.Now;
            return d.Year + "-" + d.Month + "-01";
        }
        // 当天
        public static string GetBdate2()
        {
            DateTime d = DateTime.Now;
            return d.ToString("yyyy-MM-dd");
        }
        public static string GetBTime()
        {
            DateTime d = DateTime.Now;
            return d.ToString("hh:mm:ss");
        }
        public static string GetBdate(string dt)
        {
            if (dt != "")
            {
                DateTime d = Convert.ToDateTime(dt);
                return d.ToString("yyyy-MM-dd");
            }
            else{
                return "";
            }
        }
        public static string GetEdate()
        {
            DateTime d = DateTime.Now.AddDays(1);
            return  d.ToString("yyyy-MM-dd");
        }
        public static string GetEdate(string dt)
        {
            DateTime d = Convert.ToDateTime(dt).AddDays(1);
            return d.ToString("yyyy-MM-dd");
        }
        public static string DirectionFormat(string d)
        {
            string r = "";
            switch (d)
            {
                case "内左":
                    r="内右";
                    break;
                case "内右":
                    r = "内左";
                    break;
                case "外右":
                    r = "外左";
                    break;
                case "外左":
                    r = "外右";
                    break;
            }
            return r;
        }
        public static decimal DecimalToInt(decimal v)
        {
            int cv =(int)Math.Floor( (double)v+ 0.5);
            return (decimal)cv;
        }
        public static string GetHost()
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            if (url != "")
            {
                int k = url.IndexOf('/',7);
                if (k >-1)
                {
                    url = url.Substring(0, k);
                }
            }
            return url;
        }
        public static string GetSjs(int len)
        {
            string r = "";
            if (len > 0)
            {
                for (int i = 0; i < len; i++)
                {
                    Random ran = new Random();
                    int RandKey = ran.Next(0,9);
                    r = r + RandKey.ToString();
                }
            }
            return r;
        }
        public static void PhotoChangeSize(string url, int width, int height)
        {
            System.Drawing.Image image = new Bitmap(url);
            System.Drawing.Image newImage = image.GetThumbnailImage(width, height, null, new IntPtr());
            image.Dispose();
            newImage.Save(url);
            newImage.Dispose();
        }
    }
}
