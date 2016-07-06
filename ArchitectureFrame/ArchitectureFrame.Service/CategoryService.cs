using ArchitectureFrame.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureFrame.DTO;
using ArchitectureFrame.Model;
using ArchitectureFrame.IDAL;
using AutoMapper;

namespace ArchitectureFrame.Service
{
    public class CategoryService : ICategoryService
    {

        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CategoryService));
        public ICategoryDAL CategoryDAL { get; set;}//调用数据访问层对象：通过spring.net来注入


        public IQueryable<Category> GetAll()
        {
            try
            {
                return this.CategoryDAL.GetAll();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return new List<Category>() as IQueryable<Category>;
            }
        }

        public IQueryable<Category> GetPageList(ISQLPaging paging)
        {

            int count;
            var list = this.CategoryDAL.GetPageList(paging.QuerySQL, paging.PageIndex, paging.PageSize, out count);
            paging.RecordCount = count;
            return list;
        }
        public bool Add(CategoryDTO dto)
        {
            Mapper.CreateMap<CategoryDTO, Category>();
            return this.CategoryDAL.Add(Mapper.Map<CategoryDTO, Category>(dto));
        }

        public bool Update(CategoryDTO dto)
        {
            Mapper.CreateMap<CategoryDTO, Category>();
            return this.CategoryDAL.Update(Mapper.Map<CategoryDTO, Category>(dto));
        }

        public bool Delete(CategoryDTO dto)
        {
            Mapper.CreateMap<CategoryDTO, Category>();
            return this.CategoryDAL.Delete(Mapper.Map<CategoryDTO, Category>(dto));
        }

        public int DeleteByKeys(IList<string> keys)
        {
            return this.CategoryDAL.DeleteByKeys(keys);
        }
    }
}
