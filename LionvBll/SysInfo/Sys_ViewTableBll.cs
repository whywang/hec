using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Collections;

namespace LionvBll.SysInfo
{
   public class Sys_ViewTableBll
    {
        private readonly ISys_ViewTableDal r = DataAccess.CreateSys_ViewTable();
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string tcode)
        {
            return r.Exists(tcode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ViewTable model)
        {
            return r.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ViewTable model)
        {
            return r.Update(model);
        }
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {

            return r.Delete(where);
        }
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  Sys_ViewTable Query(string where)
        {

            return r.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ViewTable> QueryList(string where)
        {
            return r.QueryList(where);
        }
       
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
           return  r.CreateCode();
        }
       //获取Table head列
        public ArrayList QueryTableCols(string emcode, string tabcode, string rcode)
        {
            ArrayList r1 = new ArrayList();
            Sys_ViewTable s = new Sys_ViewTable();
            Sys_ViewTable sr = new Sys_ViewTable();
            Sys_ViewTable sur = new Sys_ViewTable();
            sr = r.Query(" and emcode='" + emcode + "' and tabcode='" + tabcode + "' and rcode='" + rcode + "'");
            if (sr == null)
            {
                sur = r.Query(" and emcode='" + emcode + "' and tabcode='" + tabcode + "' and rcode='' ");
                if (sur != null)
                {
                    s = sur;
                }
                else
                {
                    s = null;
                }
            }
            else
            {
                s = sr;
            }
            if (s != null)
            {
                
                string[] cols = s.cols.Replace("\n","").Split(';');
                for (int i = 0; i < cols.Length; i++)
                {
                    ArrayList r2 = new ArrayList();
                    string[] col = cols[i].Split('-');
                    r2.Add(col[0]);
                    if (col.Length > 1)
                    {
                        r2.Add(col[1]);
                    }
                    else
                    {
                        r2.Add("100");
                    }
                    r1.Add(r2);
                }
             
            }
            return r1;
        }
       //获取Table对象
        public Sys_ViewTable QuerySelCols(string emcode, string tabcode, string rcode)
        {
            Sys_ViewTable s = new Sys_ViewTable();
            Sys_ViewTable sr = new Sys_ViewTable();
            Sys_ViewTable sur = new Sys_ViewTable();
            sr = r.Query(" and emcode='" + emcode + "' and tabcode='" + tabcode + "' and rcode='" + rcode + "'");
            if (sr == null)
            {
                sur = r.Query(" and emcode='" + emcode + "' and tabcode='" + tabcode + "' and rcode='' ");
                if (sur != null)
                {
                    s = sur;
                }
                else
                {
                    s = null;
                }
            }
            else
            {
                s = sr;
            }
     
            return s;
        }
        //获取Tab对象
        public List<Sys_ViewTable> Querytab(string emcode, string rcode)
        {
            List<Sys_ViewTable> ls2 = new List<Sys_ViewTable>();
            List<Sys_ViewTable> ls1 = new List<Sys_ViewTable>();
            ls1 = r.QueryList(" and emcode='" + emcode + "' and rcode='" + rcode + "' order by tabcode asc");
            if (ls1 == null)
            {
                ls2 = r.QueryList(" and emcode='" + emcode + "' order by tabcode asc");
            }
            return ls1==null?ls2:ls1;
        }
        #endregion  ExtensionMethod
    }
}
