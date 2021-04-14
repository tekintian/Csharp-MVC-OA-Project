using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tekin.OA.IDAL
{
    /// <summary>
    /// 公共接口封装
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDal<T> where T : class,new()
    {
        /// <summary>
        /// 泛型查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

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
        IQueryable<T> GetPageEntities<B>(Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, B>> orderByLambda,
            out int total, int curPage = 1, int pageSize = 10, bool isDesc = true
        );
   

        /// <summary>
        /// 新增实体后EF会自动将出入数据库后的ID返回到实体中
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>包含主键ID的T</returns>
        T Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>true|false</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns>true|false</returns>
        bool Delete(T entity);
    }
}
