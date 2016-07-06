using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.IDAL
{
    public interface IRepository<T> where T : class
    {
        bool EnableTrack { get; set; }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 通过主键返回对象
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        T GetbyId(object id);

        /// <summary>
        /// 根据条件获取数据
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        IQueryable<T> GetItems(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// 获取分页集合
        /// </summary>
        /// <param name="sql">开始记录</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="recordCount">行数</param>
        /// <param name="recordCount">参数</param>
        /// <returns></returns>
        IQueryable<T> GetPageList(string sql, int pageIndex, int pageSize, out int recordCount, params object[] parameters);

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="model">实体</param>
        /// /// <returns></returns>
        bool Update(T model);

        /// <summary>
        /// 保存对象
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool Add(T model);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="model">实体</param>
        bool Delete(T model);

        /// <summary>
        /// 根据条件删除对象
        /// </summary>
        /// <param name="predicate">表达式</param>
        bool Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 通过主键集合删除对象
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        int DeleteByKeys(IList<string> keys);

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        bool Exists(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 读取满足条件的一行数据
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        T Read(Expression<Func<T, bool>> predicate);
    }
}
