using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Drawing.Imaging;
using System.IO;

namespace LionvCommonBll
{
   public class QrCodeBll
    {
       //订单编码生产二维码
       public string CreateQtCode(string url,string scode)
       {
           QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
           qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
           qrCodeEncoder.QRCodeScale = 4;
           qrCodeEncoder.QRCodeVersion =0;
           qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
           System.Drawing.Image image = qrCodeEncoder.Encode(scode.ToString());
           string filename = DateTime.Now.ToString("yyyymmddhhmmssfff").ToString() + ".jpg";
           string filepath = url + filename;
           System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
           image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
           fs.Close();
           image.Dispose();
           //CommonBll.PhotoChangeSize(filepath, 80, 80);
           return filename;
       }
       //微信二维码
       public string CreateFQtCode(string url, string wxapi)
       {
           QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
           qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
           qrCodeEncoder.QRCodeScale = 4;
           qrCodeEncoder.QRCodeVersion = 0;
           qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
           System.Drawing.Image image = qrCodeEncoder.Encode(wxapi.ToString());
           string filename = DateTime.Now.ToString("yyyymmddhhmmssfff").ToString() + ".jpg";
           string filepath = url + filename;
           System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
           image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
           fs.Close();
           image.Dispose();
           return filename;
       }
       //url生成二维码
       public string CreateUrlQtCode(string surl, string ourl,string sid)
       {
           QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
           qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
           qrCodeEncoder.QRCodeScale = 4;
           qrCodeEncoder.QRCodeVersion = 0;
           qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
           string vstr = ourl + sid;
           System.Drawing.Image image = qrCodeEncoder.Encode(vstr.ToString());
           string filename = DateTime.Now.ToString("yyyymmddhhmmssfff").ToString() + ".jpg";
           string filepath = surl + filename;
           string aurl = System.Web.HttpContext.Current.Server.MapPath(filepath);
           if (!Directory.Exists(aurl))
           {
               Directory.CreateDirectory(aurl);
           }
           System.IO.FileStream fs = new System.IO.FileStream(aurl, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
           image.Save(aurl, System.Drawing.Imaging.ImageFormat.Jpeg);
           fs.Close();
           image.Dispose();
           return filepath;
       }
    }
}
