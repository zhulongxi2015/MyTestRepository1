using ArchitectureFrame.DTO;
using ArchitectureFrame.IService;
using ArchitectureFrame.Model;
using ArchitectureFrame.Web.ControllersBase;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Controllers
{
    public class CategoryController : BaseController
    {
        public ICategoryService CategoryService { get; set; }

        // GET: Category
        public ActionResult Index()
        {
            var categories = CategoryService.GetAll();
            return View();
        }
        //public ActionResult Query(Category category)
        //{
        //    var map = Mapper.CreateMap<Category, CategoryDTO>();
        //    map.ForMember(s => s.Name, m => m.MapFrom(f => f.Name));//首先定义mapper规则
        //    if (category.CategoryID!=0)
        //    {
        //        Category categoryModel = this.CategoryService.GetById(category.CategoryID);
        //        CategoryDTO ext =Mapper.Map<Category,CategoryDTO>(categoryModel);//进行mapper
        //        var success = ext != null;
        //        var result = new
        //        {
        //            success = success,
        //            children = ext,
        //            message = success ? null : "没有读取到任何数据"
        //        };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    //......
        //}
    }
}