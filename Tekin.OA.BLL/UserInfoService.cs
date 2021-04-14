using Tekin.OA.DALFactory;
using Tekin.OA.EFDAL;
using Tekin.OA.IDAL;
using Tekin.OA.Model;
using Tekin.OA.NHDAL;

namespace Tekin.OA.BLL
{
    
    public class UserInfoService
    {
        //使用接口类来接收 实例   依赖抽象接口编程
       // IUserInfoDal userDal = new UserInfoDal();

       // IUserInfoDal userDal = StaticDalFactory.GetUserInfoDal();

        // private DbSession dbSession = new DbSession();
      private IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();
      
       //新增
        public UserInfo Add(UserInfo user)
        {
            //return dbss.UserInfoDal.Add(user);

            dbSession.UserInfoDal.Add(user);
            if (dbSession.SaveChanges() > 0)
            {
                //提交成功
            }
            return user;
        }
        //修改
        public bool Update(UserInfo user)
        {
            //return dbss.UserInfoDal.Update(user);

            dbSession.UserInfoDal.Update(user);

            return dbSession.SaveChanges() > 0;
        }
        //删除
        public bool Delete(UserInfo user)
        {
            //dbSession.UserInfoDal.Add(user);
            //if (dbSession.SaveChanges() > 0)
            //{
            //  //保存成功  
            //}

          //  dbss.UserInfoDal.Update(user);
          dbSession.UserInfoDal.Delete(user);

          dbSession.SaveChanges();// 数据提交的权利有数据访问层提到了业务逻辑层
            // 单元提交,  UnitWork 单元工作模式 
            // 可实现批量提交
          return dbSession.SaveChanges() > 0;

            //return dbss.UserInfoDal.Delete(user);
        }
    }
}
