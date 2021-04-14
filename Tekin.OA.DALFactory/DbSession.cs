using Tekin.OA.EFDAL;
using Tekin.OA.IDAL;

namespace Tekin.OA.DALFactory
{
    public class DbSession : IDbSession
    {
        #region 简单工厂 抽象工厂

        public IUserInfoDal UserInfoDal
        {
            get { return StaticDalFactory.GetUserInfoDal(); }
        }

        public IOrderInfoDal OrderInfoDal
        {
            get { return StaticDalFactory.GetOrderInfoDal();  }
        }
        
        #endregion
        /// <summary>
        /// 拿到当前的EF的上下文, 然后进行 把修改实体进行一个整体提交.
        /// dbsession是整个数据库访问层和db的会话
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return DbContextFactory.GetDbContextFactory().SaveChanges();
        }
    }
}
