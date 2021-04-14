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
    public class BaseDal<T> where T:class,new()
    {
        // EF模型实例
        private DataModelContainer db = new DataModelContainer();

        #region 数据查询

        /// <summary>
        /// 泛型查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T,bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).AsQueryable();
        }

        /// <summary>
        /// 泛型分页查询
        /// </summary>
        /// <param name="whereLambda">查询条件lambda</param>
        /// <typeparam name="B">排序字段的类型</typeparam>
        /// <param name="orderByLambda">排序lambda</param>
        /// <param name="total">总页数</param>
        /// <param name="curPage">当前页 默认 1</param>
        /// <param name="pageSize">每页数量 默认 10</param>
        /// <param name="isDesc">是否降序 默认 是</param>
        /// <returns></returns>
        public IQueryable<T> GetPageEntities<B>(Expression<Func<T, bool>> whereLambda,Expression<Func<T,B>> orderByLambda,
            out int total, int curPage = 1, int pageSize = 10, bool isDesc=true
            )
        {
            //获取总数量并赋值 total
            total = db.Set<T>().Where(whereLambda).Count();
           
            if (isDesc)
            {
                //降序排序
                var list = db.Set<T>().Where(whereLambda)
                    .OrderByDescending<T, B>(orderByLambda)
                    .Skip(pageSize * (curPage - 1))
                    .Take(pageSize)
                    .AsQueryable();

                return list;
            }
            else
            {
                //升序排序
                var list = db.Set<T>().Where(whereLambda)
                    .OrderBy<T, B>(orderByLambda)
                    .Skip(pageSize * (curPage - 1))
                    .Take(pageSize)
                    .AsQueryable();

                return list;  
            }
        }
        #endregion

        #region CUD
        /// <summary>
        /// 新增实体后EF会自动将出入数据库后的ID返回到实体中
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>包含主键ID的T</returns>
        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>true|false</returns>
        public bool Update(T entity)
        {
            //如果只是修改某些属性则不需要使用attach,如果是需要整体修改,则需要先attach
            //db.Set<T>().Attach(entity); 
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>true|false</returns>
        public bool Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        #endregion


    }
}
