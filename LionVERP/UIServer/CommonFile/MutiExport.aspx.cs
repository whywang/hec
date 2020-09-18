using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace LionVERP.UIServer.CommonFile
{
    public partial class MutiExport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //public void PushExcelToClientEx()
        //{
        //    string fileName = "test.xls";
        //    if (!fileName.Contains(".xls"))
        //    {
        //        fileName += ".xls";
        //    }

        //    StringBuilder sbBody = new StringBuilder();
        //    StringBuilder sbSheet = new StringBuilder();

        //    sbBody.AppendFormat(
        //            "MIME-Version: 1.0\r\n" +
        //            "X-Document-Type: Workbook\r\n" +
        //            "Content-Type: multipart/related; boundary=\"-=BOUNDARY_EXCEL\"\r\n\r\n" +
        //            "---=BOUNDARY_EXCEL\r\n" +
        //            "Content-Type: text/html; charset=\"gbk\"\r\n\r\n" +
        //            "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n" +
        //            "xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n\r\n" +
        //            "<head>\r\n" +
        //            "<xml>\r\n" +
        //            "<o:DocumentProperties>\r\n" +
        //            "<o:Author>{0}</o:Author>\r\n" +
        //            "<o:LastAuthor>{0}</o:LastAuthor>\r\n" +
        //            "<o:Created>{1}</o:Created>\r\n" +
        //            "<o:LastSaved>{1}</o:LastSaved>\r\n" +
        //            "<o:Company>{2}</o:Company>\r\n" +
        //            "<o:Version>11.5606</o:Version>\r\n" +
        //            "</o:DocumentProperties>\r\n" +
        //            "</xml>\r\n" +
        //            "<xml>\r\n" +
        //            "<x:ExcelWorkbook>\r\n" +
        //            "<x:ExcelWorksheets>\r\n"
        //           , ""
        //           , DateTime.Now.ToString()
        //           , "");

        //    for(int i=1 ;i<4;i++)
        //    {
        //        string gid = Guid.NewGuid().ToString();
        //        sbBody.AppendFormat("<x:ExcelWorksheet>\r\n" +
        //            "<x:Name>{0}</x:Name>\r\n" +
        //            "<x:WorksheetSource HRef=\"cid:{1}\"/>\r\n" +
        //            "</x:ExcelWorksheet>\r\n"
        //            , d.TableName.Replace(":", "").Replace("\\", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("[", "").Replace("]", "").Trim()
        //            , gid);
        //        sbSheet.AppendFormat(
        //         "---=BOUNDARY_EXCEL\r\n" +
        //         "Content-ID: {0}\r\n" +
        //         "Content-Type: text/html; charset=\"gbk\"\r\n\r\n" +
        //         "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n" +
        //         "xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n\r\n" +
        //         "<head>\r\n" +
        //         "<xml>\r\n" +
        //         "<x:WorksheetOptions>\r\n" +
        //         "<x:ProtectContents>False</x:ProtectContents>\r\n" +
        //         "<x:ProtectObjects>False</x:ProtectObjects>\r\n" +
        //         "<x:ProtectScenarios>False</x:ProtectScenarios>\r\n" +
        //         "</x:WorksheetOptions>\r\n" +
        //         "</xml>\r\n" +
        //         "</head>\r\n" +
        //         "<body>\r\n"
        //         , gid);

        //        sbSheet.Append("<table border='1'>");
        //        sbSheet.Append("</body>\r\n" +
        //            "</html>\r\n\r\n");
        //    }

        //    StringBuilder sb = new StringBuilder(sbBody.ToString());
        //    sb.Append("</x:ExcelWorksheets>\r\n" +
        //        "</x:ExcelWorkbook>\r\n" +
        //       "</xml>\r\n" +
        //        "</head>\r\n" +
        //        "</html>\r\n\r\n");

        //    sb.Append(sbSheet.ToString());
        //    sb.Append("---=BOUNDARY_EXCEL--");
        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.ClearContent();
        //    HttpContext.Current.Response.ClearHeaders();
        //    HttpContext.Current.Response.Buffer = true;
        //    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        //    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gbk");
        //    HttpContext.Current.Response.Write(sb.ToString());
        //    HttpContext.Current.Response.End();
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    PushExcelToClientEx()
        //}
    }

}