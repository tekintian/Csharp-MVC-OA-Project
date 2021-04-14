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

        IUserInfoDal userDal = new NhUserInfoDal();
        //新增
        public UserInfo Add(UserInfo user)
        {
            return userDal.Add(user);
        }
        //修改
        public bool Update(UserInfo user)
        {
            return userDal.Update(user);
        }
        //删除
        public bool Delete(UserInfo user)
        {
            return userDal.Delete(user);
        }
    }
}
