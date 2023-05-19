using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EntityGenerics.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IGenericInterface<CategoryViewModel> _categoryService;
        public CategoriesController(IGenericInterface<CategoryViewModel> categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetEntities();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            _categoryService.CreateEntity(model);
            return RedirectToAction("Index");
        }
    }
}
