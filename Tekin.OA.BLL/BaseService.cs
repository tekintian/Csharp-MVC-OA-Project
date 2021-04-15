using System;
using System.Linq;
using System.Linq.Expressions;
using Tekin.OA.IBLL;
using Tekin.OA.IDAL;

namespace Tekin.OA.BLL
{
    /// <summary>
    /// 父类要逼迫子类给父类的一个属性赋值.
    /// 赋值的操作必须在父类的方法调用之前先执行
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> where T:class,new()
    {
        //子类需要调这里的方法,必须先给这个属性赋值
        public IBaseDal<T> CurrentDal { get; set; }
        protected IDbSession DbSession {
            get
            {
               var csses= Tekin.OA.DALFactory.DbSessionFactory.GetCurrentDbSession();
               return csses;
            }
        }

        //基类的构造函数
        public BaseService()
        {
            //调用抽象方法 实际上调用的是子类重写的方法
            SetCurrentDal();
        }

        //抽象方法,要求子类继承后必须先实现这个方法
        public abstract void SetCurrentDal();

        #region Search数据查询

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
        }

        public IQueryable<T> GetPageEntities<B>(Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, B>> orderByLambda,
            out int total, int curPage = 1, int pageSize = 10, bool isDesc = true
        )
        {
            return CurrentDal.GetPageEntities(whereLambda, orderByLambda,out total, curPage, pageSize, isDesc);
        }

        #endregion

        #region CUD

        public T Add(T entity)
        {
            return CurrentDal.Add(entity);
        }

        public bool Update(T entity)
        {
           return CurrentDal.Update(entity);
        }

        public bool Delete(T entity)
        {
            return CurrentDal.Delete(entity);
        }

        #endregion
    }
}
