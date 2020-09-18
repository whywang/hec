using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvCommon
{
   public  class UserCacheImp
    {
       public List<OnLineUser> GetAll(string key)
       {
           object obj = UserCache.Get(key);
           return obj != null && obj is List<OnLineUser> ? obj as List<OnLineUser> : new List<OnLineUser>();
       }
       public OnLineUser Get(string key,string  uname)
       {
           var list = GetAll( key);
           return list.Find(p => p.Username == uname);
       }
       private void set(string key,List<OnLineUser> list)
       {
           if (list == null) return;
           UserCache.Set(key, list);
       }
       public bool Add(OnLineUser user,string key)
       {
           if (user == null) return false;
           var onList = GetAll(key);
           var onUser = onList.Find(p => p.Username == user.Username);
           if (onUser != null)
           {
               onList.Remove(onUser);
               user.Zt = 1;
               onList.Add(onUser);
           }
           
           onList.Add(user);
           set(key,onList);
           return true;
       }
       public bool Remove(string uname,string key)
       {
           var list = GetAll(key);
           var user = list.Find(p => p.Username== uname);
           if (user != null)
           {
               list.Remove(user);
           }
           set(key,list);
           return true;
       }
       public bool RemoveAll(string key)
       {
           var list = new List<OnLineUser>();
           UserCache.Set(key, list);
           return true;
       }
    }
}
