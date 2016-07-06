using ArchitectureFrame.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.Entity;
using Simple.Web.EntityFramework5;

namespace ArchitectureFrame.DAL
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        //public DbContext DbContext
        //{
        //    get
        //    {
        //        return DbContextFactory.GetContext(); //using Simple.Web.EntityFramework5;
        //    }
        //}

        protected readonly DbContext DbContext;

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public bool EnableTrack { get; set; }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns></returns>
        public virtual int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 通过主键返回对象
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public virtual T GetbyId(object id)
        {
           return this.DbContext.Set<T>().Find(id);
        }
        /// <summary>
        /// 根据条件获取数据
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            return EnableTrack
               ? this.DbContext.Set<T>().Where(predicate)
               : this.DbContext.Set<T>().AsNoTracking().Where(predicate);

        }
        
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return EnableTrack ?
                 this.DbContext.Set<T>() :
                 this.DbContext.Set<T>().AsNoTracking();
            
        }

        /// <summary>
        /// 获取分页集合
        /// </summary>
        /// <param name="sql">开始记录</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="recordCount">行数</param>
        /// <param name="recordCount">参数</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetPageList(string sql, int pageIndex, int pageSize, out int recordCount,params object[] parameters)
        {
            var list = EnableTrack
                ? this.DbContext.Set<T>().SqlQuery(sql, parameters)
                : this.DbContext.Set<T>().SqlQuery(sql, parameters).AsNoTracking();
            recordCount = list.Count();
            return list.Skip(pageIndex * pageSize).Take(pageSize) as IQueryable<T>;
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="model">实体</param>
        /// /// <returns></returns>
        public virtual bool Update(T model)
        {
            this.DbContext.Set<T>().Attach(model);
            this.DbContext.Entry<T>(model).State = EntityState.Modified;
            return this.DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 保存对象
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public virtual bool Add(T model)
        {
            this.DbContext.Set<T>().Add(model);
            return this.DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="model">实体</param>
        public virtual bool Delete(T model)
        {
            this.DbContext.Set<T>().Remove(model);
            return this.DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据条件删除对象
        /// </summary>
        /// <param name="predicate">表达式</param>
        public virtual bool Delete(Expression<Func<T, bool>> predicate)
        {
            T model = this.DbContext.Set<T>().Single(predicate);//先根据条件找到对象
            if (model == null)
                return false;
            this.DbContext.Set<T>().Remove(model);
            return this.DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 通过主键删除对象
        /// </summary>
        /// <param name="keys">主键</param>
        /// <returns></returns>
        public virtual int DeleteByKeys(IList<string> keys)
        {
            foreach (var  key in keys)
            {
                var model = this.DbContext.Set<T>().Find(key);
                if (model != null)
                {
                    this.DbContext.Set<T>().Remove(model);
                }
            }
            return this.DbContext.SaveChanges();
        }

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return EnableTrack
                ? this.DbContext.Set<T>().Where(predicate).Any()
                : this.DbContext.Set<T>().AsNoTracking().Where(predicate).Any();
        }

        /// <summary>
        /// 读取满足条件的一行数据
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public virtual T Read(Expression<Func<T, bool>> predicate)
        {
            return EnableTrack
                ? this.DbContext.Set<T>().Single(predicate)
                : this.DbContext.Set<T>().AsNoTracking().Single(predicate);
        }    


    }
}
