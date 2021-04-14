using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tekin.OA.IDAL;
using Tekin.OA.Model;

namespace Tekin.OA.NHDAL
{
    /// <summary>
    /// NHibernate 实现演示
    /// </summary>
    public class NhUserInfoDal:IUserInfoDal
    {
        public IQueryable<UserInfo> GetEntities(Expression<Func<UserInfo, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> GetPageEntities<B>(Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, B>> orderByLambda, out int total, int curPage = 1,
            int pageSize = 10, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public UserInfo Add(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
