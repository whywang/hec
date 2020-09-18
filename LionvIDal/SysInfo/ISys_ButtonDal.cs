using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data;

namespace LionvIDal.SysInfo
{
    public interface ISys_ButtonDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string bcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Button model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_Button model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string bcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Button Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Button> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool CheckBtnSql(string sql);
        int SetRoleEmenuBtn(string rcode, string emcode, string[] bcode,string btype);
        List<Sys_Button> GetRolePageListBtn(string rcode, string emcode, string Btype);
        #endregion  MethodEx
    } 
}
