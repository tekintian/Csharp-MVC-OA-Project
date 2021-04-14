using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tekin.OA.Model;

namespace Tekin.OA.EFDAL
{
    public class UserInfoBackDal
    {
        private DataModelContainer db = new DataModelContainer();
        public UserInfo GetUserInfo(int id)
        {
          return db.UserInfoSet.Find(id);
        }

        public List<UserInfo> GetUserInfos()
        {
            return db.UserInfoSet.ToList();
        }
        //多条件查询
        public IQueryable<UserInfo> GetUsers(Expression<Func<UserInfo,bool>> whereLambda)
        {
            return db.UserInfoSet.Where(whereLambda).AsQueryable();
        }

        #region CUD
        //新增实体后EF会自动将出入数据库后的ID返回到实体中
        public UserInfo Add(UserInfo user)
        {
            db.UserInfoSet.Add(user);
            db.SaveChanges();
            return user;
        }
        public bool Update(UserInfo user)
        {
            //如果只是修改某些属性则不需要使用attach,如果是需要整体修改,则需要先attach
            //db.UserInfoSet.Attach(user); 
            db.Entry(user).State = EntityState.Modified;
            return db.SaveChanges()>0;
        }
        public bool Delete(UserInfo user)
        {
            db.Entry(user).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        #endregion
    }
}
