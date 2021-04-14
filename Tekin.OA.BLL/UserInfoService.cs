using Tekin.OA.EFDAL;
using Tekin.OA.Model;

namespace Tekin.OA.BLL
{
    
    public class UserInfoService
    {
        IUserInfoDal userDal = new UserInfoDal();
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
